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
    /// Interaction logic for MainMenuScreen.xaml
    /// </summary>
    public partial class MainMenuScreen : UserControl
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
    }
}
