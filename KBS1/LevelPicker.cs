using System;
using System.IO;
using System.Xml;
using KBS1.Exceptions.Level;

namespace KBS1
{
    public class LevelPicker
    {
        private string _level;

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
                throw new FileNotFoundException("You did not select level.");
            }

            return LoadLevel(fileName);
        }

        /// <summary>
        /// Loads first level with the name Level1.xml.
        /// </summary>
        /// <returns>if Level1.xml exist returns level</returns>
        private Level LoadFirstLevel()
        {
            return LoadLevel("Level1.xml");
        }

        /// <summary>
        /// TODO: Add proper summary
        /// </summary>
        /// <returns></returns>
        public Level LoadSelectedLevel() => _level == null ? LoadFirstLevel() : LoadLevel(_level);
        
        /// <summary>
        /// Loads the next level named Level(current+1).xml or throws exception if not available
        /// </summary>
        /// <returns>returns next level if available</returns>
        public Level NextLevel()
        {
            if (_level == null) throw new LevelLoadException("There isn't currently a level loaded");
            var levelStringArray = _level.Split(Path.DirectorySeparatorChar);
            var levelString = levelStringArray[levelStringArray.Length - 1];
            var levelId = int.Parse(levelString.Replace("Level", "").Replace(".xml", ""));

            var newLevel = $"Level{levelId + 1}.xml";

            return LoadLevel(newLevel);
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
            } catch (FileNotFoundException) {
                throw new FileNotFoundException($"Level \"{filename}\" could not be found");
            }

            try
            {
                var level = new Level(doc);
                _level = filename;
                return level;
            } catch (Exception e) {
                throw new LevelParseException($"Unable to parse level \"{filename}\"", e);
            }
        }
    }
}
