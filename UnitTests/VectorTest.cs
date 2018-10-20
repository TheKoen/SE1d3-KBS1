using System;
using KBS1.Misc;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    internal class VectorTest
    {
        private const double MAX_DELTA = 0.01;

        [TestCase(0.0, 0.0, 1.0, 0.0, 1.0)]
        [TestCase(0.0, 0.0, 1.0, 1.0, 1.41)]
        [TestCase(0.0, 0.0, 1.0, -1.0, 1.41)]
        [TestCase(0.0, 0.0, 1.0, 5.0, 5.09)]
        [TestCase(1.0, 0.7, 1.5, 9.0, 8.31)]
        [TestCase(1.3, 21.1, 1.5, 90.7, 69.60)]
        [TestCase(0.0, 0.0, 0.0, 0.0, 0.0)]
        public void Vector_Distance(double x1, double y1, double x2, double y2, double expected)
        {
            var vector1 = new Vector(x1, y1);
            var vector2 = new Vector(x2, y2);

            var result = vector1.Distance(vector2);

            Assert.AreEqual(expected, result, MAX_DELTA);
        }

        [TestCase(0.0, 0.0, 1.0, 1.0)]
        [TestCase(0.0, 0.0, 1.0, -1.0)]
        [TestCase(0.0, 0.0, 0.0, 1.0)]
        [TestCase(1.0, 0.0, 1.0, 1.0)]
        [TestCase(0.0, -1.0, 1.0, 1.0)]
        public void Vector_Add(double x, double y, double dx, double dy)
        {
            var vector = new Vector(x, y);

            vector.Add(new Vector(dx, dy));

            Assert.AreEqual(x + dx, vector.X);
            Assert.AreEqual(y + dy, vector.Y);
        }

        [TestCase(1.0, 1.0, 1.0)]
        [TestCase(1.0, 5.0, 1.0)]
        [TestCase(1.0, -1.0, 1.0)]
        [TestCase(3.0, 3.0, 1.0)]
        [TestCase(5.0, 7.0, 1.0)]
        [TestCase(2.6, 3.1, 1.0)]
        [TestCase(1.0, 1.0, 2.0)]
        [TestCase(1.0, 5.0, 2.0)]
        [TestCase(1.0, 1.0, 1.4)]
        [TestCase(1.0, 5.0, 1.4)]
        [TestCase(0.0, 1.0, 1.0)]
        [TestCase(4.0, 0.0, 1.0)]
        public void Vector_Normalize(double x, double y, double length)
        {
            var vector = new Vector(x, y);

            vector.Normalize(length);
            var result = Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));

            Assert.AreEqual(length, result, MAX_DELTA);
        }
    }
}