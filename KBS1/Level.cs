using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KBS1
{
    class Level
    {
        private string Name { get; set; }

        public Difficulty Difficulty { get; set; }
        public Collider LevelCollider { get; set; }
        public SpriteRenderer Renderer { get; set; }
        public List<GameObject> Objects { get; set; }

        public Level(XmlDocument xmlDocument)
        {

        }
    }
}
