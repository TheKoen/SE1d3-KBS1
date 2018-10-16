using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using KBS1.LevelComponents;
using KBS1.Misc;
using KBS1.Obstacles;
using KBS1.Util;
using Vector = KBS1.Misc.Vector;

namespace KBS1.Windows
{
    public partial class LevelEditor : Window
    {
        private const string XmlRootTemplate =
            @"<?xml version=""1.0"" encoding=""utf-8""?>

<level name=""{0}"" {1}>

    <objects>
        <start radius=""17"" location=""{2:d}, {3:d}"" />
        <end radius=""17"" location=""{4:d}, {5:d}"" />
        
{6}
    </objects>

</level>";

        private const string XmlObstacleTemplate =
            @"        <obstacle name=""{0}"" radius=""24"" location=""{1:d}, {2:d}"" />
";

        private readonly List<ObjectListItem> _objectList = new List<ObjectListItem>
        {
            new ObjectListItem("WallObstacle", "Wall", "#wall.png"),
            new ObjectListItem("start", "Start", "#start.png"),
            new ObjectListItem("end", "Finish", "#end.png"),
            new ObjectListItem("TreeObstacle", "Tree", "#tree.png"),
            new ObjectListItem("RunnerObstacle", "Runner", "#runner.png"),
            new ObjectListItem("CreeperObstacle", "Bomb", "#bomb.png"),
            new ObjectListItem("ArcherObstacle", "Turret", "#turret.png"),
            new ObjectListItem("TrapObstacle", "Trap", "#trap.png")
        };

        private readonly List<EditorObjectRepresentation> _editorObjects = new List<EditorObjectRepresentation>();

        private bool _changesMade = false;
        private string _background = null;
        private Vector _startLoc = null;
        private Vector _endLoc = null;

        public LevelEditor()
        {
            InitializeComponent();
            ComboBoxObjects.ItemsSource = _objectList;
            ComboBoxObjects.SelectedIndex = 0;

            Loaded += (sender, e) => DrawGrid();
            NumericGridHeight.ValueChanged += (source, args) => DrawGrid();
            NumericGridWidth.ValueChanged += (source, args) => DrawGrid();
        }


        private void DrawGrid()
        {
            EditorCanvasGrid.Children.Clear();

            var width = NumericGridWidth.Value;
            var height = NumericGridHeight.Value;
            var columns = (int) Math.Floor(EditorCanvas.ActualWidth / width);
            var rows = (int) Math.Floor(EditorCanvas.ActualHeight / height);

            for (var y = 0; y < rows; ++y)
            {
                for (var x = 0; x < columns; ++x)
                {
                    var rect = new Rectangle();
                    rect.Width = width;
                    rect.Height = height;
                    rect.Stroke = new SolidColorBrush(Colors.Gray);
                    rect.StrokeThickness = 1;
                    Canvas.SetTop(rect, y * height);
                    Canvas.SetLeft(rect, x * width);
                    EditorCanvasGrid.Children.Add(rect);
                }
            }
        }

        private void DrawObjects()
        {
            EditorCanvasObjects.Children.Clear();

            foreach (var o in _editorObjects)
            {
                var reslocation = (from i in _objectList
                        where i.Id == o.Id
                        select i.Img)
                    .First();
                var image = new Image {Source = new BitmapImage(reslocation)};
                Canvas.SetTop(image, o.Location.Y - image.Source.Height / 2.0);
                Canvas.SetLeft(image, o.Location.X - image.Source.Width / 2.0);
                EditorCanvasObjects.Children.Add(image);
            }
        }

        private void ParseLevel(XmlDocument doc)
        {
            var root = doc.DocumentElement;
            if (root == null) throw new XmlException("Missing root node");

            if (!root.HasAttribute("name"))
                throw new XmlException("Level missing name attribute");
            TextBoxLevelName.Text =
                (root.GetAttribute("name").StartsWith("custom_") ? "" : "custom_") + root.GetAttribute("name");

            if (!root.HasAttribute("background"))
            {
                EditorCanvas.Background = Brushes.DimGray;
                _background = null;
            }
            else
            {
                EditorCanvas.Background = ResourceManager.Instance.LoadImageBrush(root.GetAttribute("background"));
                _background = root.GetAttribute("background");
            }

            var objectsXml = doc.SelectSingleNode("//level/objects");
            if (objectsXml == null)
                throw new XmlException("Level missing objects node");
            _startLoc = null;
            _endLoc = null;
            // Parsing objects
            foreach (object child in objectsXml.ChildNodes)
            {
                if (!(child is XmlNode)) continue;
                var childXml = (XmlNode) child;

                if (childXml.LocalName == "start")
                    _startLoc = Level.ParseLocation(childXml.Attributes["location"].InnerText);
                if (childXml.LocalName == "end")
                    _endLoc = Level.ParseLocation(childXml.Attributes["location"].InnerText);

                _editorObjects.Add(new EditorObjectRepresentation(
                    Level.ParseLocation(childXml.Attributes["location"].InnerText),
                    childXml.LocalName == "start" || childXml.LocalName == "end"
                        ? childXml.LocalName
                        : childXml.Attributes["name"].InnerText
                ));
            }

            _changesMade = false;
            
            DrawObjects();
        }


        private void ButtonNewLevel_OnClick(object sender, RoutedEventArgs e)
        {
            if (_changesMade)
            {
                var result = MessageBox.Show("Are you sure you want to discard this level?", "New Level",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning, MessageBoxResult.No);
                if (result == MessageBoxResult.No) return;
            }

            _editorObjects.Clear();
            EditorCanvas.Background = new SolidColorBrush(Colors.DimGray);
            _changesMade = false;
            _background = null;
            _startLoc = null;
            _endLoc = null;
            TextBoxLevelName.Text = "";
            DrawObjects();
        }

