using System.Windows.Controls;

namespace KBS1
{
    public abstract class Obstacle : GameObject
    {
        public ObstacleType ObstacleType { get; }

        protected Obstacle(ObstacleType type, Canvas canvas, Vector location) : 
            base(type.CollisionRadius, type.Sprite, canvas, location)
        {
            ObstacleType = type;
        }
    }
}
