using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KBS1 {
    public partial class GameWindow : Window {
        public GameWindow() {

            InitializeComponent();
            Ellipse cirkel = new Ellipse();
            cirkel.Fill = Brushes.ForestGreen;
            cirkel.Width = 150;
            cirkel.Height = 150;
            Canvas.SetLeft(cirkel, 50);
            Canvas.SetTop(cirkel, 70);
            DrawingPanel.Children.Add(cirkel);

        }
    }
}
