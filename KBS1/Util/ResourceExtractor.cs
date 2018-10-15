using System;
using System.IO;
using System.Windows;
using KBS1.Exceptions.ResourceManager;

namespace KBS1.Util
{
    public class ResourceExtractor
    {
        public static void Extract(string source, string destination)
        {
            var uri = new Uri(@"pack://application:,,,/Resources/" + source);
            var streamInfo = Application.GetResourceStream(uri);
            if (streamInfo == null)
                throw new ResourceNotFoundException($"Internal resource {source} could not be found!");
            using (var file = new FileStream(destination, FileMode.Create, FileAccess.Write))
            {
                streamInfo.Stream.CopyTo(file);
            }
        }
    }
}