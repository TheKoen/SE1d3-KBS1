namespace KBS1
{
    public class Collider
    {
        private int Radius { get; }
        private ILocatable Locatable { get; }

        public Collider(int radius, ILocatable locatable)
        {
            this.Radius = radius;
            this.Locatable = locatable;
        }

        /// <summary>
        /// Checks whether this Collider collides with another Collider
        /// </summary>
        /// <param name="collider">Collider to check for</param>
        /// <returns>true if the Colliders collide</returns>
        public virtual bool Collides(Collider collider)
        {
            var current = Locatable.Location;
            var other = collider.Locatable.Location;

            return current.Distance(other) < Radius + collider.Radius;
        }
    }
}
