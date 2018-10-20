using System.Windows.Controls;
using System.Windows.Media.Imaging;
using KBS1.Misc;
using KBS1.Player;
using KBS1.Util;

namespace KBS1.Obstacles.Controllers
{
    public class TrapObstacleController : ObstacleController
    {
        private readonly Image explosion = ResourceManager.Instance.LoadImage("#explosion.png");
        private bool lost;

        public TrapObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle)
        {
        }

        /// <summary>
        ///     Methode called every gametick Checks if <see cref="Player" /> collides with the TrapObstacle.
        /// </summary>
        public override void Update()
        {
            var playerObject = FindPlayer();

            if (Object.Collider.Collides(playerObject.Collider))
            {
                Object.Renderer.ChangeSprite((BitmapImage) explosion.Source);
                GameWindow.Instance.Sounds.Play("explode.mp3");
                lost = true;
            }

            if (lost) GameWindow.Instance.Lose();
        }
    }
}