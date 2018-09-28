namespace KBS1
{
    class Collider
    {
        private readonly int radius;
        private readonly ILocatable locatable;

        public Collider(int radius, ILocatable locatable)
        {
            this.radius = radius;
            this.locatable = locatable;
        }

        /// <summary>
        /// Checks whether this Collider collides with another Collider
        /// </summary>
        /// <param name="collider">Collider to check for</param>
        /// <returns>true if the Colliders collide</returns>
        public bool Collides(Collider collider)
        {
            var current = locatable.Location;
            var other = collider.locatable.Location;

            return current.Distance(other) < radius + collider.radius;
        }
    }
}
