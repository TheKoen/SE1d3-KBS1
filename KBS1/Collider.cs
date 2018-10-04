namespace KBS1
{
    public class Collider
    {
        protected int Radius { get; }
        public ILocatable Locatable { get; }
        public bool Blocking { get; set; }

        public Collider(int radius, ILocatable locatable)
        {
            Blocking = true;
            Radius = radius;
            Locatable = locatable;
        }

        /// <summary>
        /// Checks whether this Collider collides with another Collider
        /// </summary>
        /// <param name="collider">Collider to check for</param>
        /// <returns>Collision status</returns>
        public bool Collides(Collider collider) => Collides(collider.Locatable.Location, collider.Radius);
        
        /// <summary>
        /// Checks whether this Collider collides with a radius
        /// </summary>
        /// <param name="vector">Vector representing an object</param>
        /// <param name="radius">Radius of the object</param>
        /// <returns>Collision status</returns>
        public virtual bool Collides(Vector vector, int radius)
        {
            var current = Locatable.Location;
            return current.Distance(vector) < Radius + radius;
        }

        public bool CollidesAny(Vector vector, bool ignoreNonBlocking)
        {
            var level = GameWindow.Instance.Loadedlevel;
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
