using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KBS1.Util;

namespace KBS1.Misc
{
    public class SpriteRenderer
    {
        private Image Sprite { get; }
        private ILocatable Locatable { get; }
        private Vector Size { get; set; }
        private Canvas Canvas { get; }

        /// <summary>
        /// This constructor clones the <see cref="Image"/> or WPF is angry, gives location, and the canvas it needs to be drawn on
        /// </summary>
        /// <param name="sprite"><see cref="Image"/> that needs to be copied</param>
        /// <param name="locatable"><see cref="Locatable"/> of sprite</param>
        /// <param name="canvas"><see cref="Canvas"/> that needs to be drawn on</param>
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

            InstanceHelper.GetGameLoop().Subscribe(Update);
        }

        /// <summary>
        /// Method that is called every game tick changes the sprite location on screen
        /// </summary>
        public void Update()
        {
            Canvas.SetTop(Sprite, Locatable.Location.Y - Size.Y);
            Canvas.SetLeft(Sprite, Locatable.Location.X - Size.X);
        }

        /// <summary>
        /// Removes the sprite from the <see cref="Canvas"/>
        /// </summary>
        public void Destroy()
        {
            Canvas.Children.Remove(Sprite);
            InstanceHelper.GetGameLoop().Unsubscribe(Update);
        }

        /// <summary>
        /// Changes the sprite
        /// </summary>
        /// <param name="sprite"><see cref="BitmapImage"/> that is taking the place of the old one</param>
        public void ChangeSprite(BitmapImage sprite)
        {
            Sprite.Source = sprite;
            Size = new Vector((int)(sprite.Width / 2), (int)(sprite.Height / 2));
        }

        public void Rotate(double angle)
        {
            Sprite.RenderTransform = new RotateTransform(angle, Size.X, Size.Y);
        }
    }
}