using System.Collections.Generic;
using System.Xml;

namespace KBS1
{
    public class Level
    {
        private string Name { get; }
        
        public Difficulty Difficulty { get; set; }
        public LevelCollider LevelCollider { get; set; }
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
