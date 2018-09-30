using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    class ObstacleController : Controller
    {
        public ObstacleController(ILocatable locatable) : base(locatable) { }

        public Obstacle Obstacle { get; set; }

        public void Update()
        {

        }
    }
}
