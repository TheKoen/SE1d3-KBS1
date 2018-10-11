using System.Windows;

namespace KBS1.Windows
{
    /// <summary>
    /// Interaction logic for OptionMenu.xaml
    /// </summary>
    public partial class OptionMenu
    {
        public OptionMenu()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Clear();
            GameWindow.Instance.LoadHome();
        }
    }
}