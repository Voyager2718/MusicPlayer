﻿namespace MusicPlayer
{
    partial class app
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(app));
            this.files = new System.Windows.Forms.RichTextBox();
            this.play = new System.Windows.Forms.Button();
            this.stp = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.filename = new System.Windows.Forms.Label();
            this.loop = new System.Windows.Forms.RadioButton();
            this.loopAll = new System.Windows.Forms.RadioButton();
            this.playOnce = new System.Windows.Forms.RadioButton();
            this.volume = new System.Windows.Forms.Label();
            this.vol = new System.Windows.Forms.Label();
            this.increaseVolume = new System.Windows.Forms.Button();
            this.decreaseVolume = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.copyright = new System.Windows.Forms.Label();
            this.ps = new System.Windows.Forms.Button();
            this.notifiIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.command = new System.Windows.Forms.TextBox();
            this.launch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // files
            // 
            this.files.Location = new System.Drawing.Point(13, 13);
            this.files.Name = "files";
            this.files.Size = new System.Drawing.Size(652, 387);
            this.files.TabIndex = 0;
            this.files.Text = "";
            this.files.TextChanged += new System.EventHandler(this.files_TextChanged);
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(672, 13);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(179, 30);
            this.play.TabIndex = 1;
            this.play.Text = "Play";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // stp
            // 
            this.stp.Location = new System.Drawing.Point(672, 49);
            this.stp.Name = "stp";
            this.stp.Size = new System.Drawing.Size(179, 30);
            this.stp.TabIndex = 2;
            this.stp.Text = "Stop";
            this.stp.UseVisualStyleBackColor = true;
            this.stp.Click += new System.EventHandler(this.stop_Click);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(761, 121);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(90, 30);
            this.next.TabIndex = 3;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(671, 121);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(91, 30);
            this.previous.TabIndex = 4;
            this.previous.Text = "Previous";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filename.Location = new System.Drawing.Point(671, 154);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(17, 20);
            this.filename.TabIndex = 5;
            this.filename.Text = "..";
            this.filename.MouseHover += new System.EventHandler(this.filename_MouseHover);
            // 
            // loop
            // 
            this.loop.AutoSize = true;
            this.loop.Location = new System.Drawing.Point(675, 337);
            this.loop.Name = "loop";
            this.loop.Size = new System.Drawing.Size(61, 21);
            this.loop.TabIndex = 6;
            this.loop.Text = "Loop";
            this.loop.UseVisualStyleBackColor = true;
            this.loop.CheckedChanged += new System.EventHandler(this.loop_CheckedChanged);
            // 
            // loopAll
            // 
            this.loopAll.AutoSize = true;
            this.loopAll.Location = new System.Drawing.Point(675, 364);
            this.loopAll.Name = "loopAll";
            this.loopAll.Size = new System.Drawing.Size(79, 21);
            this.loopAll.TabIndex = 7;
            this.loopAll.Text = "Loop all";
            this.loopAll.UseVisualStyleBackColor = true;
            this.loopAll.CheckedChanged += new System.EventHandler(this.loopAll_CheckedChanged);
            // 
            // playOnce
            // 
            this.playOnce.AutoSize = true;
            this.playOnce.Checked = true;
            this.playOnce.Location = new System.Drawing.Point(675, 391);
            this.playOnce.Name = "playOnce";
            this.playOnce.Size = new System.Drawing.Size(91, 21);
            this.playOnce.TabIndex = 8;
            this.playOnce.TabStop = true;
            this.playOnce.Text = "Play once";
            this.playOnce.UseVisualStyleBackColor = true;
            this.playOnce.CheckedChanged += new System.EventHandler(this.playOnce_CheckedChanged);
            // 
            // volume
            // 
            this.volume.AutoSize = true;
            this.volume.Location = new System.Drawing.Point(730, 317);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(32, 17);
            this.volume.TabIndex = 9;
            this.volume.Text = "100";
            // 
            // vol
            // 
            this.vol.AutoSize = true;
            this.vol.Location = new System.Drawing.Point(669, 317);
            this.vol.Name = "vol";
            this.vol.Size = new System.Drawing.Size(63, 17);
            this.vol.TabIndex = 10;
            this.vol.Text = "Volume :";
            // 
            // increaseVolume
            // 
            this.increaseVolume.Location = new System.Drawing.Point(671, 284);
            this.increaseVolume.Name = "increaseVolume";
            this.increaseVolume.Size = new System.Drawing.Size(75, 30);
            this.increaseVolume.TabIndex = 11;
            this.increaseVolume.Text = "+";
            this.increaseVolume.UseVisualStyleBackColor = true;
            this.increaseVolume.Click += new System.EventHandler(this.increaseVolume_Click);
            // 
            // decreaseVolume
            // 
            this.decreaseVolume.Location = new System.Drawing.Point(752, 284);
            this.decreaseVolume.Name = "decreaseVolume";
            this.decreaseVolume.Size = new System.Drawing.Size(75, 30);
            this.decreaseVolume.TabIndex = 12;
            this.decreaseVolume.Text = "-";
            this.decreaseVolume.UseVisualStyleBackColor = true;
            this.decreaseVolume.Click += new System.EventHandler(this.decreaseVolume_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.status.Location = new System.Drawing.Point(671, 174);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(73, 20);
            this.status.TabIndex = 13;
            this.status.Text = "Waiting..";
            this.status.Click += new System.EventHandler(this.status_Click);
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.copyright.Location = new System.Drawing.Point(668, 415);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(131, 20);
            this.copyright.TabIndex = 14;
            this.copyright.Text = "Copyright YANG";
            // 
            // ps
            // 
            this.ps.Location = new System.Drawing.Point(672, 85);
            this.ps.Name = "ps";
            this.ps.Size = new System.Drawing.Size(179, 30);
            this.ps.TabIndex = 15;
            this.ps.Text = "Pause";
            this.ps.UseVisualStyleBackColor = true;
            this.ps.Click += new System.EventHandler(this.pause_click);
            // 
            // notifiIcon
            // 
            this.notifiIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifiIcon.Icon")));
            this.notifiIcon.Text = "My Music Player";
            this.notifiIcon.Visible = true;
            this.notifiIcon.Click += new System.EventHandler(this.notifiIcon_Click);
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(13, 410);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(568, 22);
            this.command.TabIndex = 16;
            this.command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.command_KeyDown);
            // 
            // launch
            // 
            this.launch.Location = new System.Drawing.Point(587, 406);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(75, 30);
            this.launch.TabIndex = 17;
            this.launch.Text = "Launch";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.launch_Click);
            // 
            // app
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 444);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.command);
            this.Controls.Add(this.ps);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.status);
            this.Controls.Add(this.decreaseVolume);
            this.Controls.Add(this.increaseVolume);
            this.Controls.Add(this.vol);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.playOnce);
            this.Controls.Add(this.loopAll);
            this.Controls.Add(this.loop);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.next);
            this.Controls.Add(this.stp);
            this.Controls.Add(this.play);
            this.Controls.Add(this.files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "app";
            this.Text = "My Music Player";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.app_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.app_DragEnter);
            this.Resize += new System.EventHandler(this.app_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox files;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.RadioButton loop;
        private System.Windows.Forms.RadioButton loopAll;
        private System.Windows.Forms.RadioButton playOnce;
        private System.Windows.Forms.Label volume;
        private System.Windows.Forms.Label vol;
        private System.Windows.Forms.Button increaseVolume;
        private System.Windows.Forms.Button decreaseVolume;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Button ps;
        private System.Windows.Forms.Button stp;
        private System.Windows.Forms.NotifyIcon notifiIcon;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.Button launch;
    }
}

