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
    public partial class Form1 : Form
    {
        private String playing;

        private string _command;
        private bool isOpen;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public Form1()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, EventArgs e)
        {
            String[] musicFiles = files.Text.Trim().Replace("\n", "").Split(';');
            Open(musicFiles[0]);
            playing = musicFiles[0];
            Play(false);
            playing = musicFiles[0];
            filename.Text = Path.GetFileNameWithoutExtension(playing);
        }

        private void Open(string sFileName)
        {
            _command = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        private void Stop()
        {
            status.Text = "Waiting..";

            _command = "close MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
            isOpen = false;
        }

        private void Play(bool loop)
        {
            status.Text = "Playing..";

            if (isOpen)
            {
                _command = "play MediaFile";
                if (loop)
                    _command += " REPEAT";
                mciSendString(_command, null, 0, IntPtr.Zero);
            }
        }
    }
}
