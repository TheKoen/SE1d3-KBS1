using System.Windows.Controls;
using System.Windows.Media.Imaging;
using KBS1.Misc;
using KBS1.Util;

namespace KBS1.Obstacles.Controllers
{
    public class CreeperObstacleController : ObstacleController
    {
        private const int Speed = 1;
        private const int Range = 150;
        private const int ExplosionRadius = 100;
        private const int DelayCreeper = 100;
        private int _wait = 0;
        private bool _red = false;
        private readonly Image _imageRed = ResourceManager.Instance.LoadImage("#creeper_red.png");
        private readonly Image _imageGreen = ResourceManager.Instance.LoadImage("#creeper.png");

        public CreeperObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle)
        {
        }

        /// <summary>
        /// Updates the creeper location and sprite every gametick
        /// </summary>
        public override void Update()
        {
            // player 
            var playerObject = FindPlayer();

            // player location
            var player = playerObject.Location;

            // delay for changing color creeper
            if (_wait-- > 0)
            {
                if (_wait % 5 == 0)
                {
                    if (_red)
                    {
                        Object.Renderer.ChangeSprite((BitmapImage) _imageRed.Source);
                        _red = false;
                    }
                    else if (_red == false)
                    {
                        Object.Renderer.ChangeSprite((BitmapImage) _imageGreen.Source);
                        _red = true;
                    }
                }

                //explode if player is in range and timer is out of time
                if (_wait == 0 && Object.Location.Distance(player) <= ExplosionRadius)
                    GameWindow.Instance.Lose();
                // if player is out of range and creeper is out of time destroy creeper
                else if (_wait == 0 && Object.Location.Distance(player) > ExplosionRadius)
                {
                    GameWindow.Instance.Loadedlevel.Objects.Remove(Object);
                    Object.Renderer.Destroy();
                    Object.Controller.Destroy();
                }

                return;
            }

            // x distance y distance from player to object
            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);

            if (player.Distance(Object.Location) > Range)
                return;

            if (xDistance > yDistance)
                Move(player.X > Object.Location.X ? new Vector(Speed, 0) : new Vector(-Speed, 0));
            else
                Move(player.Y > Object.Location.Y ? new Vector(0, Speed) : new Vector(0, -Speed));

            // start the delay of the explostion if the distance of the player is explosionRadius/2.
            if (Object.Location.Distance(playerObject.Location) < ExplosionRadius / 2.0)
                _wait = DelayCreeper;
        }
    }
}