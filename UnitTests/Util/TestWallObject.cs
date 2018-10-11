using KBS1;
using KBS1.Collider;
using KBS1.Misc;

namespace UnitTests.Util
{
    public class TestWallObject : TestGameObject
    {
        public TestWallObject(int radius, Vector location) : base(radius, location)
        {
            Collider = new WallCollider(radius, this);
        }
    }
}