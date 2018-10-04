using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KBS1
{
    public class SpriteRenderer
    {
        private Image Sprite { get; }
        private ILocatable Locatable { get; }
        private Vector Size { get; }
        private Canvas Canvas { get; }

        public SpriteRenderer(Image sprite, ILocatable locatable, Canvas canvas)
        {
            Canvas = canvas;
            Sprite = new Image()
            {
                Source = sprite.Source
            };
            Locatable = locatable;
            Size = new Vector((int) (sprite.Width / 2), (int) (sprite.Height / 2));
            
            canvas.Children.Add(Sprite);
        }

        public void Update()
        {
            Canvas.SetTop(Sprite, Locatable.Location.Y - Size.Y);
            Canvas.SetLeft(Sprite, Locatable.Location.X -Size.X);
        }

        public void Destroy()
        {
            Canvas.Children.Remove(Sprite);
        }

        public void ChangeSprite(BitmapImage sprite)
        {
            Sprite.Source = sprite;
        }
    }
}
