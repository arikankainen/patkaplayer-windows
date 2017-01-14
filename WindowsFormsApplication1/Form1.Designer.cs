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
            this.menuHotkeys = new System.Windows.Forms.MenuItem();
            this.menuReload = new System.Windows.Forms.MenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextTray = new System.Windows.Forms.ContextMenu();
            this.menuTrayOpen = new System.Windows.Forms.MenuItem();
            this.menuTrayClose = new System.Windows.Forms.MenuItem();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.labelTotalClips = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelClipsPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSendKeystrokes = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLastPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDistance = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripPlay = new System.Windows.Forms.ToolStrip();
            this.btnRandom = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnReplay = new System.Windows.Forms.ToolStripButton();
            this.btnFolder = new System.Windows.Forms.ToolStripButton();
            this.btnFile = new System.Windows.Forms.ToolStripButton();
            this.btnPlaylist = new System.Windows.Forms.ToolStripButton();
            this.toolStripSettings = new System.Windows.Forms.ToolStrip();
            this.btnDropdown = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.btnSavePlaylist = new System.Windows.Forms.ToolStripButton();
            this.btnLoadPlaylist = new System.Windows.Forms.ToolStripButton();
            this.btnClearPlaylist = new System.Windows.Forms.ToolStripButton();
            this.panelToolbarLine = new System.Windows.Forms.Panel();
            this.labelVolume = new System.Windows.Forms.Label();
            this.comboLatency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLatencyGray = new System.Windows.Forms.Panel();
            this.checkRepeat = new System.Windows.Forms.CheckBox();
            this.timerKeyDown = new System.Windows.Forms.Timer(this.components);
            this.panelComboPort = new System.Windows.Forms.Panel();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.timerArduino = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.timerArduinoPort = new System.Windows.Forms.Timer(this.components);
            this.timerWriteTime = new System.Windows.Forms.Timer(this.components);
            this.panelBack = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtPlaylistFileFilter = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtPlaylistFolderFilter = new System.Windows.Forms.TextBox();
            this.panelFileFilterG = new System.Windows.Forms.Panel();
            this.panelFileFilterW = new System.Windows.Forms.Panel();
            this.txtFileFilter = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFolderFilter = new System.Windows.Forms.TextBox();
            this.panelPlaylist = new System.Windows.Forms.Panel();
            this.lstPlaylist = new PatkaPlayer.VisualStylesListView();
            this.clmPlaylist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPlaylistNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPlaylistFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPlaylistFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelFolders = new System.Windows.Forms.Panel();
            this.lstFolders = new PatkaPlayer.VisualStylesListView();
            this.clmFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFolderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelFiles = new System.Windows.Forms.Panel();
            this.lstFiles = new PatkaPlayer.VisualStylesListView();
            this.clmFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelVolumeName = new System.Windows.Forms.Label();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.statusStrip2.SuspendLayout();
            this.toolStripPlay.SuspendLayout();
            this.toolStripSettings.SuspendLayout();
            this.panelLatencyGray.SuspendLayout();
            this.panelComboPort.SuspendLayout();
            this.panelBack.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelFileFilterG.SuspendLayout();
            this.panelFileFilterW.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelPlaylist.SuspendLayout();
            this.panelFolders.SuspendLayout();
            this.panelFiles.SuspendLayout();
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
            this.menuHotkeys,
            this.menuItem1,
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
            // menuHotkeys
            // 
            this.menuHotkeys.Index = 3;
            this.menuHotkeys.Text = "Hotkeys...";
            this.menuHotkeys.Click += new System.EventHandler(this.menuHotkeys_Click);
            // 
            // menuReload
            // 
            this.menuReload.Index = 5;
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
            this.labelDistance,
            this.labelVersion});
            this.statusStrip2.Location = new System.Drawing.Point(0, 803);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1488, 24);
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
            this.labelClipsPlayed.Size = new System.Drawing.Size(94, 19);
            this.labelClipsPlayed.Text = "Play count: 0";
            // 
            // labelTimer1
            // 
            this.labelTimer1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelTimer1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelTimer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTimer1.Name = "labelTimer1";
            this.labelTimer1.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelTimer1.Size = new System.Drawing.Size(87, 19);
            this.labelTimer1.Text = "Timer 1: off";
            this.labelTimer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTimer1_Click);
            // 
            // labelTimer2
            // 
            this.labelTimer2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelTimer2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelTimer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTimer2.Name = "labelTimer2";
            this.labelTimer2.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelTimer2.Size = new System.Drawing.Size(87, 19);
            this.labelTimer2.Text = "Timer 2: off";
            this.labelTimer2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTimer2_Click);
            // 
            // labelSendKeystrokes
            // 
            this.labelSendKeystrokes.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelSendKeystrokes.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelSendKeystrokes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSendKeystrokes.Name = "labelSendKeystrokes";
            this.labelSendKeystrokes.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelSendKeystrokes.Size = new System.Drawing.Size(132, 19);
            this.labelSendKeystrokes.Text = "Send Keystrokes: off";
            this.labelSendKeystrokes.Visible = false;
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
            this.labelSpacer.Size = new System.Drawing.Size(1078, 19);
            this.labelSpacer.Spring = true;
            // 
            // labelDistance
            // 
            this.labelDistance.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelDistance.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelDistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelDistance.Size = new System.Drawing.Size(51, 19);
            this.labelDistance.Text = "000cm";
            this.labelDistance.Visible = false;
            // 
            // labelVersion
            // 
            this.labelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelVersion.Size = new System.Drawing.Size(37, 19);
            this.labelVersion.Text = "v1.0";
            // 
            // toolStripPlay
            // 
            this.toolStripPlay.AutoSize = false;
            this.toolStripPlay.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripPlay.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripPlay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRandom,
            this.btnStop,
            this.btnReplay,
            this.btnFolder,
            this.btnFile,
            this.btnPlaylist});
            this.toolStripPlay.Location = new System.Drawing.Point(2, 2);
            this.toolStripPlay.Name = "toolStripPlay";
            this.toolStripPlay.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripPlay.Size = new System.Drawing.Size(360, 35);
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
            // btnFolder
            // 
            this.btnFolder.Checked = true;
            this.btnFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnFolder.Image")));
            this.btnFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFolder.Margin = new System.Windows.Forms.Padding(60, 3, 0, 2);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Padding = new System.Windows.Forms.Padding(5);
            this.btnFolder.Size = new System.Drawing.Size(54, 30);
            this.btnFolder.Tag = "";
            this.btnFolder.Text = "Folder";
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnFile
            // 
            this.btnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFile.Image = ((System.Drawing.Image)(resources.GetObject("btnFile.Image")));
            this.btnFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFile.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnFile.Name = "btnFile";
            this.btnFile.Padding = new System.Windows.Forms.Padding(5);
            this.btnFile.Size = new System.Drawing.Size(39, 30);
            this.btnFile.Tag = "";
            this.btnFile.Text = "File";
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnPlaylist.Image")));
            this.btnPlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlaylist.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Padding = new System.Windows.Forms.Padding(5);
            this.btnPlaylist.Size = new System.Drawing.Size(58, 30);
            this.btnPlaylist.Tag = "";
            this.btnPlaylist.Text = "Playlist";
            this.btnPlaylist.Click += new System.EventHandler(this.btnPlaylist_Click);
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripSettings.AutoSize = false;
            this.toolStripSettings.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDropdown,
            this.toolStripButton5,
            this.btnSavePlaylist,
            this.btnLoadPlaylist,
            this.btnClearPlaylist});
            this.toolStripSettings.Location = new System.Drawing.Point(1166, 2);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripSettings.Size = new System.Drawing.Size(319, 35);
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
            // btnSavePlaylist
            // 
            this.btnSavePlaylist.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSavePlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSavePlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSavePlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePlaylist.Image")));
            this.btnSavePlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSavePlaylist.Margin = new System.Windows.Forms.Padding(0, 3, 50, 2);
            this.btnSavePlaylist.Name = "btnSavePlaylist";
            this.btnSavePlaylist.Padding = new System.Windows.Forms.Padding(5);
            this.btnSavePlaylist.Size = new System.Drawing.Size(54, 30);
            this.btnSavePlaylist.Tag = "";
            this.btnSavePlaylist.Text = "Save...";
            this.btnSavePlaylist.Click += new System.EventHandler(this.btnSavePlaylist_Click);
            // 
            // btnLoadPlaylist
            // 
            this.btnLoadPlaylist.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLoadPlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoadPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoadPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadPlaylist.Image")));
            this.btnLoadPlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadPlaylist.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnLoadPlaylist.Name = "btnLoadPlaylist";
            this.btnLoadPlaylist.Padding = new System.Windows.Forms.Padding(5);
            this.btnLoadPlaylist.Size = new System.Drawing.Size(56, 30);
            this.btnLoadPlaylist.Tag = "";
            this.btnLoadPlaylist.Text = "Load...";
            this.btnLoadPlaylist.Click += new System.EventHandler(this.btnLoadPlaylist_Click);
            // 
            // btnClearPlaylist
            // 
            this.btnClearPlaylist.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClearPlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClearPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnClearPlaylist.Image")));
            this.btnClearPlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearPlaylist.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnClearPlaylist.Name = "btnClearPlaylist";
            this.btnClearPlaylist.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearPlaylist.Size = new System.Drawing.Size(48, 30);
            this.btnClearPlaylist.Tag = "";
            this.btnClearPlaylist.Text = "Clear";
            this.btnClearPlaylist.Click += new System.EventHandler(this.btnClearPlaylist_Click);
            // 
            // panelToolbarLine
            // 
            this.panelToolbarLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelToolbarLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panelToolbarLine.Location = new System.Drawing.Point(0, 40);
            this.panelToolbarLine.Name = "panelToolbarLine";
            this.panelToolbarLine.Size = new System.Drawing.Size(1487, 1);
            this.panelToolbarLine.TabIndex = 18;
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelVolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelVolume.Location = new System.Drawing.Point(1108, 13);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(32, 13);
            this.labelVolume.TabIndex = 21;
            this.labelVolume.Text = "100%";
            // 
            // comboLatency
            // 
            this.comboLatency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLatency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLatency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboLatency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboLatency.FormattingEnabled = true;
            this.comboLatency.Items.AddRange(new object[] {
            "900",
            "800",
            "700",
            "600",
            "500",
            "400",
            "300",
            "200",
            "100",
            "50"});
            this.comboLatency.Location = new System.Drawing.Point(1, 1);
            this.comboLatency.Name = "comboLatency";
            this.comboLatency.Size = new System.Drawing.Size(51, 21);
            this.comboLatency.TabIndex = 24;
            this.comboLatency.SelectedIndexChanged += new System.EventHandler(this.comboLatency_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(787, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "ms";
            // 
            // panelLatencyGray
            // 
            this.panelLatencyGray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelLatencyGray.Controls.Add(this.comboLatency);
            this.panelLatencyGray.Location = new System.Drawing.Point(732, 9);
            this.panelLatencyGray.Name = "panelLatencyGray";
            this.panelLatencyGray.Size = new System.Drawing.Size(53, 23);
            this.panelLatencyGray.TabIndex = 1;
            // 
            // checkRepeat
            // 
            this.checkRepeat.AutoSize = true;
            this.checkRepeat.Location = new System.Drawing.Point(547, 13);
            this.checkRepeat.Name = "checkRepeat";
            this.checkRepeat.Size = new System.Drawing.Size(15, 14);
            this.checkRepeat.TabIndex = 37;
            this.checkRepeat.UseVisualStyleBackColor = true;
            this.checkRepeat.Visible = false;
            // 
            // timerKeyDown
            // 
            this.timerKeyDown.Interval = 300;
            this.timerKeyDown.Tick += new System.EventHandler(this.timerKeyDown_Tick);
            // 
            // panelComboPort
            // 
            this.panelComboPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelComboPort.Controls.Add(this.comboPort);
            this.panelComboPort.Location = new System.Drawing.Point(872, 9);
            this.panelComboPort.Name = "panelComboPort";
            this.panelComboPort.Size = new System.Drawing.Size(63, 23);
            this.panelComboPort.TabIndex = 26;
            // 
            // comboPort
            // 
            this.comboPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(1, 1);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(61, 21);
            this.comboPort.TabIndex = 24;
            this.comboPort.SelectedIndexChanged += new System.EventHandler(this.comboPort_SelectedIndexChanged);
            // 
            // timerArduino
            // 
            this.timerArduino.Interval = 500;
            this.timerArduino.Tick += new System.EventHandler(this.timerArduino_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(839, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Port";
            // 
            // timerArduinoPort
            // 
            this.timerArduinoPort.Interval = 1000;
            this.timerArduinoPort.Tick += new System.EventHandler(this.timerArduinoPort_Tick);
            // 
            // timerWriteTime
            // 
            this.timerWriteTime.Enabled = true;
            this.timerWriteTime.Interval = 300000;
            this.timerWriteTime.Tick += new System.EventHandler(this.timerWriteTime_Tick);
            // 
            // panelBack
            // 
            this.panelBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack.BackColor = System.Drawing.SystemColors.Control;
            this.panelBack.Controls.Add(this.panel7);
            this.panelBack.Controls.Add(this.panel5);
            this.panelBack.Controls.Add(this.panelFileFilterG);
            this.panelBack.Controls.Add(this.panel1);
            this.panelBack.Controls.Add(this.panelPlaylist);
            this.panelBack.Controls.Add(this.panelFolders);
            this.panelBack.Controls.Add(this.panelFiles);
            this.panelBack.Location = new System.Drawing.Point(1, 41);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(1486, 762);
            this.panelBack.TabIndex = 39;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(1105, 10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(369, 23);
            this.panel7.TabIndex = 31;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Window;
            this.panel8.Controls.Add(this.txtPlaylistFileFilter);
            this.panel8.Location = new System.Drawing.Point(1, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(367, 21);
            this.panel8.TabIndex = 28;
            // 
            // txtPlaylistFileFilter
            // 
            this.txtPlaylistFileFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlaylistFileFilter.Location = new System.Drawing.Point(4, 4);
            this.txtPlaylistFileFilter.Name = "txtPlaylistFileFilter";
            this.txtPlaylistFileFilter.Size = new System.Drawing.Size(359, 13);
            this.txtPlaylistFileFilter.TabIndex = 24;
            this.txtPlaylistFileFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPlaylistFileFilter.TextChanged += new System.EventHandler(this.txtPlaylistFileFilter_TextChanged);
            this.txtPlaylistFileFilter.DoubleClick += new System.EventHandler(this.txtPlaylistFileFilter_DoubleClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(731, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(369, 23);
            this.panel5.TabIndex = 30;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.txtPlaylistFolderFilter);
            this.panel6.Location = new System.Drawing.Point(1, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(367, 21);
            this.panel6.TabIndex = 28;
            // 
            // txtPlaylistFolderFilter
            // 
            this.txtPlaylistFolderFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlaylistFolderFilter.Location = new System.Drawing.Point(4, 4);
            this.txtPlaylistFolderFilter.Name = "txtPlaylistFolderFilter";
            this.txtPlaylistFolderFilter.Size = new System.Drawing.Size(359, 13);
            this.txtPlaylistFolderFilter.TabIndex = 25;
            this.txtPlaylistFolderFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPlaylistFolderFilter.TextChanged += new System.EventHandler(this.txtPlaylistFolderFilter_TextChanged);
            this.txtPlaylistFolderFilter.DoubleClick += new System.EventHandler(this.txtPlaylistFolderFilter_DoubleClick);
            // 
            // panelFileFilterG
            // 
            this.panelFileFilterG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelFileFilterG.Controls.Add(this.panelFileFilterW);
            this.panelFileFilterG.Location = new System.Drawing.Point(371, 10);
            this.panelFileFilterG.Name = "panelFileFilterG";
            this.panelFileFilterG.Size = new System.Drawing.Size(350, 23);
            this.panelFileFilterG.TabIndex = 29;
            // 
            // panelFileFilterW
            // 
            this.panelFileFilterW.BackColor = System.Drawing.SystemColors.Window;
            this.panelFileFilterW.Controls.Add(this.txtFileFilter);
            this.panelFileFilterW.Location = new System.Drawing.Point(1, 1);
            this.panelFileFilterW.Name = "panelFileFilterW";
            this.panelFileFilterW.Size = new System.Drawing.Size(348, 21);
            this.panelFileFilterW.TabIndex = 28;
            // 
            // txtFileFilter
            // 
            this.txtFileFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileFilter.Location = new System.Drawing.Point(4, 4);
            this.txtFileFilter.Name = "txtFileFilter";
            this.txtFileFilter.Size = new System.Drawing.Size(340, 13);
            this.txtFileFilter.TabIndex = 19;
            this.txtFileFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFileFilter.TextChanged += new System.EventHandler(this.txtFileFilter_TextChanged);
            this.txtFileFilter.DoubleClick += new System.EventHandler(this.txtFileFilter_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(11, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 23);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.txtFolderFilter);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 21);
            this.panel2.TabIndex = 28;
            // 
            // txtFolderFilter
            // 
            this.txtFolderFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFolderFilter.Location = new System.Drawing.Point(4, 4);
            this.txtFolderFilter.Name = "txtFolderFilter";
            this.txtFolderFilter.Size = new System.Drawing.Size(340, 13);
            this.txtFolderFilter.TabIndex = 20;
            this.txtFolderFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFolderFilter.TextChanged += new System.EventHandler(this.txtFolderFilter_TextChanged);
            this.txtFolderFilter.DoubleClick += new System.EventHandler(this.txtFolderFilter_DoubleClick);
            // 
            // panelPlaylist
            // 
            this.panelPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelPlaylist.Controls.Add(this.lstPlaylist);
            this.panelPlaylist.Location = new System.Drawing.Point(731, 39);
            this.panelPlaylist.Name = "panelPlaylist";
            this.panelPlaylist.Size = new System.Drawing.Size(743, 712);
            this.panelPlaylist.TabIndex = 27;
            // 
            // lstPlaylist
            // 
            this.lstPlaylist.AllowDrop = true;
            this.lstPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPlaylist,
            this.clmPlaylistNum,
            this.clmPlaylistFolder,
            this.clmPlaylistFile});
            this.lstPlaylist.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstPlaylist.FullRowSelect = true;
            this.lstPlaylist.Location = new System.Drawing.Point(1, 1);
            this.lstPlaylist.Name = "lstPlaylist";
            this.lstPlaylist.Size = new System.Drawing.Size(741, 710);
            this.lstPlaylist.TabIndex = 15;
            this.lstPlaylist.UseCompatibleStateImageBehavior = false;
            this.lstPlaylist.View = System.Windows.Forms.View.Details;
            this.lstPlaylist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lstPlaylist_ItemDrag);
            this.lstPlaylist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPlaylist_DragDrop);
            this.lstPlaylist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstPlaylist_DragEnter);
            this.lstPlaylist.DragOver += new System.Windows.Forms.DragEventHandler(this.lstPlaylist_DragOver);
            this.lstPlaylist.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.lstPlaylist_GiveFeedback);
            this.lstPlaylist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPlaylist_KeyDown);
            this.lstPlaylist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstPlaylist_MouseDown);
            this.lstPlaylist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstPlaylist_MouseUp);
            // 
            // clmPlaylist
            // 
            this.clmPlaylist.Text = "Full playlist";
            // 
            // clmPlaylistNum
            // 
            this.clmPlaylistNum.Text = "#";
            // 
            // clmPlaylistFolder
            // 
            this.clmPlaylistFolder.Text = "Folder";
            this.clmPlaylistFolder.Width = 96;
            // 
            // clmPlaylistFile
            // 
            this.clmPlaylistFile.Text = "File";
            // 
            // panelFolders
            // 
            this.panelFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelFolders.Controls.Add(this.lstFolders);
            this.panelFolders.Location = new System.Drawing.Point(11, 39);
            this.panelFolders.Name = "panelFolders";
            this.panelFolders.Size = new System.Drawing.Size(350, 712);
            this.panelFolders.TabIndex = 29;
            // 
            // lstFolders
            // 
            this.lstFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmFolder,
            this.clmFolderName});
            this.lstFolders.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFolders.FullRowSelect = true;
            this.lstFolders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstFolders.Location = new System.Drawing.Point(1, 1);
            this.lstFolders.MultiSelect = false;
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.Size = new System.Drawing.Size(348, 710);
            this.lstFolders.TabIndex = 13;
            this.lstFolders.UseCompatibleStateImageBehavior = false;
            this.lstFolders.View = System.Windows.Forms.View.Details;
            this.lstFolders.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lstFolders_ItemDrag);
            this.lstFolders.SelectedIndexChanged += new System.EventHandler(this.lstFolders_SelectedIndexChanged);
            this.lstFolders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFolders_MouseDown);
            this.lstFolders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstFolders_MouseUp);
            // 
            // clmFolder
            // 
            this.clmFolder.Text = "Full folder";
            this.clmFolder.Width = 53;
            // 
            // clmFolderName
            // 
            this.clmFolderName.Text = "Folder";
            this.clmFolderName.Width = 103;
            // 
            // panelFiles
            // 
            this.panelFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelFiles.Controls.Add(this.lstFiles);
            this.panelFiles.Location = new System.Drawing.Point(371, 39);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.Size = new System.Drawing.Size(350, 712);
            this.panelFiles.TabIndex = 27;
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmFile,
            this.clmFileName});
            this.lstFiles.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstFiles.FullRowSelect = true;
            this.lstFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstFiles.Location = new System.Drawing.Point(1, 1);
            this.lstFiles.MultiSelect = false;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(348, 710);
            this.lstFiles.TabIndex = 14;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lstFiles_ItemDrag);
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragDrop);
            this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragEnter);
            this.lstFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragOver);
            this.lstFiles.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.lstFiles_GiveFeedback);
            this.lstFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseDown);
            this.lstFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseUp);
            // 
            // clmFile
            // 
            this.clmFile.Text = "Full files";
            this.clmFile.Width = 54;
            // 
            // clmFileName
            // 
            this.clmFileName.Text = "File";
            this.clmFileName.Width = 100;
            // 
            // labelVolumeName
            // 
            this.labelVolumeName.AutoSize = true;
            this.labelVolumeName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelVolumeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelVolumeName.Location = new System.Drawing.Point(974, 13);
            this.labelVolumeName.Name = "labelVolumeName";
            this.labelVolumeName.Size = new System.Drawing.Size(45, 13);
            this.labelVolumeName.TabIndex = 40;
            this.labelVolumeName.Text = "Volume";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1487, 826);
            this.Controls.Add(this.labelVolumeName);
            this.Controls.Add(this.panelBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelComboPort);
            this.Controls.Add(this.checkRepeat);
            this.Controls.Add(this.panelLatencyGray);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.panelToolbarLine);
            this.Controls.Add(this.toolStripSettings);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.toolStripPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1503, 865);
            this.Name = "frmPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pätkä Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayer_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayer_Load);
            this.Shown += new System.EventHandler(this.frmPlayer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPlayer_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frmPlayer_PreviewKeyDown);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.toolStripPlay.ResumeLayout(false);
            this.toolStripPlay.PerformLayout();
            this.toolStripSettings.ResumeLayout(false);
            this.toolStripSettings.PerformLayout();
            this.panelLatencyGray.ResumeLayout(false);
            this.panelComboPort.ResumeLayout(false);
            this.panelBack.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelFileFilterG.ResumeLayout(false);
            this.panelFileFilterW.ResumeLayout(false);
            this.panelFileFilterW.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelPlaylist.ResumeLayout(false);
            this.panelFolders.ResumeLayout(false);
            this.panelFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuSettings;
        private System.Windows.Forms.MenuItem menuReload;
        private System.Windows.Forms.MenuItem menuFolders;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextTray;
        private System.Windows.Forms.MenuItem menuTrayOpen;
        private System.Windows.Forms.MenuItem menuTrayClose;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel labelTotalClips;
        private System.Windows.Forms.ToolStripStatusLabel labelClipsPlayed;
        private System.Windows.Forms.ToolStripStatusLabel labelTimer1;
        private System.Windows.Forms.ToolStripStatusLabel labelSendKeystrokes;
        private System.Windows.Forms.ToolStripStatusLabel labelLastPlayed;
        private System.Windows.Forms.ToolStripStatusLabel labelSpacer;
        private System.Windows.Forms.ToolStripStatusLabel labelVersion;
        private System.Windows.Forms.ToolStrip toolStripPlay;
        private System.Windows.Forms.ToolStripButton btnRandom;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnReplay;
        private System.Windows.Forms.ToolStrip toolStripSettings;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton btnDropdown;
        private System.Windows.Forms.Panel panelToolbarLine;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.ToolStripStatusLabel labelTimer2;
        private System.Windows.Forms.ComboBox comboLatency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelLatencyGray;
        private System.Windows.Forms.CheckBox checkRepeat;
        private System.Windows.Forms.Timer timerKeyDown;
        private System.Windows.Forms.Panel panelComboPort;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.Timer timerArduino;
        private System.Windows.Forms.ToolStripStatusLabel labelDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerArduinoPort;
        private System.Windows.Forms.Timer timerWriteTime;
        private VisualStylesListView lstPlaylist;
        private System.Windows.Forms.ColumnHeader clmPlaylist;
        private VisualStylesListView lstFiles;
        private System.Windows.Forms.ColumnHeader clmFile;
        private VisualStylesListView lstFolders;
        private System.Windows.Forms.ColumnHeader clmFolder;
        private System.Windows.Forms.ColumnHeader clmFolderName;
        private System.Windows.Forms.ColumnHeader clmPlaylistFolder;
        private System.Windows.Forms.ColumnHeader clmFileName;
        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.ColumnHeader clmPlaylistFile;
        private System.Windows.Forms.ColumnHeader clmPlaylistNum;
        private System.Windows.Forms.TextBox txtFolderFilter;
        private System.Windows.Forms.TextBox txtFileFilter;
        private System.Windows.Forms.TextBox txtPlaylistFolderFilter;
        private System.Windows.Forms.TextBox txtPlaylistFileFilter;
        private System.Windows.Forms.ToolStripButton btnFolder;
        private System.Windows.Forms.ToolStripButton btnFile;
        private System.Windows.Forms.ToolStripButton btnPlaylist;
        private System.Windows.Forms.Panel panelFiles;
        private System.Windows.Forms.Panel panelFolders;
        private System.Windows.Forms.Panel panelPlaylist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelFileFilterG;
        private System.Windows.Forms.Panel panelFileFilterW;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label labelVolumeName;
        private System.Windows.Forms.ToolStripButton btnSavePlaylist;
        private System.Windows.Forms.ToolStripButton btnLoadPlaylist;
        private System.Windows.Forms.ToolStripButton btnClearPlaylist;
        private System.Windows.Forms.MenuItem menuTimers;
        private System.Windows.Forms.MenuItem menuHotkeys;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}

