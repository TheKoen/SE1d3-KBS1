﻿using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace KBS1 {

    public partial class LevelPickerWindow
    {
        public string FileName { get; private set; }

        public LevelPickerWindow() {
            Initialized += (sender, e) =>
            {
                var levels = ResourceManager.Instance.LoadXmlDocument("Levels/Levels.xml");
                var root = levels.DocumentElement;
                if (root == null) throw new XmlException("Missing root node");

                var levelsNode = levels.SelectSingleNode("//levels");
                if (levelsNode == null)
                    throw new XmlException("Levels file missing levels node");

                LevelList.Items.Add(new ListViewItem {Content = "--- Base Levels ---", IsEnabled = false});
                
                foreach (XmlNode child in levelsNode.ChildNodes)
                {
                    var value = child.Attributes["filename"].InnerText;
                    var item = new ListViewItem
                    {
                        Content = value
                    };
                    LevelList.Items.Add(item);
                }

                LevelList.Items.Add(new ListViewItem {Content = "", IsEnabled = false});
                LevelList.Items.Add(new ListViewItem {Content = "--- Custom Levels ---", IsEnabled = false});
                
                if (!Directory.Exists("levels")) return;
                var ioLevelNames = Directory.GetFiles("levels");
                var ioXml = ioLevelNames.Where(f => f.EndsWith(".xml"))
                    .Select(f => f.Remove(0, f.IndexOf("\\", StringComparison.Ordinal) + 1));
                foreach (var value in ioXml)
                {
                    var item = new ListViewItem
                    {
                        Content = value
                    };
                    LevelList.Items.Add(item);
                }
            };

            InitializeComponent();
        }

        private void LevelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FileName = (string) ((ListViewItem) LevelList.SelectedItem).Content;
            Close();
        }
    }
}
