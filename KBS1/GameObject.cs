using System.Windows.Controls;

namespace KBS1
{
    public abstract class GameObject : ILocatable
    {
        public Vector Location { get; set; }
        public SpriteRenderer Renderer { get; }
        public Collider Collider { get; }
        public Controller Controller { get; private set; }

        //When making a new GameObject, a new SpriteRenderer will be made with it.
        protected GameObject(int radius, Image image, Canvas canvas, Vector location)
        {
            this.Location = location;
            this.Renderer = new SpriteRenderer(image, this, canvas);
            this.Collider = new Collider(radius, this);
        }

        //abstract method for creating a new Controller for a GameObject depending on what kind of GameObject.
        protected abstract Controller CreateController();

        //Initialize the controller
        public void Init()
        {
            this.Controller = this.CreateController();
        }
    }
}
