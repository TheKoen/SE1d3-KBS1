using System.Windows.Controls;

namespace KBS1
{
    public class SpriteRenderer
    {
        private Image Sprite { get; }
        private ILocatable Locatable { get; }

        public SpriteRenderer(Image sprite, ILocatable locatable, Canvas canvas)
        {
            this.Sprite = sprite;
            this.Locatable = locatable;

            canvas.Children.Add(this.Sprite);
        }

        public void Update()
        {
            Canvas.SetTop(this.Sprite, this.Locatable.Location.Y);
            Canvas.SetLeft(this.Sprite, this.Locatable.Location.X);
        }
    }
}
