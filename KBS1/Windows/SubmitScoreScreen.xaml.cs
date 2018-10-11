using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace KBS1.Windows
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

        private async void SubmitButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (TextName.Text.Length < 2)
            {
                ErrorLabel.Content = "Fill in more characters.";
            }
            else
            {
                Username = TextName.Text;
                GameWindow.Instance.Loadedlevel.Score.PublishScore(Score, Username);
                GameWindow.Instance.DrawingPanel.Children.Remove(this);

                //creating new httpclient and send data with it
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        {"Name", Username},
                        {"Score", Score.ToString()},
                        {"Map", GameWindow.Instance.Loadedlevel.Name}
                    };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync("https://kbs.koenn.me/post.php", content);

                    var responseString = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(responseString);
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.Instance.DrawingPanel.Children.Remove(this);
        }
    }
}