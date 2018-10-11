using System.Windows;

namespace KBS1.Windows
{
    /// <summary>
    /// Interaction logic for LoseScreen.xaml
    /// </summary>
    public partial class LoseScreen
    {
        public LoseScreen()
        {
            InitializeComponent();
        }

        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.Reset();
        }

        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Clear();
            GameWindow.Instance.LoadHome();
        }
    }
}