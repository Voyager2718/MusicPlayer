using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MusicPlayer.PlayControl
{
    class PlayControl
    {
        ////////////////Constants////////////////
        //Volume
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;
        private const int APPCOMMAND_VOLUME_UP = 10 * 65536;
        private const int APPCOMMAND_VOLUME_DOWN = 9 * 65536;

        //Handler
        private const int MM_MCINOTIFY = 0x03b9;
        private const int MCI_NOTIFY_SUCCESS = 0x01;
        private const int MCI_NOTIFY_SUPERSEDED = 0x02;
        private const int MCI_NOTIFY_ABORTED = 0x04;
        private const int MCI_NOTIFY_FAILURE = 0x08;
        protected IntPtr handle;

        ////////////////End of constants////////////////


        protected List<String> playList;

        protected int volume = 100;

        protected bool fileOpened;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public PlayControl(List<String> playList, int volume = 100)
        {
            this.playList = new List<String>(playList);
            this.volume = volume;
        }

        public PlayControl()
        {
            playList = new List<String>();
        }

        public void open(String filename)
        {
            String command = "open \"" + filename + "\" type mpegvideo alias MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
            fileOpened = true;
            setVolume(volume);
        }

        public bool play(bool loop = false)
        {
            if (fileOpened)
            {
                String command = "play MediaFile notify";
                if (loop)
                    command += " REPEAT";
                mciSendString(command, null, 0, IntPtr.Zero);
                return true;
            }
            return false;
        }

        public void pause()
        {
            String command = "pause MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void resume()
        {
            String command = "resume MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void stop() { }

        public void setVolume(int volume) { }

        public int getVolume()
        {
            return this.volume;
        }
    }
}
