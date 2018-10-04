using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.Archer
{
    public class ArrowObstacleController : ObstacleController
    {
        private readonly Vector direction;

        private int lifetime = 500;

        public ArrowObstacleController(ILocatable locatable, Obstacle obstacle, Vector direction) : base(locatable, obstacle)
        {
            this.Object.Collider.Blocking = false;
            this.direction = direction;
        }

        public override void Update()
        {
            if (lifetime > 0)
            {
                lifetime--;
            }
            else
            {
                GameWindow.Current().Loadedlevel.Objects.Remove(Object);
                Object.Renderer.Destroy();
            }

            var player = FindPlayer();

            Move(direction);
            
            if (Object.Collider.Collides(player.Collider))
            {
                GameWindow.Current().Lose();
            }
        }
    }
}
