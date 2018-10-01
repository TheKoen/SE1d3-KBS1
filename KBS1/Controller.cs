using System;

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
            var newLocation = this.Locatable.Location.CopyAdd(vector);
            if (!Object.Collider.CollidesAny(newLocation))
            {
                Locatable.Location.Add(vector);
            }
        }

        public abstract void Update();

        protected GameObject FindPlayer()
        {
            var level = GameWindow.Current().Loadedlevel;
            foreach (GameObject gameObject in level.Objects)
            {
                if (gameObject.GetType() == typeof(Player))
                {
                    return gameObject;
                }
            }
            throw new NullReferenceException("Level does not contain a player");
        }
    }
}
