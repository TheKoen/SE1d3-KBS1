using KBS1;
using KBS1.Controller;
using KBS1.Misc;
using KBS1.Player;

namespace UnitTests.Util
{
    class TestPlayer : Player
    {
        public TestPlayer(Vector location) : base(24, null, null, location)
        {
        }

        protected override Controller CreateController()
        {
            return new TestController(this);
        }
    }
}