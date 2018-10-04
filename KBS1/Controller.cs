using System;

namespace KBS1
{
    public abstract class Controller
    {
        protected GameObject Object { get; }

        protected Controller(GameObject gameObject)
        {
            this.Object = gameObject;
        }

        /// <summary>
        /// Move the GameObject in a direction;
        /// </summary>
        /// <param name="vector">Direction to move in</param>
        public bool Move(Vector vector)
        {
            var newLocation = Object.Location.CopyAdd(vector);
            if (Object.Collider.CollidesAny(newLocation, true))
            {
                return false;
            }

            Object.Location = newLocation;
            return true;

        }

        public abstract void Update();

        public static GameObject FindPlayer()
        {
            var level = GameWindow.Current().Loadedlevel;
            foreach (var gameObject in level.Objects)
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
