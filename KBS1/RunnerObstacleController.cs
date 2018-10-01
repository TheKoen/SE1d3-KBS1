using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    public class RunnerObstacleController : ObstacleController
    {
        private const int SPEED = 2;
        private int wait = 0;

        public RunnerObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }

        public override void Update()
        {
            if (wait > 0)
            {
                wait--;
                return;
            }

            wait = 1;

            // Info speler opvragen
            var playerObject = FindPlayer();
            var player = playerObject.Location;
            // Move, eerst langste X of Y en die richting beweging
            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);
            
            if(xDistance > yDistance)
            {
                if(player.X < Object.Location.X)
                {
                    Move(new Vector(-SPEED, 0));
                } else
                {
                    Move(new Vector(SPEED, 0));
                }
            }
            else
            {
                if (player.Y < Object.Location.Y)
                {
                    Move(new Vector(0, -SPEED));
                }
                else
                {
                    Move(new Vector(0, SPEED));
                }
            }
            // Colliden met speler
            /*if (Object.Collider.Collides(playerObject.Collider))
            {
                GameWindow.Current().Reset();
            }*/
            // Constrain zone
        }
    }
}
