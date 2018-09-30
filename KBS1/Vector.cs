using System;

namespace KBS1
{
    public class Vector
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

        /// <summary>
        /// Add Vector to this Vector
        /// </summary>
        /// <param name="vector">Vector to add to this Vector</param>
        public void Add(Vector vector)
        {
            X += vector.X;
            Y += vector.Y;
        }
    }
}   
