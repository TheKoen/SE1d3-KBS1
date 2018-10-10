using System.Windows;

namespace KBS1
{
    /// <summary>
    /// Interaction logic for WinScreen.xaml
    /// </summary>
    public partial class WinScreen
    {
        public WinScreen(double score)
        {
            InitializeComponent();
            ScoreLabel.Content = "Your score: " + score;
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Clear();
            GameWindow.Instance.LoadHome();
        }

        private void NextLevelButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.NextLevel();
        }

        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.Reset();
        }
    }
}
