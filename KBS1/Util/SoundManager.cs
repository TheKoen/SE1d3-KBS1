using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Xml;

namespace KBS1.Util
{
    public class SoundManager
    {
        private readonly Dictionary<string, MediaPlayer> Sounds = new Dictionary<string, MediaPlayer>();
        private readonly string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Sound\\";
        
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

                var mediaplayer = new MediaPlayer();
                mediaplayer.Open(new Uri(path + value, UriKind.Absolute));
                while (!mediaplayer.HasAudio) { }

                mediaplayer.MediaEnded += (sender, e) =>
                {
                    mediaplayer.Stop();
                    mediaplayer.Position = TimeSpan.Zero;
                };
                Sounds.Add(value, mediaplayer);
            }
        }
        
        /// <summary>
        /// Plays the sound with the specific name 
        /// </summary>
        /// <param name="trackName"></param>
        public void Play(string trackName)
        {
            if (Sounds.TryGetValue(trackName, out var player))
            {
                player.Play();
            }
            else
            {
                throw new FileNotFoundException("Sound could not be found!");
            }
        }
        public void SetLoopingPlay(string trackName)
        {
            if (Sounds.TryGetValue(trackName, out var player))
            {
                player.MediaEnded += (sender, e) => player.Play();
                player.Play();
            }
            else
            {
                throw new FileNotFoundException("Sound could not be found!");
            }
        }

        public void Stop(string trackName)
        {
            if (Sounds.TryGetValue(trackName, out var player))
            {
                player.Stop();
            }
            else
            {
                throw new FileNotFoundException("Sound could not be found!");
            }
        }
    }
}
    


