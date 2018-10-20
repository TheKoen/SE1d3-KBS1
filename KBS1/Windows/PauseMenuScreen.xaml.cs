using System.Windows;

namespace KBS1.Windows
{
    /// <summary>
    ///     Interaction logic for PauseMenuScreen.xaml
    /// </summary>
    public partial class PauseMenuScreen
    {
        public PauseMenuScreen()
        {
            InitializeComponent();
        }

        private void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Remove(this);
            GameWindow.Instance.Loop.Start();
        }

        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.Reset();
        }

        private void QuitToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Clear();
            GameWindow.Instance.LoadHome();
        }
    }
}