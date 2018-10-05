using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KBS1
{
    public class LevelPicker
    {
        private string Level;
        public Level PickLevel()
        {
            var dialog = new OpenFileDialog();

            var result = dialog.ShowDialog();
            if (result == false)
            {
                throw new ArgumentException("User did not select file.");
            }
            XmlDocument doc = new XmlDocument();
            
            doc.Load(dialog.FileName);
            try
            {
                Level = dialog.FileName;
                return new Level(doc);
            }
            catch(Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        public Level NextLevel()
        {
            
            if(Level != null)
            {
                var levelStringArray = Level.Split(Path.DirectorySeparatorChar);
                var levelString = levelStringArray[levelStringArray.Length - 1];
                var levelID = int.Parse(levelString.Replace("Level", "").Replace(".xml", ""));

                var newLevel = $"Levels\\Level{levelID + 1}.xml";
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load(newLevel);
                }
                catch (FileNotFoundException e)
                {
                    throw new FileNotFoundException("There isn't a next level");
                }
                try
                {
                    Level = newLevel;
                    return new Level(doc);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }

            }
            else
            {
                throw new ArgumentException("Current level does not exist");
            }
        }
    }
}
