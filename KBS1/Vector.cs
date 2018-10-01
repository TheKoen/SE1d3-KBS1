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

        public Vector()
        {
            X = 0;
            Y = 0;
        }

        public Vector(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        /// <summary>
        /// Calculates the distance between this and another Vector.
        /// </summary>
        /// <param name="vector">The Vector to calculate distance to</param>
        /// <returns>The distance between this and the provided Vector</returns>
        public double Distance(Vector vector)
        {
           return Math.Sqrt(Math.Pow(X - vector.X, 2) + Math.Pow(Y - vector.Y, 2));
        }

        public double AxisDistance(Vector vector, bool x)
        {
            if (x) {
                return Math.Abs(X - vector.X);
            } else
            {
                return Math.Abs(Y - vector.Y);
            }
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

        public Vector CopyAdd(Vector vector)
        {
            var newVector = new Vector(X, Y);
            newVector.Add(vector);
            return newVector;
        }
    }
}   
