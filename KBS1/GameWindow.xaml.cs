using System.Windows;
using System.Xml;

namespace KBS1 {
    public partial class GameWindow : Window {

        public GameWindow()
        {
            // Starting the game once this FrameworkElement is initialized
            Initialized += (sender, e) =>
            {
                Loop = new Gameloop(this);
                LoadLevel();
                Loop.Start();

                var controller = (PlayerController)Controller.FindPlayer().Controller;
                KeyDown += controller.KeyPress;
            };

            Instance = this;
            InitializeComponent();
        }


        // Properties

        public Level Loadedlevel { get; set; }
        public Gameloop Loop { get; set; }
        public static GameWindow Instance { get; private set; }


        // Methods

        /// <summary>
        /// Loads the test level
        /// </summary>
        public void LoadLevel()
        {
            XmlDocument doc = ResourceManager.Instance.LoadXmlDocument("Levels/TestLevel.xml");
            Loadedlevel = new Level(doc);
        }

        /// <summary>
        /// Restarts the game loop and resets the level
        /// </summary>
        public void Reset()
        {
            Loop.Stop();
            DrawingPanel.Children.Clear();
            LoadLevel();
            Loop.Start();
        }

    }
}
