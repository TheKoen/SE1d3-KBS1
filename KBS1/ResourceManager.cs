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

        private const int AantalImagesPlayerSprite = 16;

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

        public Image[] LoadImageSpritePlayer(string path)
        {

            if (!imageCache.ContainsKey(path))
            {
                //array with the pictures form the sprite
                Image[] images = new Image[AantalImagesPlayerSprite];
                // array with rect for the images.
                Int32Rect[] rects = new Int32Rect[AantalImagesPlayerSprite];
                int j = 0;
                int q = 0;
                for (int i = 0; i < AantalImagesPlayerSprite; i++)
                {
                    if (i % 4 != 0 || i == 0)
                    {
                        rects[i] = new Int32Rect(j * 64, q * 64, 64, 64);
                        j++;
                    }
                    else
                    {
                        j = 0;
                        q++;
                        rects[i] = new Int32Rect(j * 64, q * 64, 64, 64);
                        j++;
                    }
                }
                for(int i = 0; i < rects.Length; i ++)
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"pack://application:,,,/Resources/" + path);
                    bitmapImage.SourceRect = rects[i];
                    bitmapImage.EndInit();
                    var image = new Image
                    {
                        Width = bitmapImage.Width,
                        Height = bitmapImage.Height,
                        Name = path.Substring(path.LastIndexOf('/') + 1).Split('.')[0],
                        Source = bitmapImage
                    };
                    images[i] = image;
                }
                return images;
            }
            return null;
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
