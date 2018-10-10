using System;

namespace KBS1
{
    public class Vector
    {
        /// <summary>
        /// X coordinate of this <see cref="Vector"/>
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y coordinate of this <see cref="Vector"/>
        /// </summary>
        public double Y { get; set; }

        public Vector() : this(0, 0) { }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Calculates the distance between this <see cref="Vector"/> and another <see cref="Vector"/>
        /// </summary>
        /// <param name="vector"><see cref="Vector"/> to calculate distance with</param>
        /// <returns>Distance between this <see cref="Vector"/> and the provided <see cref="Vector"/></returns>
        public double Distance(Vector vector) => Math.Sqrt(Math.Pow(X - vector.X, 2) + Math.Pow(Y - vector.Y, 2));

        /// <summary>
        /// Method to return the distance of an axis
        /// </summary>
        /// <param name="vector"><see cref="Vector"/> used to calculate de distance</param>
        /// <param name="x">Bool for x or y axis</param>
        /// <returns>Double of the distance form a specific axis</returns>
        public double AxisDistance(Vector vector, bool x) => Math.Abs( x ? X - vector.X : Y - vector.Y );

        /// <summary>
        /// Adds a <see cref="Vector"/> to this <see cref="Vector"/>
        /// </summary>
        /// <param name="vector"><see cref="Vector"/> to add</param>
        public void Add(Vector vector)
        {
            X += vector.X;
            Y += vector.Y;
        }

        /// <summary>
        /// Copys the <see cref="Vector"/> of the given <see cref="Vector"/>
        /// </summary>
        /// <param name="vector">Given <see cref="Vector"/> to be copied</param>
        /// <returns>A copied <see cref="Vector"/></returns>
        public Vector CopyAdd(Vector vector)
        {
            var newVector = new Vector(X, Y);
            newVector.Add(vector);
            return newVector;
        }

        /// <summary>
        /// Normilizes this <see cref="Vector"/> for movement 
        /// </summary>
        /// <param name="length">Length to normalize to</param>
        /// <returns>This <see cref="Vector"/></returns>
        public Vector Normalize(double length)
        {
            var div = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            if (Math.Abs(div) < 0.01) return this;
            X = X / div * length;
            Y = Y / div * length;

            return this;
        }
    }
}   
