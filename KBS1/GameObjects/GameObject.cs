using System.Windows.Controls;
using KBS1.Misc;

namespace KBS1.GameObjects
{
    public abstract class GameObject : ILocatable
    {
        /// <summary>
        ///     When making a new GameObject, a new SpriteRenderer and Collider wil be made.
        /// </summary>
        /// <param name="radius">radius gameobject</param>
        /// <param name="image">image gameobject</param>
        /// <param name="canvas">canvas gameobject is drawn on</param>
        /// <param name="location">location of the gameobject</param>
        protected GameObject(int radius, Image image, Canvas canvas, Vector location)
        {
            Location = location;
            if (image != null || canvas != null)
                Renderer = new SpriteRenderer(image, this, canvas);
            Collider = new Collider.Collider(radius, this);
        }

        public SpriteRenderer Renderer { get; }
        public Collider.Collider Collider { get; set; }
        public Controller.Controller Controller { get; private set; }
        public Vector Location { get; set; }

        /// <summary>
        ///     abstract method for creating a new Controller for a GameObject depending on what kind of GameObject.
        /// </summary>
        protected abstract Controller.Controller CreateController();

        /// <summary>
        ///     Initializes the controller for the game
        /// </summary>
        public void Init()
        {
            Controller = CreateController();
        }
    }
}