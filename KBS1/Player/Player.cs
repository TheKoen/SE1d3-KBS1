using System.Windows.Controls;
using KBS1.GameObjects;
using KBS1.Misc;

namespace KBS1.Player
{
    public class Player : GameObject
    {
        public Player(int radius, Image image, Canvas canvas, Vector location) :
            base(radius, image, canvas, location)
        {
        }

        //abstract method from abstract class GameObject to create a new Controller.
        /// <summary>
        ///     Initializes the controller for the Player object
        /// </summary>
        /// <returns>The controller for the Player object</returns>
        protected override Controller.Controller CreateController()
        {
            return new PlayerController(this);
        }
    }
}