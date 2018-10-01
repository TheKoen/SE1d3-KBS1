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
            if (wait-- > 0) return;

            wait = 1;

            // Get information from Player
            var playerObject = FindPlayer();
            var player = playerObject.Location;
            // TODO: Translate this please
            // Move, eerst langste X of Y en die richting beweging
            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);
            
            if(xDistance > yDistance)
            {
                if(player.X < Object.Location.X)
                    Move(new Vector(-SPEED, 0));
                else
                    Move(new Vector(SPEED, 0));
            }
            else
            {
                if (player.Y < Object.Location.Y)
                    Move(new Vector(0, -SPEED));
                else
                    Move(new Vector(0, SPEED));
            }
            // Collide with Player
            /*if (Object.Collider.Collides(playerObject.Collider))
            {
                GameWindow.Instance.Reset();
            }*/
            // Constrain zone
        }
    }
}
