using System.Windows;
using System.Windows.Controls;

namespace KBS1.Windows
{
    /// <summary>
    /// Interaction logic for WinScreen.xaml
    /// </summary>
    public partial class WinScreen
    {
        private double _score;

        public WinScreen(double score)
        {
            InitializeComponent();
            _score = score;
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

        private void SubmitScoreButton_Click(object sender, RoutedEventArgs e)
        {
            var sss = new SubmitScoreScreen(_score);
            Canvas.SetLeft(sss, 0);
            Canvas.SetTop(sss, 0);
            GameWindow.Instance.DrawingPanel.Children.Add(sss);
        }
    }
}