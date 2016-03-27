﻿using System;
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
        ////////////////End of constants////////////////

        ////////////////Enums////////////////
        public enum Status { PLAYING, WAITING, PAUSED, EXCEPTION };
        public enum ChangeVolume { INCR1, DECR1, INCR5, DECR5, INCR10, DECR10 };
        ////////////////End of enums////////////////


        ////////////////Local variables////////////////
        protected IntPtr handle;

        protected List<String> playList;
        protected int volume = 100;
        protected String playingFile = "";
        protected bool fileOpened = false;
        protected Status status;

        [DllImport("winmm.dll")]
        protected static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        ////////////////End of local variables////////////////

        ////////////////Constructors////////////////
        public PlayControl(List<String> playList, IntPtr handle, int volume = 100)
        {
            this.playList = new List<String>(playList);
            this.volume = volume;
            this.handle = handle;
            this.status = Status.WAITING;
        }

        public PlayControl(IntPtr handle)
        {
            playList = new List<String>();
            this.handle = handle;
            this.status = Status.WAITING;
        }

        ////////////////Control functions////////////////
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
                mciSendString(command, null, 0, handle);
                return true;
            }
            return false;
        }

        public void pause()
        {
            String command = "pause MediaFile";
            mciSendString(command, null, 0, handle);
        }

        public void resume()
        {
            String command = "resume MediaFile";
            mciSendString(command, null, 0, handle);
        }

        public void stop()
        {
            String command = "stop MediaFile";
            mciSendString(command, null, 0, handle);
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

        public String getPlayingFile() { return playingFile; }

        public void setPlaylist(String playlist)
        {

        }

        public void setPlaylist(List<String> playlist) { this.playList = playlist.ToList(); }

        public List<String> getPlaylist() { return playList; }
    }
}
