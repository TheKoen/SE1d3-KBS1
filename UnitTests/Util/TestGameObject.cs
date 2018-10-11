using System.Windows.Controls;
using KBS1;
using KBS1.Controller;
using KBS1.GameObjects;
using KBS1.Misc;

namespace UnitTests.Util
{
    public class TestGameObject : GameObject
    {
        public TestGameObject(int radius, Vector location) : base(radius, null, null, location)
        {
        }

        protected override Controller CreateController()
        {
            return new TestController(this);
        }
    }
}