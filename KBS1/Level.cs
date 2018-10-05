using System;
using System.Collections.Generic;
using System.Windows.Controls;
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
        public ScoreTracker score { get; set; }
        public Label scorelabel;

        /// <summary>
        /// Uses an XmlDocument to load a level and it's properties
        /// </summary>
        /// <param name="xmlDocument">XML document containing a level</param>
        public Level(XmlDocument xmlDocument)
        {
            Objects = new List<GameObject>();
            ObstacleType.Init();
            LevelCollider = new LevelCollider();
            score = new ScoreTracker(this);

            var root = xmlDocument.DocumentElement;

            if (!root.HasAttribute("name"))
                throw new XmlException("Level missing name attribute");
            Name = root.GetAttribute("name");
            
            var objectsXml = xmlDocument.SelectSingleNode("//level/objects");
            if (objectsXml == null)
                throw new XmlException("Level missing objects node");
            // Parsing objects
            foreach (object child in objectsXml.ChildNodes)
            {
                if (!(child is XmlNode)) continue;
                XmlNode childXml = (XmlNode)child;
                if (childXml.LocalName == "start") CreateStartPoint(childXml);
                if (childXml.LocalName == "end") CreateEndPoint(childXml);
                if (childXml.LocalName == "obstacle") CreateObstacle(childXml);
            }

            //label for showing score
            scorelabel = new Label();
            Canvas.SetTop(scorelabel, 10);
            Canvas.SetLeft(scorelabel, 730);
            GameWindow.Instance.DrawingPanel.Children.Add(scorelabel);

            Objects.Add(new Player(11, ResourceManager.Instance.LoadImage("player.png"),
                GameWindow.Instance.DrawingPanel, new Vector(14, 14)));
        }

        /// <summary>
        /// Creates a start point in the level
        /// </summary>
        /// <param name="node">XML node representing the start point</param>
        private void CreateStartPoint(XmlNode node)
        {
            if (node.Attributes == null)
                throw new XmlException("StartPoint node doesn't have any attributes");

            var radius = int.Parse(node.Attributes["radius"].InnerText);
            var image = ResourceManager.Instance.LoadImage("start.png");
            var location = ParseLocation(node.Attributes["location"].InnerText);

            Objects.Add(new FinishObject(radius, image, GameWindow.Instance.DrawingPanel, location, false));
        }

        /// <summary>
        /// Creates an end point in the level
        /// </summary>
        /// <param name="node">XML node representing the end point</param>
        private void CreateEndPoint(XmlNode node)
        {
            if (node.Attributes == null)
                throw new XmlException("StartPoint node doesn't have any attributes");

            var radius = int.Parse(node.Attributes["radius"].InnerText);
            var image = ResourceManager.Instance.LoadImage("end.png");
            var location = ParseLocation(node.Attributes["location"].InnerText);

            Objects.Add(new FinishObject(radius, image, GameWindow.Instance.DrawingPanel, location, true));
        }

        /// <summary>
        /// Creates an obstacle in the level
        /// </summary>
        /// <param name="node">XML node representing the obstacle</param>
        private void CreateObstacle(XmlNode node)
        {
            if (node.Attributes == null)
                throw new XmlException("StartPoint node doesn't have any attributes");

            var type = ObstacleType.Find(node.Attributes["name"].InnerText);
            var location = ParseLocation(node.Attributes["location"].InnerText);
            // Bij elk object een Description aanmaken
            // Displayen op Speelveld (Rechts)
            // Checken als Description al bestaat 
            // Y opslaan in Attribuut ++50?:
            // Valkuilen en muren en bomen? 
            Objects.Add(new Obstacle(type, GameWindow.Instance.DrawingPanel, location));
        }

        

        /// <summary>
        /// Parses location strings used in levels
        /// </summary>
        /// <param name="locationString">String containing a parsable location</param>
        /// <returns>Vector created using the parsable location</returns>
        private static Vector ParseLocation(string locationString)
        {
            if (locationString.Equals("random"))
            {
                var rand = new Random();
                return new Vector(rand.Next(1, 700), rand.Next(1, 500));
            }
            var split = locationString.Split(',');
            return new Vector(int.Parse(split[0]), int.Parse(split[1]));
        }

        public void UpdateScore(double s)
        {
            scorelabel.Content = score.SecondsRunning;
        }
    }
}
