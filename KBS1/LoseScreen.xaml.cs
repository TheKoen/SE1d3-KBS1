using System.Windows;
using System.Windows.Controls;

namespace KBS1
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
