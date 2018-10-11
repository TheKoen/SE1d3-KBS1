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