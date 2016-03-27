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

        private PlayControl.PlayControl playControl;

        public app()
        {
            InitializeComponent();
            //this.DragEnter += new DragEventHandler(app_DragEnter);
            this.DragDrop += new DragEventHandler(app_DragDrop);
            files.Text = readFromUserconfig();
            //       loadPlaylist();
            notifiIcon.ContextMenu = new ContextMenu(new MenuItem[] { 
                new MenuItem("Exit", exit),
            });

            playControl = new PlayControl.PlayControl(this.Handle);
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
            if (m.Msg == PlayControl.PlayControl.MM_MCINOTIFY)
            {
                playControl.messageListener(m.WParam.ToInt32());
            }
            base.WndProc(ref m);
        }

        ////////////////Internal functions////////////////
        //Minimize the window to system tray and hide in taskbar.
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

        private void writeToUserconfig(String data)
        {
            System.IO.File.WriteAllText(@".\userconfig.conf", data);
        }

        private string readFromUserconfig()
        {
            try { return System.IO.File.ReadAllText(@".\userconfig.conf"); }
            catch (FileNotFoundException) { return ""; }
            catch (Exception) { return ""; }
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
            //TODO
        }
        private void tokenizer(string cmd)
        {
            //TODO
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
                    case "start": writeToUserconfig(files.Text); interpreterEnabled = true; autosave = false; files.Text = ""; files.Focus(); break;
                    // case "goback": files.Text = readFile(@".\userconfig.conf"); loadPlaylist(); interpreterEnabled = false; autosave = true; break;
                    //  case "mute": setVolume(0); break;
                }

                //mciSendString(command.Text, null, 0, IntPtr.Zero);
                command.Text = "";
            }
        }

        ////////////////Events////////////////
        private void play_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void next_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void previous_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void stop_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void pause_click(object sender, EventArgs e)
        {
            //TODO
        }

        private void files_TextChanged(object sender, EventArgs e)
        {
            //TODO
        }

        private void app_Resize(object sender, EventArgs e)
        {
            minimizeToSystemTray();
        }

        private void notifiIcon_Click(object sender, EventArgs e)
        {
            restoreWindow();
        }

        //Weird bug. If I drop anything here, this function will be called 2 times.
        private int times = 0;
        private void app_DragDrop(object sender, DragEventArgs e)
        {
            if (times >= 1) { times = 0; return; }
            times++;
            //TODO
        }

        private void app_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            //TODO
        }

        private void increaseVolume_Click(object sender, EventArgs e)
        {
            playControl.setVolume(PlayControl.PlayControl.ChangeVolume.INCR5);
        }

        private void decreaseVolume_Click(object sender, EventArgs e)
        {
            playControl.setVolume(PlayControl.PlayControl.ChangeVolume.DECR5);
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
            toolTip1.SetToolTip(filename, playControl.getPlayingFile());
            //TODO
        }

        private void loop_CheckedChanged(object sender, EventArgs e)
        {
            //TODO
        }

        private void loopAll_CheckedChanged(object sender, EventArgs e)
        {
            //TODO
        }

        private void playOnce_CheckedChanged(object sender, EventArgs e)
        {
            //TODO
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
