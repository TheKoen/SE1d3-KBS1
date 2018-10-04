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
        private const int RANGE = 300;

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

            // Kijken of de speler in range is
            if (player.Distance(Object.Location) > RANGE)
            {
                return;
            }

            // Move, eerst langste X of Y en die richting beweging
            var xDistance = player.AxisDistance(Object.Location, true);
            var yDistance = player.AxisDistance(Object.Location, false);

            var result  = xDistance > yDistance ? Move(player.X < Object.Location.X ? new Vector(-SPEED, 0) : new Vector(SPEED, 0)) : Move(player.Y < Object.Location.Y ? new Vector(0, -SPEED) : new Vector(0, SPEED));
            
            // Colliden met speler -> reset
            if (result == false)
            {
                GameWindow.Current().Lose();
            }
        }
    }
}
