using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using Microsoft.VisualBasic.PowerPacks;
using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace PatkaPlayer
{
    public partial class frmPlayer : Form
    {

        private Mp3Player _mp3Player;
        private string[] array1 = new string[] {};
        private bool minimized { get; set; }
        private string mp3Dir, hotkey1, hotkey2, hotkey3, hotkey4, hotkey5, hotkey6, hotkey7, hotkey8, hotkey9, hotkey0;
        private int frmSize = 1;
        private int frmMaximized;
        private string lastPlayed;
        private string appName = "Pätkä Player";
        private string filterFolder = "";
        private string filterFile = "";
        private int normalSizeX;
        private int normalSizeY;
        private int playerButtonX;
        private int numOfButtons;
        private int numOfCols;
        private List<string> randomSound = new List<string>();
        private int lastRandomNumber = 0;

        public frmPlayer()
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            this.SizeChanged += new EventHandler(Form1_Layout);
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            txtFilterFolder.KeyDown += new KeyEventHandler(txtFilterFolder_KeyDown);
            txtFilterFile.KeyDown += new KeyEventHandler(txtFilterFile_KeyDown);

            InsertPanelButtons();
        }

        // read application settings from config file
        public void ReadSettings()
        {
            mp3Dir = hotkey1 = hotkey2 = hotkey3 = hotkey4 = hotkey5 = hotkey6 = hotkey7 = hotkey8 = hotkey9 = hotkey0 = "";

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConfigurationManager.RefreshSection("appSettings");

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["mp3dir"])) mp3Dir = config.AppSettings.Settings["mp3dir"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_1"])) hotkey1 = config.AppSettings.Settings["hotkey_1"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_2"])) hotkey2 = config.AppSettings.Settings["hotkey_2"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_3"])) hotkey3 = config.AppSettings.Settings["hotkey_3"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_4"])) hotkey4 = config.AppSettings.Settings["hotkey_4"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_5"])) hotkey5 = config.AppSettings.Settings["hotkey_5"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_6"])) hotkey6 = config.AppSettings.Settings["hotkey_6"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_7"])) hotkey7 = config.AppSettings.Settings["hotkey_7"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_8"])) hotkey8 = config.AppSettings.Settings["hotkey_8"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_9"])) hotkey9 = config.AppSettings.Settings["hotkey_9"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_0"])) hotkey0 = config.AppSettings.Settings["hotkey_0"].Value;
        }

        // error text to form, eg. "no clips", "no folder selected", etc...
        public void ErrorText(string errorText)
        {
            panelButtons.Controls.Clear();

            Label label = new Label();
            label.Top = 12;
            label.Left = 10;
            label.Text = errorText;
            label.Width = 900;
            label.Height = 100;
            label.Font = new Font("Segoe UI", 12);

            panelButtons.Controls.Add(label);
        }

        public void InsertPanelButtons()
        {
            ReadSettings();

            if (Directory.Exists(mp3Dir))
            {
                array1 = Directory.GetFiles(@mp3Dir, "*.mp3", SearchOption.AllDirectories);
                AddPanel(mp3Dir);
            }
            else if (mp3Dir != "") ErrorText("Selected audio folder does not exist. Go to settings and reselect folder.");
            else ErrorText("No audio folder selected. Go to settings and select folder.");
        }

        // add panel for soundbuttons
        public void AddPanel(string mp3Dir)
        {
            panelButtons.Controls.Clear();
            panelButtons.Visible = false;

            int top = 5;
            int left = 10;

            string lastPath = "";
            string currentPath = "";
            string currentPathOnly = "";
            int cols = 0;
            int numColor = 0;
            numOfButtons = 0;
            string fileName = "";
            string folderName = "";

            toolStripStatusLabel1.Text = " 1.  " + Path.GetFileNameWithoutExtension(hotkey1);
            toolStripStatusLabel2.Text = " 2.  " + Path.GetFileNameWithoutExtension(hotkey2);
            toolStripStatusLabel3.Text = " 3.  " + Path.GetFileNameWithoutExtension(hotkey3);
            toolStripStatusLabel4.Text = " 4.  " + Path.GetFileNameWithoutExtension(hotkey4);
            toolStripStatusLabel5.Text = " 5.  " + Path.GetFileNameWithoutExtension(hotkey5);
            toolStripStatusLabel6.Text = " 6.  " + Path.GetFileNameWithoutExtension(hotkey6);
            toolStripStatusLabel7.Text = " 7.  " + Path.GetFileNameWithoutExtension(hotkey7);
            toolStripStatusLabel8.Text = " 8.  " + Path.GetFileNameWithoutExtension(hotkey8);
            toolStripStatusLabel9.Text = " 9.  " + Path.GetFileNameWithoutExtension(hotkey9);
            toolStripStatusLabel10.Text = " 0.  " + Path.GetFileNameWithoutExtension(hotkey0);

            //int numOfCols;
            if (panelButtons.Width > 200) numOfCols = panelButtons.Width / 150;
            else numOfCols = 2;


            if (array1.Length == 0) ErrorText("No audio clips found. Go to settings and select another audio folder.");
            randomSound.Clear();

            // loop for adding buttons
            for (int i = 0; i < array1.Length; i++)
            {

                if (filterFolder != "") folderName = Path.GetDirectoryName(array1[i]).Substring(Path.GetDirectoryName(array1[i]).LastIndexOf("\\") + 1);
                if (filterFile != "") fileName = Path.GetFileNameWithoutExtension(array1[i]);

                if (filterFile != "" && fileName.IndexOf(filterFile, StringComparison.OrdinalIgnoreCase) == -1) continue;
                if (filterFolder != "" && folderName.IndexOf(filterFolder, StringComparison.OrdinalIgnoreCase) == -1) continue;

                if (frmSize == 2) continue;

                cols++;
                numOfButtons++;

                randomSound.Add(array1[i]);
                
                currentPath = Path.GetDirectoryName(array1[i]);

                if (currentPath != lastPath)
                {

                    numColor++;
                    if (numOfButtons > 0 && cols > 1) top += 73;
                    else if (numOfButtons > 1 && cols == 1) top += 16;

                    currentPathOnly = currentPath.Substring(currentPath.LastIndexOf("\\") + 1);

                    // add new separator line between folders, but not before first one
                    if (numOfButtons > 1)
                    {
                        Panel panel = new Panel();
                        panel.Top = top - 6;
                        panel.Left = 12;
                        panel.AutoSize = false;
                        panel.Height = 1;
                        panel.Width = panelButtons.Width - 45;
                        panel.BorderStyle = BorderStyle.None;
                        panel.BackColor = Color.FromArgb(200, 200, 200);
                        panelButtons.Controls.Add(panel);
                    }

                    top += 6;

                    // label for folder name
                    Label folderLabel = new Label();
                    folderLabel.Top = top;
                    folderLabel.Left = 12;
                    folderLabel.Text = currentPathOnly;
                    folderLabel.Width = panelButtons.Width - 45;
                    folderLabel.Height = 30;
                    folderLabel.BorderStyle = BorderStyle.None;
                    folderLabel.Font = new Font("Segoe UI", 13);
                    folderLabel.ForeColor = ColorTranslator.FromHtml("#222");

                    panelButtons.Controls.Add(folderLabel);

                    top += folderLabel.Height + 8;
                    left = 10;
                    cols = 1;
                }

                Panel buttonPanel1 = new Panel();
                buttonPanel1.Top = top - 1;
                buttonPanel1.Left = left - 1;
                buttonPanel1.AutoSize = false;
                buttonPanel1.Height = 50 + 2;
                buttonPanel1.Width = (panelButtons.Width - ((numOfCols - 1) * 6 + 40)) / numOfCols + 2;
                buttonPanel1.BorderStyle = BorderStyle.None;
                buttonPanel1.Name = "SoundPanel" + numOfButtons.ToString();

                Button button = new Button();
                button.Top = top;
                button.Left = left;
                button.Text = Path.GetFileNameWithoutExtension(array1[i]); // filename only
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.Tag = array1[i]; // filepath + filename + ext
                button.Width = (panelButtons.Width - ((numOfCols - 1) * 6 + 40)) / numOfCols;
                button.Height = 50;
                //button.Padding = new Padding(0);
                button.Font = new Font("Segoe UI", 10);
                button.Name = "SoundButton" + numOfButtons.ToString();

                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 1;

                // different colors for even and odd folders
                if (numColor > 5) numColor = 1;

                switch (numColor)
                {
                    case 1:
                        // orange
                        button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        button.BackColor = ColorTranslator.FromHtml("#e27a25");
                        button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#ffbd65"); // +25 bg lightness
                        button.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#ff963c");
                        button.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#e27a25"); // bg
                        buttonPanel1.BackColor = ColorTranslator.FromHtml("#b25300"); // -15 bg lightness
                        break;

                    case 2:
                        // green
                        button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        button.BackColor = ColorTranslator.FromHtml("#1dbe6f");
                        button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#92f1bb");
                        button.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#48da89");
                        button.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1dbe6f");
                        buttonPanel1.BackColor = ColorTranslator.FromHtml("#00944a");
                        break;

                    case 3:
                        // red
                        button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        button.BackColor = ColorTranslator.FromHtml("#dc3c44");
                        button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#ff857f");
                        button.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#f75758");
                        button.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#dc3c44");
                        buttonPanel1.BackColor = ColorTranslator.FromHtml("#ac0022");
                        break;

                    case 4:
                        // blue
                        button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        button.BackColor = ColorTranslator.FromHtml("#3185a7");
                        button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#7dc9ee");
                        button.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#55a3c6");
                        button.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#3185a7");
                        buttonPanel1.BackColor = ColorTranslator.FromHtml("#006081");
                        break;

                    case 5:
                        // violet
                        button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        button.BackColor = ColorTranslator.FromHtml("#b688ba");
                        button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#f4bff4");
                        button.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#cc9bce");
                        button.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#b688ba");
                        buttonPanel1.BackColor = ColorTranslator.FromHtml("#906393");
                        break;
                }

                button.Click += new System.EventHandler(btnSound_Click);

                // new row for buttons
                if (cols % numOfCols == 0)
                {
                    left = 10;
                    top += button.Height + 6;
                    cols = 0;
                }
                else left += button.Width + 6;

                panelButtons.Controls.Add(buttonPanel1);
                panelButtons.Controls.Add(button);
                button.BringToFront();

                lastPath = currentPath;

            }

            // dummy invisible label to add space to bottom
            Label labelBottom = new Label();
            labelBottom.Top = top + 71;
            labelBottom.Left = 12;
            labelBottom.AutoSize = false;
            labelBottom.Height = 0;
            labelBottom.Width = panelButtons.Width - 45;
            labelBottom.BorderStyle = BorderStyle.Fixed3D;
            panelButtons.Controls.Add(labelBottom);

            panelButtons.Visible = true;
        }

        // stop-button action
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_mp3Player != null)
            _mp3Player.Stop();
        }

        // generated play-buttons action
        private void btnSound_Click(object sender, EventArgs e)
        {

            Button temp = (Button)sender;
            string fileToPlay = temp.Tag.ToString();
            string pathToPlay = Path.GetDirectoryName(fileToPlay);

            Button button = this.Controls.Find("btnReplay", true).FirstOrDefault() as Button;
            button.Tag = fileToPlay;

            lastPlayed = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " - " + temp.Text;
            this.Text = appName + " - " + lastPlayed;

            if (_mp3Player != null) _mp3Player.Dispose();
            _mp3Player = new Mp3Player(fileToPlay);

            if (checkRepeat.Checked) _mp3Player.Repeat = true;
            else _mp3Player.Repeat = false;

            _mp3Player.Play();
        }


        // sets focus to panelButtons on mousescroll
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            panelButtons.Focus();
        }

        // window size changes
        private void Form1_Layout(object sender, System.EventArgs e)
        {
            if (frmSize == 2) return;
            if (panelButtons.Width == 0) minimized = true;
            
            if (!minimized && panelButtons.Width > 0)
            {
                InsertPanelButtons();
                
                /*
                int columns = 7;

                for (int i = 1; i <= array1.Length; i++)
                {
                    string bName = "SoundButton" + i.ToString();
                    Button b = this.Controls.Find(bName, true).FirstOrDefault() as Button;

                    b.Width = (panelButtons.Width - ((columns - 1) * 6 + 40)) / columns;

                }
                */
                
            }
            
            if (panelButtons.Width > 0) minimized = false;
        }

        // keypress event
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ActiveControl.Name == "txtFilterFolder" || this.ActiveControl.Name == "txtFilterFile") return;

            if (e.KeyChar == 120 || e.KeyChar == 88 || e.KeyChar == (char)Keys.Back) PlayRandom();
            if (e.KeyChar == 114 || e.KeyChar == 82 || e.KeyChar == (char)Keys.PageUp) btnReplay.PerformClick();

            if (e.KeyChar == 49 && File.Exists(hotkey1)) playFile(hotkey1);
            if (e.KeyChar == 50 && File.Exists(hotkey2)) playFile(hotkey2);
            if (e.KeyChar == 51 && File.Exists(hotkey3)) playFile(hotkey3);
            if (e.KeyChar == 52 && File.Exists(hotkey4)) playFile(hotkey4);
            if (e.KeyChar == 53 && File.Exists(hotkey5)) playFile(hotkey5);
            if (e.KeyChar == 54 && File.Exists(hotkey6)) playFile(hotkey6);
            if (e.KeyChar == 55 && File.Exists(hotkey7)) playFile(hotkey7);
            if (e.KeyChar == 56 && File.Exists(hotkey8)) playFile(hotkey8);
            if (e.KeyChar == 57 && File.Exists(hotkey9)) playFile(hotkey9);
            if (e.KeyChar == 48 && File.Exists(hotkey0)) playFile(hotkey0);

            if (e.KeyChar == 44 && File.Exists(hotkey1)) playFile(hotkey1);
            if (e.KeyChar == 97 && File.Exists(hotkey2)) playFile(hotkey2);
            if (e.KeyChar == 100 && File.Exists(hotkey3)) playFile(hotkey3);
            if (e.KeyChar == 103 && File.Exists(hotkey4)) playFile(hotkey4);
            if (e.KeyChar == 106 && File.Exists(hotkey5)) playFile(hotkey5);
            if (e.KeyChar == 109 && File.Exists(hotkey6)) playFile(hotkey6);
            if (e.KeyChar == 112 && File.Exists(hotkey7)) playFile(hotkey7);
            if (e.KeyChar == 116 && File.Exists(hotkey8)) playFile(hotkey8);
            if (e.KeyChar == 119 && File.Exists(hotkey9)) playFile(hotkey9);
            if (e.KeyChar == 32 && File.Exists(hotkey0)) playFile(hotkey0);
        }

        private void playFile(string fileToPlay)
        {
            string pathToPlay = Path.GetDirectoryName(fileToPlay);

            Button button = this.Controls.Find("btnReplay", true).FirstOrDefault() as Button;
            button.Tag = fileToPlay;

            lastPlayed = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(fileToPlay);
            this.Text = appName + " - " + lastPlayed;
            
            if (_mp3Player != null) _mp3Player.Dispose();
            _mp3Player = new Mp3Player(fileToPlay);

            if (checkRepeat.Checked) _mp3Player.Repeat = true;
            else _mp3Player.Repeat = false;

            _mp3Player.Play();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            InsertPanelButtons();
        }

        // replay button
        private void btnReplay_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            string fileToPlay = temp.Tag.ToString();

            if (fileToPlay != "nofile")
            {
                if (_mp3Player != null) _mp3Player.Dispose();
                _mp3Player = new Mp3Player(fileToPlay);

                if (checkRepeat.Checked) _mp3Player.Repeat = true;
                else _mp3Player.Repeat = false;
                _mp3Player.Play();
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (array1.Length > 0) PlayRandom();
        }

        public void PlayRandom()
        {
            Random random = new Random();
            int clipCount = randomSound.Count;
            int randomNumber = random.Next(0, clipCount);

            if (clipCount > 1)
            {
                while (randomNumber == lastRandomNumber)
                {
                    randomNumber = random.Next(0, clipCount);
                }
            }

            lastRandomNumber = randomNumber;

            string fileToPlay = randomSound[randomNumber].ToString();
            string pathToPlay = Path.GetDirectoryName(fileToPlay);

            Button button = this.Controls.Find("btnReplay", true).FirstOrDefault() as Button;
            button.Tag = fileToPlay;

            lastPlayed = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(fileToPlay);
            this.Text = appName + " - " + lastPlayed;

            if (_mp3Player != null) _mp3Player.Dispose();
            _mp3Player = new Mp3Player(fileToPlay);

            if (checkRepeat.Checked) _mp3Player.Repeat = true;
            else _mp3Player.Repeat = false;

            _mp3Player.Play();

        }

        // show settings dialog
        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings(this);

            // Show the settings form
            settingsForm.ShowDialog();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized) frmMaximized = 1;

            if (frmSize == 1) // switch to mini player
            {
                // hide window
                fadeOut();
                this.Opacity = 0;

                frmSize = 2;

                // restore window to normal if maximized, then save size to variables
                this.WindowState = FormWindowState.Normal;
                normalSizeX = this.Width;
                normalSizeY = this.Height;
                playerButtonX = btnToggle.Left;

                this.MaximizeBox = false;
                //this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.MinimumSize = new Size(100, 106);
                this.Size = new Size(800, 106);

                Screen screen = Screen.FromPoint(Cursor.Position);
                this.Left = screen.WorkingArea.Left + (screen.Bounds.Size.Width - (this.Width + 10));
                this.Top = screen.WorkingArea.Top + (screen.Bounds.Size.Height - (this.Height + 50));

                this.btnToggle.Text = "Switch To Normal";

                panelButtons.Visible = false;
                txtFilterFolder.Visible = false;
                txtFilterFile.Visible = false;
                btnFilterFolder.Visible = false;
                btnFilterFile.Visible = false;
                btnReload.Visible = false;
                btnSettings.Visible = false;
                btnToggle.Left = 670;

                fadeIn();
                this.Opacity = 1;
            }

            else // switch to normal player
            {
                // hide window
                fadeOut();
                this.Opacity = 0;

                this.MaximizeBox = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MinimumSize = new Size(1050, 113);

                // restore window size
                this.Width = normalSizeX;
                this.Height = normalSizeY;
                btnToggle.Left = playerButtonX;

                this.btnToggle.Text = "Switch To Mini";

                Screen screen = Screen.FromPoint(Cursor.Position);
                this.Left = screen.WorkingArea.Left + (screen.Bounds.Size.Width / 2 - this.Width / 2);
                this.Top = screen.WorkingArea.Top + (screen.Bounds.Size.Height / 2 - this.Height / 2);

                if (frmMaximized == 1) this.WindowState = FormWindowState.Maximized;
                frmMaximized = 0;

                panelButtons.Visible = true;
                txtFilterFolder.Visible = true;
                txtFilterFile.Visible = true;
                btnFilterFolder.Visible = true;
                btnFilterFile.Visible = true;
                btnReload.Visible = true;
                btnSettings.Visible = true;
                
                frmSize = 1;
                fadeIn();
                this.Opacity = 1;
            }
            
        }

        private void fadeIn()
        {
            for (double i = 0.0; i <= 1.0; i += 0.1)
            {
                System.Threading.Thread.Sleep(10);
                this.Opacity = i;
            }
        }

        private void fadeOut()
        {
            for (double i = 1.0; i >= 0.0; i -= 0.1)
            {
                System.Threading.Thread.Sleep(10);
                this.Opacity = i;
            }
        }

        private void txtFilterFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnFilterFolder.PerformClick();
            if (e.KeyCode == Keys.Escape)
            {
                txtFilterFile.Text = "";
                filterFile = "";
                txtFilterFolder.Text = "";
                filterFolder = "";
                AddPanel(mp3Dir);
            }
                
        }

        private void txtFilterFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnFilterFile.PerformClick();
            if (e.KeyCode == Keys.Escape)
            {
                txtFilterFile.Text = "";
                filterFile = "";
                txtFilterFolder.Text = "";
                filterFolder = "";
                AddPanel(mp3Dir);
            }
        }

        private void btnFilterFolder_Click(object sender, EventArgs e)
        {
            filterFolder = txtFilterFolder.Text;
            txtFilterFile.Text = "";
            filterFile = "";
            AddPanel(mp3Dir);
        }

        private void btnFilterFile_Click(object sender, EventArgs e)
        {
            filterFile = txtFilterFile.Text;
            txtFilterFolder.Text = "";
            filterFolder = "";
            AddPanel(mp3Dir);
        }
    }
}
