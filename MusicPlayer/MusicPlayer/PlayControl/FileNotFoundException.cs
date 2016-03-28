using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PlayControl
{
    class FileNotFoundException : Exception
    {
        public FileNotFoundException() { }

        public FileNotFoundException(string message) : base(message) { }

        public FileNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
