using System.Windows.Controls;

namespace KBS1
{
    public class FinishObject : GameObject
    {
        private bool Finish { get; }

        public FinishObject(int radius, Image image, Canvas canvas, Vector location, bool finish) : 
            base(radius, image, canvas, location)
        {
            this.Finish = finish;
        }

        protected override Controller CreateController()
        {
            return new FinishController(this, this.Finish);
        }
    }
}
