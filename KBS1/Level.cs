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

        /// <summary>
        /// xmlDocument loading the gamelevel field difficulty, objects, renderer and name. 
        /// </summary>
        /// <param name="xmlDocument">xml document for loading gamelevel</param>
        public Level(XmlDocument xmlDocument)
        {

        }
    }
}
