using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    public class TrapObstacleController : ObstacleController
    {
        public TrapObstacleController(ILocatable locatable, Obstacle obstacle) : base(locatable, obstacle)
        {
        }

        public override void Update()
        {
            //Info speler opvragen
            var playerObject = FindPlayer();
            var player = playerObject.Location;

            //Colliden met speler
            if (Object.Collider.Collides(playerObject.Collider))
            {
                GameWindow.Current().Reset();
            }
        }
    }
}
