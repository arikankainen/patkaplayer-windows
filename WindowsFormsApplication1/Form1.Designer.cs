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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuReload = new System.Windows.Forms.MenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextTray = new System.Windows.Forms.ContextMenu();
            this.menuTrayOpen = new System.Windows.Forms.MenuItem();
            this.menuTrayClose = new System.Windows.Forms.MenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelTotalClips = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelClipsPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTimer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSendKeystrokes = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLastPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripPlay = new System.Windows.Forms.ToolStrip();
            this.btnRandom = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnReplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSettings = new System.Windows.Forms.ToolStrip();
            this.btnDropdown = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.btnSavePlaylist = new System.Windows.Forms.ToolStripButton();
            this.btnLoadPlaylist = new System.Windows.Forms.ToolStripButton();
            this.btnClearPlaylist = new System.Windows.Forms.ToolStripButton();
            this.panelToolbarLine = new System.Windows.Forms.Panel();
            this.labelVolumePercent = new System.Windows.Forms.Label();
            this.comboLatency = new System.Windows.Forms.ComboBox();
            this.labelRefreshMs = new System.Windows.Forms.Label();
            this.timerKeyDown = new System.Windows.Forms.Timer(this.components);
            this.panelBack = new System.Windows.Forms.Panel();
            this.txtFolderFilter = new System.Windows.Forms.TextBox();
            this.labelFolderFilter = new System.Windows.Forms.Label();
            this.btnFolderFilterClear = new System.Windows.Forms.Button();
            this.txtFileFilter = new System.Windows.Forms.TextBox();
            this.labelFileFilter = new System.Windows.Forms.Label();
            this.btnFileFilterClear = new System.Windows.Forms.Button();
            this.btnPlaylistFileFilterClear = new System.Windows.Forms.Button();
            this.btnPlaylistFolderFilterClear = new System.Windows.Forms.Button();
            this.txtPlaylistFileFilter = new System.Windows.Forms.TextBox();
            this.labelButton15 = new System.Windows.Forms.Label();
            this.txtPlaylistFolderFilter = new System.Windows.Forms.TextBox();
            this.labelPlaylistFileFilter = new System.Windows.Forms.Label();
            this.labelButton14 = new System.Windows.Forms.Label();
            this.labelPlaylistFolderFilter = new System.Windows.Forms.Label();
            this.labelButton13 = new System.Windows.Forms.Label();
            this.labelButton12 = new System.Windows.Forms.Label();
            this.labelButton11 = new System.Windows.Forms.Label();
            this.labelButton10 = new System.Windows.Forms.Label();
            this.labelButton9 = new System.Windows.Forms.Label();
            this.labelButton8 = new System.Windows.Forms.Label();
            this.labelButton7 = new System.Windows.Forms.Label();
            this.labelButton6 = new System.Windows.Forms.Label();
            this.labelButton5 = new System.Windows.Forms.Label();
            this.labelButton4 = new System.Windows.Forms.Label();
            this.labelButton3 = new System.Windows.Forms.Label();
            this.labelButton2 = new System.Windows.Forms.Label();
            this.labelButton1 = new System.Windows.Forms.Label();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn14 = new System.Windows.Forms.Button();
            this.btn13 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.radioFolders = new System.Windows.Forms.RadioButton();
            this.radioFiles = new System.Windows.Forms.RadioButton();
            this.radioPlaylist = new System.Windows.Forms.RadioButton();
            this.labelVolumeName = new System.Windows.Forms.Label();
            this.labelRefresh = new System.Windows.Forms.Label();
            this.lstFolders = new PatkaPlayer.VisualStylesListView();
            this.clmFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFolderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstFiles = new PatkaPlayer.VisualStylesListView();
            this.clmFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstPlaylist = new PatkaPlayer.VisualStylesListView();
            this.clmPlaylist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPlaylistNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPlaylistFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPlaylistFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.toolStripPlay.SuspendLayout();
            this.toolStripSettings.SuspendLayout();
            this.panelBack.SuspendLayout();
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
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
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
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelTotalClips,
            this.labelClipsPlayed,
            this.labelTimer1,
            this.labelTimer2,
            this.labelSendKeystrokes,
            this.labelLastPlayed,
            this.labelSpacer,
            this.labelVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 778);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1399, 24);
            this.statusStrip1.TabIndex = 0;
            // 
            // labelTotalClips
            // 
            this.labelTotalClips.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.labelClipsPlayed.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.labelTimer1.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.labelTimer2.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.labelSendKeystrokes.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.labelLastPlayed.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.labelSpacer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelSpacer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSpacer.Name = "labelSpacer";
            this.labelSpacer.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelSpacer.Size = new System.Drawing.Size(904, 19);
            this.labelSpacer.Spring = true;
            // 
            // labelVersion
            // 
            this.labelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelVersion.Size = new System.Drawing.Size(122, 19);
            this.labelVersion.Text = "Pätkä Player v1.0.0.0";
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
            this.toolStripPlay.Location = new System.Drawing.Point(2, 2);
            this.toolStripPlay.Name = "toolStripPlay";
            this.toolStripPlay.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripPlay.Size = new System.Drawing.Size(101, 35);
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
            this.toolStripButton5,
            this.btnSavePlaylist,
            this.btnLoadPlaylist,
            this.btnClearPlaylist});
            this.toolStripSettings.Location = new System.Drawing.Point(1218, 2);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripSettings.Size = new System.Drawing.Size(181, 35);
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
            this.btnSavePlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSavePlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSavePlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePlaylist.Image")));
            this.btnSavePlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSavePlaylist.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.btnSavePlaylist.Name = "btnSavePlaylist";
            this.btnSavePlaylist.Padding = new System.Windows.Forms.Padding(5);
            this.btnSavePlaylist.Size = new System.Drawing.Size(30, 30);
            this.btnSavePlaylist.Tag = "";
            this.btnSavePlaylist.Text = "Save...";
            this.btnSavePlaylist.Click += new System.EventHandler(this.btnSavePlaylist_Click);
            // 
            // btnLoadPlaylist
            // 
            this.btnLoadPlaylist.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLoadPlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoadPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadPlaylist.Image")));
            this.btnLoadPlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadPlaylist.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnLoadPlaylist.Name = "btnLoadPlaylist";
            this.btnLoadPlaylist.Padding = new System.Windows.Forms.Padding(5);
            this.btnLoadPlaylist.Size = new System.Drawing.Size(30, 30);
            this.btnLoadPlaylist.Tag = "";
            this.btnLoadPlaylist.Text = "Load...";
            this.btnLoadPlaylist.Click += new System.EventHandler(this.btnLoadPlaylist_Click);
            // 
            // btnClearPlaylist
            // 
            this.btnClearPlaylist.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClearPlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClearPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnClearPlaylist.Image")));
            this.btnClearPlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearPlaylist.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnClearPlaylist.Name = "btnClearPlaylist";
            this.btnClearPlaylist.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearPlaylist.Size = new System.Drawing.Size(30, 30);
            this.btnClearPlaylist.Tag = "";
            this.btnClearPlaylist.Text = "Clear";
            this.btnClearPlaylist.Click += new System.EventHandler(this.btnClearPlaylist_Click);
            // 
            // panelToolbarLine
            // 
            this.panelToolbarLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelToolbarLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.panelToolbarLine.Location = new System.Drawing.Point(0, 40);
            this.panelToolbarLine.Name = "panelToolbarLine";
            this.panelToolbarLine.Size = new System.Drawing.Size(1399, 1);
            this.panelToolbarLine.TabIndex = 18;
            // 
            // labelVolumePercent
            // 
            this.labelVolumePercent.AutoSize = true;
            this.labelVolumePercent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelVolumePercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelVolumePercent.Location = new System.Drawing.Point(281, 13);
            this.labelVolumePercent.Name = "labelVolumePercent";
            this.labelVolumePercent.Size = new System.Drawing.Size(35, 15);
            this.labelVolumePercent.TabIndex = 21;
            this.labelVolumePercent.Text = "100%";
            // 
            // comboLatency
            // 
            this.comboLatency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLatency.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboLatency.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.comboLatency.Location = new System.Drawing.Point(411, 9);
            this.comboLatency.Name = "comboLatency";
            this.comboLatency.Size = new System.Drawing.Size(70, 23);
            this.comboLatency.TabIndex = 24;
            this.comboLatency.SelectedIndexChanged += new System.EventHandler(this.comboLatency_SelectedIndexChanged);
            // 
            // labelRefreshMs
            // 
            this.labelRefreshMs.AutoSize = true;
            this.labelRefreshMs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelRefreshMs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRefreshMs.Location = new System.Drawing.Point(482, 13);
            this.labelRefreshMs.Name = "labelRefreshMs";
            this.labelRefreshMs.Size = new System.Drawing.Size(23, 15);
            this.labelRefreshMs.TabIndex = 25;
            this.labelRefreshMs.Text = "ms";
            // 
            // timerKeyDown
            // 
            this.timerKeyDown.Interval = 300;
            this.timerKeyDown.Tick += new System.EventHandler(this.timerKeyDown_Tick);
            // 
            // panelBack
            // 
            this.panelBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack.BackColor = System.Drawing.SystemColors.Control;
            this.panelBack.Controls.Add(this.txtFolderFilter);
            this.panelBack.Controls.Add(this.labelFolderFilter);
            this.panelBack.Controls.Add(this.lstFolders);
            this.panelBack.Controls.Add(this.btnFolderFilterClear);
            this.panelBack.Controls.Add(this.txtFileFilter);
            this.panelBack.Controls.Add(this.labelFileFilter);
            this.panelBack.Controls.Add(this.lstFiles);
            this.panelBack.Controls.Add(this.btnFileFilterClear);
            this.panelBack.Controls.Add(this.btnPlaylistFileFilterClear);
            this.panelBack.Controls.Add(this.btnPlaylistFolderFilterClear);
            this.panelBack.Controls.Add(this.lstPlaylist);
            this.panelBack.Controls.Add(this.txtPlaylistFileFilter);
            this.panelBack.Controls.Add(this.labelButton15);
            this.panelBack.Controls.Add(this.txtPlaylistFolderFilter);
            this.panelBack.Controls.Add(this.labelPlaylistFileFilter);
            this.panelBack.Controls.Add(this.labelButton14);
            this.panelBack.Controls.Add(this.labelPlaylistFolderFilter);
            this.panelBack.Controls.Add(this.labelButton13);
            this.panelBack.Controls.Add(this.labelButton12);
            this.panelBack.Controls.Add(this.labelButton11);
            this.panelBack.Controls.Add(this.labelButton10);
            this.panelBack.Controls.Add(this.labelButton9);
            this.panelBack.Controls.Add(this.labelButton8);
            this.panelBack.Controls.Add(this.labelButton7);
            this.panelBack.Controls.Add(this.labelButton6);
            this.panelBack.Controls.Add(this.labelButton5);
            this.panelBack.Controls.Add(this.labelButton4);
            this.panelBack.Controls.Add(this.labelButton3);
            this.panelBack.Controls.Add(this.labelButton2);
            this.panelBack.Controls.Add(this.labelButton1);
            this.panelBack.Controls.Add(this.btn15);
            this.panelBack.Controls.Add(this.btn14);
            this.panelBack.Controls.Add(this.btn13);
            this.panelBack.Controls.Add(this.btn12);
            this.panelBack.Controls.Add(this.btn11);
            this.panelBack.Controls.Add(this.btn10);
            this.panelBack.Controls.Add(this.btn9);
            this.panelBack.Controls.Add(this.btn8);
            this.panelBack.Controls.Add(this.btn7);
            this.panelBack.Controls.Add(this.btn6);
            this.panelBack.Controls.Add(this.btn5);
            this.panelBack.Controls.Add(this.btn4);
            this.panelBack.Controls.Add(this.btn3);
            this.panelBack.Controls.Add(this.btn2);
            this.panelBack.Controls.Add(this.btn1);
            this.panelBack.Location = new System.Drawing.Point(1, 41);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(1398, 737);
            this.panelBack.TabIndex = 39;
            // 
            // txtFolderFilter
            // 
            this.txtFolderFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFolderFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolderFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFolderFilter.Location = new System.Drawing.Point(85, 699);
            this.txtFolderFilter.Name = "txtFolderFilter";
            this.txtFolderFilter.Size = new System.Drawing.Size(258, 23);
            this.txtFolderFilter.TabIndex = 20;
            this.txtFolderFilter.TextChanged += new System.EventHandler(this.txtFolderFilter_TextChanged);
            this.txtFolderFilter.DoubleClick += new System.EventHandler(this.txtFolderFilter_DoubleClick);
            // 
            // labelFolderFilter
            // 
            this.labelFolderFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFolderFilter.AutoSize = true;
            this.labelFolderFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelFolderFilter.Location = new System.Drawing.Point(9, 703);
            this.labelFolderFilter.Name = "labelFolderFilter";
            this.labelFolderFilter.Size = new System.Drawing.Size(70, 15);
            this.labelFolderFilter.TabIndex = 43;
            this.labelFolderFilter.Text = "Folder filter:";
            // 
            // btnFolderFilterClear
            // 
            this.btnFolderFilterClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFolderFilterClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFolderFilterClear.Location = new System.Drawing.Point(349, 699);
            this.btnFolderFilterClear.Name = "btnFolderFilterClear";
            this.btnFolderFilterClear.Size = new System.Drawing.Size(30, 23);
            this.btnFolderFilterClear.TabIndex = 78;
            this.btnFolderFilterClear.Text = "X";
            this.btnFolderFilterClear.UseVisualStyleBackColor = true;
            this.btnFolderFilterClear.Click += new System.EventHandler(this.btnFolderFilterClear_Click);
            // 
            // txtFileFilter
            // 
            this.txtFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFileFilter.Location = new System.Drawing.Point(466, 699);
            this.txtFileFilter.Name = "txtFileFilter";
            this.txtFileFilter.Size = new System.Drawing.Size(258, 23);
            this.txtFileFilter.TabIndex = 19;
            this.txtFileFilter.TextChanged += new System.EventHandler(this.txtFileFilter_TextChanged);
            this.txtFileFilter.DoubleClick += new System.EventHandler(this.txtFileFilter_DoubleClick);
            // 
            // labelFileFilter
            // 
            this.labelFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFileFilter.AutoSize = true;
            this.labelFileFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelFileFilter.Location = new System.Drawing.Point(405, 703);
            this.labelFileFilter.Name = "labelFileFilter";
            this.labelFileFilter.Size = new System.Drawing.Size(55, 15);
            this.labelFileFilter.TabIndex = 42;
            this.labelFileFilter.Text = "File filter:";
            // 
            // btnFileFilterClear
            // 
            this.btnFileFilterClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFileFilterClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFileFilterClear.Location = new System.Drawing.Point(730, 699);
            this.btnFileFilterClear.Name = "btnFileFilterClear";
            this.btnFileFilterClear.Size = new System.Drawing.Size(32, 23);
            this.btnFileFilterClear.TabIndex = 79;
            this.btnFileFilterClear.Text = "X";
            this.btnFileFilterClear.UseVisualStyleBackColor = true;
            this.btnFileFilterClear.Click += new System.EventHandler(this.btnFileFilterClear_Click);
            // 
            // btnPlaylistFileFilterClear
            // 
            this.btnPlaylistFileFilterClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlaylistFileFilterClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPlaylistFileFilterClear.Location = new System.Drawing.Point(1116, 699);
            this.btnPlaylistFileFilterClear.Name = "btnPlaylistFileFilterClear";
            this.btnPlaylistFileFilterClear.Size = new System.Drawing.Size(30, 23);
            this.btnPlaylistFileFilterClear.TabIndex = 80;
            this.btnPlaylistFileFilterClear.Text = "X";
            this.btnPlaylistFileFilterClear.UseVisualStyleBackColor = true;
            this.btnPlaylistFileFilterClear.Click += new System.EventHandler(this.btnPlaylistFileFilterClear_Click);
            // 
            // btnPlaylistFolderFilterClear
            // 
            this.btnPlaylistFolderFilterClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlaylistFolderFilterClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPlaylistFolderFilterClear.Location = new System.Drawing.Point(1116, 670);
            this.btnPlaylistFolderFilterClear.Name = "btnPlaylistFolderFilterClear";
            this.btnPlaylistFolderFilterClear.Size = new System.Drawing.Size(30, 23);
            this.btnPlaylistFolderFilterClear.TabIndex = 81;
            this.btnPlaylistFolderFilterClear.Text = "X";
            this.btnPlaylistFolderFilterClear.UseVisualStyleBackColor = true;
            this.btnPlaylistFolderFilterClear.Click += new System.EventHandler(this.btnPlaylistFolderFilterClear_Click);
            // 
            // txtPlaylistFileFilter
            // 
            this.txtPlaylistFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPlaylistFileFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaylistFileFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPlaylistFileFilter.Location = new System.Drawing.Point(851, 699);
            this.txtPlaylistFileFilter.Name = "txtPlaylistFileFilter";
            this.txtPlaylistFileFilter.Size = new System.Drawing.Size(259, 23);
            this.txtPlaylistFileFilter.TabIndex = 24;
            this.txtPlaylistFileFilter.TextChanged += new System.EventHandler(this.txtPlaylistFileFilter_TextChanged);
            this.txtPlaylistFileFilter.DoubleClick += new System.EventHandler(this.txtPlaylistFileFilter_DoubleClick);
            // 
            // labelButton15
            // 
            this.labelButton15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton15.AutoSize = true;
            this.labelButton15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton15.Location = new System.Drawing.Point(1166, 698);
            this.labelButton15.Name = "labelButton15";
            this.labelButton15.Size = new System.Drawing.Size(19, 15);
            this.labelButton15.TabIndex = 77;
            this.labelButton15.Text = "15";
            // 
            // txtPlaylistFolderFilter
            // 
            this.txtPlaylistFolderFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPlaylistFolderFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaylistFolderFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPlaylistFolderFilter.Location = new System.Drawing.Point(851, 671);
            this.txtPlaylistFolderFilter.Name = "txtPlaylistFolderFilter";
            this.txtPlaylistFolderFilter.Size = new System.Drawing.Size(259, 23);
            this.txtPlaylistFolderFilter.TabIndex = 25;
            this.txtPlaylistFolderFilter.TextChanged += new System.EventHandler(this.txtPlaylistFolderFilter_TextChanged);
            this.txtPlaylistFolderFilter.DoubleClick += new System.EventHandler(this.txtPlaylistFolderFilter_DoubleClick);
            // 
            // labelPlaylistFileFilter
            // 
            this.labelPlaylistFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPlaylistFileFilter.AutoSize = true;
            this.labelPlaylistFileFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlaylistFileFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPlaylistFileFilter.Location = new System.Drawing.Point(790, 703);
            this.labelPlaylistFileFilter.Name = "labelPlaylistFileFilter";
            this.labelPlaylistFileFilter.Size = new System.Drawing.Size(55, 15);
            this.labelPlaylistFileFilter.TabIndex = 44;
            this.labelPlaylistFileFilter.Text = "File filter:";
            // 
            // labelButton14
            // 
            this.labelButton14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton14.AutoSize = true;
            this.labelButton14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton14.Location = new System.Drawing.Point(1166, 650);
            this.labelButton14.Name = "labelButton14";
            this.labelButton14.Size = new System.Drawing.Size(19, 15);
            this.labelButton14.TabIndex = 76;
            this.labelButton14.Text = "14";
            // 
            // labelPlaylistFolderFilter
            // 
            this.labelPlaylistFolderFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPlaylistFolderFilter.AutoSize = true;
            this.labelPlaylistFolderFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlaylistFolderFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPlaylistFolderFilter.Location = new System.Drawing.Point(775, 674);
            this.labelPlaylistFolderFilter.Name = "labelPlaylistFolderFilter";
            this.labelPlaylistFolderFilter.Size = new System.Drawing.Size(70, 15);
            this.labelPlaylistFolderFilter.TabIndex = 45;
            this.labelPlaylistFolderFilter.Text = "Folder filter:";
            // 
            // labelButton13
            // 
            this.labelButton13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton13.AutoSize = true;
            this.labelButton13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton13.Location = new System.Drawing.Point(1166, 602);
            this.labelButton13.Name = "labelButton13";
            this.labelButton13.Size = new System.Drawing.Size(19, 15);
            this.labelButton13.TabIndex = 75;
            this.labelButton13.Text = "13";
            // 
            // labelButton12
            // 
            this.labelButton12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton12.AutoSize = true;
            this.labelButton12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton12.Location = new System.Drawing.Point(1166, 554);
            this.labelButton12.Name = "labelButton12";
            this.labelButton12.Size = new System.Drawing.Size(19, 15);
            this.labelButton12.TabIndex = 74;
            this.labelButton12.Text = "12";
            // 
            // labelButton11
            // 
            this.labelButton11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton11.AutoSize = true;
            this.labelButton11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton11.Location = new System.Drawing.Point(1166, 506);
            this.labelButton11.Name = "labelButton11";
            this.labelButton11.Size = new System.Drawing.Size(19, 15);
            this.labelButton11.TabIndex = 73;
            this.labelButton11.Text = "11";
            // 
            // labelButton10
            // 
            this.labelButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton10.AutoSize = true;
            this.labelButton10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton10.Location = new System.Drawing.Point(1166, 458);
            this.labelButton10.Name = "labelButton10";
            this.labelButton10.Size = new System.Drawing.Size(19, 15);
            this.labelButton10.TabIndex = 72;
            this.labelButton10.Text = "10";
            // 
            // labelButton9
            // 
            this.labelButton9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton9.AutoSize = true;
            this.labelButton9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton9.Location = new System.Drawing.Point(1172, 410);
            this.labelButton9.Name = "labelButton9";
            this.labelButton9.Size = new System.Drawing.Size(13, 15);
            this.labelButton9.TabIndex = 71;
            this.labelButton9.Text = "9";
            // 
            // labelButton8
            // 
            this.labelButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton8.AutoSize = true;
            this.labelButton8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton8.Location = new System.Drawing.Point(1172, 362);
            this.labelButton8.Name = "labelButton8";
            this.labelButton8.Size = new System.Drawing.Size(13, 15);
            this.labelButton8.TabIndex = 70;
            this.labelButton8.Text = "8";
            // 
            // labelButton7
            // 
            this.labelButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton7.AutoSize = true;
            this.labelButton7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton7.Location = new System.Drawing.Point(1172, 314);
            this.labelButton7.Name = "labelButton7";
            this.labelButton7.Size = new System.Drawing.Size(13, 15);
            this.labelButton7.TabIndex = 69;
            this.labelButton7.Text = "7";
            // 
            // labelButton6
            // 
            this.labelButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton6.AutoSize = true;
            this.labelButton6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton6.Location = new System.Drawing.Point(1172, 266);
            this.labelButton6.Name = "labelButton6";
            this.labelButton6.Size = new System.Drawing.Size(13, 15);
            this.labelButton6.TabIndex = 68;
            this.labelButton6.Text = "6";
            // 
            // labelButton5
            // 
            this.labelButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton5.AutoSize = true;
            this.labelButton5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton5.Location = new System.Drawing.Point(1172, 218);
            this.labelButton5.Name = "labelButton5";
            this.labelButton5.Size = new System.Drawing.Size(13, 15);
            this.labelButton5.TabIndex = 67;
            this.labelButton5.Text = "5";
            // 
            // labelButton4
            // 
            this.labelButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton4.AutoSize = true;
            this.labelButton4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton4.Location = new System.Drawing.Point(1172, 170);
            this.labelButton4.Name = "labelButton4";
            this.labelButton4.Size = new System.Drawing.Size(13, 15);
            this.labelButton4.TabIndex = 66;
            this.labelButton4.Text = "4";
            // 
            // labelButton3
            // 
            this.labelButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton3.AutoSize = true;
            this.labelButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton3.Location = new System.Drawing.Point(1172, 122);
            this.labelButton3.Name = "labelButton3";
            this.labelButton3.Size = new System.Drawing.Size(13, 15);
            this.labelButton3.TabIndex = 65;
            this.labelButton3.Text = "3";
            // 
            // labelButton2
            // 
            this.labelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton2.AutoSize = true;
            this.labelButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton2.Location = new System.Drawing.Point(1172, 74);
            this.labelButton2.Name = "labelButton2";
            this.labelButton2.Size = new System.Drawing.Size(13, 15);
            this.labelButton2.TabIndex = 64;
            this.labelButton2.Text = "2";
            // 
            // labelButton1
            // 
            this.labelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelButton1.AutoSize = true;
            this.labelButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelButton1.Location = new System.Drawing.Point(1172, 26);
            this.labelButton1.Name = "labelButton1";
            this.labelButton1.Size = new System.Drawing.Size(13, 15);
            this.labelButton1.TabIndex = 63;
            this.labelButton1.Text = "1";
            // 
            // btn15
            // 
            this.btn15.AllowDrop = true;
            this.btn15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn15.Location = new System.Drawing.Point(1191, 683);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(195, 42);
            this.btn15.TabIndex = 62;
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btn_Click);
            this.btn15.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn15.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn15.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn15.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn14
            // 
            this.btn14.AllowDrop = true;
            this.btn14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn14.Location = new System.Drawing.Point(1191, 635);
            this.btn14.Name = "btn14";
            this.btn14.Size = new System.Drawing.Size(195, 42);
            this.btn14.TabIndex = 61;
            this.btn14.UseVisualStyleBackColor = true;
            this.btn14.Click += new System.EventHandler(this.btn_Click);
            this.btn14.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn14.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn14.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn14.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn13
            // 
            this.btn13.AllowDrop = true;
            this.btn13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn13.Location = new System.Drawing.Point(1191, 587);
            this.btn13.Name = "btn13";
            this.btn13.Size = new System.Drawing.Size(195, 42);
            this.btn13.TabIndex = 60;
            this.btn13.UseVisualStyleBackColor = true;
            this.btn13.Click += new System.EventHandler(this.btn_Click);
            this.btn13.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn13.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn13.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn13.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn12
            // 
            this.btn12.AllowDrop = true;
            this.btn12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn12.Location = new System.Drawing.Point(1191, 539);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(195, 42);
            this.btn12.TabIndex = 59;
            this.btn12.UseVisualStyleBackColor = true;
            this.btn12.Click += new System.EventHandler(this.btn_Click);
            this.btn12.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn12.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn12.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn12.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn11
            // 
            this.btn11.AllowDrop = true;
            this.btn11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn11.Location = new System.Drawing.Point(1191, 491);
            this.btn11.Name = "btn11";
            this.btn11.Size = new System.Drawing.Size(195, 42);
            this.btn11.TabIndex = 58;
            this.btn11.UseVisualStyleBackColor = true;
            this.btn11.Click += new System.EventHandler(this.btn_Click);
            this.btn11.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn11.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn11.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn11.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn10
            // 
            this.btn10.AllowDrop = true;
            this.btn10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn10.Location = new System.Drawing.Point(1191, 443);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(195, 42);
            this.btn10.TabIndex = 57;
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btn_Click);
            this.btn10.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn10.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn10.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn10.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn9
            // 
            this.btn9.AllowDrop = true;
            this.btn9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn9.Location = new System.Drawing.Point(1191, 395);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(195, 42);
            this.btn9.TabIndex = 56;
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn_Click);
            this.btn9.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn9.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn9.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn9.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn8
            // 
            this.btn8.AllowDrop = true;
            this.btn8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn8.Location = new System.Drawing.Point(1191, 347);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(195, 42);
            this.btn8.TabIndex = 55;
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn_Click);
            this.btn8.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn8.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn8.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn8.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn7
            // 
            this.btn7.AllowDrop = true;
            this.btn7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn7.Location = new System.Drawing.Point(1191, 299);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(195, 42);
            this.btn7.TabIndex = 54;
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn_Click);
            this.btn7.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn7.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn7.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn7.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn6
            // 
            this.btn6.AllowDrop = true;
            this.btn6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn6.Location = new System.Drawing.Point(1191, 251);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(195, 42);
            this.btn6.TabIndex = 53;
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn_Click);
            this.btn6.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn6.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn6.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn6.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn5
            // 
            this.btn5.AllowDrop = true;
            this.btn5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn5.Location = new System.Drawing.Point(1191, 203);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(195, 42);
            this.btn5.TabIndex = 52;
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn_Click);
            this.btn5.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn5.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn5.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn5.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn4
            // 
            this.btn4.AllowDrop = true;
            this.btn4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn4.Location = new System.Drawing.Point(1191, 155);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(195, 42);
            this.btn4.TabIndex = 51;
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn_Click);
            this.btn4.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn4.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn4.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn4.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn3
            // 
            this.btn3.AllowDrop = true;
            this.btn3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn3.Location = new System.Drawing.Point(1191, 107);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(195, 42);
            this.btn3.TabIndex = 50;
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn_Click);
            this.btn3.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn3.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn3.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn3.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn2
            // 
            this.btn2.AllowDrop = true;
            this.btn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn2.Location = new System.Drawing.Point(1191, 59);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(195, 42);
            this.btn2.TabIndex = 49;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            this.btn2.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn2.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn2.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn2.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // btn1
            // 
            this.btn1.AllowDrop = true;
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn1.Location = new System.Drawing.Point(1191, 11);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(195, 42);
            this.btn1.TabIndex = 48;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            this.btn1.DragDrop += new System.Windows.Forms.DragEventHandler(this.btn_DragDrop);
            this.btn1.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.btn1.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_DragOver);
            this.btn1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.btn_GiveFeedback);
            this.btn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            // 
            // radioFolders
            // 
            this.radioFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioFolders.AutoSize = true;
            this.radioFolders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFolders.Location = new System.Drawing.Point(1009, 11);
            this.radioFolders.Name = "radioFolders";
            this.radioFolders.Size = new System.Drawing.Size(63, 19);
            this.radioFolders.TabIndex = 103;
            this.radioFolders.Text = "Folders";
            this.radioFolders.UseVisualStyleBackColor = true;
            this.radioFolders.CheckedChanged += new System.EventHandler(this.radioFolders_CheckedChanged);
            // 
            // radioFiles
            // 
            this.radioFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioFiles.AutoSize = true;
            this.radioFiles.Checked = true;
            this.radioFiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFiles.Location = new System.Drawing.Point(1078, 11);
            this.radioFiles.Name = "radioFiles";
            this.radioFiles.Size = new System.Drawing.Size(48, 19);
            this.radioFiles.TabIndex = 104;
            this.radioFiles.TabStop = true;
            this.radioFiles.Text = "Files";
            this.radioFiles.UseVisualStyleBackColor = true;
            this.radioFiles.CheckedChanged += new System.EventHandler(this.radioFiles_CheckedChanged);
            // 
            // radioPlaylist
            // 
            this.radioPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPlaylist.AutoSize = true;
            this.radioPlaylist.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPlaylist.Location = new System.Drawing.Point(1132, 11);
            this.radioPlaylist.Name = "radioPlaylist";
            this.radioPlaylist.Size = new System.Drawing.Size(62, 19);
            this.radioPlaylist.TabIndex = 105;
            this.radioPlaylist.Text = "Playlist";
            this.radioPlaylist.UseVisualStyleBackColor = true;
            this.radioPlaylist.CheckedChanged += new System.EventHandler(this.radioPlaylist_CheckedChanged);
            // 
            // labelVolumeName
            // 
            this.labelVolumeName.AutoSize = true;
            this.labelVolumeName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelVolumeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelVolumeName.Location = new System.Drawing.Point(135, 13);
            this.labelVolumeName.Name = "labelVolumeName";
            this.labelVolumeName.Size = new System.Drawing.Size(50, 15);
            this.labelVolumeName.TabIndex = 40;
            this.labelVolumeName.Text = "Volume:";
            // 
            // labelRefresh
            // 
            this.labelRefresh.AutoSize = true;
            this.labelRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRefresh.Location = new System.Drawing.Point(356, 13);
            this.labelRefresh.Name = "labelRefresh";
            this.labelRefresh.Size = new System.Drawing.Size(49, 15);
            this.labelRefresh.TabIndex = 41;
            this.labelRefresh.Text = "Refresh:";
            // 
            // lstFolders
            // 
            this.lstFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmFolder,
            this.clmFolderName});
            this.lstFolders.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFolders.FullRowSelect = true;
            this.lstFolders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstFolders.HideSelection = false;
            this.lstFolders.Location = new System.Drawing.Point(11, 11);
            this.lstFolders.MultiSelect = false;
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.Size = new System.Drawing.Size(370, 672);
            this.lstFolders.TabIndex = 13;
            this.lstFolders.UseCompatibleStateImageBehavior = false;
            this.lstFolders.View = System.Windows.Forms.View.Details;
            this.lstFolders.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lstFolders_ItemDrag);
            this.lstFolders.SelectedIndexChanged += new System.EventHandler(this.lstFolders_SelectedIndexChanged);
            this.lstFolders.Layout += new System.Windows.Forms.LayoutEventHandler(this.lstFolders_Layout);
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
            this.clmFolderName.Text = "Folders";
            this.clmFolderName.Width = 103;
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmFile,
            this.clmFileName});
            this.lstFiles.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstFiles.FullRowSelect = true;
            this.lstFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstFiles.HideSelection = false;
            this.lstFiles.Location = new System.Drawing.Point(392, 11);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(370, 672);
            this.lstFiles.TabIndex = 14;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lstFiles_ItemDrag);
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragDrop);
            this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragEnter);
            this.lstFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragOver);
            this.lstFiles.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.lstFiles_GiveFeedback);
            this.lstFiles.Layout += new System.Windows.Forms.LayoutEventHandler(this.lstFiles_Layout);
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
            this.clmFileName.Text = "Files";
            this.clmFileName.Width = 100;
            // 
            // lstPlaylist
            // 
            this.lstPlaylist.AllowDrop = true;
            this.lstPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPlaylist,
            this.clmPlaylistNum,
            this.clmPlaylistFolder,
            this.clmPlaylistFile});
            this.lstPlaylist.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstPlaylist.FullRowSelect = true;
            this.lstPlaylist.HideSelection = false;
            this.lstPlaylist.Location = new System.Drawing.Point(776, 11);
            this.lstPlaylist.Name = "lstPlaylist";
            this.lstPlaylist.Size = new System.Drawing.Size(370, 642);
            this.lstPlaylist.TabIndex = 15;
            this.lstPlaylist.UseCompatibleStateImageBehavior = false;
            this.lstPlaylist.View = System.Windows.Forms.View.Details;
            this.lstPlaylist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lstPlaylist_ItemDrag);
            this.lstPlaylist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPlaylist_DragDrop);
            this.lstPlaylist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstPlaylist_DragEnter);
            this.lstPlaylist.DragOver += new System.Windows.Forms.DragEventHandler(this.lstPlaylist_DragOver);
            this.lstPlaylist.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.lstPlaylist_GiveFeedback);
            this.lstPlaylist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPlaylist_KeyDown);
            this.lstPlaylist.Layout += new System.Windows.Forms.LayoutEventHandler(this.lstPlaylist_Layout);
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
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1399, 801);
            this.Controls.Add(this.comboLatency);
            this.Controls.Add(this.radioFolders);
            this.Controls.Add(this.radioFiles);
            this.Controls.Add(this.radioPlaylist);
            this.Controls.Add(this.labelRefresh);
            this.Controls.Add(this.labelVolumeName);
            this.Controls.Add(this.panelBack);
            this.Controls.Add(this.labelRefreshMs);
            this.Controls.Add(this.labelVolumePercent);
            this.Controls.Add(this.panelToolbarLine);
            this.Controls.Add(this.toolStripSettings);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1415, 840);
            this.Name = "frmPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pätkä Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayer_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayer_Load);
            this.Shown += new System.EventHandler(this.frmPlayer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPlayer_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frmPlayer_PreviewKeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripPlay.ResumeLayout(false);
            this.toolStripPlay.PerformLayout();
            this.toolStripSettings.ResumeLayout(false);
            this.toolStripSettings.PerformLayout();
            this.panelBack.ResumeLayout(false);
            this.panelBack.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
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
        private System.Windows.Forms.Label labelVolumePercent;
        private System.Windows.Forms.ToolStripStatusLabel labelTimer2;
        private System.Windows.Forms.ComboBox comboLatency;
        private System.Windows.Forms.Label labelRefreshMs;
        private System.Windows.Forms.Timer timerKeyDown;
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
        private System.Windows.Forms.Label labelVolumeName;
        private System.Windows.Forms.ToolStripButton btnSavePlaylist;
        private System.Windows.Forms.ToolStripButton btnLoadPlaylist;
        private System.Windows.Forms.ToolStripButton btnClearPlaylist;
        private System.Windows.Forms.MenuItem menuTimers;
        private System.Windows.Forms.MenuItem menuHotkeys;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Label labelRefresh;
        private System.Windows.Forms.Label labelFileFilter;
        private System.Windows.Forms.Label labelFolderFilter;
        private System.Windows.Forms.Label labelPlaylistFolderFilter;
        private System.Windows.Forms.Label labelPlaylistFileFilter;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn12;
        private System.Windows.Forms.Button btn11;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn14;
        private System.Windows.Forms.Button btn13;
        private System.Windows.Forms.Label labelButton15;
        private System.Windows.Forms.Label labelButton14;
        private System.Windows.Forms.Label labelButton13;
        private System.Windows.Forms.Label labelButton12;
        private System.Windows.Forms.Label labelButton11;
        private System.Windows.Forms.Label labelButton10;
        private System.Windows.Forms.Label labelButton9;
        private System.Windows.Forms.Label labelButton8;
        private System.Windows.Forms.Label labelButton7;
        private System.Windows.Forms.Label labelButton6;
        private System.Windows.Forms.Label labelButton5;
        private System.Windows.Forms.Label labelButton4;
        private System.Windows.Forms.Label labelButton3;
        private System.Windows.Forms.Label labelButton2;
        private System.Windows.Forms.Label labelButton1;
        private System.Windows.Forms.Button btnFileFilterClear;
        private System.Windows.Forms.Button btnFolderFilterClear;
        private System.Windows.Forms.Button btnPlaylistFolderFilterClear;
        private System.Windows.Forms.Button btnPlaylistFileFilterClear;
        private System.Windows.Forms.RadioButton radioFolders;
        private System.Windows.Forms.RadioButton radioPlaylist;
        private System.Windows.Forms.RadioButton radioFiles;
    }
}

