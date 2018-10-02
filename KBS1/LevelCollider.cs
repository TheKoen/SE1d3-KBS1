namespace KBS1
{
    public class LevelCollider : Collider
    {
        public LevelCollider() : base(0, null)
        {
        }
        
        public override bool Collides(Vector location, int radius)
        {
            return location.X < radius || location.X > 784 - radius || location.Y < radius || location.Y > 564 - radius;
        }
    }
}
