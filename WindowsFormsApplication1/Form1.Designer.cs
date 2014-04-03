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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.labelTotalClips = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLastPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelToolStripLine = new System.Windows.Forms.Panel();
            this.toolStripPlay = new System.Windows.Forms.ToolStrip();
            this.btnRandom = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnReplay = new System.Windows.Forms.ToolStripButton();
            this.checkRepeat = new System.Windows.Forms.ToolStripButton();
            this.toolStripFilters = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtFilterFolder = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtFilterFile = new System.Windows.Forms.ToolStripTextBox();
            this.btnClearFilters = new System.Windows.Forms.ToolStripButton();
            this.toolStripSettings = new System.Windows.Forms.ToolStrip();
            this.btnToggle = new System.Windows.Forms.ToolStripButton();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.labelClipsPlayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.toolStripPlay.SuspendLayout();
            this.toolStripFilters.SuspendLayout();
            this.toolStripSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.AutoScroll = true;
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelButtons.Controls.Add(this.statusStrip1);
            this.panelButtons.ForeColor = System.Drawing.Color.Black;
            this.panelButtons.Location = new System.Drawing.Point(0, 1);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1133, 518);
            this.panelButtons.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel10});
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1134, 25);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel1.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = " 1.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " 2.";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = " 3.";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.AutoSize = false;
            this.toolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = " 4.";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.AutoSize = false;
            this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel5.Spring = true;
            this.toolStripStatusLabel5.Text = " 5.";
            this.toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.AutoSize = false;
            this.toolStripStatusLabel6.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel6.Spring = true;
            this.toolStripStatusLabel6.Text = " 6.";
            this.toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.AutoSize = false;
            this.toolStripStatusLabel7.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel7.Spring = true;
            this.toolStripStatusLabel7.Text = " 7.";
            this.toolStripStatusLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.AutoSize = false;
            this.toolStripStatusLabel8.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel8.Spring = true;
            this.toolStripStatusLabel8.Text = " 8.";
            this.toolStripStatusLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.AutoSize = false;
            this.toolStripStatusLabel9.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel9.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel9.Spring = true;
            this.toolStripStatusLabel9.Text = " 9.";
            this.toolStripStatusLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.AutoSize = false;
            this.toolStripStatusLabel10.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel10.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripStatusLabel10.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel10.Spring = true;
            this.toolStripStatusLabel10.Text = " 0.";
            this.toolStripStatusLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripPlay);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripFilters);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripSettings);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelTotalClips,
            this.labelClipsPlayed,
            this.labelLastPlayed,
            this.labelClock});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1134, 24);
            this.statusStrip2.TabIndex = 0;
            this.statusStrip2.Text = "dsadas";
            // 
            // labelTotalClips
            // 
            this.labelTotalClips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalClips.Name = "labelTotalClips";
            this.labelTotalClips.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelTotalClips.Size = new System.Drawing.Size(54, 19);
            this.labelTotalClips.Text = "Clips: -";
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
            // 
            // labelClock
            // 
            this.labelClock.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelClock.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClock.Name = "labelClock";
            this.labelClock.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.labelClock.Size = new System.Drawing.Size(45, 19);
            this.labelClock.Text = "test";
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
            this.toolStripPlay.Size = new System.Drawing.Size(211, 34);
            this.toolStripPlay.TabIndex = 1;
            // 
            // btnRandom
            // 
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
            this.checkRepeat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.checkRepeat.Image = ((System.Drawing.Image)(resources.GetObject("checkRepeat.Image")));
            this.checkRepeat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkRepeat.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.checkRepeat.Name = "checkRepeat";
            this.checkRepeat.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.checkRepeat.Size = new System.Drawing.Size(53, 29);
            this.checkRepeat.Text = "Repeat";
            this.checkRepeat.Click += new System.EventHandler(this.checkRepeat_Click);
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
            this.toolStripFilters.Size = new System.Drawing.Size(464, 34);
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
            this.txtFilterFolder.Size = new System.Drawing.Size(94, 31);
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
            this.txtFilterFile.Size = new System.Drawing.Size(100, 31);
            // 
            // btnClearFilters
            // 
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
            // toolStripSettings
            // 
            this.toolStripSettings.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToggle,
            this.btnSettings,
            this.btnReload});
            this.toolStripSettings.Location = new System.Drawing.Point(3, 0);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripSettings.Size = new System.Drawing.Size(220, 34);
            this.toolStripSettings.TabIndex = 2;
            // 
            // btnToggle
            // 
            this.btnToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnToggle.Image = ((System.Drawing.Image)(resources.GetObject("btnToggle.Image")));
            this.btnToggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToggle.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnToggle.Size = new System.Drawing.Size(96, 29);
            this.btnToggle.Text = "Switch To Mini";
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSettings.Size = new System.Drawing.Size(68, 29);
            this.btnSettings.Text = "Settings...";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnReload.Size = new System.Drawing.Size(53, 29);
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
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
            // labelClipsPlayed
            // 
            this.labelClipsPlayed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelClipsPlayed.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelClipsPlayed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClipsPlayed.Name = "labelClipsPlayed";
            this.labelClipsPlayed.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelClipsPlayed.Size = new System.Drawing.Size(66, 19);
            this.labelClipsPlayed.Text = "Count: 0";
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1134, 645);
            this.Controls.Add(this.toolStripContainer1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(900, 97);
            this.Name = "frmPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pätkä Player";
            this.panelButtons.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.toolStripPlay.ResumeLayout(false);
            this.toolStripPlay.PerformLayout();
            this.toolStripFilters.ResumeLayout(false);
            this.toolStripFilters.PerformLayout();
            this.toolStripSettings.ResumeLayout(false);
            this.toolStripSettings.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripButton btnSettings;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripButton btnToggle;
        private System.Windows.Forms.ToolStripStatusLabel labelClock;
        private System.Windows.Forms.ToolStripButton btnClearFilters;
        private System.Windows.Forms.ToolStripStatusLabel labelClipsPlayed;
    }
}

