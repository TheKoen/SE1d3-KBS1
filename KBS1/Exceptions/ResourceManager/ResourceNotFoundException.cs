using System;

namespace KBS1.Exceptions.ResourceManager
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string resource) :
            base($"Could not find or load resource \"{resource}\"")
        {
        }

        public ResourceNotFoundException(string resource, Exception innerException) :
            base($"Could not find or load resource \"{resource}\"", innerException)
        {
        }
    }
}