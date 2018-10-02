using System.Windows.Controls;

namespace KBS1
{
    public class SpriteRenderer
    {
        private Image Sprite { get; }
        private ILocatable Locatable { get; }
        private Vector Size { get; }

        public SpriteRenderer(Image sprite, ILocatable locatable, Canvas canvas)
        {
            this.Sprite = sprite;
            this.Locatable = locatable;
            this.Size = new Vector((int) (sprite.Width / 2), (int) (sprite.Height / 2));

            canvas.Children.Add(this.Sprite);
        }

        public void Update()
        {
            Canvas.SetBottom(this.Sprite, this.Locatable.Location.Y - Size.Y);
            Canvas.SetLeft(this.Sprite, this.Locatable.Location.X -Size.X);
        }
    }
}
