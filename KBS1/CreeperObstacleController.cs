using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    public class CreeperObstacleController : ObstacleController
    {
        private int speed = 1;

        public CreeperObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }

        public override void Update()
        {
            // player object
            var playerObject = FindPlayer();

            // player location
            var player = playerObject.Location;

            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);
            
            

            if (xDistance > yDistance)
            {
                if(xDistance < 0)
                {
                    Move(new Vector(speed, 0));
                }
                else
                {
                    Move(new Vector(-speed, 0));
                }
            }
            if(xDistance < yDistance)
            {
                if (yDistance < 0)
                {
                    Move(new Vector(0, speed));
                }
                else
                {
                    Move(new Vector(0, -speed));
                }  
            }
        }
    }
}
