using System;
using KBS1.GameObjects;
using KBS1.Misc;
using KBS1.Util;

namespace KBS1.Controller
{
    public abstract class Controller
    {
        public GameObject Object { get; }

        protected Controller(GameObject gameObject)
        {
            Object = gameObject;

            InstanceHelper.GetGameLoop().Subscribe(Update);
        }

        public void Destroy()
        {
            InstanceHelper.GetGameLoop().Unsubscribe(Update);
        }

        /// <summary>
        /// Move the GameObject using a Vector
        /// </summary>
        /// <param name="vector">Movement Vector</param>
        public bool Move(Vector vector)
        {
            var newLocation = Object.Location.CopyAdd(vector);
            if (!Object.Collider.CollidesAny(newLocation, true))
            {
                Object.Location = newLocation;
                return true;
            }

            var newLocationHorizontal = new Vector(newLocation.X, Object.Location.Y);
            if (!Object.Collider.CollidesAny(newLocationHorizontal, true))
            {
                Object.Location = newLocationHorizontal;
                return true;
            }

            var newLocationVertical = new Vector(Object.Location.X, newLocation.Y);
            if (!Object.Collider.CollidesAny(newLocationVertical, true))
            {
                Object.Location = newLocationVertical;
                return true;
            }

            return false;
        }

        public abstract void Update();

        /// <summary>
        /// Gets the Player object in the current level
        /// </summary>
        /// <returns>The Player object</returns>
        public static GameObject FindPlayer()
        {
            var level = InstanceHelper.GetCurrentLevel();
            foreach (var gameObject in level.Objects)
            {
                if (gameObject is Player.Player)
                    return gameObject;
            }

            throw new NullReferenceException("Level does not contain a player");
        }
    }
}