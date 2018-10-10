using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System;

namespace KBS1 {
    public partial class GameWindow : Window {

        private LevelPicker levelPicker = new LevelPicker();

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
        private PauseMenuScreen p1;
        private MainMenuScreen m1;
        private WinScreen w;
        private LoseScreen l;
        private OptionMenu o1;

        // Methods

        public void LoadHome()
        {
            DrawingPanel.Background = Brushes.LightGreen;
            m1 = new MainMenuScreen();
            Canvas.SetTop(m1, 0);
            Canvas.SetLeft(m1, 0);
            DrawingPanel.Children.Add(m1);
        }

        public void NextLevel()
        {
            DrawingPanel.Children.Clear();
            try
            {
                Loadedlevel = levelPicker.NextLevel();
            }
            catch (Exception q)
            {
                MessageBox.Show($"{q.Message}", "Error");
            }
            Loop.Start();
        }

        public void SelectLevel()
        {
            DrawingPanel.Children.Clear();
            try
            {
                Loadedlevel = levelPicker.PickLevel();
                Loop = new Gameloop(this);
                Loop.Start();
            }
            catch (Exception q)
            {
                MessageBox.Show($"{q.Message}", "Error");
                LoadHome();
            }
        }

        public void LoadGame()
        {
            Loop = new Gameloop(this);
            try {
                LoadLevel();
            }
            catch (Exception q)
            {
                MessageBox.Show($"{q.Message}", "Error");
                LoadHome();
                return;
            }
            Loop.Start();
        }
        
        public void LoadLevel()
        {
            Loadedlevel = levelPicker.LoadSelectedLevel();
        }

        public void LoadOptions()
        {
            o1 = new OptionMenu();
            Canvas.SetLeft(o1, 0);
            Canvas.SetTop(o1, 0);
            DrawingPanel.Children.Add(o1);
        }

        public void PauseGame()
        {
            Loop.Stop();
            p1 = new PauseMenuScreen();
            Canvas.SetTop(p1, 0);
            Canvas.SetLeft(p1, 0);
            DrawingPanel.Children.Add(p1);
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
            w = new WinScreen(Loadedlevel.Score.SecondsRunning + 0.01);
            Canvas.SetLeft(w, 0);
            Canvas.SetTop(w, 0);
            DrawingPanel.Children.Add(w);
        }

        public void Lose()
        {
            Reset();
            GameWindow.Instance.Loop.Stop();
            l = new LoseScreen();
            Canvas.SetLeft(l, 0);
            Canvas.SetTop(l, 0);
            DrawingPanel.Children.Add(l);
        }
    }
}
