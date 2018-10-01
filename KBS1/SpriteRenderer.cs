using System.Windows.Controls;

namespace KBS1
{
    public class SpriteRenderer
    {
        private Image Sprite { get; }
        private ILocatable Locatable { get; }

        public SpriteRenderer(Image sprite, ILocatable locatable, Canvas canvas)
        {
            Sprite = sprite;
            Locatable = locatable;

            canvas.Children.Add(Sprite);
        }

        public void Update()
        {
            Canvas.SetBottom(Sprite, Locatable.Location.Y);
            Canvas.SetLeft(Sprite, Locatable.Location.X);
        }
    }
}
