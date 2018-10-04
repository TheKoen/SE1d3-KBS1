using System.Windows.Controls;

namespace KBS1
{
    public class FinishObject : GameObject
    {
        private bool Finish { get; }

        public FinishObject(int radius, Image image, Canvas canvas, Vector location, bool finish) : 
            base(radius, image, canvas, location)
        {
            Finish = finish;
        }

        /// <summary>
        /// Creates a controller for this FinishObject
        /// </summary>
        /// <returns>Controller for this FinishObject</returns>
        protected override Controller CreateController() => new FinishController(this, Finish);
    }
}
