using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;

namespace KBS1
{
    /// <summary>
    /// Singleton for loading and caching Resources
    /// </summary>
    sealed class ResourceManager
    {
        public static ResourceManager Instance { get; } = new ResourceManager();
        private ResourceManager() { }

        private SortedDictionary<string, Image> imageCache = new SortedDictionary<string, Image>();
        private SortedDictionary<string, XmlDocument> xmlCache = new SortedDictionary<string, XmlDocument>();

        /// <summary>
        /// Loads and caches a Resource as an Image control
        /// </summary>
        /// <param name="path">Path to image inside Resources directory</param>
        /// <returns>Image control from cache</returns>
        public Image LoadImage(string path)
        {
            if (!imageCache.ContainsKey(path))
            {

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(@"pack://application:,,,/Resources/" + path);
                bitmapImage.EndInit();
                var image = new Image
                {
                    Width = bitmapImage.Width,
                    Height = bitmapImage.Height,
                    Name = path.Substring(path.LastIndexOf('/') + 1).Split('.')[0],
                    Source = bitmapImage
                };
                imageCache.Add(path, image);

            }

            return imageCache[path];
        }

        /// <summary>
        /// Loads and caches an XML document as an XmlDocument
        /// </summary>
        /// <param name="path">Path to document inside Resources directory</param>
        /// <returns>XmlDocument from cache</returns>
        public XmlDocument LoadXmlDocument(string path)
        {
            if (!xmlCache.ContainsKey(path))
            {
                var document = new XmlDocument();
                var streamInfo = Application.GetResourceStream(new Uri(@"pack://application:,,,/Resources/" + path));
                document.Load(streamInfo.Stream);
                xmlCache.Add(path, document);

            }

            return xmlCache[path];
        }
    }
}
