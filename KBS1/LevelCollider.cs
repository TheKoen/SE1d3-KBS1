﻿namespace KBS1
{
    public class LevelCollider : Collider
    {
        public LevelCollider() : base(0, null)
        {
        }
        
        public override bool Collides(Vector location, int radius)
        {
            return Blocking && (location.X < radius || location.X > 1000 - radius - 200 ||
                                location.Y < radius || location.Y > 600 - radius);
        }
    }
}
