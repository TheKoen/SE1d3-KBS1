namespace KBS1
{
    class WallObstacleController : ObstacleController
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
