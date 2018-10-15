using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using KBS1.Collider;
using KBS1.GameObjects;
using KBS1.Misc;
using KBS1.Obstacles;
using KBS1.Util;
using KBS1.Windows;

namespace KBS1.LevelComponents
{ 

    public class Level
    {
        private Brush Background { get; }
        private static double DescriptionHeight { get; set; }
        private List<string> MadeObjects { get; set; } = new List<string>();

        public bool IsAlreadySubmitted;
        public string Name { get; }
        public Difficulty Difficulty { get; set; }
        public LevelCollider LevelCollider { get; set; }
        public List<GameObject> Objects { get; set; }
        public ScoreTracker Score { get; }
        private Label Scorelabel { get; }

        private static readonly Random Rand = new Random();

        public event EventHandler Initialized; 
        /// <summary>
        /// Uses an XmlDocument to load a level and it's properties
        /// </summary>
        /// <param name="xmlDocument">XML document containing a level</param>
        public Level(XmlDocument xmlDocument)
        {
            GameWindow.Instance.DrawingPanel.Background = Brushes.DimGray;

            Objects = new List<GameObject>();
//            ObstacleType.Init();
            LevelCollider = new LevelCollider();
            Score = new ScoreTracker();
            DescriptionHeight = 0;

            var root = xmlDocument.DocumentElement;
            if (root == null) throw new XmlException("Missing root node");

            if (!root.HasAttribute("name"))
                throw new XmlException("Level missing name attribute");
            Name = root.GetAttribute("name");

            if (!root.HasAttribute("background"))
                Background = Brushes.DimGray;
            else
                Background = ResourceManager.Instance.LoadImageBrush(root.GetAttribute("background"));

            var objectsXml = xmlDocument.SelectSingleNode("//level/objects");
            if (objectsXml == null)
                throw new XmlException("Level missing objects node");
            // Parsing objects
            foreach (object child in objectsXml.ChildNodes)
            {
                if (!(child is XmlNode)) continue;
                var childXml = (XmlNode) child;
                if (childXml.LocalName == "start") CreateStartPoint(childXml);
                if (childXml.LocalName == "end") CreateEndPoint(childXml);
                if (childXml.LocalName == "obstacle") CreateObstacle(childXml);
            }

            // Setting level background
            GameWindow.Instance.DrawingPanel.Background = Background;

            // Label for showing score
            Scorelabel = new Label();
            Canvas.SetTop(Scorelabel, 10);
            Canvas.SetLeft(Scorelabel, 730);
            GameWindow.Instance.DrawingPanel.Children.Add(Scorelabel);

            //checking where start location is so the player can spawn at the start location
            foreach (object child in objectsXml.ChildNodes)
            {
                if (!(child is XmlNode)) continue;
                XmlNode childXml = (XmlNode) child;
                if (childXml.LocalName == "start")
                {
                    var location = ParseLocation(childXml.Attributes["location"].InnerText);
                    Objects.Add(new Player.Player(11, ResourceManager.Instance.LoadImage("#player.png"),
                        GameWindow.Instance.DrawingPanel, new Vector(location.X, location.Y)));
                }
            }

            var border = new Border
            {
                Height = 600,
                Width = 5,
                BorderThickness = new System.Windows.Thickness(5),
                BorderBrush = new SolidColorBrush(Colors.Black)
            };
            Canvas.SetLeft(border, 782);
            GameWindow.Instance.DrawingPanel.Children.Add(border);
        }


        /// <summary>
        /// FOR UNIT TESTING ONLY!
        /// Creates an empty Level.
        /// </summary>
        public Level()
        {
        }

        public void SubscribeInitialized(EventHandler source)
        {
            Initialized += source;
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
            var image = ResourceManager.Instance.LoadImage("#start.png");
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
            var image = ResourceManager.Instance.LoadImage("#end.png");
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
            Objects.Add(new Obstacle(type, GameWindow.Instance.DrawingPanel, location));

            var name = type.Sprite.Name;
            var image = type.Sprite.Source;
            if (name == "tree" || name == "wall") return;
            if (MadeObjects.Contains(name)) return;
            MadeObjects.Add(name);
            CreateDescription(name, image);
        }

        /// <summary>
        /// Creates a description
        /// </summary>
        /// <param name="name">String containing name</param>
        /// <param name="source">ImageSource containing the source of an image</param>
        private static void CreateDescription(string name, ImageSource source)
        {
            var obstacleInfo = new ObstacleInfo(name);
            var infoContainer = new ObjectInfoContainer
            {
                ImageSource = source,
                GameObjectName = name,
                GameObjectDescription = obstacleInfo.Description
            };

            Canvas.SetRight(infoContainer, 0);
            Canvas.SetTop(infoContainer, DescriptionHeight);

            GameWindow.Instance.DrawingPanel.Children.Add(infoContainer);
            DescriptionHeight = DescriptionHeight + 140;
        }

        /// <summary>
        /// Parses location strings used in levels
        /// </summary>
        /// <param name="locationString">String containing a parsable location</param>
        /// <returns>Vector created using the parsable location</returns>
        public static Vector ParseLocation(string locationString)
        {
            if (locationString.Equals("random"))
            {
                return new Vector(Rand.Next(1, 700), Rand.Next(1, 500));
            }

            var split = locationString.Split(',');
            return new Vector(int.Parse(split[0]), int.Parse(split[1]));
        }

        public void UpdateScore()
        {
            Scorelabel.Content = Score.SecondsRunning;
        }
    }
}