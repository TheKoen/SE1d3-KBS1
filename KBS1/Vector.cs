using System;

namespace KBS1
{
    class Vector
    {
        /// <summary>
        /// X coordinate of this Vector
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of this Vector
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Calculates the distance between this and another Vector.
        /// </summary>
        /// <param name="vector">The Vector to calculate distance to</param>
        /// <returns>The distance between this and the provided Vector</returns>
        public double Distance(Vector vector)
        {
           return Math.Sqrt(Math.Pow(X - vector.X, 2) + Math.Pow(Y - vector.Y, 2));
        }
    }
}
