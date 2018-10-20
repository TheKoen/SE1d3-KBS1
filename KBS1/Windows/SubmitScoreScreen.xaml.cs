using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace KBS1.Windows
{
    /// <summary>
    ///     Interaction logic for SubmitScoreScreen.xaml
    /// </summary>
    public partial class SubmitScoreScreen : UserControl
    {
        private readonly double Score;
        private string Username;

        public SubmitScoreScreen(double s)
        {
            InitializeComponent();
            Score = s;
            ScoreLabel.Content = "Your score: " + Score;
        }

        private async void SubmitButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            //checking if the player has filled in more than 1 character
            if (TextName.Text.Length < 2)
            {
                ErrorLabel.Content = "Please fill in more characters to submit.";
            }
            else
            {
                //player submits
                GameWindow.Instance.Loadedlevel.IsAlreadySubmitted = true;
                //showing message for player with "submitted"
                var messageBoxResult = MessageBox.Show(
                    "You submitted your score successfully! \nDo you want to see the highscores?",
                    "Your score: " + Score, MessageBoxButton.YesNo,
                    MessageBoxImage.Asterisk);
                if (messageBoxResult.ToString() == "Yes") Process.Start("https://kbs.koenn.me/highscores.php");

                //get the input from player
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