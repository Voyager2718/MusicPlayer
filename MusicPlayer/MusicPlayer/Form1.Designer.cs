namespace MusicPlayer
{
    partial class Form1
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
            this.files = new System.Windows.Forms.RichTextBox();
            this.play = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // files
            // 
            this.files.Location = new System.Drawing.Point(13, 13);
            this.files.Name = "files";
            this.files.Size = new System.Drawing.Size(652, 419);
            this.files.TabIndex = 0;
            this.files.Text = "";
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
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(672, 49);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(179, 30);
            this.pause.TabIndex = 2;
            this.pause.Text = "Stop";
            this.pause.UseVisualStyleBackColor = true;
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(672, 85);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(179, 30);
            this.next.TabIndex = 3;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(672, 121);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(179, 30);
            this.previous.TabIndex = 4;
            this.previous.Text = "Previous";
            this.previous.UseVisualStyleBackColor = true;
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filename.Location = new System.Drawing.Point(671, 154);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(77, 20);
            this.filename.TabIndex = 5;
            this.filename.Text = "Filename";
            // 
            // loop
            // 
            this.loop.AutoSize = true;
            this.loop.Location = new System.Drawing.Point(675, 337);
            this.loop.Name = "loop";
            this.loop.Size = new System.Drawing.Size(61, 21);
            this.loop.TabIndex = 6;
            this.loop.TabStop = true;
            this.loop.Text = "Loop";
            this.loop.UseVisualStyleBackColor = true;
            // 
            // loopAll
            // 
            this.loopAll.AutoSize = true;
            this.loopAll.Location = new System.Drawing.Point(675, 364);
            this.loopAll.Name = "loopAll";
            this.loopAll.Size = new System.Drawing.Size(79, 21);
            this.loopAll.TabIndex = 7;
            this.loopAll.TabStop = true;
            this.loopAll.Text = "Loop all";
            this.loopAll.UseVisualStyleBackColor = true;
            // 
            // playOnce
            // 
            this.playOnce.AutoSize = true;
            this.playOnce.Location = new System.Drawing.Point(675, 391);
            this.playOnce.Name = "playOnce";
            this.playOnce.Size = new System.Drawing.Size(91, 21);
            this.playOnce.TabIndex = 8;
            this.playOnce.TabStop = true;
            this.playOnce.Text = "Play once";
            this.playOnce.UseVisualStyleBackColor = true;
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
            // 
            // decreaseVolume
            // 
            this.decreaseVolume.Location = new System.Drawing.Point(752, 284);
            this.decreaseVolume.Name = "decreaseVolume";
            this.decreaseVolume.Size = new System.Drawing.Size(75, 30);
            this.decreaseVolume.TabIndex = 12;
            this.decreaseVolume.Text = "-";
            this.decreaseVolume.UseVisualStyleBackColor = true;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.status.Location = new System.Drawing.Point(671, 178);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(73, 20);
            this.status.TabIndex = 13;
            this.status.Text = "Waiting..";
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.copyright.Location = new System.Drawing.Point(720, 415);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(131, 20);
            this.copyright.TabIndex = 14;
            this.copyright.Text = "Copyright YANG";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 444);
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
            this.Controls.Add(this.pause);
            this.Controls.Add(this.play);
            this.Controls.Add(this.files);
            this.Name = "Form1";
            this.Text = "My Music Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox files;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button pause;
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
    }
}

