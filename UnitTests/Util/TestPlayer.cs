using KBS1;

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
