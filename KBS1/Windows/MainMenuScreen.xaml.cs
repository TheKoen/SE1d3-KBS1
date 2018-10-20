using System.Windows;

namespace KBS1.Windows
{
    /// <summary>
    ///     Interaction logic for MainMenuScreen.xaml
    /// </summary>
    public partial class MainMenuScreen
    {
        public MainMenuScreen()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Clear();
            GameWindow.Instance.LoadGame();
        }

        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Clear();
            GameWindow.Instance.LoadOptions();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SelectLevel_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.SelectLevel();
        }

        private void LevelEditorButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.ShowLevelEditor();
        }
    }
}