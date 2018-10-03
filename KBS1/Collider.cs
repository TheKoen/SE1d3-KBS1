namespace KBS1
{
    public class Collider
    {
        protected int Radius { get; }
        public ILocatable Locatable { get; }
        public bool Blocking { get; set; }

        public Collider(int radius, ILocatable locatable)
        {
            this.Radius = radius;
            this.Locatable = locatable;
            this.Blocking = true;
        }

        /// <summary>
        /// Checks whether this Collider collides with another Collider
        /// </summary>
        /// <param name="collider">Collider to check for</param>
        /// <returns>true if the Colliders collide</returns>
        public bool Collides(Collider collider)
        {
            return Collides(collider.Locatable.Location, collider.Radius);
        }
        

        public virtual bool Collides(Vector vector, int radius)
        {
            var current = Locatable.Location;

            return current.Distance(vector) < Radius + radius;
        }

        public bool CollidesAny(Vector vector, bool ignoreNonBlocking)
        {
            var level = GameWindow.Current().Loadedlevel;
            if (ignoreNonBlocking && !Blocking)
            {
                return false;
            }
            if (level.LevelCollider.Collides(vector, Radius))
            {
                return true;
            }

            foreach(var GameObject in level.Objects)
            {
                if (GameObject.Collider?.Collides(vector, Radius) != true || GameObject.Collider == this)
                {
                    continue;
                }
                if (ignoreNonBlocking && !GameObject.Collider.Blocking) 
                {
                    continue;
                }

                return true;
            }
            return false;
        }
    }
}
