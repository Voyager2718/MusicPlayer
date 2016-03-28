using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PlayControl
{
    class FileNotOpenedException : Exception
    {
        public FileNotOpenedException() { }

        public FileNotOpenedException(string message) : base(message) { }

        public FileNotOpenedException(string message, Exception inner) : base(message, inner) { }
    }
}
