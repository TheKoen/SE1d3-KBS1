using System.Windows;
using System.Windows.Input;

namespace KBS1.Windows
{
    /// <summary>
    /// Interaction logic for OptionMenu.xaml
    /// </summary>
    public partial class OptionMenu
    {
        public static Key Up = Key.W;
        public static Key Down = Key.S;
        public static Key Left = Key.A;
        public static Key Right = Key.D;
        public static Key Pause = Key.Escape;
        public static Key Retry = Key.R;

        public OptionMenu()
        {
            Initialized += (Sender, args) =>
            {
                TBMoveUp.Text = GetKeyName(Up);
                TBMoveDown.Text = GetKeyName(Down);
                TBMoveLeft.Text = GetKeyName(Left);
                TBMoveRight.Text = GetKeyName(Right);
                TBPause.Text = GetKeyName(Pause);
                TBRetry.Text = GetKeyName(Retry);
            };
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Clear();
            GameWindow.Instance.LoadHome();
        }

        private void MoveUpOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBMoveUp.Text = GetKeyName(e.Key);
            
            Up = e.Key;
        }

        private void MoveDownOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBMoveDown.Text = GetKeyName(e.Key);
            Down = e.Key;
        }

        private void MoveLeftOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBMoveLeft.Text = GetKeyName(e.Key);
            Left = e.Key;
        }

        private void MoveRightOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBMoveRight.Text = GetKeyName(e.Key);
            Right = e.Key;
        }
        private void PauseOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBPause.Text = GetKeyName(e.Key);
            Pause = e.Key;
        }
        private void RetryOnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TBRetry.Text = GetKeyName(e.Key);
            Pause = e.Key;
        }

        private string GetKeyName(Key k)
        {
            switch (k)
            {
                case Key.Left:
                    return "LEFT";
                case Key.Right:
                    return "RIGHT";
                case Key.Up:
                    return "UP";
                case Key.Down:
                    return "DOWN";
                case Key.Escape:
                    return "ESCAPE";
                case Key.Tab:
                    return "TAB";
                case Key.Space:
                    return "SPACE";
                default:
                    return k.ToString().ToUpper();
            }
        }
    }
}