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
    /// Interaction logic for PauseMenuScreen.xaml
    /// </summary>
    public partial class PauseMenuScreen : UserControl
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
