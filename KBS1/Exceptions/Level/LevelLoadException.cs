using System;

namespace KBS1.Exceptions.Level
{
    internal class LevelLoadException : Exception
    {
        public LevelLoadException()
        {
        }

        public LevelLoadException(string message) : base(message)
        {
        }

        public LevelLoadException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}