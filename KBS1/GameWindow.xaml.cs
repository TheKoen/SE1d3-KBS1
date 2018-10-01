using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace KBS1 {
    public partial class GameWindow : Window {
        public GameWindow()
        {
            instance = this;
            InitializeComponent();
            
            Loop = new Gameloop(this);
            LoadLevel();
            Loop.Start();
        }

        
        /// <summary>
        /// Properties
        /// </summary>
        public Level Loadedlevel { get; set; }
        public Gameloop Loop { get; set; }
        private static GameWindow instance;

        /// <summary>
        /// Methods
        /// </summary>
        public static GameWindow Current()
        {
            return instance;
        }
        
        public void LoadLevel()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Level.xml");
            Loadedlevel = new Level(doc);
        }

        public void Reset()
        {
            Loop.Stop();
            DrawingPanel.Children.Clear();
            LoadLevel();
            Loop.Start();
        }
    }
}
