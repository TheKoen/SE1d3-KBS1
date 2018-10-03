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
            this.Canvas = canvas;
            this.Sprite = new Image()
            {
                Source = sprite.Source
            };
            this.Locatable = locatable;
            this.Size = new Vector((int) (sprite.Width / 2), (int) (sprite.Height / 2));
            
            canvas.Children.Add(Sprite);
        }

        public void Update()
        {
            Canvas.SetTop(this.Sprite, this.Locatable.Location.Y - Size.Y);
            Canvas.SetLeft(this.Sprite, this.Locatable.Location.X -Size.X);
        }

        public void Destroy()
        {
            this.Canvas.Children.Remove(this.Sprite);
        }

        public void ChangeSprite(BitmapImage sprite)
        {
            this.Sprite.Source = sprite;
        }
    }
}
