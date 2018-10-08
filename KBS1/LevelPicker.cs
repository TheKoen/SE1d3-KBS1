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

        public Level LoadFirstLevel()
        {
            return LoadLevel("Level1.xml");
        }

        public Level LoadSelectedLevel()
        {
            return Level == null ? LoadFirstLevel() : LoadLevel(Level);
        }

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
