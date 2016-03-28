using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MusicPlayer.PlayControl
{
    class PlayControl
    {
        ////////////////Constants////////////////
        //Volume
        public const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        public const int WM_APPCOMMAND = 0x319;
        public const int APPCOMMAND_VOLUME_UP = 10 * 65536;
        public const int APPCOMMAND_VOLUME_DOWN = 9 * 65536;

        //Handler
        public const int MM_MCINOTIFY = 0x03b9;
        public const int MCI_NOTIFY_SUCCESS = 0x01;
        public const int MCI_NOTIFY_SUPERSEDED = 0x02;
        public const int MCI_NOTIFY_ABORTED = 0x04;
        public const int MCI_NOTIFY_FAILURE = 0x08;

        ////////////////Enums////////////////
        public enum Status { PLAYING, WAITING, PAUSED, EXCEPTION };
        public enum ChangeVolume { INCR1, DECR1, INCR5, DECR5, INCR10, DECR10 };
        public enum LoopMode { ONCE, LOOP, ALL };

        ////////////////Local variables////////////////
        protected IntPtr handle;

        protected List<String> playlist;

        protected String playingFileName = "";

        protected bool fileOpened = false;
        protected Status status = Status.WAITING;
        protected LoopMode loopMode;

        protected int playPosition = 0;
        protected int volume = 100;

        protected bool playlistChanged = false;

        [DllImport("winmm.dll")]
        protected static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        ////////////////End of local variables////////////////

        ////////////////Constructors////////////////
        public PlayControl(List<String> playlist, IntPtr handle, int volume = 100)
        {
            this.playlist = new List<String>(playlist);
            this.volume = volume;
            this.handle = handle;
        }

        public PlayControl(IntPtr handle)
        {
            playlist = new List<String>();
            this.handle = handle;
        }

        ////////////////Message listeners////////////////
        public void messageListener(Int32 message)
        {
            switch (message)
            {
                case MCI_NOTIFY_SUCCESS:
                    MessageBox.Show("1");
                    status = Status.WAITING;
                    onFinished();
                    break;
                case MCI_NOTIFY_SUPERSEDED:
                    //MessageBox.Show("2");
                    break;
                case MCI_NOTIFY_FAILURE:
                    //MessageBox.Show("3");
                    break;
                case MCI_NOTIFY_ABORTED:
                    //MessageBox.Show("4");
                    break;
                default:
                    break;
            }
        }

        protected void onPlaylistChanged()
        {
            playPosition = 0;
            playlistChanged = true;
        }

        protected void onFinished()
        {
            switch (loopMode)
            {
                case LoopMode.ONCE: return;
                case LoopMode.LOOP: play(); break;
                case LoopMode.ALL: open(getNextFilePath()).play(); break;
            }
        }

        ////////////////Control functions////////////////
        public PlayControl open(String filepath)
        {
            if (!File.Exists(filepath))
                throw new FileNotFoundException();
            String command = "open \"" + filepath + "\" type mpegvideo alias MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
            fileOpened = true;
            status = Status.WAITING;
            return this;
        }

        public PlayControl play()
        {
            play(loopMode);
            return this;
        }

        public PlayControl play(LoopMode loopMode)
        {
            if (!fileOpened)
            {
                status = Status.EXCEPTION;
                throw new FileNotOpenedException();
            }

            if (status == Status.PAUSED)
            {
                resume();
                return this;
            }

            status = Status.PLAYING;
            this.loopMode = loopMode;

            String command = "play MediaFile notify";

            changeLoopMode(loopMode);

            mciSendString(command, null, 0, handle);
            setVolume(volume);

            return this;
        }

        public PlayControl playAt(int index)
        {
            open(getFileAt(index)).play();
            return this;
        }

        public PlayControl playAt(LoopMode loopMode, int index)
        {
            open(getFileAt(index)).play(loopMode);
            return this;
        }

        public PlayControl playNext()
        {
            open(getNextFilePath()).play();
            return this;
        }

        public PlayControl playPrevious()
        {
            open(getPreviousFilePath()).play();
            return this;
        }

        public PlayControl pause()
        {
            status = Status.PAUSED;
            String command = "pause MediaFile";
            mciSendString(command, null, 0, handle);
            return this;
        }

        public PlayControl resume()
        {
            status = Status.PLAYING;
            String command = "resume MediaFile";
            mciSendString(command, null, 0, handle);
            return this;
        }

        public PlayControl stop()
        {
            status = Status.WAITING;
            String command = "stop MediaFile";
            mciSendString(command, null, 0, handle);
            return this;
        }

        public PlayControl changeLoopMode(LoopMode loopMode)
        {
            this.loopMode = loopMode;
            return this;
        }

        ////////////////Setters and getters////////////////
        public void setVolume(int volume) { this.volume = volume; }

        public void setVolume(ChangeVolume volume)
        {
            switch (volume)
            {
                case ChangeVolume.INCR1: setVolume(this.volume + 1); break;
                case ChangeVolume.INCR5: setVolume(this.volume + 5); break;
                case ChangeVolume.INCR10: setVolume(this.volume + 10); break;

                case ChangeVolume.DECR1: setVolume(this.volume - 1); break;
                case ChangeVolume.DECR5: setVolume(this.volume - 5); break;
                case ChangeVolume.DECR10: setVolume(this.volume - 10); break;
            }
        }
        public int getVolume() { return this.volume; }

        public Status getStatus() { return status; }

        public String getPlayingFileName() { return playingFileName; }

        public void setplaylist(String playlist)
        {
            //TODO : Interpret filepath
            onPlaylistChanged();
        }

        public void setplaylist(List<String> playlist) { this.playlist = playlist.ToList(); onPlaylistChanged(); }

        public List<String> getplaylist() { return playlist; }

        public String getNextFilePath()
        {
            return playPosition >= playlist.Count - 2 ?
                playlist.ElementAt(0) :
                playlist.ElementAt(playPosition + 1);
        }

        public String getPreviousFilePath()
        {
            return playPosition <= 1 ?
                playlist.ElementAt(playlist.Count - 1) :
                playlist.ElementAt(playPosition - 1);
        }

        /// <summary>
        /// Get filename at the playlist.
        /// </summary>
        /// <param name="index">Index of file</param>
        /// <returns></returns>
        public String getFileAt(int index)
        {
            return playlist.ElementAt(index);
        }
    }
}
