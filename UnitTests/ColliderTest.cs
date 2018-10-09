using KBS1;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class ColliderTest
    {
        [TestCase(2, 1.0, 1.0, 2, true)]
        [TestCase(2, 6.0, 0.0, 2, false)]
        [TestCase(2, 5.0, 0.0, 2, true)]
        [TestCase(2, 0.0, 0.0, 2, true)]
        [TestCase(1, 1.0, 1.0, 1, true)]
        [TestCase(1, 1.0, 1.0, 10, true)]
        [TestCase(1, -1.0, -1.0, 10, true)]
        [TestCase(10, -1.0, -1.0, 10, true)]
        [TestCase(1, 100.0, -100.0, 1, false)]
        public void Collider_Collides(int radius1, double x2, double y2, int radius2, bool expectation)
        {
            var collider1 = new Collider(radius1, CreateLocatable(new Vector()));
            var collider2 = new Collider(radius2, CreateLocatable(new Vector(x2, y2)));

            var collides = collider1.Collides(collider2);

            Assert.AreEqual(collides, expectation);
        }

        private static ILocatable CreateLocatable(Vector location)
        {
            return new TestLocatable(location);
        }

        private class TestLocatable : ILocatable
        {
            public TestLocatable(Vector location)
            {
                Location = location;
            }

            public Vector Location { get; set; }
        }
    }
}
