using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1
{
    class ObstacleType
    {
        public List<ObstacleType> Types { get; set; }
        public IControllerCreator Creator { get; set; }

        public ObstacleInfo createController()
        {
            // please fix
            return null;
        }

    }
}
