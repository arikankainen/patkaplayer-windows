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
                //if (_mp3Player != null) _mp3Player.Dispose();
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextTray = new System.Windows.Forms.ContextMenu();
            this.menuTrayOpen = new System.Windows.Forms.MenuItem();
            this.menuTrayClose = new System.Windows.Forms.MenuItem();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.labelTotalClips = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelClipsPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSendKeystrokes = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLastPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelFolders = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripPlay = new System.Windows.Forms.ToolStrip();
            this.btnRandom = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnReplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSettings = new System.Windows.Forms.ToolStrip();
            this.btnDropdown = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.panelToolbarLine = new System.Windows.Forms.Panel();
            this.toolStripFilters = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtFilterFolder = new System.Windows.Forms.ToolStripTextBox();
            this.btnClearFilters = new System.Windows.Forms.ToolStripButton();
            this.txtFilterFile = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripPlay.SuspendLayout();
            this.toolStripSettings.SuspendLayout();
            this.toolStripFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
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
            this.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
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
            this.ContentPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ContentPanel.Size = new System.Drawing.Size(1087, 595);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFolders,
            this.menuSettings,
            this.menuTimers,
            this.menuItem2,
            this.menuReload});
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
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Pätkä Player";
            // 
            // contextTray
            // 
            this.contextTray.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuTrayOpen,
            this.menuTrayClose});
            // 
            // menuTrayOpen
            // 
            this.menuTrayOpen.Index = 0;
            this.menuTrayOpen.Text = "Open";
            this.menuTrayOpen.Click += new System.EventHandler(this.menuTrayOpen_Click);
            // 
            // menuTrayClose
            // 
            this.menuTrayClose.Index = 1;
            this.menuTrayClose.Text = "Close";
            this.menuTrayClose.Click += new System.EventHandler(this.menuTrayClose_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.AutoScroll = true;
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelButtons.Size = new System.Drawing.Size(804, 583);
            this.panelButtons.TabIndex = 12;
            this.panelButtons.MouseEnter += new System.EventHandler(this.panelButtons_MouseEnter);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip2.AutoSize = false;
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelTotalClips,
            this.labelClipsPlayed,
            this.labelTimer1,
            this.labelTimer2,
            this.labelSendKeystrokes,
            this.labelLastPlayed,
            this.labelSpacer,
            this.labelVersion});
            this.statusStrip2.Location = new System.Drawing.Point(0, 622);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1138, 24);
            this.statusStrip2.TabIndex = 0;
            // 
            // labelTotalClips
            // 
            this.labelTotalClips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalClips.Name = "labelTotalClips";
            this.labelTotalClips.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelTotalClips.Size = new System.Drawing.Size(59, 19);
            this.labelTotalClips.Text = "Clips: -";
            // 
            // labelClipsPlayed
            // 
            this.labelClipsPlayed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelClipsPlayed.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelClipsPlayed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClipsPlayed.Name = "labelClipsPlayed";
            this.labelClipsPlayed.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelClipsPlayed.Size = new System.Drawing.Size(96, 19);
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
            // labelSendKeystrokes
            // 
            this.labelSendKeystrokes.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelSendKeystrokes.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelSendKeystrokes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSendKeystrokes.Name = "labelSendKeystrokes";
            this.labelSendKeystrokes.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelSendKeystrokes.Size = new System.Drawing.Size(134, 19);
            this.labelSendKeystrokes.Text = "Send Keystrokes: Off";
            this.labelSendKeystrokes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelSendKeystrokes_MouseUp);
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
            // labelSpacer
            // 
            this.labelSpacer.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelSpacer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSpacer.Name = "labelSpacer";
            this.labelSpacer.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelSpacer.Size = new System.Drawing.Size(592, 19);
            this.labelSpacer.Spring = true;
            // 
            // labelVersion
            // 
            this.labelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelVersion.Size = new System.Drawing.Size(33, 19);
            this.labelVersion.Text = "v1.0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.DarkGray;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.panelFolders);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel2.Controls.Add(this.panelButtons);
            this.splitContainer1.Size = new System.Drawing.Size(1138, 583);
            this.splitContainer1.SplitterDistance = 329;
            this.splitContainer1.TabIndex = 15;
            // 
            // panelFolders
            // 
            this.panelFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFolders.AutoScroll = true;
            this.panelFolders.Location = new System.Drawing.Point(0, 0);
            this.panelFolders.Name = "panelFolders";
            this.panelFolders.Padding = new System.Windows.Forms.Padding(5);
            this.panelFolders.Size = new System.Drawing.Size(328, 583);
            this.panelFolders.TabIndex = 0;
            this.panelFolders.MouseEnter += new System.EventHandler(this.panelFolders_MouseEnter);
            // 
            // toolStripPlay
            // 
            this.toolStripPlay.AutoSize = false;
            this.toolStripPlay.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripPlay.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPlay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRandom,
            this.btnStop,
            this.btnReplay});
            this.toolStripPlay.Location = new System.Drawing.Point(2, 1);
            this.toolStripPlay.Name = "toolStripPlay";
            this.toolStripPlay.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripPlay.Size = new System.Drawing.Size(91, 35);
            this.toolStripPlay.TabIndex = 2;
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
            // toolStripSettings
            // 
            this.toolStripSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripSettings.AutoSize = false;
            this.toolStripSettings.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDropdown,
            this.toolStripButton5});
            this.toolStripSettings.Location = new System.Drawing.Point(1073, 1);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripSettings.Size = new System.Drawing.Size(62, 35);
            this.toolStripSettings.TabIndex = 17;
            // 
            // btnDropdown
            // 
            this.btnDropdown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
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
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripButton5.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton5.Text = "Hide";
            this.toolStripButton5.ToolTipText = "Hide to Tray";
            this.toolStripButton5.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // panelToolbarLine
            // 
            this.panelToolbarLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelToolbarLine.BackColor = System.Drawing.Color.Gray;
            this.panelToolbarLine.Location = new System.Drawing.Point(0, 38);
            this.panelToolbarLine.Name = "panelToolbarLine";
            this.panelToolbarLine.Size = new System.Drawing.Size(1137, 1);
            this.panelToolbarLine.TabIndex = 18;
            // 
            // toolStripFilters
            // 
            this.toolStripFilters.AutoSize = false;
            this.toolStripFilters.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFilters.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFilters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.txtFilterFolder,
            this.btnClearFilters,
            this.txtFilterFile,
            this.toolStripLabel4});
            this.toolStripFilters.Location = new System.Drawing.Point(647, 4);
            this.toolStripFilters.Name = "toolStripFilters";
            this.toolStripFilters.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripFilters.Size = new System.Drawing.Size(372, 35);
            this.toolStripFilters.TabIndex = 19;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.toolStripLabel3.Size = new System.Drawing.Size(74, 30);
            this.toolStripLabel3.Text = "Folder Filter";
            // 
            // txtFilterFolder
            // 
            this.txtFilterFolder.AutoSize = false;
            this.txtFilterFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.txtFilterFolder.Margin = new System.Windows.Forms.Padding(1, 3, 1, 0);
            this.txtFilterFolder.Name = "txtFilterFolder";
            this.txtFilterFolder.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.txtFilterFolder.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtFilterFolder.Size = new System.Drawing.Size(100, 31);
            this.txtFilterFolder.Click += new System.EventHandler(this.txtFilterFolder_Enter);
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
            this.txtFilterFile.AutoSize = false;
            this.txtFilterFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(136)))));
            this.txtFilterFile.Margin = new System.Windows.Forms.Padding(1, 3, 1, 0);
            this.txtFilterFile.Name = "txtFilterFile";
            this.txtFilterFile.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.txtFilterFile.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtFilterFile.Size = new System.Drawing.Size(100, 31);
            this.txtFilterFile.Click += new System.EventHandler(this.txtFilterFile_Enter);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.toolStripLabel4.Size = new System.Drawing.Size(60, 29);
            this.toolStripLabel4.Text = "File Filter";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.LargeChange = 0;
            this.trackBarVolume.Location = new System.Drawing.Point(118, 9);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(111, 45);
            this.trackBarVolume.TabIndex = 20;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.ValueChanged += new System.EventHandler(this.trackBarVolume_ValueChanged);
            this.trackBarVolume.MouseEnter += new System.EventHandler(this.trackBarVolume_MouseEnter);
            this.trackBarVolume.MouseLeave += new System.EventHandler(this.trackBarVolume_MouseLeave);
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelVolume.Location = new System.Drawing.Point(226, 13);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(33, 13);
            this.labelVolume.TabIndex = 21;
            this.labelVolume.Text = "100%";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPosition.Location = new System.Drawing.Point(420, 13);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(72, 13);
            this.labelPosition.TabIndex = 23;
            this.labelPosition.Text = "00:00 / 00:00";
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1137, 645);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.toolStripFilters);
            this.Controls.Add(this.panelToolbarLine);
            this.Controls.Add(this.toolStripSettings);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.toolStripPlay);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.trackBarVolume);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(997, 99);
            this.Name = "frmPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pätkä Player";
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripPlay.ResumeLayout(false);
            this.toolStripPlay.PerformLayout();
            this.toolStripSettings.ResumeLayout(false);
            this.toolStripSettings.PerformLayout();
            this.toolStripFilters.ResumeLayout(false);
            this.toolStripFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuSettings;
        private System.Windows.Forms.MenuItem menuReload;
        private System.Windows.Forms.MenuItem menuFolders;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuTimers;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextTray;
        private System.Windows.Forms.MenuItem menuTrayOpen;
        private System.Windows.Forms.MenuItem menuTrayClose;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel labelTotalClips;
        private System.Windows.Forms.ToolStripStatusLabel labelClipsPlayed;
        private System.Windows.Forms.ToolStripStatusLabel labelTimer1;
        private System.Windows.Forms.ToolStripStatusLabel labelSendKeystrokes;
        private System.Windows.Forms.ToolStripStatusLabel labelLastPlayed;
        private System.Windows.Forms.ToolStripStatusLabel labelSpacer;
        private System.Windows.Forms.ToolStripStatusLabel labelVersion;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel panelFolders;
        private System.Windows.Forms.ToolStrip toolStripPlay;
        private System.Windows.Forms.ToolStripButton btnRandom;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnReplay;
        private System.Windows.Forms.ToolStrip toolStripSettings;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton btnDropdown;
        private System.Windows.Forms.Panel panelToolbarLine;
        private System.Windows.Forms.ToolStrip toolStripFilters;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txtFilterFolder;
        private System.Windows.Forms.ToolStripButton btnClearFilters;
        private System.Windows.Forms.ToolStripTextBox txtFilterFile;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.ToolStripStatusLabel labelTimer2;
    }
}

