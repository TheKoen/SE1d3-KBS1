using System.Windows.Controls;

namespace KBS1
{
    class Player : GameObject
    {
        public Player(int radius, Image image, Canvas canvas, Vector location) : 
            base(radius, image, canvas, location)
        {
        }

        //abstract method from abstract class GameObject to create a new Controller.
        protected override Controller CreateController()
        {
            return new PlayerController(this);
        }
    }
}
