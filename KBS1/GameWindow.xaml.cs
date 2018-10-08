using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System;
using System.Drawing.Text;

namespace KBS1 {
    public partial class GameWindow : Window {

        private LevelPicker levelPicker = new LevelPicker();

        private Button ResumeButton;
        private Rectangle rect;
        private Button QuitToMainMenuButton;

        public Level Loadedlevel { get; set; }
        public Gameloop Loop { get; set; }
        public static GameWindow Instance { get; private set; }
        
        public GameWindow()
        {
            Initialized += (sender, e) =>
            {
                LoadHome();
            };
            Instance = this;
            InitializeComponent();
        }

        // Properties
        private Button RetryButton;
        private Button MenuLoseButton;
        private Button MenuWinButton;
        private Button NextLevelButton;
        private Rectangle LoseRect;
        private Rectangle WinRect;
        private Label WinLabel;
        private Label LoseLabel;

        // Methods

        public void LoadHome()
        {
            var StartButton = new Button
            {
                Content = "Start", Width = 70, Height = 23, Background = Brushes.LightBlue
            };
            Canvas.SetLeft(StartButton, 400 - StartButton.Width/2);
            Canvas.SetTop(StartButton, 300 + StartButton.Height);
            StartButton.Click += new RoutedEventHandler(OnStartButtonClick);

            var OptionButton = new Button
            {
                Content = "Options", Width = 70, Height = 23, Background = Brushes.LightBlue
            };
            Canvas.SetLeft(OptionButton, 400 - StartButton.Width / 2);
            Canvas.SetTop(OptionButton, 300 + OptionButton.Height + 50);
            OptionButton.Click += new RoutedEventHandler(OnOptionButtonClick);

            var QuitButton = new Button
            {
                Content = "Quit", Width = 70, Height = 23, Background = Brushes.LightBlue
            };
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
            Application.Current.Shutdown();
        }

        private void OnRetryButtonClick(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void OnNextlevelButtonClick(object sender, RoutedEventArgs e)
        {
            DrawingPanel.Children.Clear();
            Loadedlevel = levelPicker.NextLevel();
            //DrawingPanel.Children.Remove(WinRect);
            //DrawingPanel.Children.Remove(WinLabel);
            //DrawingPanel.Children.Remove(MenuWinButton);
            //DrawingPanel.Children.Remove(NextLevelButton);
            Loop.Start();
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
            Loadedlevel = levelPicker.LoadFirstLevel();
        }

        public void LoadOptions()
        {
            var BackButton = new Button
            {
                Content = "Back", Width = 70, Height = 23, Background = Brushes.LightBlue
            };
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
            LoadGame();
        }
        
        public void Win()
        {
            GameWindow.Instance.Loop.Stop();
            //creates a rectangle for when the player wins
            WinRect = new Rectangle() { Width = 500, Height = 400 };
            Canvas.SetLeft(WinRect, 400 - (WinRect.Width / 2));
            Canvas.SetTop(WinRect, 300 - (WinRect.Height / 2));
            WinRect.Stroke = new SolidColorBrush(Colors.Green);
            WinRect.StrokeThickness = 2;
            WinRect.Fill = new SolidColorBrush(Colors.GreenYellow);
            DrawingPanel.Children.Add(WinRect);

            //creates a label for showing win message.
            WinLabel = new Label() { Content = "You won :-)", Width = 140, Height = 50 };
            WinLabel.FontSize = 25;
            Canvas.SetLeft(WinLabel, 400 - (WinLabel.Width / 2));
            Canvas.SetTop(WinLabel, 100);
            DrawingPanel.Children.Add(WinLabel);

            //creates a button to go to main menu.
            MenuWinButton = new Button() { Content = "Main menu", Width = 70, Height = 20 };
            Canvas.SetLeft(MenuWinButton, 400 - (MenuWinButton.Width / 2));
            Canvas.SetTop(MenuWinButton, 200);
            DrawingPanel.Children.Add(MenuWinButton);
            MenuWinButton.Click += new RoutedEventHandler(QuitToMainMenuButtonClick);

            //creates a button to go to next level.
            NextLevelButton = new Button() { Content = "Next level", Width = 70, Height = 20 };
            Canvas.SetLeft(NextLevelButton, 400 - (NextLevelButton.Width / 2));
            Canvas.SetTop(NextLevelButton, 240);
            DrawingPanel.Children.Add(NextLevelButton);
            NextLevelButton.Click += new RoutedEventHandler(OnNextlevelButtonClick);
        }

        public void Lose()
        {
            Reset();
            GameWindow.Instance.Loop.Stop();
            //creates a rectangle for when the player loses.
            LoseRect = new Rectangle() { Width = 500, Height = 400 };
            Canvas.SetLeft(LoseRect, 400 - (LoseRect.Width / 2));
            Canvas.SetTop(LoseRect, 300 - (LoseRect.Height / 2));
            LoseRect.Stroke = new SolidColorBrush(Colors.DarkRed);
            LoseRect.Fill = new SolidColorBrush(Colors.Red);
            LoseRect.StrokeThickness = 2;
            DrawingPanel.Children.Add(LoseRect);

            //creates a label for showing lose message.
            LoseLabel = new Label() { Content = "Game over :-(", Width = 180, Height = 50 };
            LoseLabel.FontSize = 25;
            Canvas.SetLeft(LoseLabel, 400 - (LoseLabel.Width / 2));
            Canvas.SetTop(LoseLabel, 125);
            DrawingPanel.Children.Add(LoseLabel);

            //creates a button so the player can go back to the main menu.
            MenuLoseButton = new Button() { Content = "Main menu", Width = 70, Height = 20 };
            Canvas.SetLeft(MenuLoseButton, 400 - (MenuLoseButton.Width / 2));
            Canvas.SetTop(MenuLoseButton, 200);
            DrawingPanel.Children.Add(MenuLoseButton);
            MenuLoseButton.Click += new RoutedEventHandler(QuitToMainMenuButtonClick);

            //creates a button so the player can start the level again.
            RetryButton = new Button() { Content = "Retry", Width = 70, Height = 20 };
            Canvas.SetLeft(RetryButton, 400 - (RetryButton.Width / 2));
            Canvas.SetTop(RetryButton, 240);
            DrawingPanel.Children.Add(RetryButton);
            RetryButton.Click += new RoutedEventHandler(OnRetryButtonClick);
        }
    }
}
