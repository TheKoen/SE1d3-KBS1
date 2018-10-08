using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using KBS1.Exceptions.ResourceManager;

namespace KBS1
{
    /// <summary>
    /// Singleton for loading and caching Resources
    /// </summary>
    sealed class ResourceManager
    {
        private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
        private static readonly string ResName = Assembly.GetName().Name + ".g.resources";
        private static string[] _resources;
        
        public static ResourceManager Instance { get; } = new ResourceManager();
        private ResourceManager() { }

        private readonly SortedDictionary<string, Image> _imageCache = new SortedDictionary<string, Image>();
        private readonly SortedDictionary<string, XmlDocument> _xmlCache = new SortedDictionary<string, XmlDocument>();
        private readonly SortedDictionary<string, ImageBrush> _imgBrushCache = new SortedDictionary<string, ImageBrush>();

        /// <summary>
        /// Loads and caches a Resource as an <see cref="Image"/> control
        /// </summary>
        /// <param name="path">Path to image inside Resources directory</param>
        /// <returns><see cref="Image"/> from cache</returns>
        public Image LoadImage(string path)
        {
            if (_imageCache.ContainsKey(path)) return _imageCache[path];
            if (!ResourceExists(path)) throw new ResourceNotFoundException(path);
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
            _imageCache.Add(path, image);

            return _imageCache[path];
        }

        /// <summary>
        /// Loads and caches an XML document as an <see cref="XmlDocument"/>
        /// </summary>
        /// <param name="path">Path to document inside Resources directory</param>
        /// <returns><see cref="XmlDocument"/> from cache</returns>
        public XmlDocument LoadXmlDocument(string path)
        {
            if (_xmlCache.ContainsKey(path)) return _xmlCache[path];
            var document = new XmlDocument();
            var streamInfo = Application.GetResourceStream(new Uri(@"pack://application:,,,/Resources/" + path));
            if (streamInfo != null) document.Load(streamInfo.Stream);
            else throw new ResourceNotFoundException(path);
            _xmlCache.Add(path, document);

            return _xmlCache[path];
        }

        /// <summary>
        /// Loads and caches a Resource as an <see cref="ImageBrush"/>
        /// </summary>
        /// <param name="path">Path to image inside Resources directory</param>
        /// <returns><see cref="ImageBrush"/> from cache</returns>
        public ImageBrush LoadImageBrush(string path)
        {
            if (_imgBrushCache.ContainsKey(path)) return _imgBrushCache[path];
            if (!ResourceExists(path)) throw new ResourceNotFoundException(path);
            var brush = new ImageBrush();
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"pack://application:,,,/Resources/" + path);
            bitmapImage.EndInit();
            brush.ImageSource = bitmapImage;
            _imgBrushCache.Add(path, brush);

            return _imgBrushCache[path];
        }

        /// <summary>
        /// Checks if a resource exists
        /// </summary>
        /// <param name="path">Path of resource to verify</param>
        /// <returns>Resource's existance</returns>
        private static bool ResourceExists(string path)
        {
            if (_resources == null)
            {
                using (var stream = Assembly.GetManifestResourceStream(ResName))
                {
                    using (var reader = new System.Resources.ResourceReader(stream))
                    {
                        _resources = reader.Cast<DictionaryEntry>().Select(entry =>
                            ((string) entry.Key).Replace("resources/", "")).ToArray();
                    }
                }
            }

            var exists = false;
            Array.ForEach(_resources, n =>
            {
                if (Array.IndexOf(_resources, path) != -1) exists = true;
            });
            return exists;
        }
    }
}
