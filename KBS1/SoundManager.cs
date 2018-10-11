using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace KBS1
{
    /// <summary>
    /// Can not play more sounds than 200
    /// </summary>
    public class SoundManager
    {
        Dictionary<string, string> Sounds = new Dictionary<string, string>();
        
        private MediaPlayer[] activeMediaPlayers = new MediaPlayer[200];
        private int mediaplayers = 0;

        private string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Sound\\";
        
        public SoundManager()
        { 
            var sounds = ResourceManager.Instance.LoadXmlDocument("Sound/Sounds.xml");
            var root = sounds.DocumentElement;

            if (root == null)
            {
                throw new XmlException("Missing root note");
            }

            var soundsNode = sounds.SelectSingleNode("//sounds");
            if (soundsNode == null)
            {
                throw new XmlException("Levels file missing levels node");
            }
 
            foreach (var child in soundsNode.ChildNodes)
            {
                var value = ((XmlNode)child).Attributes["filename"].InnerText;

                Sounds.Add(value, path + value);             
            }
        }


        

        /// <summary>
        /// Plays the sound with the specific name 
        /// </summary>
        /// <param name="trackName"></param>
        public void Play(string trackName)
        {
            try
            {
                foreach (var item in Sounds)
                {
                    if (item.Key == trackName)
                    {
                        var mediaplayer = new MediaPlayer();
                        mediaplayer.Open(new Uri(item.Value, UriKind.Absolute));
                        while (!mediaplayer.HasAudio) { }
                        mediaplayer.MediaEnded += (sender, e) => mediaplayer.Close();
                        activeMediaPlayers[mediaplayers] = mediaplayer;
                        activeMediaPlayers[mediaplayers].Play();
                        mediaplayers++;
                        return;
                    }   
                }
                throw new FileNotFoundException("No track with that name");
                
            }
            catch (Exception)
            {
                new FileNotFoundException("Error with the sound ");
            }
        }
        public void SetLoopingPlay(string trackName)
        {
            foreach (var item in Sounds)
            {
                if (item.Key == trackName)
                {
                    var mediaplayer = new MediaPlayer();
                    mediaplayer.Open(new Uri(item.Value, UriKind.Absolute));
                    while (!mediaplayer.HasAudio) { }

                    mediaplayer.MediaEnded += (sender, e) => mediaplayer.Position = TimeSpan.Zero ;
                    activeMediaPlayers[mediaplayers] = mediaplayer;
                    activeMediaPlayers[mediaplayers].Play();
                    mediaplayers++;
                    return;
                }
            }
        }

        public void Stop(string trackName)
        {
            foreach (var item in activeMediaPlayers)
            {
                if(item.Source == new Uri("C:\\Users\\Robin\\Documents\\windesheim\\C#\\SE1d3-KBS1\\SE1d3-KBS1\\KBS1\\Resources\\Sound\\" + trackName))
                {
                    item.Stop();
                    return;
                }
            }
        }
    }
}
    


