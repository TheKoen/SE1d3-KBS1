﻿using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace KBS1 {

    public partial class LevelPickerWindow : Window
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

                foreach (var child in levelsNode.ChildNodes)
                {
                    var value = ((XmlNode) child).Attributes["filename"].InnerText;
                    var item = new ListViewItem()
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