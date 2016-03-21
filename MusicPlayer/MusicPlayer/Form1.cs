using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Media;

namespace MusicPlayer
{
    public partial class app : Form
    {
        private bool minimizedToSystemTray = false;

        private bool autosave = true;
        private bool interpreterEnabled = false;

        private String[] playlist;
        private int playPosition = -1;
        private int musicVolume = 100;

        private bool playing = false;
        private bool paused = false;

        private string _command;
        private bool fileOpened;

        private string writeBuffer;

        //Volume
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;
        private const int APPCOMMAND_VOLUME_UP = 10 * 65536;
        private const int APPCOMMAND_VOLUME_DOWN = 9 * 65536;

        //
        private const int MM_MCINOTIFY = 0x03b9;
        private const int MCI_NOTIFY_SUCCESS = 0x01;
        private const int MCI_NOTIFY_SUPERSEDED = 0x02;
        private const int MCI_NOTIFY_ABORTED = 0x04;
        private const int MCI_NOTIFY_FAILURE = 0x08;

        //dll
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public app()
        {
            InitializeComponent();
            //this.DragEnter += new DragEventHandler(app_DragEnter);
            this.DragDrop += new DragEventHandler(app_DragDrop);
            files.Text = readFile(@".\userconfig.conf");
            loadPlaylist();
            notifiIcon.ContextMenu = new ContextMenu(new MenuItem[] { 
                new MenuItem("Exit", exit),
            });
        }

        private void exit(object sender, EventArgs e)
        {
            exit();
        }

        private void exit()
        {
            notifiIcon.Visible = false;
            System.Environment.Exit(0);
        }

        private void Open(string sFileName)
        {
            _command = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
            fileOpened = true;
            setVolume(musicVolume);
        }

        private void Stop()
        {
            status.Text = "Waiting..";
            paused = false;
            ps.Text = "Pause";

            _command = "close MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
            fileOpened = false;
        }

        private void Play(bool loop)
        {
            if (playlist.Length == 0) return;
            if (fileOpened)
            {
                _command = "play MediaFile notify";
                if (loop)
                    _command += " REPEAT";
                mciSendString(_command, null, 0, this.Handle);
                status.Text = "Playing..";
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MM_MCINOTIFY)
            {
                switch (m.WParam.ToInt32())
                {
                    case MCI_NOTIFY_SUCCESS:
                        if (!loop.Checked && !loopAll.Checked)
                            Stop();
                        if (loopAll.Checked)
                            playNext();
                        //MessageBox.Show("1");
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
            base.WndProc(ref m);
        }

        private void setVolume(int vol)
        {
            if (vol > 100) vol = 100;
            if (vol < 0) vol = 0;
            musicVolume = vol;
            mciSendString("setaudio MediaFile volume to " + musicVolume.ToString(), null, 0, IntPtr.Zero);
            volume.Text = musicVolume.ToString();
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

        private string getPlayingFilename()
        {
            try { return Path.GetFileNameWithoutExtension(playlist[playPosition]); }
            catch (IndexOutOfRangeException) { return ""; }
        }

        private void setFilename()
        {
            String fn = getPlayingFilename();
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
                ps.Text = "Pause";
                paused = false;
            }
            catch (NullReferenceException) { }
        }

        private void playNext()
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

        private void playPrevious()
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

        private void next_Click(object sender, EventArgs e)
        {
            playNext();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            playPrevious();
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
            if (!interpreterEnabled)
            {
                loadPlaylist();
                if (autosave)
                {
                    addStringToWriteBuffer(files.Text);
                    writeBufferToFile();
                }
            }
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
                this.notifiIcon.Text = "Click to restore window";
            }
        }

        //Restore windows
        private void restoreWindow()
        {
            minimizedToSystemTray = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void app_Resize(object sender, EventArgs e)
        {
            minimizeToSystemTray();
        }

        private void notifiIcon_Click(object sender, EventArgs e)
        {
            restoreWindow();
        }

        private void addStringToWriteBuffer(String s)
        {
            writeBuffer += s;
        }

        private void writeBufferToFile()
        {
            System.IO.File.WriteAllText(@".\userconfig.conf", writeBuffer);
            writeBuffer = "";
        }

        private string readFile(string path)
        {
            try { return System.IO.File.ReadAllText(path); }
            catch (FileNotFoundException) { return ""; }
        }

        //Weird bug. If I drop anything here, this function will be called 2 times.
        private int times = 0;
        private void app_DragDrop(object sender, DragEventArgs e)
        {
            if (times >= 1) { times = 0; return; }
            times++;
            string paths = "";
            string[] musics = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string music in musics) paths += music;
            files.Text += ";" + paths;
        }

        private void app_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void increaseVolume_Click(object sender, EventArgs e)
        {
            setVolume(musicVolume + 5);
        }

        private void decreaseVolume_Click(object sender, EventArgs e)
        {
            setVolume(musicVolume - 5);
        }

        private void setCommand(string cmd)
        {
            string[] cmds = cmd.Split(' ');
            if (cmds.Length == 2)
                ;
            else if (cmds.Length == 3)
                switch (cmds[1])
                {
                    case "vol": int v = 0; if (int.TryParse(cmds[2], out v)) setVolume(v); break;
                }
        }

        private void parser(string cmd)
        {

        }
        private void tokenizer(string cmd)
        {

        }

        private void interpreter(string cmd)
        {
            string[] cmds = cmd.Split(';');
            foreach (string c in cmds)
            {
                if (c.Substring(0, 3) == "set") setCommand(c);
                switch (c.ToLower())
                {
                    case "q": exit(); break;
                    case "exit": exit(); break;
                    case "start": addStringToWriteBuffer(files.Text); writeBufferToFile(); interpreterEnabled = true; autosave = false; files.Text = ""; files.Focus(); break;
                    case "goback": files.Text = readFile(@".\userconfig.conf"); loadPlaylist(); interpreterEnabled = false; autosave = true; break;
                    case "mute": setVolume(0); break;
                }

                mciSendString(command.Text, null, 0, IntPtr.Zero);
                command.Text = "";
            }
        }

        private void launch_Click(object sender, EventArgs e)
        {
            interpreter(command.Text);
        }

        private void command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                interpreter(command.Text);
        }

        private void filename_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(filename, getPlayingFilename());
        }

        private void loop_CheckedChanged(object sender, EventArgs e)
        {
            mciSendString("REPEAT", null, 0, this.Handle);
        }
    }
}
