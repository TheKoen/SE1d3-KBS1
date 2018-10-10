namespace KBS1
{
    public class Collider
    {
        public int Radius { get; }
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
        public bool Collides(Collider collider) => Collides(collider.Locatable.Location, collider.Radius + 2);
        
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

        /// <summary>
        /// TODO: Add proper summary
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="ignoreNonBlocking"></param>
        /// <returns></returns>
        public bool CollidesAny(Vector vector, bool ignoreNonBlocking)
        {
            var level = GameWindow.Instance.Loadedlevel;
            if (ignoreNonBlocking && !Blocking)
                return false;

            if (level.LevelCollider.Collides(vector, Radius))
                return true;

            foreach(var gameObject in level.Objects)
            {
                if (gameObject.Collider?.Collides(vector, Radius) != true || gameObject.Collider == this)
                    continue;
                if (ignoreNonBlocking && !gameObject.Collider.Blocking)
                    continue;

                return true;
            }
            return false;
        }
    }
}
