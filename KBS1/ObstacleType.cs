using System.Collections.Generic;
using System.Windows.Controls;

namespace KBS1
{
    public class ObstacleType
    {
        public static List<ObstacleType> Types = new List<ObstacleType>();

        public int CollisionRadius { get; }
        public Image Sprite { get; }

        private readonly IControllerCreator Creator;

        public ObstacleType(IControllerCreator creator, int collisionRadius, Image sprite)
        {
            Creator = creator;
            CollisionRadius = collisionRadius;
            Sprite = sprite;
        }

        /// <summary>
        /// Creates a new ObstacleController for this ObstacleType
        /// </summary>
        /// <returns>ObstacleController for this ObstacleType</returns>
        public Controller CreateController()
        {
            return Creator.Create();
        }

    }
}
