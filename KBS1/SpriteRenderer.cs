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

        /// <summary>
        /// Constructor of spriteRenderer clones the image or WPF is angry, gives location, and the canvas where it needs to be drawn on
        /// </summary>
        /// <param name="sprite">Image that needs to be copied</param>
        /// <param name="locatable">location of sprite</param>
        /// <param name="canvas">canvas that needs to be drawn on</param>
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

        /// <summary>
        /// Method that is called every game tick changes the sprite location on screen
        /// </summary>
        public void Update()
        {
            Canvas.SetTop(Sprite, Locatable.Location.Y - Size.Y);
            Canvas.SetLeft(Sprite, Locatable.Location.X -Size.X);
        }
        /// <summary>
        /// Removes the sprite from the canvas
        /// </summary>
        public void Destroy()
        {
            Canvas.Children.Remove(Sprite);
        }
        
        /// <summary>
        /// Changes the sprite
        /// </summary>
        /// <param name="sprite">Image that is taking the place of the old one</param>
        public void ChangeSprite(BitmapImage sprite)
        {
            Sprite.Source = sprite;
        }
    }
}
