using System.Windows.Controls;
using KBS1;

namespace UnitTests.Util
{
    class TestGameObject : GameObject {

        public TestGameObject(int radius, Vector location) : base(radius, null, null, location)
        {
        }

        protected override Controller CreateController()
        {
            return new TestController(this);
        }
    }
}
