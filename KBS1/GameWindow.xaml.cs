using System.Windows;
using System.Xml;
using System.Windows.Media;

namespace KBS1 {
    public partial class GameWindow : Window {

        //Constructor
        public GameWindow()
        {
            Initialized += (sender, e) =>
            {
                LoadHome();
            };
            instance = this;
            InitializeComponent();
        }


        // Properties

        public Level Loadedlevel { get; set; }
        public Gameloop Loop { get; set; }
        public static GameWindow Instance { get; private set; }


        // Methods

        public void LoadHome()
        {
            Button StartButton = new Button { Content = "Start", Width = 70, Height = 23 };
            StartButton.Background = Brushes.LightBlue;
            Canvas.SetLeft(StartButton, 400 - StartButton.Width/2);
            Canvas.SetTop(StartButton, 300 - StartButton.Height);
            StartButton.Click += new RoutedEventHandler(OnStartButtonClick);

            Button OptionButton = new Button { Content = "Options", Width = 70, Height = 23 };
            OptionButton.Background = Brushes.LightBlue;
            Canvas.SetLeft(OptionButton, 400 - StartButton.Width / 2);
            Canvas.SetTop(OptionButton, 300 - OptionButton.Height - 100);
            OptionButton.Click += new RoutedEventHandler(OnOptionButtonClick);

            Button QuitButton = new Button { Content = "Quit", Width = 70, Height = 23 };
            QuitButton.Background = Brushes.LightBlue;
            Canvas.SetLeft(QuitButton, 400 - StartButton.Width / 2);
            Canvas.SetTop(QuitButton, 300 - QuitButton.Height - 200);
            QuitButton.Click += new RoutedEventHandler(OnQuitButtonClick);

            DrawingPanel.Children.Add(StartButton);
            DrawingPanel.Children.Add(OptionButton);
            DrawingPanel.Children.Add(QuitButton);
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            DrawingPanel.Children.Clear();
            LoadGame();
        }

        private void OnOptionButtonClick(object sender, RoutedEventArgs e)
        {
            DrawingPanel.Children.Clear();
            LoadOptions();
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            DrawingPanel.Children.Clear();
            LoadHome();
        }

        private void OnQuitButtonClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void LoadGame()
        {
            Loop = new Gameloop(this);
            LoadLevel();
            Loop.Start();
        }

        public void LoadLevel()
        {
            XmlDocument doc = ResourceManager.Instance.LoadXmlDocument("Levels/TestLevel.xml");
            Loadedlevel = new Level(doc);
        }

        public void LoadOptions()
        {
            var BackButton = new Button { Content = "Back", Width = 70, Height = 23 };
            BackButton.Background = Brushes.LightBlue;
            Canvas.SetLeft(BackButton, 400 - BackButton.Width / 2);
            Canvas.SetTop(BackButton, 300 - BackButton.Height);
            BackButton.Click += new RoutedEventHandler(OnBackButtonClick);
            DrawingPanel.Children.Add(BackButton);
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
