namespace KBS1
{
    public abstract class Controller
    {
        protected ILocatable Locatable { get; }
        protected GameObject Object { get; }

        protected Controller(GameObject gameObject)
        {
            this.Locatable = gameObject;
            this.Object = gameObject;
        }

        /// <summary>
        /// Move the GameObject in a direction;
        /// </summary>
        /// <param name="vector">Direction to move in</param>
        public void Move(Vector vector)
        {
            Locatable.Location.Add(vector);
        }

        public abstract void Update();
    }
}
