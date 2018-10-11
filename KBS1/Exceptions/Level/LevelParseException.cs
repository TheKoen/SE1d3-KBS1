using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.Exceptions.Level
{
    class LevelParseException : Exception
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