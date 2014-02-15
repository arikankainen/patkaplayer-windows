namespace WindowsFormsApplication1
{
    partial class frmPlayer
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
            if (disposing)
            {
                if (_mp3Player != null) _mp3Player.Dispose();
            }

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
            this.btnStop = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.checkRepeat = new System.Windows.Forms.CheckBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtPlaying = new System.Windows.Forms.TextBox();
            this.btnReplay = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Location = new System.Drawing.Point(724, 632);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(345, 20);
            this.txtPath.TabIndex = 3;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolder.Location = new System.Drawing.Point(618, 630);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(100, 23);
            this.btnSelectFolder.TabIndex = 8;
            this.btnSelectFolder.Text = "Select Folder...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.AutoScroll = true;
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButtons.ForeColor = System.Drawing.Color.Black;
            this.panelButtons.Location = new System.Drawing.Point(10, 45);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1165, 576);
            this.panelButtons.TabIndex = 9;
            // 
            // checkRepeat
            // 
            this.checkRepeat.Location = new System.Drawing.Point(251, 12);
            this.checkRepeat.Name = "checkRepeat";
            this.checkRepeat.Size = new System.Drawing.Size(104, 24);
            this.checkRepeat.TabIndex = 0;
            this.checkRepeat.Text = "Repeat";
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.Location = new System.Drawing.Point(1075, 630);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(100, 23);
            this.btnReload.TabIndex = 0;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtPlaying
            // 
            this.txtPlaying.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaying.BackColor = System.Drawing.Color.White;
            this.txtPlaying.Location = new System.Drawing.Point(721, 13);
            this.txtPlaying.Name = "txtPlaying";
            this.txtPlaying.ReadOnly = true;
            this.txtPlaying.Size = new System.Drawing.Size(345, 20);
            this.txtPlaying.TabIndex = 11;
            // 
            // btnReplay
            // 
            this.btnReplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplay.Location = new System.Drawing.Point(1072, 11);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(100, 23);
            this.btnReplay.TabIndex = 0;
            this.btnReplay.Tag = "nofile";
            this.btnReplay.Text = "Replay";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(118, 12);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(100, 23);
            this.btnRandom.TabIndex = 0;
            this.btnRandom.Text = "Random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Last Played:";
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1184, 662);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlaying);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.checkRepeat);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.panelButtons);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "frmPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pätkä Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.CheckBox checkRepeat;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox txtPlaying;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Label label1;
    }
}

