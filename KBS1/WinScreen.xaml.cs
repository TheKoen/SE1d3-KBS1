using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KBS1
{
    /// <summary>
    /// Interaction logic for WinScreen.xaml
    /// </summary>
    public partial class WinScreen : UserControl
    {
        private double score;
        public WinScreen(double Score)
        {
            InitializeComponent();
            this.score = Score;
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
            SubmitScoreScreen sss = new SubmitScoreScreen(score);
            Canvas.SetLeft(sss, 0);
            Canvas.SetTop(sss, 0);
            GameWindow.Instance.DrawingPanel.Children.Add(sss);
        }
    }
}
