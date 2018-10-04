using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KBS1
{
    public class CreeperObstacleController : ObstacleController
    {
        private const int speed = 1;
        private const int range = 300;
        private const int explosionRadius = 100;
        private const int delayCreeper = 100;
        private int wait = 0;
        private Boolean red = false;
        private Image imageRed = Level.LoadImage("creeper_red.png");
        private Image imageGreen = Level.LoadImage("creeper.png");

        public CreeperObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }

        public override void Update()
        {
            // player object
            var playerObject = FindPlayer();

            // player location
            var player = playerObject.Location;

            if (wait > 0)
            {
                wait--;


                if (wait % 5 == 0)
                {
                    // color chancing creeper if in explosion range
                    if (red == true)
                    {
                        
                        Object.Renderer.ChangeSprite((BitmapImage)imageRed.Source);
                        red = false;
                    }
                    else if (red == false)
                    {
                        Object.Renderer.ChangeSprite((BitmapImage)imageGreen.Source);
                        red = true;
                    }

                }

                //explode if player is in range and timer is out of time
                if (wait == 0 && Object.Location.Distance(player) < explosionRadius)
                {
                    GameWindow.Instance.Lose();
                }
                // reset timer if player is out of range and set creeper back to green.
                else if(wait == 0 && Object.Location.Distance(player) > explosionRadius)
                {
                    GameWindow.Current().Loadedlevel.Objects.Remove(Object);
                    Object.Renderer.Destroy();
                }
                return;
            } 
            
            // x distance y distance from player to object
            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);

            if (player.Distance(Object.Location) > range)
            {
                return;
            }
            
            if (xDistance > yDistance)
            {
                if(player.X > Object.Location.X)
                {
                    Move(new Vector(speed, 0));
                }
                else
                {
                    Move(new Vector(-speed, 0));
                }
            }
            else
            { 
                if (player.Y > Object.Location.Y)
                {
                    Move(new Vector(0, speed));
                }
                else
                {
                    Move(new Vector(0, -speed));
                }  
            }
            // result if not moving/collided
            if (Object.Location.Distance(playerObject.Location) < (explosionRadius/2))
            {
                wait = delayCreeper;
            }
        }
    }
}
