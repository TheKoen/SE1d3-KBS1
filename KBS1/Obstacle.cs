using System.Windows.Controls;

namespace KBS1
{
    public class Obstacle : GameObject
    {
    
        public ObstacleType ObstacleType { get; }

        /// <summary>
        /// Obstacle that needs to be created
        /// </summary>
        /// <param name="type">what type of obstacle</param>
        /// <param name="canvas">Canvas that where its dawn on</param>
        /// <param name="location">location of obstacle</param>
        public Obstacle(ObstacleType type, Canvas canvas, Vector location) : 
            base(type.CollisionRadius, type.Sprite, canvas, location)
        {
            ObstacleType = type;
        }
        /// <summary>
        /// Creates a controller of a Obstacle
        /// </summary>
        /// <returns>Controller of a Obstacle</returns>
        protected override Controller CreateController() => ObstacleType.CreateController(this);
    }
}
