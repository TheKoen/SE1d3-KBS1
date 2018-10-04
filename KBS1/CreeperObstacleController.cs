using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KBS1
{
    public class CreeperObstacleController : ObstacleController
    {
        private int speed = 1;
        private int range = 300;
        private int explosionRadius = 100;
        private int delayCreeper = 100;
        private int wait = 0;
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
                if (wait == 0 && Object.Location.Distance(player) < explosionRadius)
                {
                    GameWindow.Current().Reset();
                }
                return;
            } 
            

            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);

            if (player.Distance(Object.Location) > range)
            {
                return;
            }

            var result = false;
            if (xDistance > yDistance)
            {
                if(player.X > Object.Location.X)
                {
                    result = Move(new Vector(speed, 0));
                }
                else
                {
                    result = Move(new Vector(-speed, 0));
                }
            }
            else
            { 
                if (player.Y > Object.Location.Y)
                {
                    result = Move(new Vector(0, speed));
                }
                else
                {
                    result = Move(new Vector(0, -speed));
                }  
            }
            // result if not moving/collided
            if(Object.Collider.Collides(playerObject.Collider))
            {
                wait = delayCreeper;
                

            }
            

        }
    }
}
