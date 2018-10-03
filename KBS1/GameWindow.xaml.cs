using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KBS1 {
    public partial class GameWindow : Window {
        private Button ResumeButton;
        private Rectangle rect;
        private Button QuitToMainMenuButton;

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
        private static GameWindow instance;

        // Methods
        public static GameWindow Current() => instance;

        public void LoadHome()
        {
            Button StartButton = new Button { Content = "Start", Width = 70, Height = 23 };
            StartButton.Background = Brushes.LightBlue;
            Canvas.SetLeft(StartButton, 400 - StartButton.Width/2);
            Canvas.SetTop(StartButton, 300 + StartButton.Height);
            StartButton.Click += new RoutedEventHandler(OnStartButtonClick);

            Button OptionButton = new Button { Content = "Options", Width = 70, Height = 23 };
            OptionButton.Background = Brushes.LightBlue;
            Canvas.SetLeft(OptionButton, 400 - StartButton.Width / 2);
            Canvas.SetTop(OptionButton, 300 + OptionButton.Height + 50);
            OptionButton.Click += new RoutedEventHandler(OnOptionButtonClick);

            Button QuitButton = new Button { Content = "Quit", Width = 70, Height = 23 };
            QuitButton.Background = Brushes.LightBlue;
            Canvas.SetLeft(QuitButton, 400 - StartButton.Width / 2);
            Canvas.SetTop(QuitButton, 300 + QuitButton.Height + 100);
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

        private void OnResumeButtonClick(object sender, RoutedEventArgs e)
        {
            DrawingPanel.Children.Remove(rect);
            DrawingPanel.Children.Remove(ResumeButton);
            DrawingPanel.Children.Remove(QuitToMainMenuButton);
            Loop.Start();
        }

        private void OnQuitButtonClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void QuitToMainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            DrawingPanel.Children.Clear();
            LoadHome();
        }

        public void LoadGame()
        {
            Loop = new Gameloop(this);
            LoadLevel();
            Loop.Start();
        }

        public void LoadLevel()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Levels/TestLevel.xml");
            Loadedlevel = new Level(doc);
        }

        public void LoadOptions()
        {
            Button BackButton = new Button { Content = "Back", Width = 70, Height = 23 };
            BackButton.Background = Brushes.LightBlue;
            Canvas.SetLeft(BackButton, 400 - BackButton.Width / 2);
            Canvas.SetTop(BackButton, 300 - BackButton.Height);
            BackButton.Click += new RoutedEventHandler(OnBackButtonClick);
            DrawingPanel.Children.Add(BackButton);
        }

        public void PauseGame()
        {
            Loop.Stop();
            
            rect = new Rectangle { Name = "rect", Width = 200, Height = 200 };
            rect.Stroke = new SolidColorBrush(Colors.Gray);
            rect.Fill = new SolidColorBrush(Colors.Gray);
            Canvas.SetLeft(rect, 400 - rect.Width / 2);
            Canvas.SetTop(rect, 300 - rect.Height);

            ResumeButton = new Button {Name = "ResumeButton", Content = "Resume", Width = 70, Height = 23 };
            Canvas.SetLeft(ResumeButton, 400 - ResumeButton.Width / 2);
            Canvas.SetTop(ResumeButton, 200 - ResumeButton.Height);
            Canvas.SetZIndex(ResumeButton, 1);
            ResumeButton.Click += new RoutedEventHandler(OnResumeButtonClick);

            QuitToMainMenuButton = new Button { Name = "QuitToMainMenu", Content = "Quit to main menu", Width = 110, Height = 23 };
            Canvas.SetLeft(QuitToMainMenuButton, 400 - QuitToMainMenuButton.Width / 2);
            Canvas.SetTop(QuitToMainMenuButton, 250 - QuitToMainMenuButton.Height);
            Canvas.SetZIndex(QuitToMainMenuButton, 1);
            QuitToMainMenuButton.Click += new RoutedEventHandler(QuitToMainMenuButtonClick);


            DrawingPanel.Children.Add(ResumeButton);
            DrawingPanel.Children.Add(QuitToMainMenuButton);
            DrawingPanel.Children.Add(rect);
            
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
