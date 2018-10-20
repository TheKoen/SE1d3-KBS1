using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using KBS1.LevelComponents;
using KBS1.Obstacles;
using KBS1.Util;
using KBS1.Windows;

namespace KBS1
{
    public partial class GameWindow
    {
        public static bool keyDown;
        private readonly LevelPicker _levelPicker = new LevelPicker();
        private LoseScreen _screenLose;
        private MainMenuScreen _screenMainMenu;
        private OptionMenu _screenOptionMenu;


        // Properties
        private PauseMenuScreen _screenPauseMenu;
        private WinScreen _screenWin;
        private LevelEditor _windowLevelEditor;

        public GameWindow()
        {
            Initialized += (sender, e) =>
            {
                Sounds = new SoundManager();
                LoadOptions();
                DrawingPanel.Children.Clear();
                LoadHome();
            };
            Instance = this;
            InitializeComponent();
        }

        public Level Loadedlevel { get; set; }
        public Gameloop Loop { get; set; }
        public static GameWindow Instance { get; private set; }

        public SoundManager Sounds { get; private set; }

        // check if keyinput exists
        public void onKeyDownHandler(object sender, KeyEventArgs e)
        {
            keyDown = true;
        }

        // Methods

        /// <summary>
        ///     Loads the main menu screen
        /// </summary>
        public void LoadHome()
        {
            ObstacleType.Init();

            DrawingPanel.Background = ResourceManager.Instance.LoadImageBrush("#bg.jpg");
            _screenMainMenu = new MainMenuScreen();
            Canvas.SetTop(_screenMainMenu, 0);
            Canvas.SetLeft(_screenMainMenu, 0);
            DrawingPanel.Children.Add(_screenMainMenu);
        }

        /// <summary>
        ///     Starts playing the next level
        /// </summary>
        public void NextLevel()
        {
            DrawingPanel.Children.Clear();
            try
            {
                Loadedlevel = _levelPicker.NextLevel();
            }
            catch (Exception q)
            {
                MessageBox.Show($"{q.Message}", "Error");
            }

            Loop.Start();
        }

        /// <summary>
        ///     Makes the user pick a level and plays it
        /// </summary>
        public void SelectLevel()
        {
            DrawingPanel.Children.Clear();
            try
            {
                Loop = new Gameloop();
                Loadedlevel = _levelPicker.PickLevel();
                Loop.Start();
            }
            catch (Exception q)
            {
                ExceptionManager.Catch(q);
            }
        }

        /// <summary>
        ///     Loads the selected level
        /// </summary>
        public void LoadGame()
        {
            Loop = new Gameloop();
            try
            {
                LoadLevel();
            }
            catch (Exception q)
            {
                ExceptionManager.Catch(q);
                return;
            }

            Loop.Start();
        }

        /// <summary>
        ///     Makes the user pick a level
        /// </summary>
        public void LoadLevel()
        {
            Loadedlevel = _levelPicker.LoadSelectedLevel();
        }

        /// <summary>
        ///     Loads the options screen
        /// </summary>
        public void LoadOptions()
        {
            DrawingPanel.Background = Brushes.DimGray;
            _screenOptionMenu = new OptionMenu();
            Canvas.SetLeft(_screenOptionMenu, 0);
            Canvas.SetTop(_screenOptionMenu, 0);
            DrawingPanel.Children.Add(_screenOptionMenu);
        }

        /// <summary>
        ///     Pauses the game and shows the pause menu screen
        /// </summary>
        public void PauseGame()
        {
            Loop.Stop();
            _screenPauseMenu = new PauseMenuScreen();
            Canvas.SetTop(_screenPauseMenu, 0);
            Canvas.SetLeft(_screenPauseMenu, 0);
            DrawingPanel.Children.Add(_screenPauseMenu);
        }

        /// <summary>
        ///     Resets the current level
        /// </summary>
        public void Reset()
        {
            Loop.Stop();
            DrawingPanel.Children.Clear();
            LoadGame();
        }

        /// <summary>
        ///     Shows the win screen
        /// </summary>
        public void Win()
        {
            Loop.Stop();
            _screenWin = new WinScreen(Loadedlevel.Score.SecondsRunning + 0.01);
            Canvas.SetLeft(_screenWin, 0);
            Canvas.SetTop(_screenWin, 0);
            DrawingPanel.Children.Add(_screenWin);
        }

        /// <summary>
        ///     Shows the lose screen
        /// </summary>
        public void Lose()
        {
            Sounds.Play("lose.mp3");

            Reset();
            Loop.Stop();
            _screenLose = new LoseScreen();
            Canvas.SetLeft(_screenLose, 0);
            Canvas.SetTop(_screenLose, 0);
            DrawingPanel.Children.Add(_screenLose);
        }

        /// <summary>
        ///     Shows the level editor
        /// </summary>
        public void ShowLevelEditor()
        {
            if (_windowLevelEditor == null || !_windowLevelEditor.IsLoaded)
            {
                _windowLevelEditor = new LevelEditor();
                _windowLevelEditor.Show();
            }
            else if (_windowLevelEditor.IsLoaded)
            {
                _windowLevelEditor.Focus();
            }
        }
    }
}