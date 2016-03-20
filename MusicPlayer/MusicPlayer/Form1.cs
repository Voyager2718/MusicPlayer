using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace MusicPlayer
{
    public partial class app : Form
    {
        private bool minimizedToSystemTray = false;

        private String[] playlist;
        private int playPosition = -1;

        private bool playing = false;
        private bool paused = false;

        private string _command;
        private bool fileOpened;

        //Volume
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;
        private const int APPCOMMAND_VOLUME_UP = 10 * 65536;
        private const int APPCOMMAND_VOLUME_DOWN = 9 * 65536;

        //dll
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public app()
        {
            InitializeComponent();
        }

        private void Open(string sFileName)
        {
            _command = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
            fileOpened = true;
        }

        private void Stop()
        {
            status.Text = "Waiting..";

            _command = "close MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
            fileOpened = false;
        }

        private void Play(bool loop)
        {
            if (playlist.Length == 0) return;
            if (fileOpened)
            {
                _command = "play MediaFile";
                if (loop)
                    _command += " REPEAT";
                mciSendString(_command, null, 0, IntPtr.Zero);
                status.Text = "Playing..";
            }
        }

        private void pause()
        {
            _command = "pause MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
        }

        private void resume()
        {
            _command = "resume MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
        }

        private void loadPlaylist()
        {
            playlist = files.Text.Trim().Replace("\n", "").Split(';');
            playPosition = -1;
        }

        private void setNextPosition()
        {
            playPosition = playPosition >= playlist.Length - 1 ? 0 : playPosition + 1;
        }

        private int getNextPosition()
        {
            return playPosition >= playlist.Length - 1 ? 0 : playPosition + 1;
        }

        private void setPrevPosition()
        {
            playPosition = playPosition <= 0 ? playlist.Length - 1 : playPosition - 1;
        }

        private int getPrevPosition()
        {
            return playPosition <= 0 ? playlist.Length - 1 : playPosition - 1;
        }

        private void setFilename()
        {
            String fn = Path.GetFileNameWithoutExtension(playlist[playPosition]);
            if (fn.Length > 14) fn = fn.Substring(0, 14) + "..";
            filename.Text = fn;
        }

        private void play_Click(object sender, EventArgs e)
        {
            try
            {
                if (playlist.Length == 0) return;
                Open(playlist[playPosition == -1 ? ++playPosition : playPosition]);
                Play(loop.Checked);
                playing = true;
                setFilename();
            }
            catch (NullReferenceException) { }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (!playing) return;
            int nextPosition = getNextPosition();
            setNextPosition();
            Stop();
            loadPlaylist();
            Open(playlist[nextPosition]);
            Play(loop.Checked);
            setFilename();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (!playing) return;
            int prevPosition = getPrevPosition();
            setPrevPosition();
            Stop();
            loadPlaylist();
            Open(playlist[prevPosition]);
            Play(loop.Checked);
            setFilename();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            Stop();
            playing = false;
        }

        private void pause_click(object sender, EventArgs e)
        {
            if (!playing) return;
            if (!paused)
            {
                ps.Text = "Resume";
                pause();
                paused = true;
            }
            else
            {
                ps.Text = "Pause";
                resume();
                paused = false;
            }
        }

        private void files_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Changed");
            loadPlaylist();
        }

        /**
         * Minimize the window to system tray and hide in taskbar.
         * 
         */
        private void minimizeToSystemTray()
        {
            bool cursorNotInBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);
            if (this.WindowState == FormWindowState.Minimized && cursorNotInBar)
            {
                minimizedToSystemTray = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        //Show the minimized window.
        private void backToNormalState()
        {
            minimizedToSystemTray = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void app_Resize(object sender, EventArgs e)
        {
            minimizeToSystemTray();
        }

        private void notifiIcon_Click(object sender, EventArgs e)
        {
            backToNormalState();
        }
    }
}
