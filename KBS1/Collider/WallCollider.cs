using System.Windows;
using KBS1.Misc;
using Vector = KBS1.Misc.Vector;

namespace KBS1.Collider
{
    public class WallCollider : Collider
    {
        public WallCollider(int radius, ILocatable locatable) : base(radius, locatable)
        {
        }

        /// <summary>
        ///     Collider of a wall object
        /// </summary>
        /// <param name="vector">Vector representing an object</param>
        /// <param name="radius">radius player</param>
        /// <returns>bool Collided</returns>
        public override bool Collides(Vector vector, int radius)
        {
            var playerSizeHorizontal = radius * 2.0;
            var playerSizeVertical = radius * 2.0;

            var playerRect = new Rect(vector.X, vector.Y, playerSizeHorizontal, playerSizeVertical);
            var wallRect = new Rect(Locatable.Location.X, Locatable.Location.Y, Radius * 2, Radius * 2);

            return playerRect.IntersectsWith(wallRect);
        }
    }
}