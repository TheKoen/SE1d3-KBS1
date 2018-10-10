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
        private const int range = 150;
        private const int explosionRadius = 100;
        private const int delayCreeper = 100;
        private int wait = 0;
        private Boolean red = false;
        private Image imageRed = ResourceManager.Instance.LoadImage("creeper_red.png");
        private Image imageGreen = ResourceManager.Instance.LoadImage("creeper.png");

        public CreeperObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }

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
            if (wait > 0)
            {
                wait--;

                
                if (wait % 5 == 0)
                {
                    // color chancing creeper if in range 
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
                    //GameWindow.Instance.Sounds.Play();
                    GameWindow.Instance.Lose();
                }
                // if player is out of range and creeper is out of time destroy creeper
                else if(wait == 0 && Object.Location.Distance(player) > explosionRadius)
                {
                    GameWindow.Instance.Loadedlevel.Objects.Remove(Object);
                    GameWindow.Instance.Sounds.Play("Boom.mp3"); 
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
            // start the delay of the explostion if the distance of the player is explosionRadius/2.
            if (Object.Location.Distance(playerObject.Location) < (explosionRadius/2))
            {
                wait = delayCreeper;
                GameWindow.Instance.Sounds.Play("Ignite.mp3");
            }
        }
    }
}
