namespace PatkaPlayer
{
    partial class FormHotkey
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTopic = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboAction = new System.Windows.Forms.ComboBox();
            this.checkGlobal = new System.Windows.Forms.CheckBox();
            this.txtHotkey = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnHotkeyCancel = new System.Windows.Forms.Button();
            this.btnHotkeyOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.labelTopic);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 41);
            this.panel1.TabIndex = 7;
            // 
            // labelTopic
            // 
            this.labelTopic.AutoSize = true;
            this.labelTopic.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopic.Location = new System.Drawing.Point(20, 14);
            this.labelTopic.Name = "labelTopic";
            this.labelTopic.Size = new System.Drawing.Size(93, 13);
            this.labelTopic.TabIndex = 0;
            this.labelTopic.Text = "Add new hotkey";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Hotkey:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Action:";
            // 
            // comboAction
            // 
            this.comboAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAction.FormattingEnabled = true;
            this.comboAction.Items.AddRange(new object[] {
            "Random",
            "Replay",
            "Stop",
            "Volume up",
            "Volume down",
            "Quick filter",
            "Focus application",
            "Playmode: Folder",
            "Playmode: File",
            "Playmode: Playlist",
            "Start timer1",
            "Start timer2",
            "Stop timer",
            "Play clip 1",
            "Play clip 2",
            "Play clip 3",
            "Play clip 4",
            "Play clip 5",
            "Play clip 6",
            "Play clip 7",
            "Play clip 8",
            "Play clip 9",
            "Play clip 10",
            "Play clip 11",
            "Play clip 12",
            "Play clip 13",
            "Play clip 14",
            "Play clip 15"});
            this.comboAction.Location = new System.Drawing.Point(74, 56);
            this.comboAction.Name = "comboAction";
            this.comboAction.Size = new System.Drawing.Size(183, 21);
            this.comboAction.TabIndex = 12;
            // 
            // checkGlobal
            // 
            this.checkGlobal.AutoSize = true;
            this.checkGlobal.Location = new System.Drawing.Point(74, 120);
            this.checkGlobal.Name = "checkGlobal";
            this.checkGlobal.Size = new System.Drawing.Size(91, 17);
            this.checkGlobal.TabIndex = 11;
            this.checkGlobal.Text = "Global hotkey";
            this.checkGlobal.UseVisualStyleBackColor = true;
            // 
            // txtHotkey
            // 
            this.txtHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHotkey.Location = new System.Drawing.Point(74, 89);
            this.txtHotkey.Name = "txtHotkey";
            this.txtHotkey.Size = new System.Drawing.Size(183, 20);
            this.txtHotkey.TabIndex = 10;
            this.txtHotkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHotkey.Enter += new System.EventHandler(this.txtHotkey_Enter);
            this.txtHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);
            this.txtHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyUp);
            this.txtHotkey.Leave += new System.EventHandler(this.txtHotkey_Leave);
            this.txtHotkey.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtHotkey_PreviewKeyDown);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Location = new System.Drawing.Point(0, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 1);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel4.Location = new System.Drawing.Point(0, 151);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(285, 1);
            this.panel4.TabIndex = 16;
            // 
            // btnHotkeyCancel
            // 
            this.btnHotkeyCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHotkeyCancel.Location = new System.Drawing.Point(198, 164);
            this.btnHotkeyCancel.Name = "btnHotkeyCancel";
            this.btnHotkeyCancel.Size = new System.Drawing.Size(75, 23);
            this.btnHotkeyCancel.TabIndex = 18;
            this.btnHotkeyCancel.Text = "Cancel";
            this.btnHotkeyCancel.UseVisualStyleBackColor = true;
            this.btnHotkeyCancel.Click += new System.EventHandler(this.btnHotkeyCancel_Click);
            // 
            // btnHotkeyOk
            // 
            this.btnHotkeyOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHotkeyOk.Location = new System.Drawing.Point(12, 164);
            this.btnHotkeyOk.Name = "btnHotkeyOk";
            this.btnHotkeyOk.Size = new System.Drawing.Size(75, 23);
            this.btnHotkeyOk.TabIndex = 15;
            this.btnHotkeyOk.Text = "OK";
            this.btnHotkeyOk.UseVisualStyleBackColor = true;
            this.btnHotkeyOk.Click += new System.EventHandler(this.btnHotkeyOk_Click);
            // 
            // FormHotkey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 198);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnHotkeyCancel);
            this.Controls.Add(this.btnHotkeyOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboAction);
            this.Controls.Add(this.checkGlobal);
            this.Controls.Add(this.txtHotkey);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHotkey";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hotkeys";
            this.Shown += new System.EventHandler(this.FormHotkey_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTopic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboAction;
        private System.Windows.Forms.CheckBox checkGlobal;
        private System.Windows.Forms.TextBox txtHotkey;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnHotkeyCancel;
        private System.Windows.Forms.Button btnHotkeyOk;
    }
}