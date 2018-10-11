using KBS1.Misc;
using KBS1.Player;

namespace KBS1.Obstacles.Controllers
{
    public class TrapObstacleController : ObstacleController
    {
        public TrapObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle)
        {
        }

        /// <summary>
        /// Methode called every gametick Checks if <see cref="Player"/> collides with the TrapObstacle.
        /// </summary>
        public override void Update()
        {
            var playerObject = FindPlayer();

            if (Object.Collider.Collides(playerObject.Collider))
                GameWindow.Instance.Lose();
        }
    }
}