using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.Exceptions.Level {
    class LevelLoadException : Exception {
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
