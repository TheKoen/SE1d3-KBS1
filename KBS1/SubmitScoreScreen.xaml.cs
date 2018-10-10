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
//using System.Net.Http;

namespace KBS1
{
    /// <summary>
    /// Interaction logic for SubmitScoreScreen.xaml
    /// </summary>
    public partial class SubmitScoreScreen : UserControl
    {

        private string Username;
        private double Score;

        public SubmitScoreScreen(double s)
        {
            InitializeComponent();
            Score = s;
            ScoreLabel.Content = "Your score: " + Score;
            


        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextName.Text.Length < 2)
            {
                ErrorLabel.Content = "zweepslagen";
            }
            else
            {
                Username = TextName.Text;
                GameWindow.Instance.Loadedlevel.Score.PublishScore(Score, Username);
                GameWindow.Instance.DrawingPanel.Children.Remove(this);
                /*
                using (var client = new HttpClient)
                var request = (HttpWebRequest)WebRequest.Create("https://koenn.me");
                var postData = Score.ToString();
                postData += Username;
                */



            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Remove(this);
        }
    }
}
