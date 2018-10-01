namespace KBS1
{
    public class Collider
    {
        private int Radius { get; }
        private ILocatable Locatable { get; }

        public Collider(int radius, ILocatable locatable)
        {
            Radius = radius;
            Locatable = locatable;
        }

        /// <summary>
        /// Checks whether this Collider collides with another Collider
        /// </summary>
        /// <param name="collider">Collider to check for</param>
        /// <returns>Collision status</returns>
        public virtual bool Collides(Collider collider) => Collides(collider.Locatable.Location, collider.Radius);
        
        /// <summary>
        /// Checks whether this Collider collides with a radius
        /// </summary>
        /// <param name="vector">Vector representing an object</param>
        /// <param name="radius">Radius of the object</param>
        /// <returns>Collision status</returns>
        public bool Collides(Vector vector, int radius)
        {
            var current = Locatable.Location;
            return current.Distance(vector) < Radius + radius;
        }

        // TODO: Finish documentation
        /// <summary>
        /// Checks whether this Collider collides with any object present in the current level
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Collision status</returns>
        public bool CollidesAny(Vector vector)
        {
            var level = GameWindow.Instance.Loadedlevel;
            foreach(var GameObject in level.Objects)
            {
                if(GameObject.Collider?.Collides(vector, Radius) == true)
                    return true;
            }
            return false;
        }
    }
}
