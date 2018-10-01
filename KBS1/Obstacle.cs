using System.Windows.Controls;

namespace KBS1
{
    public class Obstacle : GameObject
    {
        public ObstacleType ObstacleType { get; }

        public Obstacle(ObstacleType type, Canvas canvas, Vector location) : 
            base(type.CollisionRadius, type.Sprite, canvas, location)
        {
            ObstacleType = type;
        }

        protected override Controller CreateController()
        {
            return ObstacleType.CreateController(this);
        }
    }
}
