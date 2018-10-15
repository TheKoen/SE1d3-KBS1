using KBS1.Misc;

namespace KBS1.Collider
{
    public class LevelCollider : Collider
    {
        public LevelCollider() : base(0, null)
        {
        }

        public override bool Collides(Vector location, int radius)
        {
            return Blocking && (location.X < radius || location.X > 980 - radius - 200 ||
                                location.Y < radius || location.Y > 550 - radius);
        }
    }
}