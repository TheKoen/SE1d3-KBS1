using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
                var levelID = int.Parse(Level.Replace("Level", "").Replace(".xml", ""));
                var newLevel = $"Level{levelID + 1}.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(newLevel);
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
