namespace KBS1
{
    public abstract class ObstacleController : Controller
    {
        protected Obstacle Obstacle { get; }

        protected ObstacleController(ILocatable locatable, Obstacle obstacle) :
            base(obstacle)
        {
            Obstacle = obstacle;
        }
        
    }
}
