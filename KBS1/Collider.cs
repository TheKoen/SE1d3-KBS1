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
            return Collides(collider.Locatable.Location, collider.Radius);
        }
        

        public bool Collides(Vector vector, int radius)
        {
            var current = Locatable.Location;

            return current.Distance(vector) < Radius + radius;
        }

        public bool CollidesAny(Vector vector)
        {
            var level = GameWindow.Current().Loadedlevel;
            foreach(var GameObject in level.Objects)
            {
                if(GameObject.Collider?.Collides(vector, Radius) == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
