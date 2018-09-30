using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    abstract class Obstacle : GameObject
    {
        public Type ObstacleType { get; private set; }

        protected Obstacle(Type type)
        {
            ObstacleType = type;
        }
        



    }
}
