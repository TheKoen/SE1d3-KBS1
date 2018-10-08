using Microsoft.Win32;
using System;
using System.IO;
using System.Xml;
using KBS1.Exceptions.Level;

namespace KBS1
{
    public class LevelPicker
    {
        private string Level;

        /// <summary>
        /// Picklevel creates custom dialog if you dont select a level it throws an Exception.
        /// </summary>
        /// <returns>level if picked</returns>
        public Level PickLevel()
        {
            var dialog = new LevelPickerWindow();

            dialog.ShowDialog();
            var fileName = dialog.FileName;
            if (fileName == null)
            {
                throw new FileNotFoundException("You did not select file.");
            }

            return LoadLevel(fileName);
        }

        /// <summary>
        /// Loads first level with the name Level1.xml.
        /// </summary>
        /// <returns>if Level1.xml exist returns level</returns>
        public Level LoadFirstLevel()
        {
            return LoadLevel("Level1.xml");
        }

        /// <summary>
        /// Loads the next level named Level(current+1).xml or throws exception if not available
        /// </summary>
        /// <returns>returns next level if available</returns>
        public Level NextLevel()
        {
            
            if(Level != null)
            {
                var levelStringArray = Level.Split(Path.DirectorySeparatorChar);
                var levelString = levelStringArray[levelStringArray.Length - 1];
                var levelID = int.Parse(levelString.Replace("Level", "").Replace(".xml", ""));

                var newLevel = $"Level{levelID + 1}.xml";

                return LoadLevel(newLevel);
            }
            else
            {
                throw new LevelLoadException("There isn't currently a level loaded");
            }
        }

        /// <summary>
        /// Load level with a specific name
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <returns>Level if exists</returns>
        private Level LoadLevel(string filename)
        {
            XmlDocument doc;
            try
            {
                doc = ResourceManager.Instance.LoadXmlDocument($"Levels\\{filename}");
            } catch (FileNotFoundException e) {
                throw new FileNotFoundException($"Level \"{filename}\" could not be found");
            }

            try
            {
                var level = new Level(doc);
                Level = filename;
                return level;
            } catch (Exception e) {
                throw new LevelParseException($"Unable to parse level \"{filename}\"", e);
            }
        }
    }
}
