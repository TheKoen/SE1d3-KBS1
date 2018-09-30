namespace KBS1
{
    public class LevelCollider : Collider
    {
        public LevelCollider() : base(0, null)
        {
        }

        //TODO: Implement level collision
        public override bool Collides(Collider collider)
        {
            return false;
        }
    }
}
