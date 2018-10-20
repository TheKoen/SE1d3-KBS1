using System;

namespace KBS1.Exceptions.Level
{
    internal class LevelParseException : Exception
    {
        public LevelParseException()
        {
        }

        public LevelParseException(string message) : base(message)
        {
        }

        public LevelParseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}