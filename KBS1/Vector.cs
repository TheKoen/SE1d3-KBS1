using System;

namespace KBS1
{
    public class Vector
    {
        /// <summary>
        /// X coordinate of this Vector
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y coordinate of this Vector
        /// </summary>
        public double Y { get; set; }

        public Vector() : this(0, 0) { }

        public Vector(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Calculates the distance between this Vector and another Vector
        /// </summary>
        /// <param name="vector">Vector to calculate distance with</param>
        /// <returns>Distance between this Vector and the provided Vector</returns>
        public double Distance(Vector vector) => Math.Sqrt(Math.Pow(X - vector.X, 2) + Math.Pow(Y - vector.Y, 2));

        /// <summary>
        /// Method to return the distance of a axis
        /// </summary>
        /// <param name="vector">Vector used to calculate de distance</param>
        /// <param name="x">boolean for x or y axis</param>
        /// <returns>a double of the distance form a specific axis</returns>
        public double AxisDistance(Vector vector, bool x) => Math.Abs( x ? X - vector.X : Y - vector.Y );

        /// <summary>
        /// Adds a Vector to this Vector
        /// </summary>
        /// <param name="vector">Vector to add to this Vector</param>
        public void Add(Vector vector)
        {
            X += vector.X;
            Y += vector.Y;
        }

        /// <summary>
        /// Copys the vector of the given vector
        /// </summary>
        /// <param name="vector">given vector to be copied</param>
        /// <returns>A copied Vector</returns>
        public Vector CopyAdd(Vector vector)
        {
            var newVector = new Vector(X, Y);
            newVector.Add(vector);
            return newVector;
        }

        /// <summary>
        /// method used to normilize this Vector for movement 
        /// </summary>
        /// <param name="length"></param>
        /// <returns>this vector</returns>
        public Vector Normalize(double length)
        {
            var div = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            if (Math.Abs(div) < 0.01)
            {
                return this;
            }
            X = (X / div) * length;
            Y = (Y / div) * length;
            return this;
        }
    }
}   
