using System.Collections.Generic;
using System.Xml;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            Objects = new List<GameObject>();
            ObstacleType.Init();

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

            Objects.Add(new Player(11, LoadImage("player.png"), GameWindow.Current().DrawingPanel, new Vector(10, 10)));
        }

        private void CreateStartPoint(XmlNode node)
        {
            if (node.Attributes == null)
            {
                throw new XmlException("StartPoint node doesn't have any attributes");
            }

            var radius = int.Parse(node.Attributes["radius"].InnerText);
            var image = LoadImage("start.png");
            var location = ParseLocation(node.Attributes["location"].InnerText);

            Objects.Add(new FinishObject(radius, image, GameWindow.Current().DrawingPanel, location, false));
        }

        private void CreateEndPoint(XmlNode node)
        {
            if (node.Attributes == null)
            {
                throw new XmlException("StartPoint node doesn't have any attributes");
            }

            var radius = int.Parse(node.Attributes["radius"].InnerText);
            var image = LoadImage("end.png");
            var location = ParseLocation(node.Attributes["location"].InnerText);

            Objects.Add(new FinishObject(radius, image, GameWindow.Current().DrawingPanel, location, true));
        }

        private void CreateObstacle(XmlNode node)
        {
            if (node.Attributes == null)
            {
                throw new XmlException("StartPoint node doesn't have any attributes");
            }

            var type = ObstacleType.Find(node.Attributes["name"].InnerText);
            var location = ParseLocation(node.Attributes["location"].InnerText);

            Objects.Add(new Obstacle(type, GameWindow.Current().DrawingPanel, location));
        }

        public static Image LoadImage(string path)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(path, UriKind.Relative);
            bitmapImage.EndInit();
            var image = new Image
            {
                Width = bitmapImage.Width,
                Height = bitmapImage.Height,
                Name = path.Split('.')[0],
                Source = bitmapImage
            };
            return image;
        }

        private static Vector ParseLocation(string locationString)
        {
            var split = locationString.Split(',');
            return new Vector(int.Parse(split[0]), int.Parse(split[1]));
        }
    }
}
