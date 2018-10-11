using KBS1.Misc;

namespace KBS1.Obstacles
{
    public abstract class ObstacleController : Controller.Controller
    {
        protected Obstacle Obstacle { get; }

        protected ObstacleController(ILocatable locatable, Obstacle obstacle) :
            base(obstacle)
        {
            Obstacle = obstacle;
        }
    }
}