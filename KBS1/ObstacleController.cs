namespace KBS1
{
    abstract class ObstacleController : Controller
    {
        protected  Obstacle Obstacle { get; }

        protected ObstacleController(ILocatable locatable, Obstacle obstacle) :
            base(obstacle)
        {
            this.Obstacle = obstacle;
        }
    }
}
