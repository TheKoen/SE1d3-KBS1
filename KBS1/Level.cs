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
            var root = xmlDocument.DocumentElement;

            if (!root.HasAttribute("name")) throw new XmlException("Level missing name attribute");
            Name = root.GetAttribute("name");
            
            var objectsXml = xmlDocument.SelectSingleNode("//level/objects");
            if (objectsXml == null) throw new XmlException("Level missing objects node");
            // Parsing objects
            foreach (var child in objectsXml.ChildNodes)
            {
                if (!(child is XmlNode)) continue;
                XmlNode childXml = (XmlNode)child;
                if (childXml.LocalName == "start") CreateStartPoint(childXml);
                if (childXml.LocalName == "end") CreateEndPoint(childXml);
                if (childXml.LocalName == "obstacle") CreateObstacle(childXml);
            }
        }

        private void CreateStartPoint(XmlNode node)
        {
            // TODO: Create StartPoint object
        }

        private void CreateEndPoint(XmlNode node)
        {
            // TODO: Create EndPoint object
        }

        private void CreateObstacle(XmlNode node)
        {
            // TODO: Create Obstacle object
        }
    }
}
