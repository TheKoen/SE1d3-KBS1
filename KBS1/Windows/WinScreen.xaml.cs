using System.Windows;
using System.Windows.Controls;

namespace KBS1.Windows
{
    /// <summary>
    /// Interaction logic for WinScreen.xaml
    /// </summary>
    public partial class WinScreen
    {
        private double Score;
        public WinScreen(double score)
        {
            InitializeComponent();
            this.Score = score;
            ScoreLabel.Content = "Your score: " + Score;          
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
            SubmitScoreScreen sss = new SubmitScoreScreen(Score);
            //checking if the player already submitted his score
            if (GameWindow.Instance.Loadedlevel.IsAlreadySubmitted == false)
            {
                Canvas.SetLeft(sss, 0);
                Canvas.SetTop(sss, 0);
                GameWindow.Instance.DrawingPanel.Children.Add(sss);
            }   else
            {
                //creating content for the label when the player clicks submit again
                AlreadySubmittedLabel.Content = "You've already submitted!";
            }
        }
    }
}