using KBS1.Collider;
using KBS1.Misc;

namespace KBS1.Obstacles.Controllers
{
    internal class WallObstacleController : ObstacleController
    {
        public WallObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle)
        {
            Object.Collider = new WallCollider(obstacle.Collider.Radius, locatable);
        }

        public override void Update()
        {
        }
    }
}