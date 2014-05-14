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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayer));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.labelTotalClips = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelClipsPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLastPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTest = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.panelToolStripLine = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSettings = new System.Windows.Forms.ToolStrip();
            this.btnHide = new System.Windows.Forms.ToolStripButton();
            this.btnToggle = new System.Windows.Forms.ToolStripButton();
            this.btnDropdown = new System.Windows.Forms.ToolStripButton();
            this.toolStripFilters = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtFilterFolder = new System.Windows.Forms.ToolStripTextBox();
            this.btnClearFilters = new System.Windows.Forms.ToolStripButton();
            this.txtFilterFile = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripPlay = new System.Windows.Forms.ToolStrip();
            this.btnRandom = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnReplay = new System.Windows.Forms.ToolStripButton();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuFolders = new System.Windows.Forms.MenuItem();
            this.menuSettings = new System.Windows.Forms.MenuItem();
            this.menuTimers = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuReload = new System.Windows.Forms.MenuItem();
            this.menuCenter = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuTimer1 = new System.Windows.Forms.MenuItem();
            this.menuTimer2 = new System.Windows.Forms.MenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelButtons);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelToolStripLine);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1120, 516);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1120, 645);
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
            this.statusStrip2.Size = new System.Drawing.Size(1120, 24);
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
            this.labelClipsPlayed.Size = new System.Drawing.Size(91, 19);
            this.labelClipsPlayed.Text = "Play Count: 0";
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
            this.labelTimer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTimer1_Click);
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
            this.labelTimer2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTimer2_Click);
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
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.AutoScroll = true;
            this.panelButtons.Location = new System.Drawing.Point(0, 2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelButtons.Size = new System.Drawing.Size(1119, 515);
            this.panelButtons.TabIndex = 12;
            // 
            // panelToolStripLine
            // 
            this.panelToolStripLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelToolStripLine.BackColor = System.Drawing.Color.Gray;
            this.panelToolStripLine.ForeColor = System.Drawing.Color.Black;
            this.panelToolStripLine.Location = new System.Drawing.Point(0, 1);
            this.panelToolStripLine.Name = "panelToolStripLine";
            this.panelToolStripLine.Size = new System.Drawing.Size(1137, 1);
            this.panelToolStripLine.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 11;
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStripSettings.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHide,
            this.btnToggle,
            this.btnDropdown});
            this.toolStripSettings.Location = new System.Drawing.Point(3, 0);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripSettings.Size = new System.Drawing.Size(124, 35);
            this.toolStripSettings.TabIndex = 2;
            // 
            // btnHide
            // 
            this.btnHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHide.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnHide.Name = "btnHide";
            this.btnHide.Padding = new System.Windows.Forms.Padding(5);
            this.btnHide.Size = new System.Drawing.Size(30, 30);
            this.btnHide.Text = "Hide";
            this.btnHide.ToolTipText = "Hide to Tray";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToggle.Image = ((System.Drawing.Image)(resources.GetObject("btnToggle.Image")));
            this.btnToggle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToggle.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Padding = new System.Windows.Forms.Padding(5);
            this.btnToggle.Size = new System.Drawing.Size(30, 30);
            this.btnToggle.Tag = "";
            this.btnToggle.Text = "MiniPlayer";
            this.btnToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnToggle.ToolTipText = "Switch between Normal and MiniPlayer";
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnDropdown
            // 
            this.btnDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDropdown.Image = ((System.Drawing.Image)(resources.GetObject("btnDropdown.Image")));
            this.btnDropdown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDropdown.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Padding = new System.Windows.Forms.Padding(5);
            this.btnDropdown.Size = new System.Drawing.Size(30, 30);
            this.btnDropdown.Text = "Options";
            this.btnDropdown.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDropdown.Click += new System.EventHandler(this.btnDropdown_Click);
            // 
            // toolStripFilters
            // 
            this.toolStripFilters.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStripFilters.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFilters.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFilters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtFilterFolder,
            this.btnClearFilters,
            this.txtFilterFile,
            this.toolStripLabel2});
            this.toolStripFilters.Location = new System.Drawing.Point(3, 35);
            this.toolStripFilters.Name = "toolStripFilters";
            this.toolStripFilters.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripFilters.Size = new System.Drawing.Size(195, 35);
            this.toolStripFilters.TabIndex = 3;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 30);
            this.toolStripLabel1.Text = "Folder Filter";
            // 
            // txtFilterFolder
            // 
            this.txtFilterFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.txtFilterFolder.Margin = new System.Windows.Forms.Padding(1, 3, 1, 0);
            this.txtFilterFolder.Name = "txtFilterFolder";
            this.txtFilterFolder.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtFilterFolder.Size = new System.Drawing.Size(12, 32);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.AutoToolTip = false;
            this.btnClearFilters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearFilters.Enabled = false;
            this.btnClearFilters.Image = ((System.Drawing.Image)(resources.GetObject("btnClearFilters.Image")));
            this.btnClearFilters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearFilters.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearFilters.Size = new System.Drawing.Size(30, 30);
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // txtFilterFile
            // 
            this.txtFilterFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.txtFilterFile.Margin = new System.Windows.Forms.Padding(1, 3, 1, 0);
            this.txtFilterFile.Name = "txtFilterFile";
            this.txtFilterFile.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtFilterFile.Size = new System.Drawing.Size(12, 32);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.toolStripLabel2.Size = new System.Drawing.Size(60, 30);
            this.toolStripLabel2.Text = "File Filter";
            // 
            // toolStripPlay
            // 
            this.toolStripPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStripPlay.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripPlay.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripPlay.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPlay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRandom,
            this.btnStop,
            this.btnReplay});
            this.toolStripPlay.Location = new System.Drawing.Point(3, 70);
            this.toolStripPlay.Name = "toolStripPlay";
            this.toolStripPlay.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripPlay.Size = new System.Drawing.Size(93, 35);
            this.toolStripPlay.TabIndex = 1;
            // 
            // btnRandom
            // 
            this.btnRandom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRandom.Image = ((System.Drawing.Image)(resources.GetObject("btnRandom.Image")));
            this.btnRandom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRandom.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Padding = new System.Windows.Forms.Padding(5);
            this.btnRandom.Size = new System.Drawing.Size(30, 30);
            this.btnRandom.Text = "Random";
            this.btnRandom.ToolTipText = "Play Random";
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Padding = new System.Windows.Forms.Padding(5);
            this.btnStop.Size = new System.Drawing.Size(30, 30);
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReplay.Image = ((System.Drawing.Image)(resources.GetObject("btnReplay.Image")));
            this.btnReplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplay.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Padding = new System.Windows.Forms.Padding(5);
            this.btnReplay.Size = new System.Drawing.Size(30, 30);
            this.btnReplay.Tag = "";
            this.btnReplay.Text = "Replay";
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
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
            this.menuTimers,
            this.menuItem2,
            this.menuReload,
            this.menuCenter,
            this.menuItem6,
            this.menuTimer1,
            this.menuTimer2});
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
            // menuTimers
            // 
            this.menuTimers.Index = 2;
            this.menuTimers.Text = "Timers...";
            this.menuTimers.Click += new System.EventHandler(this.menuTimers_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "-";
            // 
            // menuReload
            // 
            this.menuReload.Index = 4;
            this.menuReload.Text = "Reload";
            this.menuReload.Click += new System.EventHandler(this.menuReload_Click);
            // 
            // menuCenter
            // 
            this.menuCenter.Index = 5;
            this.menuCenter.Text = "Center";
            this.menuCenter.Click += new System.EventHandler(this.menuCenter_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 6;
            this.menuItem6.Text = "-";
            // 
            // menuTimer1
            // 
            this.menuTimer1.Index = 7;
            this.menuTimer1.Text = "Start Timer 1";
            this.menuTimer1.Click += new System.EventHandler(this.menuTimer1_Click);
            // 
            // menuTimer2
            // 
            this.menuTimer2.Index = 8;
            this.menuTimer2.Text = "Start Timer 2";
            this.menuTimer2.Click += new System.EventHandler(this.menuTimer2_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Pätkä Player";
            this.notifyIcon1.Visible = true;
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1120, 645);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(824, 97);
            this.Name = "frmPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pätkä Player";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
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
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.ToolStripButton btnDropdown;
        private System.Windows.Forms.ToolStripStatusLabel labelTimer2;
        private System.Windows.Forms.ToolStripStatusLabel labelTest;
        private System.Windows.Forms.MenuItem menuFolders;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.ToolStripButton btnToggle;
        private System.Windows.Forms.MenuItem menuCenter;
        private System.Windows.Forms.MenuItem menuTimers;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripButton btnHide;
    }
}

