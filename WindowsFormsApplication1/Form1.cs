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
        private int timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec, timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec;
        private bool timer1ClipsAll = true;
        private bool timer2ClipsAll = true;
        private bool logging, rememberDaily;
        private string dailyDate;
        private int dailyCount;
        private bool timer1Started = false;
        private bool timer2Started = false;
        private int frmSize = 1;
        private int frmMaximized;
        private string lastPlayed;
        private string filterFolder = "";
        private string filterFile = "";
        private int normalSizeX;
        private int normalSizeY;
        private int numOfButtons;
        private int numOfCols;
        private List<string> randomSound = new List<string>();
        private int lastRandomNumber = 0;
        private int lastRandomNumberAll = 0;
        private Image buttonBack = new Bitmap(patka.Properties.Resources.buttonback);
        private Image buttonBackHover = new Bitmap(patka.Properties.Resources.buttonback_hover);
        private FormWindowState LastWindowState;
        private int lastWidth;
        private int playCount = 0;
        public int settingsPage;
        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        
        public frmPlayer()
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            txtFilterFolder.KeyDown += new KeyEventHandler(txtFilterFolder_KeyDown);
            txtFilterFile.KeyDown += new KeyEventHandler(txtFilterFile_KeyDown);

            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Start();

            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer2.Tick += new System.EventHandler(timer2_Tick);

            lastWidth = this.Width;
            LastWindowState = this.WindowState;

            btnReplay.Enabled = false;

            // correcting a bug in the "system" renderer (white bottom line in toolstrip)
            toolStripPlay.Renderer = new MySR();
            toolStripSettings.Renderer = new MySR();
            toolStripFilters.Renderer = new MySR();

            txtFilterFolder.Size = new Size(100, 31);
            txtFilterFile.Size = new Size(100, 31);

            ButtonLocations();

            InsertPanelButtons();
        }

        // read application settings from config file
        public void ReadSettings()
        {
            mp3Dir = hotkey1 = hotkey2 = hotkey3 = hotkey4 = hotkey5 = hotkey6 = hotkey7 = hotkey8 = hotkey9 = hotkey0 = "";
            timer1MinHour = timer1MinMin = timer1MinSec = timer1MaxHour = timer1MaxMin = timer1MaxSec = 0;
            timer2MinHour = timer2MinMin = timer2MinSec = timer2MaxHour = timer2MaxMin = timer2MaxSec = 0;

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConfigurationManager.RefreshSection("appSettings");

            // folders
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

            // timer 1 settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minhour"])) timer1MinHour = Convert.ToInt32(config.AppSettings.Settings["timer1minhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minmin"])) timer1MinMin = Convert.ToInt32(config.AppSettings.Settings["timer1minmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minsec"])) timer1MinSec = Convert.ToInt32(config.AppSettings.Settings["timer1minsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxhour"])) timer1MaxHour = Convert.ToInt32(config.AppSettings.Settings["timer1maxhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxmin"])) timer1MaxMin = Convert.ToInt32(config.AppSettings.Settings["timer1maxmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxsec"])) timer1MaxSec = Convert.ToInt32(config.AppSettings.Settings["timer1maxsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1playall"])) timer1ClipsAll = true;
            else timer1ClipsAll = false;

            // timer 2 settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minhour"])) timer2MinHour = Convert.ToInt32(config.AppSettings.Settings["timer2minhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minmin"])) timer2MinMin = Convert.ToInt32(config.AppSettings.Settings["timer2minmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minsec"])) timer2MinSec = Convert.ToInt32(config.AppSettings.Settings["timer2minsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxhour"])) timer2MaxHour = Convert.ToInt32(config.AppSettings.Settings["timer2maxhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxmin"])) timer2MaxMin = Convert.ToInt32(config.AppSettings.Settings["timer2maxmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxsec"])) timer2MaxSec = Convert.ToInt32(config.AppSettings.Settings["timer2maxsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2playall"])) timer2ClipsAll = true;
            else timer2ClipsAll = false;

            // misc settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["log"])) logging = true;
            else logging = false;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["daily"])) rememberDaily = true;
            else rememberDaily = false;

            if (rememberDaily) saveDailyDate();
            labelClipsPlayed.Text = "Play count: " + playCount.ToString();
        }

        // error text to form, eg. "no clips", "no folder selected", etc...
        public void ErrorText(string errorText)
        {
            panelButtons.Controls.Clear();

            Label label = new Label();
            label.Top = 250;
            label.Left = 10;
            label.Text = errorText;
            label.Width = panelButtons.Width - 20;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new Font("Segoe UI", 12);

            Button button = new Button();
            button.Top = 290;
            button.Left = panelButtons.Width / 2 - 40;
            button.Text = "Settings...";
            button.Width = 80;
            button.Height = 23;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.Name = "btnSettingsPage1";
            button.Click += new System.EventHandler(menuFolders_Click);

            panelButtons.Controls.Add(button);
            panelButtons.Controls.Add(label);
        }

        public void ButtonLocations()
        {
            toolStripSettings.Left = toolStripContainer1.TopToolStripPanel.Width - toolStripSettings.Width;
            toolStripFilters.Left = toolStripContainer1.TopToolStripPanel.Width / 2 - toolStripFilters.Width / 2;
            toolStripPlay.Left = 3;

            toolStripSettings.Top = 0;
            toolStripFilters.Top = 0;
            toolStripPlay.Top = 0;
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
            if (filterFolder != "" || filterFile != "") btnClearFilters.Enabled = true;
            else btnClearFilters.Enabled = false;

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

                //if (frmSize == 2) continue;

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
                        panel.BackColor = ColorTranslator.FromHtml("#d1dbe7");
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
                    //folderLabel.ForeColor = ColorTranslator.FromHtml("#222");
                    //folderLabel.ForeColor = ColorTranslator.FromHtml("#445769");
                    folderLabel.ForeColor = ColorTranslator.FromHtml("#384b5d");

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
                button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                button.Tag = array1[i]; // filepath + filename + ext
                button.Width = (panelButtons.Width - ((numOfCols - 1) * 6 + 40)) / numOfCols;
                button.Height = 50;
                //button.Padding = new Padding(0);
                button.Font = new Font("Segoe UI", 10);
                button.Name = "SoundButton" + numOfButtons.ToString();
                button.MouseEnter += new EventHandler(SoundButton_MouseEnter);
                button.MouseLeave += new EventHandler(SoundButton_MouseLeave);
                button.MouseDown += new MouseEventHandler(SoundButton_MouseDown);
                button.MouseUp += new MouseEventHandler(SoundButton_MouseUp);

                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 1;

                // different colors for even and odd folders
                if (numColor > 5) numColor = 1;
                
                numColor = 1; // test

                switch (numColor)
                {
                    case 1:
                        // orange
                        //button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        //button.BackColor = ColorTranslator.FromHtml("#e27a25");
                        //button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#ffbd65"); // +25 bg lightness
                        //button.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#ff963c");
                        //button.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#e27a25"); // bg
                        //buttonPanel1.BackColor = ColorTranslator.FromHtml("#b25300"); // -15 bg lightness

                        button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        button.BackgroundImage = buttonBack;
                        button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#abc8e5"); // +25 bg lightness
                        buttonPanel1.BackColor = ColorTranslator.FromHtml("#7a8ea2"); // -15 bg lightness
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
            labelTotalClips.Text = "Clips: " + numOfButtons.ToString() + " / " + array1.Length.ToString();
            
            ButtonLocations();

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
            playFile(fileToPlay);
        }

        private void SoundButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackHover;
            button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#c7e0f7");
        }

        private void SoundButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBack;
            button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#abc8e5");
        }

        private void SoundButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBack;
            button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#abc8e5");
        }

        private void SoundButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackHover;
            button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#c7e0f7");
        }

        // sets focus to panelButtons on mousescroll
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            panelButtons.Focus();
        }

        // window size changes
        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            // refresh toolbars
            ButtonLocations();

            // if window state changes, reload buttons
            if (WindowState != LastWindowState && LastWindowState != FormWindowState.Minimized)
            {
                LastWindowState = WindowState;

                if (WindowState == FormWindowState.Maximized)
                {
                    InsertPanelButtons();
                }

                if (WindowState == FormWindowState.Normal)
                {
                    InsertPanelButtons();
                }
            }
        }

        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            if (frmSize == 2) return;
            if (panelButtons.Width == 0) minimized = true;

            if (!minimized && panelButtons.Width > 0)
            {
                if (lastWidth != this.Width) InsertPanelButtons();
                lastWidth = this.Width;
            }

            if (panelButtons.Width > 0) minimized = false;
        }

        // keypress event
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFilterFolder.Selected == true || txtFilterFile.Selected == true) return;

            if (e.KeyChar == 120 || e.KeyChar == 88 || e.KeyChar == (char)Keys.Back) btnRandom.PerformClick(); //PlayRandom();
            if (e.KeyChar == 114 || e.KeyChar == 82 || e.KeyChar == (char)Keys.PageUp) btnReplay.PerformClick();
            if (e.KeyChar == 115 || e.KeyChar == 83 || e.KeyChar == (char)Keys.PageUp) btnStop.PerformClick();

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

            btnReplay.Tag = fileToPlay;
            btnReplay.Enabled = true;

            lastPlayed = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(fileToPlay);
            labelLastPlayed.Text = lastPlayed;
            
            if (_mp3Player != null) _mp3Player.Dispose();
            _mp3Player = new Mp3Player(fileToPlay);

            if (checkRepeat.Checked) _mp3Player.Repeat = true;
            else _mp3Player.Repeat = false;

            _mp3Player.Play();

            // save logfile
            if (logging)
            {
                string logFolder = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1);
                string logFile = Path.GetFileNameWithoutExtension(fileToPlay);
                string log = DateTime.Now.ToString("dd.MM.yyyy|HH:mm:ss") + "|" + logFolder + "|" + logFile + "|" + lastPlayed;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@System.Windows.Forms.Application.ExecutablePath + ".log", true, System.Text.Encoding.Default))
                {
                    file.WriteLine(log);
                }
            }

            playCount++;
            if (rememberDaily) saveDailyDate();
            labelClipsPlayed.Text = "Play count: " + playCount.ToString();
        }

        private void saveDailyDate()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConfigurationManager.RefreshSection("appSettings");

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["dailydate"])) dailyDate = config.AppSettings.Settings["dailydate"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["dailycount"])) dailyCount = Convert.ToInt32(config.AppSettings.Settings["dailycount"].Value);

            if (dailyCount > playCount) playCount = dailyCount;
            
            if (dailyDate != DateTime.Now.ToString("yyyyMMdd"))
            {
                dailyDate = DateTime.Now.ToString("yyyyMMdd");
                playCount = 0;
            }

            config.AppSettings.Settings.Remove("dailydate");
            config.AppSettings.Settings.Remove("dailycount");

            config.AppSettings.Settings.Add("dailydate", dailyDate);
            config.AppSettings.Settings.Add("dailycount", playCount.ToString());

            config.AppSettings.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }

        // replay button
        private void btnReplay_Click(object sender, EventArgs e)
        {
            string fileToPlay = btnReplay.Tag.ToString();

            if (fileToPlay != "nofile")
            {
                playFile(fileToPlay);
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

            if (clipCount == 0) return;
            if (clipCount > 1)
            {
                while (randomNumber == lastRandomNumber)
                {
                    randomNumber = random.Next(0, clipCount);
                }
            }

            lastRandomNumber = randomNumber;

            string fileToPlay = randomSound[randomNumber].ToString();
            playFile(fileToPlay);
        }

        public void PlayRandomAll()
        {
            Random random = new Random();
            int clipCount = array1.Length;
            int randomNumber = random.Next(0, clipCount);

            if (clipCount == 0) return;
            if (clipCount > 1)
            {
                while (randomNumber == lastRandomNumberAll)
                {
                    randomNumber = random.Next(0, clipCount);
                }
            }

            lastRandomNumberAll = randomNumber;

            string fileToPlay = array1[randomNumber].ToString();
            playFile(fileToPlay);
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
            if (e.KeyCode == Keys.Enter)
            {
                filterFolder = txtFilterFolder.Text;
                txtFilterFile.Text = "";
                filterFile = "";
                AddPanel(mp3Dir);
                Button button = this.Controls.Find("SoundButton1", true).FirstOrDefault() as Button;
                this.ActiveControl = button;
            }
        }

        private void txtFilterFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filterFile = txtFilterFile.Text;
                txtFilterFolder.Text = "";
                filterFolder = "";
                AddPanel(mp3Dir);
                Button button = this.Controls.Find("SoundButton1", true).FirstOrDefault() as Button;
                this.ActiveControl = button;
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtFilterFile.Text = "";
            filterFile = "";
            txtFilterFolder.Text = "";
            filterFolder = "";
            AddPanel(mp3Dir);
        }

        private void checkRepeat_Click(object sender, EventArgs e)
        {
            if (checkRepeat.Checked == true) checkRepeat.Checked = false;
            else checkRepeat.Checked = true;
        }

        public class MySR : ToolStripSystemRenderer
        {
            public MySR() { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                //base.OnRenderToolStripBorder(e);
            }
        }

        private void btnDropdown_Click(object sender, EventArgs e)
        {
            /* // same menu with contextMenuStrip
            Rectangle rect = this.btnDropdown.Bounds;
            Point pt = this.PointToScreen(Point.Empty);

            pt.X += rect.Left;
            pt.Y += rect.Bottom;

            contextMenuStrip1.Show(pt);
            */

            Rectangle rect = this.btnDropdown.Bounds;
            Point pt = new Point(rect.Left, rect.Bottom);
            contextMenu1.Show(toolStripSettings, pt);

        }

        // show settings dialog
        private void menuFolders_Click(object sender, EventArgs e)
        {
            settingsPage = 1;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            settingsPage = 2;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        private void menuReload_Click(object sender, EventArgs e)
        {
            InsertPanelButtons();
        }

        // show settings dialog
        private void btnSettingsPage1_Click(object sender, EventArgs e)
        {
            settingsPage = 1;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        // toggle miniplayer
        private void menuToggle_Click(object sender, EventArgs e)
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

                this.MaximizeBox = false;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Size = new Size(900, 97);

                Screen screen = Screen.FromPoint(Cursor.Position);
                this.Left = screen.WorkingArea.Left + (screen.Bounds.Size.Width - (this.Width + 10));
                this.Top = screen.WorkingArea.Top + (screen.Bounds.Size.Height - (this.Height + 50));

                this.menuToggle.Text = "Switch to Normal";

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

                // restore window size
                this.Width = normalSizeX;
                this.Height = normalSizeY;

                this.menuToggle.Text = "Switch to MiniPlayer";

                Screen screen = Screen.FromPoint(Cursor.Position);
                this.Left = screen.WorkingArea.Left + (screen.Bounds.Size.Width / 2 - this.Width / 2);
                this.Top = screen.WorkingArea.Top + (screen.Bounds.Size.Height / 2 - this.Height / 2);

                if (frmMaximized == 1) this.WindowState = FormWindowState.Maximized;
                frmMaximized = 0;

                frmSize = 1;
                fadeIn();
                this.Opacity = 1;

                InsertPanelButtons();
            }
        }

        private void menuTimer1_Click(object sender, EventArgs e)
        {
            if (timer1MinHour == 0 && timer1MinMin == 0 && timer1MinSec == 0)
            {
                var result = MessageBox.Show("Delays for timer must be larger than 00:00:00.\nDo you wan't to set timer now?", "Timer 1 not set", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    menuSettings.PerformClick();
                }
            }
            else
            {
                if (!timer1Started)
                {
                    timer1.Interval = randomTime(timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec);
                    timer1.Start();
                    timer2.Stop();

                    labelTimer1.Text = "Timer 1: On";
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#dd0000");
                    menuTimer1.Text = "Stop Timer 1";
                    timer1Started = true;
                    timer2Started = false;

                    labelTimer2.Text = "Timer 2: Off";
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#404040");
                    menuTimer2.Text = "Start Timer 2";
                    timer2Started = false;
                }
                else
                {
                    timer1.Stop();

                    labelTimer1.Text = "Timer 1: Off";
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#404040");
                    menuTimer1.Text = "Start Timer 1";
                    timer1Started = false;
                }
            }
        }

        private void menuTimer2_Click(object sender, EventArgs e)
        {
            if (timer2MinHour == 0 && timer2MinMin == 0 && timer2MinSec == 0)
            {
                var result = MessageBox.Show("Delays for timer must be larger than 00:00:00.\nDo you wan't to set timer now?", "Timer 2 not set", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    menuSettings.PerformClick();
                }
            }
            else
            {
                if (!timer2Started)
                {
                    timer2.Interval = randomTime(timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec);
                    timer2.Start();
                    timer1.Stop();

                    labelTimer2.Text = "Timer 2: On";
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#dd0000");
                    menuTimer2.Text = "Stop Timer 2";
                    timer2Started = true;

                    labelTimer1.Text = "Timer 1: Off";
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#404040");
                    menuTimer1.Text = "Start Timer 1";
                    timer1Started = false;
                }
                else
                {
                    timer2.Stop();

                    labelTimer2.Text = "Timer 2: Off";
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#404040");
                    menuTimer2.Text = "Start Timer 2";
                    timer2Started = false;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //labelTest.Text = DateTime.Now.ToString("HH:mm:ss");
            //if (txtFilterFolder.Focused == false && txtFilterFile.Focused == false) panelButtons.Focus();
            ButtonLocations();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = randomTime(timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec);
            if (timer1ClipsAll) PlayRandomAll();
            else PlayRandom();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = randomTime(timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec);
            if (timer2ClipsAll) PlayRandomAll();
            else PlayRandom();
        }
        
        public int randomTime(int minHour, int minMin, int minSec, int maxHour, int maxMin, int maxSec)
        {
            int minTime = (minHour * 60 * 60) + (minMin * 60) + minSec;
            int maxTime = (maxHour * 60 * 60) + (maxMin * 60) + maxSec;
            
            Random random = new Random();
            int rnd = random.Next(minTime, maxTime);
            if (rnd == 0) rnd = 1;
            //labelTest.Text = rnd.ToString();
            return rnd * 1000;
        }

        private void labelTimer1_Click(object sender, EventArgs e)
        {
            menuTimer1.PerformClick();
        }

        private void labelTimer2_Click(object sender, EventArgs e)
        {
            menuTimer2.PerformClick();
        }

        private void labelLastPlayed_Click(object sender, EventArgs e)
        {
            labelLastPlayed.Text = "-";
            btnReplay.Tag = "";
            btnReplay.Enabled = false;
        }

    }

}
