using KBS1;

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
