using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    public class RunnerObstacleController : ObstacleController
    {
        public RunnerObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle) { }
        public override void Update()
        {
            // Info speler opvragen
            var playerObject = FindPlayer();
            var player = playerObject.Location;
            // Move, eerst langste X of Y en die richting beweging
            var xDistance = player.AxisDistance(Locatable.Location, true);
            var yDistance = player.AxisDistance(Locatable.Location, false);
            
            if(xDistance > yDistance)
            {
                if(player.X < Locatable.Location.X)
                {
                    Move(new Vector(-1, 0));
                } else
                {
                    Move(new Vector(1, 0));
                }
            }
            else
            {
                if (player.Y < Locatable.Location.Y)
                {
                    Move(new Vector(0, -1));
                }
                else
                {
                    Move(new Vector(0, 1));
                }
            }
            // Colliden met speler
            if (Object.Collider.Collides(playerObject.Collider))
            {
                GameWindow.Current().Reset();
            }
            // Constrain zone
        }
    }
}
