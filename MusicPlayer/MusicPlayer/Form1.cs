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

        private string writeBuffer;

        private PlayControl.PlayControl playControl;

        public app()
        {
            InitializeComponent();
            //this.DragEnter += new DragEventHandler(app_DragEnter);
            this.DragDrop += new DragEventHandler(app_DragDrop);
            files.Text = readFile(@".\userconfig.conf");
            //       loadPlaylist();
            notifiIcon.ContextMenu = new ContextMenu(new MenuItem[] { 
                new MenuItem("Exit", exit),
            });
        }

        private void exit(object sender, EventArgs e)
        {
            notifiIcon.Visible = false;
            System.Environment.Exit(0);
        }

        private void exit()
        {
            notifiIcon.Visible = false;
            System.Environment.Exit(0);
        }

        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == MM_MCINOTIFY)
            //{
            //    //MessageBox.Show(loop.Checked.ToString() + " " + loopAll.Checked.ToString());
            //    switch (m.WParam.ToInt32())
            //    {
            //        case MCI_NOTIFY_SUCCESS:
            //            if (!loop.Checked && !loopAll.Checked)
            //                Stop();
            //            if (loopAll.Checked)
            //                playNext();
            //            //messagebox.Show("1");
            //            break;
            //        case MCI_NOTIFY_SUPERSEDED:
            //            //MessageBox.Show("2");
            //            break;
            //        case MCI_NOTIFY_FAILURE:
            //            //MessageBox.Show("3");
            //            break;
            //        case MCI_NOTIFY_ABORTED:
            //            //MessageBox.Show("4");
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //base.WndProc(ref m);
        }

        private void setFilename()
        {

        }

        private void play_Click(object sender, EventArgs e)
        {

        }

        private void playNext()
        {

        }

        private void next_Click(object sender, EventArgs e)
        {

        }

        private void previous_Click(object sender, EventArgs e)
        {

        }

        private void stop_Click(object sender, EventArgs e)
        {

        }

        private void pause_click(object sender, EventArgs e)
        {

        }

        private void files_TextChanged(object sender, EventArgs e)
        {

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

        }

        private void decreaseVolume_Click(object sender, EventArgs e)
        {

        }

        private void setCommand(string cmd)
        {
            string[] cmds = cmd.Split(' ');
            if (cmds.Length == 2)
                ;
            else if (cmds.Length == 3)
                switch (cmds[1])
                {
                    //case "vol": int v = 0; if (int.TryParse(cmds[2], out v)) setVolume(v); break;
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
                    // case "goback": files.Text = readFile(@".\userconfig.conf"); loadPlaylist(); interpreterEnabled = false; autosave = true; break;
                    //  case "mute": setVolume(0); break;
                }

                //mciSendString(command.Text, null, 0, IntPtr.Zero);
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
            //toolTip1.SetToolTip(filename, getPlayingFilename());
        }

        private void loop_CheckedChanged(object sender, EventArgs e)
        {
            //mciSendString("REPEAT", null, 0, this.Handle);
        }


        //get version
        private int cheat = 0;
        private void status_Click(object sender, EventArgs e)
        {
            if (++cheat >= 2)
            {
                MessageBox.Show("v0.01.1100");
                cheat = 0;
            }
        }
    }
}
