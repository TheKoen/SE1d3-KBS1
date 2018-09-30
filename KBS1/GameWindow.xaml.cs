using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KBS1 {
    public partial class GameWindow : Window {

        // Properties
        public Canvas DrawPanel { get; set; }
        public Level Loadedlevel { get; set; }
        //public SoundManager SManager { get; set; }
        //public GameLoop Loop { get; set; }


        public GameWindow()
        {
            InitializeComponent();
            Ellipse circle = new Ellipse();
            circle.Fill = Brushes.ForestGreen;
            circle.Width = 150;
            circle.Height = 150;
            Canvas.SetLeft(circle, 50);
            Canvas.SetTop(circle, 70);
            DrawingPanel.Children.Add(circle);
        }
        

        // Methods
        public GameWindow Current()
        {
            return null;
        }
                
    }
}
