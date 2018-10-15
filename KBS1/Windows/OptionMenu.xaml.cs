using KBS1.Exceptions.ResourceManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using KBS1.Util;

namespace KBS1.Windows
{
    /// <summary>
    /// Interaction logic for OptionMenu.xaml
    /// </summary>
    public partial class OptionMenu
    {
        public static Key Up = Key.W;
        public static Key Down = Key.S;
        public static Key Left = Key.A;
        public static Key Right = Key.D;
        public static Key Pause = Key.Escape;
        public static Key Retry = Key.R;
        public string Path = "Configuration.xml";

        private readonly SortedDictionary<string, XmlDocument> _xmlCache = new SortedDictionary<string, XmlDocument>();

        public OptionMenu()
        {
            try
            {
                LoadXmlConfiguration(Path);
            }
            catch (FileNotFoundException)
            {
                ResourceExtractor.Extract(Path, Path);
            }

            Initialized += (Sender, args) =>
            {
                TBMoveUp.Text = GetKeyName(Up);
                TBMoveDown.Text = GetKeyName(Down);
                TBMoveLeft.Text = GetKeyName(Left);
                TBMoveRight.Text = GetKeyName(Right);
                TBPause.Text = GetKeyName(Pause);
                TBRetry.Text = GetKeyName(Retry);
            };
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SaveChanges(Up, Down, Left, Right, Pause, Retry, Path);
            GameWindow.Instance.DrawingPanel.Children.Clear();
            GameWindow.Instance.LoadHome();
        }

        private void MoveUpOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBMoveUp.Text = GetKeyName(e.Key);

            Up = e.Key;
        }

        private void MoveDownOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBMoveDown.Text = GetKeyName(e.Key);
            Down = e.Key;
        }

        private void MoveLeftOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBMoveLeft.Text = GetKeyName(e.Key);
            Left = e.Key;
        }

        private void MoveRightOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBMoveRight.Text = GetKeyName(e.Key);
            Right = e.Key;
        }

        private void PauseOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBPause.Text = GetKeyName(e.Key);
            Pause = e.Key;
        }

        private void RetryOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBRetry.Text = GetKeyName(e.Key);
            Pause = e.Key;
        }

        private string GetKeyName(Key k)
        {
            switch (k)
            {
                case Key.Left:
                    return "LEFT";
                case Key.Right:
                    return "RIGHT";
                case Key.Up:
                    return "UP";
                case Key.Down:
                    return "DOWN";
                case Key.Escape:
                    return "ESCAPE";
                case Key.Tab:
                    return "TAB";
                case Key.Space:
                    return "SPACE";
                default:
                    return k.ToString().ToUpper();
            }
        }

        public void LoadXmlConfiguration(string Path)
        {
            var document = new XmlDocument();
            var streamInfo = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + Path;
            if (streamInfo != null) document.Load(streamInfo);
            else throw new ResourceNotFoundException(Path);

            var objectsXml = document.SelectSingleNode("//player/buttons");
            foreach (object child in objectsXml.ChildNodes)
            {
                if (!(child is XmlNode)) continue;
                var childXml = (XmlNode) child;
                if (childXml.LocalName == "MoveUp") Key.TryParse(childXml.Attributes["Key"].InnerText, out Up);
                if (childXml.LocalName == "MoveDown") Key.TryParse(childXml.Attributes["Key"].InnerText, out Down);
                if (childXml.LocalName == "MoveLeft") Key.TryParse(childXml.Attributes["Key"].InnerText, out Left);
                if (childXml.LocalName == "MoveRight") Key.TryParse(childXml.Attributes["Key"].InnerText, out Right);
                if (childXml.LocalName == "Pause") Key.TryParse(childXml.Attributes["Key"].InnerText, out Pause);
                if (childXml.LocalName == "Retry") Key.TryParse(childXml.Attributes["Key"].InnerText, out Retry);
            }
        }

        public void SaveChanges(Key Up, Key Down, Key Left, Key Right, Key Pause, Key Retry, String Path)
        {
            var document = new XmlDocument();
            var streamInfo = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + Path;
            if (streamInfo != null) document.Load(streamInfo);

            var bNodes = document.SelectSingleNode("//player/buttons");

            foreach (XmlNode bNode in bNodes.ChildNodes)
            {
                if (bNode.LocalName == "MoveUp") bNode.Attributes["Key"].Value = Up.ToString();
                if (bNode.LocalName == "MoveDown") bNode.Attributes["Key"].Value = Down.ToString();
                if (bNode.LocalName == "MoveLeft") bNode.Attributes["Key"].Value = Left.ToString();
                if (bNode.LocalName == "MoveRight") bNode.Attributes["Key"].Value = Right.ToString();
                if (bNode.LocalName == "Pause") bNode.Attributes["Key"].Value = Pause.ToString();
                if (bNode.LocalName == "Retry") bNode.Attributes["Key"].Value = Retry.ToString();
            }

            document.Save(streamInfo);
        }

        private void SetToDefault_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation",
                System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                SaveChanges(Key.W, Key.S, Key.A, Key.D, Key.Escape, Key.R, Path);
                GameWindow.Instance.DrawingPanel.Children.Clear();
                GameWindow.Instance.LoadOptions();
            }
        }
    }
}