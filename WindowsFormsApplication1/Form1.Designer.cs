namespace PatkaPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayer));
            this.panelButtons = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.labelTotalClips = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelClipsPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLastPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTest = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelToolStripLine = new System.Windows.Forms.Panel();
            this.toolStripSettings = new System.Windows.Forms.ToolStrip();
            this.btnDropdown = new System.Windows.Forms.ToolStripButton();
            this.toolStripFilters = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtFilterFolder = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtFilterFile = new System.Windows.Forms.ToolStripTextBox();
            this.btnClearFilters = new System.Windows.Forms.ToolStripButton();
            this.toolStripPlay = new System.Windows.Forms.ToolStrip();
            this.btnRandom = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnReplay = new System.Windows.Forms.ToolStripButton();
            this.checkRepeat = new System.Windows.Forms.ToolStripButton();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuFolders = new System.Windows.Forms.MenuItem();
            this.menuSettings = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuReload = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuTimer1 = new System.Windows.Forms.MenuItem();
            this.menuTimer2 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuToggle = new System.Windows.Forms.MenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.toolStripSettings.SuspendLayout();
            this.toolStripFilters.SuspendLayout();
            this.toolStripPlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.AutoScroll = true;
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelButtons.ForeColor = System.Drawing.Color.Black;
            this.panelButtons.Location = new System.Drawing.Point(0, 1);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1133, 518);
            this.panelButtons.TabIndex = 9;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelToolStripLine);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelButtons);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1134, 519);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1134, 645);
            this.toolStripContainer1.TabIndex = 19;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripSettings);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripFilters);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripPlay);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelTotalClips,
            this.labelClipsPlayed,
            this.labelTimer1,
            this.labelTimer2,
            this.labelLastPlayed,
            this.labelTest});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1134, 24);
            this.statusStrip2.TabIndex = 0;
            // 
            // labelTotalClips
            // 
            this.labelTotalClips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalClips.Name = "labelTotalClips";
            this.labelTotalClips.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelTotalClips.Size = new System.Drawing.Size(54, 19);
            this.labelTotalClips.Text = "Clips: -";
            // 
            // labelClipsPlayed
            // 
            this.labelClipsPlayed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelClipsPlayed.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelClipsPlayed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClipsPlayed.Name = "labelClipsPlayed";
            this.labelClipsPlayed.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelClipsPlayed.Size = new System.Drawing.Size(89, 19);
            this.labelClipsPlayed.Text = "Play count: 0";
            // 
            // labelTimer1
            // 
            this.labelTimer1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelTimer1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelTimer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTimer1.Name = "labelTimer1";
            this.labelTimer1.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelTimer1.Size = new System.Drawing.Size(89, 19);
            this.labelTimer1.Text = "Timer 1: Off";
            this.labelTimer1.Click += new System.EventHandler(this.labelTimer1_Click);
            // 
            // labelTimer2
            // 
            this.labelTimer2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelTimer2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelTimer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTimer2.Name = "labelTimer2";
            this.labelTimer2.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelTimer2.Size = new System.Drawing.Size(89, 19);
            this.labelTimer2.Text = "Timer 2: Off";
            this.labelTimer2.Click += new System.EventHandler(this.labelTimer2_Click);
            // 
            // labelLastPlayed
            // 
            this.labelLastPlayed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelLastPlayed.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelLastPlayed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelLastPlayed.Name = "labelLastPlayed";
            this.labelLastPlayed.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelLastPlayed.Size = new System.Drawing.Size(31, 19);
            this.labelLastPlayed.Text = "-";
            this.labelLastPlayed.Click += new System.EventHandler(this.labelLastPlayed_Click);
            // 
            // labelTest
            // 
            this.labelTest.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTest.Name = "labelTest";
            this.labelTest.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelTest.Size = new System.Drawing.Size(15, 19);
            // 
            // panelToolStripLine
            // 
            this.panelToolStripLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelToolStripLine.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelToolStripLine.ForeColor = System.Drawing.Color.Black;
            this.panelToolStripLine.Location = new System.Drawing.Point(0, 1);
            this.panelToolStripLine.Name = "panelToolStripLine";
            this.panelToolStripLine.Size = new System.Drawing.Size(1151, 1);
            this.panelToolStripLine.TabIndex = 10;
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDropdown});
            this.toolStripSettings.Location = new System.Drawing.Point(3, 0);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripSettings.Size = new System.Drawing.Size(71, 34);
            this.toolStripSettings.TabIndex = 2;
            // 
            // btnDropdown
            // 
            this.btnDropdown.AutoToolTip = false;
            this.btnDropdown.Image = global::patka.Properties.Resources.dropdownarrow;
            this.btnDropdown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDropdown.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDropdown.Size = new System.Drawing.Size(68, 29);
            this.btnDropdown.Text = "Options";
            this.btnDropdown.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDropdown.Click += new System.EventHandler(this.btnDropdown_Click);
            // 
            // toolStripFilters
            // 
            this.toolStripFilters.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.toolStripFilters.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFilters.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFilters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtFilterFolder,
            this.toolStripLabel2,
            this.txtFilterFile,
            this.btnClearFilters});
            this.toolStripFilters.Location = new System.Drawing.Point(3, 34);
            this.toolStripFilters.Name = "toolStripFilters";
            this.toolStripFilters.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripFilters.Size = new System.Drawing.Size(379, 34);
            this.toolStripFilters.TabIndex = 3;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 29);
            this.toolStripLabel1.Text = "Folder Filter";
            // 
            // txtFilterFolder
            // 
            this.txtFilterFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.txtFilterFolder.Margin = new System.Windows.Forms.Padding(1, 3, 1, 0);
            this.txtFilterFolder.Name = "txtFilterFolder";
            this.txtFilterFolder.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtFilterFolder.Size = new System.Drawing.Size(70, 31);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.toolStripLabel2.Size = new System.Drawing.Size(60, 29);
            this.toolStripLabel2.Text = "File Filter";
            // 
            // txtFilterFile
            // 
            this.txtFilterFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.txtFilterFile.Margin = new System.Windows.Forms.Padding(1, 3, 1, 0);
            this.txtFilterFile.Name = "txtFilterFile";
            this.txtFilterFile.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtFilterFile.Size = new System.Drawing.Size(70, 31);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.AutoToolTip = false;
            this.btnClearFilters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearFilters.Enabled = false;
            this.btnClearFilters.Image = ((System.Drawing.Image)(resources.GetObject("btnClearFilters.Image")));
            this.btnClearFilters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearFilters.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClearFilters.Size = new System.Drawing.Size(78, 29);
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // toolStripPlay
            // 
            this.toolStripPlay.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripPlay.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripPlay.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPlay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRandom,
            this.btnStop,
            this.btnReplay,
            this.checkRepeat});
            this.toolStripPlay.Location = new System.Drawing.Point(3, 68);
            this.toolStripPlay.Name = "toolStripPlay";
            this.toolStripPlay.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripPlay.Size = new System.Drawing.Size(158, 34);
            this.toolStripPlay.TabIndex = 1;
            // 
            // btnRandom
            // 
            this.btnRandom.AutoToolTip = false;
            this.btnRandom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRandom.Image = ((System.Drawing.Image)(resources.GetObject("btnRandom.Image")));
            this.btnRandom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRandom.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRandom.Size = new System.Drawing.Size(62, 29);
            this.btnRandom.Text = "Random";
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnStop
            // 
            this.btnStop.AutoToolTip = false;
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnStop.Size = new System.Drawing.Size(41, 29);
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.AutoToolTip = false;
            this.btnReplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReplay.Image = ((System.Drawing.Image)(resources.GetObject("btnReplay.Image")));
            this.btnReplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplay.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnReplay.Size = new System.Drawing.Size(52, 29);
            this.btnReplay.Tag = "";
            this.btnReplay.Text = "Replay";
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // checkRepeat
            // 
            this.checkRepeat.AutoToolTip = false;
            this.checkRepeat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.checkRepeat.Image = ((System.Drawing.Image)(resources.GetObject("checkRepeat.Image")));
            this.checkRepeat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkRepeat.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.checkRepeat.Name = "checkRepeat";
            this.checkRepeat.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.checkRepeat.Size = new System.Drawing.Size(53, 29);
            this.checkRepeat.Text = "Repeat";
            this.checkRepeat.Visible = false;
            this.checkRepeat.Click += new System.EventHandler(this.checkRepeat_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 175);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFolders,
            this.menuSettings,
            this.menuItem2,
            this.menuReload,
            this.menuItem6,
            this.menuTimer1,
            this.menuTimer2,
            this.menuItem7,
            this.menuToggle});
            // 
            // menuFolders
            // 
            this.menuFolders.Index = 0;
            this.menuFolders.Text = "Folders...";
            this.menuFolders.Click += new System.EventHandler(this.menuFolders_Click);
            // 
            // menuSettings
            // 
            this.menuSettings.Index = 1;
            this.menuSettings.Text = "Settings...";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // menuReload
            // 
            this.menuReload.Index = 3;
            this.menuReload.Text = "Reload";
            this.menuReload.Click += new System.EventHandler(this.menuReload_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "-";
            // 
            // menuTimer1
            // 
            this.menuTimer1.Index = 5;
            this.menuTimer1.Text = "Start Timer 1";
            this.menuTimer1.Click += new System.EventHandler(this.menuTimer1_Click);
            // 
            // menuTimer2
            // 
            this.menuTimer2.Index = 6;
            this.menuTimer2.Text = "Start Timer 2";
            this.menuTimer2.Click += new System.EventHandler(this.menuTimer2_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "-";
            // 
            // menuToggle
            // 
            this.menuToggle.Index = 8;
            this.menuToggle.Text = "Switch to MiniPlayer";
            this.menuToggle.Click += new System.EventHandler(this.menuToggle_Click);
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1134, 645);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(900, 97);
            this.Name = "frmPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pätkä Player";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.toolStripSettings.ResumeLayout(false);
            this.toolStripSettings.PerformLayout();
            this.toolStripFilters.ResumeLayout(false);
            this.toolStripFilters.PerformLayout();
            this.toolStripPlay.ResumeLayout(false);
            this.toolStripPlay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStripPlay;
        private System.Windows.Forms.ToolStripButton btnRandom;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnReplay;
        private System.Windows.Forms.ToolStrip toolStripSettings;
        private System.Windows.Forms.ToolStrip toolStripFilters;
        private System.Windows.Forms.ToolStripTextBox txtFilterFolder;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtFilterFile;
        private System.Windows.Forms.ToolStripButton checkRepeat;
        private System.Windows.Forms.Panel panelToolStripLine;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel labelLastPlayed;
        private System.Windows.Forms.ToolStripStatusLabel labelTotalClips;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripStatusLabel labelTimer1;
        private System.Windows.Forms.ToolStripButton btnClearFilters;
        private System.Windows.Forms.ToolStripStatusLabel labelClipsPlayed;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuTimer1;
        private System.Windows.Forms.MenuItem menuTimer2;
        private System.Windows.Forms.MenuItem menuSettings;
        private System.Windows.Forms.MenuItem menuReload;
        private System.Windows.Forms.MenuItem menuToggle;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.ToolStripButton btnDropdown;
        private System.Windows.Forms.ToolStripStatusLabel labelTimer2;
        private System.Windows.Forms.ToolStripStatusLabel labelTest;
        private System.Windows.Forms.MenuItem menuFolders;
        private System.Windows.Forms.MenuItem menuItem2;
    }
}

