using KBS1.Collider;
using KBS1.GameObjects;
using KBS1.Misc;
using NUnit.Framework;
using UnitTests.Util;

namespace UnitTests
{
    [TestFixture]
    internal class ColliderTest
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

            Assert.AreEqual(expectation, collides);
        }

        [TestCase(10.0, 10.0, 1, 10.0, 10.0, 1, true)]
        [TestCase(10.0, 10.0, 1, 10.0, 10.0, 2, true)]
        [TestCase(10.0, 10.0, 2, 14.0, 10.0, 2, false)]
        [TestCase(100.0, 10.0, 2, 14.0, 10.0, 8, false)]
        [TestCase(10.0, 10.0, 1, 10.0, 10.0, 20, true)]
        [TestCase(0.0, 0.0, 1, 10.0, 10.0, 1, true)]
        public void Collider_CollidesAny(double x1, double y1, int r1, double x2, double y2, int r2, bool expected)
        {
            var object1 = new TestGameObject(r1, new Vector(x1, y1));
            var object2 = new TestGameObject(r2, new Vector(x2, y2));
            LevelUtil.CreateLevel(new GameObject[] {object1, object2});

            var result = object1.Collider.CollidesAny(object1.Location, true);

            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 1.0, 1.0, 2, true)]
        [TestCase(2, 9.0, 0.0, 2, false)]
        [TestCase(2, 5.0, 0.0, 2, true)]
        [TestCase(2, 0.0, 0.0, 2, true)]
        [TestCase(1, 1.0, 1.0, 1, true)]
        [TestCase(1, 1.0, 1.0, 10, true)]
        [TestCase(1, -1.0, -1.0, 10, true)]
        [TestCase(10, -1.0, -1.0, 10, true)]
        [TestCase(1, 100.0, -100.0, 1, false)]
        public void WallCollider_Collides(int radius1, double x2, double y2, int radius2, bool expectation)
        {
            var collider1 = new Collider(radius1, CreateLocatable(new Vector()));
            var collider2 = new WallCollider(radius2, CreateLocatable(new Vector(x2, y2)));

            var collides = collider2.Collides(collider1);

            Assert.AreEqual(expectation, collides);
        }

        [TestCase(10.0, 10.0, 1, 10.0, 10.0, 1, true)]
        [TestCase(10.0, 10.0, 1, 10.0, 10.0, 2, true)]
        [TestCase(10.0, 10.0, 2, 14.0, 10.0, 2, false)]
        [TestCase(100.0, 10.0, 2, 14.0, 10.0, 8, false)]
        [TestCase(10.0, 10.0, 1, 10.0, 10.0, 20, true)]
        [TestCase(0.0, 0.0, 1, 10.0, 10.0, 1, true)]
        public void WallCollider_CollidesAny(double x1, double y1, int r1, double x2, double y2, int r2, bool expected)
        {
            var object1 = new TestWallObject(r1, new Vector(x1, y1));
            var object2 = new TestGameObject(r2, new Vector(x2, y2));
            LevelUtil.CreateLevel(new GameObject[] {object1, object2});

            var result = object1.Collider.CollidesAny(object1.Location, true);

            Assert.AreEqual(expected, result);
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