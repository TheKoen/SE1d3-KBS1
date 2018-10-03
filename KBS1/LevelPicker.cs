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
                return new Level(doc);
            }
            catch(Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