        private void ButtonSaveLevel_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxLevelName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a level name", "Save", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_startLoc == null)
            {
                MessageBox.Show("Please create a start object", "Save", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_endLoc == null)
            {
                MessageBox.Show("Please create an end object", "Save", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TextBoxLevelName.Text.Trim().StartsWith("custom_"))
                TextBoxLevelName.Text = "custom_" + TextBoxLevelName.Text.Trim();
            var fileName = TextBoxLevelName.Text.ToLower().Replace(" ", "_") + ".xml";
            if (File.Exists($"levels\\{fileName}"))
            {
                var result = MessageBox.Show($"File \"{fileName}\" already exists! Do you want to replace it?", "Save",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result != MessageBoxResult.Yes) return;
            }

            var obstacles = from o in _editorObjects
                where o.Id != "start" && o.Id != "end"
                select o;
            var obstaclesString = "";
            obstacles.ToList()
                .ForEach(o =>
                    obstaclesString +=
                        string.Format(XmlObstacleTemplate, o.Id, (int) o.Location.X, (int) o.Location.Y));

            var root = string.Format(XmlRootTemplate,
                TextBoxLevelName.Text.StartsWith("custom_")
                    ? TextBoxLevelName.Text
                    : "custom_" + TextBoxLevelName.Text,
                _background == null ? "" : $"background=\"{_background}\"",
                (int) _startLoc.X, (int) _startLoc.Y,
                (int) _endLoc.X, (int) _endLoc.Y,
                obstaclesString);
            if (!Directory.Exists("levels"))
                Directory.CreateDirectory("levels");
            var writer = File.CreateText($"levels\\{fileName}");
            writer.Write(root);
            writer.Flush();
            writer.Close();

            _changesMade = false;

            MessageBox.Show($"Level saved as \"levels\\{fileName}\"", "Save", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void ButtonLoadLevel_OnClick(object sender, RoutedEventArgs e)
        {
            if (_changesMade)
            {
                var result = MessageBox.Show("Are you sure you want to discard this level?", "New Level",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning, MessageBoxResult.No);
                if (result == MessageBoxResult.No) return;
            }

            _editorObjects.Clear();

            var levelPicker = new LevelPicker();
            XmlDocument level;
            try
            {
                level = levelPicker.PickDocument();
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ParseLevel(level);
        }

        private void EditorCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(EditorCanvasObjects);
            var vector = new Vector(Math.Round(pos.X), Math.Round(pos.Y));

            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    if (_startLoc != null && ((ObjectListItem) ComboBoxObjects.SelectedItem).Id == "start") return;
                    if (_endLoc != null && ((ObjectListItem) ComboBoxObjects.SelectedItem).Id == "end") return;
                    if (CheckBoxEnforceGrid.IsChecked ?? false)
                        vector = new Vector(
                            (int) (vector.X / NumericGridWidth.Value) * NumericGridWidth.Value +
                            NumericGridWidth.Value / 2.0,
                            (int) (vector.Y / NumericGridHeight.Value) * NumericGridHeight.Value +
                            NumericGridHeight.Value / 2.0);
                    _editorObjects.Add(new EditorObjectRepresentation(
                        vector,
                        ((ObjectListItem) ComboBoxObjects.SelectedItem).Id
                    ));
                    if (((ObjectListItem) ComboBoxObjects.SelectedItem).Id == "start")
                        _startLoc = vector;
                    if (((ObjectListItem) ComboBoxObjects.SelectedItem).Id == "end")
                        _endLoc = vector;
                    _changesMade = true;
                    break;

                case MouseButton.Right:
                    EditorObjectRepresentation removable = null;
                    foreach (var o in _editorObjects)
                    {
                        var oImage = (from i in _objectList
                            where i.Id == o.Id
                            select i.ImageBrush).First().ImageSource;
                        var loc = new Vector(o.Location.X - oImage.Width / 2.0, o.Location.Y - oImage.Height / 2.0);
                        var loc2 = new Vector(loc.X + oImage.Width, loc.Y + oImage.Height);
                        if (vector.X >= loc.X && vector.X < loc2.X &&
                            vector.Y >= loc.Y && vector.Y < loc2.Y)
                            removable = o;
                    }

                    if (removable != null)
                    {
                        if (removable.Id == "start")
                            _startLoc = null;
                        if (removable.Id == "end")
                            _endLoc = null;
                        _editorObjects.Remove(removable);
                    }

                    _changesMade = true;
                    break;
            }

            DrawObjects();
        }

        private void ButtonSetBackground_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxBackground.Text == "")
            {
                EditorCanvas.Background = new SolidColorBrush(Colors.DimGray);
                _background = null;
                _changesMade = true;
                return;
            }
            
            try
            {
                EditorCanvas.Background = ResourceManager.Instance.LoadImageBrush(TextBoxBackground.Text.Trim());
                _background = TextBoxBackground.Text.Trim();
                _changesMade = true;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"The background \"{TextBoxBackground.Text.Trim()}\" can not be found",
                    "Background", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private class ObjectListItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string ImgUri { get; set; }
            public Uri Img { get; set; }
            public ImageBrush ImageBrush { get; private set; }

            public ObjectListItem(string id, string name, string img)
            {
                Id = id;
                Name = name;
                ImageBrush = ResourceManager.Instance.LoadImageBrush(img);
                Img = ((BitmapImage) ImageBrush.ImageSource).UriSource;
                ImgUri = img;
            }
        }
    }
}