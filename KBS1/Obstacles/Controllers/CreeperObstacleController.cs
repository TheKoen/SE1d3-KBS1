using System;
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
        private int _wait;
        private bool _red;
        private int step;
        private bool walkSprite;
        private readonly Image idle = ResourceManager.Instance.LoadImage("bomb.png");
        private readonly Image walk = ResourceManager.Instance.LoadImage("bombwalk.png");
        private readonly Image explode = ResourceManager.Instance.LoadImage("bombexplode.png");
        private readonly Image explosion = ResourceManager.Instance.LoadImage("explosion.png");

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
                        Object.Renderer.ChangeSprite((BitmapImage) idle.Source);
                        _red = false;
                    }
                    else if (_red == false)
                    {
                        Object.Renderer.ChangeSprite((BitmapImage) explode.Source);
                        _red = true;
                    }
                }

                if (_wait < 16)
                {
                    Object.Renderer.ChangeSprite((BitmapImage) explosion.Source);
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

            if (step < 10)
            {
                step++;
                if (step == 10)
                {
                    step = 0;
                    walkSprite = !walkSprite;
                }
            }

            if (walkSprite)
                Object.Renderer.ChangeSprite((BitmapImage) walk.Source);
            else
                Object.Renderer.ChangeSprite((BitmapImage) idle.Source);

            // start the delay of the explostion if the distance of the player is explosionRadius/2.
            if (Object.Location.Distance(playerObject.Location) < ExplosionRadius / 2.0)
                _wait = DelayCreeper;
        }
    }
}