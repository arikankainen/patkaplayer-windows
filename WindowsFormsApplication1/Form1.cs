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
using System.Drawing.Drawing2D;

namespace PatkaPlayer
{
    public partial class frmPlayer : Form
    {
        private Mp3Player _mp3Player;
        private string[] array1 = new string[] {};
        private bool minimized { get; set; }
        private string mp3Dir, hotkey1, hotkey2, hotkey3, hotkey4, hotkey5, hotkey6, hotkey7, hotkey8, hotkey9, hotkey10, hotkey11, hotkey12;
        private int timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec, timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec;
        private int numTop, numBottom, numLeft, numRight;
        private bool checkTop, checkBottom, checkLeft, checkRight;
        private decimal transNormal = 1, transMini = 1;
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
        private List<string> randomSound = new List<string>();
        private int lastRandomNumber = 0;
        private int lastRandomNumberAll = 0;
        private FormWindowState LastWindowState;
        private int lastWidth;
        private int playCount = 0;
        public int settingsPage;
        private bool tray = false;

        private ContextMenu contextButton;
        private MenuItem menuItemF1, menuItemF2, menuItemF3, menuItemF4, menuItemF5, menuItemF6, menuItemF7, menuItemF8, menuItemF9, menuItemF10, menuItemF11, menuItemF12;
        
        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timerTemp = new System.Windows.Forms.Timer();
        private Random randomT = new Random(); // random timer delay
        private Random randomA = new Random(); // random clip from all clips
        private Random randomF = new Random(); // random clip from filtered clips
       
        private Bitmap buttonBack;
        private Bitmap buttonBackHover;
        private Bitmap buttonBackPress;

        private string buttonColorShadow = "#e3e3e3";
        private string buttonColorCorner = "#92b3d3";
        private string buttonColorCornerShadow = "#ffffff";
        private string buttonColorBorder = "#5582ac";
        private string buttonColorBorderGradientTop = "#d0e5fb";
        private string buttonColorBorderGradientBottom = "#bad5f1";
        private string buttonColorBackGradientUpperTop = "#9ac0e7";
        private string buttonColorBackGradientUpperBottom = "#88b1d8";
        private string buttonColorBackGradientLowerTop = "#7fa9d2";
        private string buttonColorBackGradientLowerBottom = "#78a5ce";

        private string buttonColorShadowH = "#e3e3e3";
        private string buttonColorCornerH = "#799fc6";
        private string buttonColorCornerShadowH = "#ffffff";
        private string buttonColorBorderH = "#3b6897";
        private string buttonColorBorderGradientTopH = "#c1dcf8";
        private string buttonColorBorderGradientBottomH = "#a7c9ed";
        private string buttonColorBackGradientUpperTopH = "#80acdd";
        private string buttonColorBackGradientUpperBottomH = "#6e9dcc";
        private string buttonColorBackGradientLowerTopH = "#6593c5";
        private string buttonColorBackGradientLowerBottomH = "#5d8fc0";

        private string buttonColorShadowP = "#e3e3e3";
        private string buttonColorCornerP = "#5582b3";
        private string buttonColorCornerShadowP = "#ffffff";
        private string buttonColorBorderP = "#3b6897";
        private string buttonColorBorderGradientTopP = "#a7c9ed";
        private string buttonColorBorderGradientBottomP = "#c1dcf8";
        private string buttonColorBackGradientUpperTopP = "#6e9dcc";
        private string buttonColorBackGradientUpperBottomP = "#80acdd";
        private string buttonColorBackGradientLowerTopP = "#6e9dcc";
        private string buttonColorBackGradientLowerBottomP = "#80acdd";

        KeyboardHook hook = new KeyboardHook();

        // default constructor
        public frmPlayer()
        {
            InitializeComponent();
            this.Text = "Pätkä Player v1.21";

            notifyIcon1.Visible = false;
            notifyIcon1.MouseUp += new MouseEventHandler(NotifyIcon1_Click);

            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            //hook.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Alt, Keys.F12); // not working
            try
            {
                hook.RegisterHotKey((ModifierKeys)1, Keys.Space);
                hook.RegisterHotKey((ModifierKeys)1, Keys.R);
                hook.RegisterHotKey((ModifierKeys)1, Keys.S);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F1);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F2);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F3);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F4);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F5);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F6);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F7);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F8);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F9);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F10);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F11);
                hook.RegisterHotKey((ModifierKeys)1, Keys.F12);
            }
            catch
            {
                MessageBox.Show("Some of the global hotkeys are currently registered to another application, so they do not work with this instance of Pätkä Player.", "Global Hotkey Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            this.Layout += new LayoutEventHandler(Form1_Layout);
            this.KeyUp += new KeyEventHandler(Form1_KeyEvent);
            txtFilterFolder.KeyDown += new KeyEventHandler(txtFilterFolder_KeyDown);
            txtFilterFile.KeyDown += new KeyEventHandler(txtFilterFile_KeyDown);

            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Start();

            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer2.Tick += new System.EventHandler(timer2_Tick);

            timerTemp.Tick += new System.EventHandler(timerTemp_Tick);
            timerTemp.Interval = 400;

            lastWidth = this.Width;
            LastWindowState = this.WindowState;

            btnReplay.Enabled = false;

            // correcting a bug in the "system" renderer (white bottom line in toolstrip)
            toolStripPlay.Renderer = new MySR();
            toolStripSettings.Renderer = new MySR();
            toolStripFilters.Renderer = new MySR();

            txtFilterFolder.Size = new Size(130, 31);
            txtFilterFile.Size = new Size(130, 31);

            contextButton = new ContextMenu();

            menuItemF1 = new MenuItem();
            menuItemF2 = new MenuItem();
            menuItemF3 = new MenuItem();
            menuItemF4 = new MenuItem();
            menuItemF5 = new MenuItem();
            menuItemF6 = new MenuItem();
            menuItemF7 = new MenuItem();
            menuItemF8 = new MenuItem();
            menuItemF9 = new MenuItem();
            menuItemF10 = new MenuItem();
            menuItemF11 = new MenuItem();
            menuItemF12 = new MenuItem();

            menuItemF1.Click += new EventHandler(menuItemSet_Click);
            menuItemF2.Click += new EventHandler(menuItemSet_Click);
            menuItemF3.Click += new EventHandler(menuItemSet_Click);
            menuItemF4.Click += new EventHandler(menuItemSet_Click);
            menuItemF5.Click += new EventHandler(menuItemSet_Click);
            menuItemF6.Click += new EventHandler(menuItemSet_Click);
            menuItemF7.Click += new EventHandler(menuItemSet_Click);
            menuItemF8.Click += new EventHandler(menuItemSet_Click);
            menuItemF9.Click += new EventHandler(menuItemSet_Click);
            menuItemF10.Click += new EventHandler(menuItemSet_Click);
            menuItemF11.Click += new EventHandler(menuItemSet_Click);
            menuItemF12.Click += new EventHandler(menuItemSet_Click);

            renderButtons();
            buttonLocations();
            InsertPanelButtons();
        }

        // reset toolstrip button locations
        private void buttonLocations()
        {
            toolStripSettings.Left = toolStripContainer1.TopToolStripPanel.Width - toolStripSettings.Width;
            toolStripFilters.Left = (toolStripContainer1.TopToolStripPanel.Width / 2 - toolStripFilters.Width / 2);
            toolStripPlay.Left = 3;

            toolStripSettings.Top = 0;
            toolStripFilters.Top = 0;
            toolStripPlay.Top = 0;
        }

        // read settings for adding sound buttons
        public void InsertPanelButtons()
        {
            ReadSettings();

            if (Directory.Exists(mp3Dir))
            {
                array1 = Directory.GetFiles(@mp3Dir, "*.mp3", SearchOption.AllDirectories);
                addPanel();
            }
            else if (mp3Dir != "") errorText("Selected audio folder does not exist. Go to settings and reselect folder.");
            else errorText("No audio folder selected. Go to settings and select folder.");
        }

        // add panel and sound buttons
        private void addPanel()
        {
            if (filterFolder != "" || filterFile != "") btnClearFilters.Enabled = true;
            else btnClearFilters.Enabled = false;

            panelButtons.Controls.Clear();
            
            string lastPath = "";
            string currentPath = "";
            string currentPathOnly = "";
            string fileName = "";
            string folderName = "";
            numOfButtons = 0;

            if (array1.Length == 0) errorText("No audio clips found. Go to settings and select another audio folder.");

            randomSound.Clear();

            // loop for adding buttons
            for (int i = 0; i < array1.Length; i++)
            {

                if (filterFolder != "") folderName = Path.GetDirectoryName(array1[i]).Substring(Path.GetDirectoryName(array1[i]).LastIndexOf("\\") + 1);
                if (filterFile != "") fileName = Path.GetFileNameWithoutExtension(array1[i]);

                if (filterFile != "" && fileName.IndexOf(filterFile, StringComparison.OrdinalIgnoreCase) == -1) continue;
                if (filterFolder != "" && folderName.IndexOf(filterFolder, StringComparison.OrdinalIgnoreCase) == -1) continue;

                numOfButtons++;
                randomSound.Add(array1[i]);
                currentPath = Path.GetDirectoryName(array1[i]);

                if (currentPath != lastPath)
                {
                    currentPathOnly = currentPath.Substring(currentPath.LastIndexOf("\\") + 1);

                    // label for folder name
                    if (numOfButtons > 1)
                    {
                        // break flow with previous button
                        Button lastButton = this.Controls.Find("SoundButton" + (numOfButtons - 1).ToString(), true).FirstOrDefault() as Button;
                        panelButtons.SetFlowBreak(lastButton, true);
                    }

                    Label folderLabel = new Label();
                    folderLabel.Text = currentPathOnly;
                    folderLabel.AutoSize = true;
                    folderLabel.Font = new Font("Segoe UI", 13);
                    folderLabel.ForeColor = ColorTranslator.FromHtml("#384b5d");

                    if (numOfButtons > 1) folderLabel.Margin = new Padding(0, 20, 0, 0);
                    else folderLabel.Margin = new Padding(0, 10, 0, 0);

                    panelButtons.Controls.Add(folderLabel);

                    // correcting extra space bug by dummy label
                    Label dummyLabel = new Label();
                    dummyLabel.Width = 0;
                    dummyLabel.Height = 0;
                    dummyLabel.Margin = new Padding(0, 0, 0, 0);

                    panelButtons.Controls.Add(dummyLabel);
                    panelButtons.SetFlowBreak(dummyLabel, true);
                    
                }

                Button button = new Button();
                button.Text = Path.GetFileNameWithoutExtension(array1[i]); // filename only
                button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                button.Tag = array1[i]; // filepath + filename + ext
                button.Width = 150;
                button.Height = 50;
                button.Font = new Font("Segoe UI", 10);
                button.Name = "SoundButton" + numOfButtons.ToString();

                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.ForeColor = ColorTranslator.FromHtml("#fff");
                button.BackgroundImage = buttonBack;

                button.MouseEnter += new EventHandler(SoundButton_MouseEnter);
                button.MouseLeave += new EventHandler(SoundButton_MouseLeave);
                button.MouseDown += new MouseEventHandler(SoundButton_MouseDown);
                button.MouseUp += new MouseEventHandler(SoundButton_MouseUp);

                panelButtons.Controls.Add(button);

                lastPath = currentPath;

            }

            // dummy invisible label to add space to bottom
            if (numOfButtons > 1)
            {
                // break flow with previous button
                Button lastButton2 = this.Controls.Find("SoundButton" + numOfButtons.ToString(), true).FirstOrDefault() as Button;
                panelButtons.SetFlowBreak(lastButton2, true);

                Label labelBottom = new Label();
                labelBottom.AutoSize = false;
                labelBottom.Height = 0;
                labelBottom.Margin = new Padding(0, 0, 0, 6);
                labelBottom.BorderStyle = BorderStyle.Fixed3D;
                panelButtons.Controls.Add(labelBottom);

                labelTotalClips.Text = "Clips: " + numOfButtons.ToString() + " / " + array1.Length.ToString();
                buttonLocations();
            }
            timerTemp.Start();
        }

        // play file
        private void playFile(string fileToPlay)
        {
            string pathToPlay = Path.GetDirectoryName(fileToPlay);

            btnReplay.Tag = fileToPlay;
            btnReplay.Enabled = true;

            lastPlayed = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(fileToPlay);
            labelLastPlayed.Text = lastPlayed;
            
            if (_mp3Player != null) _mp3Player.Dispose();
            _mp3Player = new Mp3Player(fileToPlay);

            _mp3Player.Play();

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

            if (tray)
            {
                string balloonFolder = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1);
                string balloonFile = Path.GetFileNameWithoutExtension(fileToPlay);
                notifyIcon1.BalloonTipText = balloonFolder + " - " + balloonFile;
                notifyIcon1.ShowBalloonTip(100);
            }

            playCount++;
            if (rememberDaily) saveDailyDate();
            labelClipsPlayed.Text = "Play Count: " + playCount.ToString();
        }

        // save date for daily play count
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

        // play random, filtered clips
        private void playRandom()
        {
            int clipCount = randomSound.Count;
            int randomNumber = randomF.Next(0, clipCount);

            if (clipCount == 0) return;
            if (clipCount > 1)
            {
                while (randomNumber == lastRandomNumber)
                {
                    randomNumber = randomF.Next(0, clipCount);
                }
            }

            lastRandomNumber = randomNumber;

            string fileToPlay = randomSound[randomNumber].ToString();
            playFile(fileToPlay);
        }

        // play random, all clips
        private void playRandomAll()
        {
            int clipCount = array1.Length;
            int randomNumber = randomA.Next(0, clipCount);

            if (clipCount == 0) return;
            if (clipCount > 1)
            {
                while (randomNumber == lastRandomNumberAll)
                {
                    randomNumber = randomA.Next(0, clipCount);
                }
            }

            lastRandomNumberAll = randomNumber;

            string fileToPlay = array1[randomNumber].ToString();
            playFile(fileToPlay);
        }

        // fade window in
        private void fadeIn(double max)
        {
            for (double i = 0.0; i <= max; i += 0.1)
            {
                System.Threading.Thread.Sleep(10);
                this.Opacity = i;
            }
        }

        // fade window out
        private void fadeOut(double max)
        {
            for (double i = max; i >= 0.0; i -= 0.1)
            {
                System.Threading.Thread.Sleep(10);
                this.Opacity = i;
            }
        }

        // correcting a bug in the "system" renderer (white bottom line in toolstrip)
        public class MySR : ToolStripSystemRenderer
        {
            public MySR() { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                //base.OnRenderToolStripBorder(e);
            }
        }

        // switch to miniplayer or back to normal
        public void MiniPlayer()
        {
            if (this.WindowState == FormWindowState.Maximized) frmMaximized = 1;

            if (frmSize == 1) // switch to mini player
            {
                // hide window
                fadeOut(Convert.ToDouble(transNormal));
                this.Opacity = 0;

                //btnToggle.Checked = true;
                btnToggle.Image = patka.Properties.Resources.maxi;
                //btnToggle.ForeColor = ColorTranslator.FromHtml("#416585");
                
                frmSize = 2;

                // restore window to normal if maximized, then save size to variables
                this.WindowState = FormWindowState.Normal;
                normalSizeX = this.Width;
                normalSizeY = this.Height;

                this.MaximizeBox = false;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Size = new Size(824, 97);

                Screen screen = Screen.FromPoint(Cursor.Position);

                if (numLeft + this.Width > screen.Bounds.Size.Width) numLeft = screen.Bounds.Size.Width - this.Width;
                if (numRight + this.Width > screen.Bounds.Size.Width) numRight = screen.Bounds.Size.Width - this.Width;
                if (numTop + this.Height > screen.Bounds.Size.Height) numTop = screen.Bounds.Size.Height - this.Height;
                if (numBottom + this.Height > screen.Bounds.Size.Height) numBottom = screen.Bounds.Size.Height - this.Height;

                if (checkTop)
                {
                    this.Top = screen.WorkingArea.Top + numTop;
                }
                else if (checkBottom)
                {
                    this.Top = screen.WorkingArea.Top + (screen.Bounds.Size.Height - (this.Height + numBottom));
                }

                if (checkLeft)
                {
                    this.Left = screen.WorkingArea.Left + numLeft;
                }
                else if (checkRight)
                {
                    this.Left = screen.WorkingArea.Left + (screen.Bounds.Size.Width - (this.Width + numRight));
                }
                
                buttonLocations();
                Application.DoEvents();

                // show window
                fadeIn(Convert.ToDouble(transMini));
                this.Opacity = Convert.ToDouble(transMini);
            }

            else // switch to normal player
            {
                // hide window
                fadeOut(Convert.ToDouble(transMini));
                this.Opacity = 0;

                //btnToggle.Checked = false;
                btnToggle.Image = patka.Properties.Resources.mini;

                btnToggle.ForeColor = ColorTranslator.FromHtml("#000"); 
                
                this.MaximizeBox = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;

                // restore window size
                this.Width = normalSizeX;
                this.Height = normalSizeY;

                Screen screen = Screen.FromPoint(Cursor.Position);
                this.Left = screen.WorkingArea.Left + (screen.Bounds.Size.Width / 2 - this.Width / 2);
                this.Top = screen.WorkingArea.Top + (screen.Bounds.Size.Height / 2 - this.Height / 2);

                if (frmMaximized == 1) this.WindowState = FormWindowState.Maximized;
                frmMaximized = 0;

                frmSize = 1;

                buttonLocations();
                Application.DoEvents();

                // show window
                fadeIn(Convert.ToDouble(transNormal));
                this.Opacity = Convert.ToDouble(transNormal);
            }
        }
        
        // get random time
        private int randomTime(int minHour, int minMin, int minSec, int maxHour, int maxMin, int maxSec)
        {
            int minTime = (minHour * 60 * 60) + (minMin * 60) + minSec;
            int maxTime = (maxHour * 60 * 60) + (maxMin * 60) + maxSec;

            int rnd = randomT.Next(minTime, maxTime);
            if (rnd == 0) rnd = 1;

            return rnd * 1000;
        }

        // start timer 1
        private void startTimer1()
        {
            if (timer1MinHour == 0 && timer1MinMin == 0 && timer1MinSec == 0)
            {
                var result = MessageBox.Show("Delays for timer must be larger than 00:00:00.\nDo you wan't to set timer now?", "Timer 1 not set", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes) menuTimers.PerformClick();
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
 
        // start timer 2
        private void startTimer2()
        {
            if (timer2MinHour == 0 && timer2MinMin == 0 && timer2MinSec == 0)
            {
                var result = MessageBox.Show("Delays for timer must be larger than 00:00:00.\nDo you wan't to set timer now?", "Timer 2 not set", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes) menuTimers.PerformClick();
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

        // read application settings from config file
        public void ReadSettings()
        {
            mp3Dir = hotkey1 = hotkey2 = hotkey3 = hotkey4 = hotkey5 = hotkey6 = hotkey7 = hotkey8 = hotkey9 = hotkey10 = hotkey11 = hotkey12 = "";
            timer1MinHour = timer1MinMin = timer1MinSec = timer1MaxHour = timer1MaxMin = timer1MaxSec = 0;
            timer2MinHour = timer2MinMin = timer2MinSec = timer2MaxHour = timer2MaxMin = timer2MaxSec = 0;
            transNormal = transMini = 1;
            numTop = numLeft = 0;
            numBottom = 50;
            numRight = 10;
            logging = rememberDaily = false;
            timer1ClipsAll = timer2ClipsAll = false;
            checkTop = checkLeft = false;
            checkBottom = checkRight = true;

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
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_10"])) hotkey10 = config.AppSettings.Settings["hotkey_10"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_11"])) hotkey11 = config.AppSettings.Settings["hotkey_11"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_12"])) hotkey12 = config.AppSettings.Settings["hotkey_12"].Value;

            // timer 1 settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minhour"])) timer1MinHour = Convert.ToInt32(config.AppSettings.Settings["timer1minhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minmin"])) timer1MinMin = Convert.ToInt32(config.AppSettings.Settings["timer1minmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minsec"])) timer1MinSec = Convert.ToInt32(config.AppSettings.Settings["timer1minsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxhour"])) timer1MaxHour = Convert.ToInt32(config.AppSettings.Settings["timer1maxhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxmin"])) timer1MaxMin = Convert.ToInt32(config.AppSettings.Settings["timer1maxmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxsec"])) timer1MaxSec = Convert.ToInt32(config.AppSettings.Settings["timer1maxsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1playall"])) timer1ClipsAll = true;

            // timer 2 settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minhour"])) timer2MinHour = Convert.ToInt32(config.AppSettings.Settings["timer2minhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minmin"])) timer2MinMin = Convert.ToInt32(config.AppSettings.Settings["timer2minmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minsec"])) timer2MinSec = Convert.ToInt32(config.AppSettings.Settings["timer2minsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxhour"])) timer2MaxHour = Convert.ToInt32(config.AppSettings.Settings["timer2maxhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxmin"])) timer2MaxMin = Convert.ToInt32(config.AppSettings.Settings["timer2maxmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxsec"])) timer2MaxSec = Convert.ToInt32(config.AppSettings.Settings["timer2maxsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2playall"])) timer2ClipsAll = true;

            // misc settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["log"])) logging = true;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["daily"])) rememberDaily = true;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["transparencynormal"])) transNormal = Convert.ToDecimal(config.AppSettings.Settings["transparencynormal"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["transparencymini"])) transMini = Convert.ToDecimal(config.AppSettings.Settings["transparencymini"].Value);

            // miniplayer location
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["numtop"])) numTop = Convert.ToInt32(config.AppSettings.Settings["numtop"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["numbottom"])) numBottom = Convert.ToInt32(config.AppSettings.Settings["numbottom"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["numleft"])) numLeft = Convert.ToInt32(config.AppSettings.Settings["numleft"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["numright"])) numRight = Convert.ToInt32(config.AppSettings.Settings["numright"].Value);

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["checktop"])) checkTop = true;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["checkbottom"])) checkBottom = true;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["checkleft"])) checkLeft = true;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["checkright"])) checkRight = true;
            
            // loading complete, setting things
            if (rememberDaily) saveDailyDate();
            labelClipsPlayed.Text = "Play Count: " + playCount.ToString();

            if (frmSize == 1) this.Opacity = Convert.ToDouble(transNormal);
            if (frmSize == 2) this.Opacity = Convert.ToDouble(transMini);
        }

        // error text to form, eg. "no clips", "no folder selected", etc...
        private void errorText(string errorText)
        {
            panelButtons.Controls.Clear();

            Label label = new Label();
            label.Margin = new Padding(10, 15, 0, 0);
            label.AutoSize = true;
            label.Text = errorText;
            label.Font = new Font("Segoe UI", 10);
            panelButtons.Controls.Add(label);

            panelButtons.SetFlowBreak(label, true);

            Button button = new Button();
            button.Margin = new Padding(10, 10, 0, 0);
            button.Text = "Settings...";
            button.Width = 80;
            button.Height = 23;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Click += new System.EventHandler(menuFolders_Click);
            panelButtons.Controls.Add(button);
        }

        // background image for buttons
        private void renderButtons()
        {
            // button normal
            buttonBack = new Bitmap(150, 50);
            Graphics g = Graphics.FromImage(buttonBack);

            SolidBrush brushBackShadow = new SolidBrush(ColorTranslator.FromHtml(buttonColorShadow));
            g.FillRectangle(brushBackShadow, 0, 0, 150, 50);

            SolidBrush brushBackOuter = new SolidBrush(ColorTranslator.FromHtml(buttonColorBorder));
            g.FillRectangle(brushBackOuter, 1, 1, 148, 48);

            LinearGradientBrush gradBackInner = new LinearGradientBrush(new Point(0, 0), new Point(0, 48), ColorTranslator.FromHtml(buttonColorBorderGradientTop), ColorTranslator.FromHtml(buttonColorBorderGradientBottom));
            g.FillRectangle(gradBackInner, 2, 2, 146, 46);

            LinearGradientBrush gradUpper = new LinearGradientBrush(new Point(0, 0), new Point(0, 23), ColorTranslator.FromHtml(buttonColorBackGradientUpperTop), ColorTranslator.FromHtml(buttonColorBackGradientUpperBottom));
            LinearGradientBrush gradLower = new LinearGradientBrush(new Point(0, 0), new Point(0, 23), ColorTranslator.FromHtml(buttonColorBackGradientLowerTop), ColorTranslator.FromHtml(buttonColorBackGradientLowerBottom));

            g.FillRectangle(gradUpper, 3, 3, 144, 23);
            g.FillRectangle(gradLower, 3, 24, 144, 23);

            SolidBrush brushCorner = new SolidBrush(ColorTranslator.FromHtml(buttonColorCorner));
            g.FillRectangle(brushCorner, 1, 1, 1, 1);
            g.FillRectangle(brushCorner, 1, 48, 1, 1);
            g.FillRectangle(brushCorner, 148, 1, 1, 1);
            g.FillRectangle(brushCorner, 148, 48, 1, 1);

            SolidBrush brushCornerShadow = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerShadow));
            g.FillRectangle(brushCornerShadow, 0, 0, 1, 1);
            g.FillRectangle(brushCornerShadow, 0, 49, 1, 1);
            g.FillRectangle(brushCornerShadow, 149, 0, 1, 1);
            g.FillRectangle(brushCornerShadow, 149, 49, 1, 1);

            // button hover
            buttonBackHover = new Bitmap(150, 50);
            Graphics gH = Graphics.FromImage(buttonBackHover);

            SolidBrush brushBackShadowH = new SolidBrush(ColorTranslator.FromHtml(buttonColorShadowH));
            gH.FillRectangle(brushBackShadowH, 0, 0, 150, 50);

            SolidBrush brushBackOuterH = new SolidBrush(ColorTranslator.FromHtml(buttonColorBorderH));
            gH.FillRectangle(brushBackOuterH, 1, 1, 148, 48);

            LinearGradientBrush gradBackInnerH = new LinearGradientBrush(new Point(0, 0), new Point(0, 48), ColorTranslator.FromHtml(buttonColorBorderGradientTopH), ColorTranslator.FromHtml(buttonColorBorderGradientBottomH));
            gH.FillRectangle(gradBackInnerH, 2, 2, 146, 46);

            LinearGradientBrush gradUpperH = new LinearGradientBrush(new Point(0, 0), new Point(0, 23), ColorTranslator.FromHtml(buttonColorBackGradientUpperTopH), ColorTranslator.FromHtml(buttonColorBackGradientUpperBottomH));
            LinearGradientBrush gradLowerH = new LinearGradientBrush(new Point(0, 0), new Point(0, 23), ColorTranslator.FromHtml(buttonColorBackGradientLowerTopH), ColorTranslator.FromHtml(buttonColorBackGradientLowerBottomH));

            gH.FillRectangle(gradUpperH, 3, 3, 144, 23);
            gH.FillRectangle(gradLowerH, 3, 24, 144, 23);

            SolidBrush brushCornerH = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerH));
            gH.FillRectangle(brushCornerH, 1, 1, 1, 1);
            gH.FillRectangle(brushCornerH, 1, 48, 1, 1);
            gH.FillRectangle(brushCornerH, 148, 1, 1, 1);
            gH.FillRectangle(brushCornerH, 148, 48, 1, 1);

            SolidBrush brushCornerShadowH = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerShadowH));
            gH.FillRectangle(brushCornerShadowH, 0, 0, 1, 1);
            gH.FillRectangle(brushCornerShadowH, 0, 49, 1, 1);
            gH.FillRectangle(brushCornerShadowH, 149, 0, 1, 1);
            gH.FillRectangle(brushCornerShadowH, 149, 49, 1, 1);

            // button press
            buttonBackPress = new Bitmap(150, 50);
            Graphics gP = Graphics.FromImage(buttonBackPress);

            SolidBrush brushBackShadowP = new SolidBrush(ColorTranslator.FromHtml(buttonColorShadowP));
            gP.FillRectangle(brushBackShadowP, 0, 0, 150, 50);

            SolidBrush brushBackOuterP = new SolidBrush(ColorTranslator.FromHtml(buttonColorBorderP));
            gP.FillRectangle(brushBackOuterP, 1, 1, 148, 48);

            LinearGradientBrush gradBackInnerP = new LinearGradientBrush(new Point(0, 0), new Point(0, 48), ColorTranslator.FromHtml(buttonColorBorderGradientTopP), ColorTranslator.FromHtml(buttonColorBorderGradientBottomP));
            gP.FillRectangle(gradBackInnerP, 2, 2, 146, 46);

            LinearGradientBrush gradUpperP = new LinearGradientBrush(new Point(0, 0), new Point(0, 23), ColorTranslator.FromHtml(buttonColorBackGradientUpperTopP), ColorTranslator.FromHtml(buttonColorBackGradientUpperBottomP));
            LinearGradientBrush gradLowerP = new LinearGradientBrush(new Point(0, 0), new Point(0, 23), ColorTranslator.FromHtml(buttonColorBackGradientLowerTopP), ColorTranslator.FromHtml(buttonColorBackGradientLowerBottomP));

            gP.FillRectangle(gradUpperP, 3, 3, 144, 23);
            gP.FillRectangle(gradLowerP, 3, 24, 144, 23);

            SolidBrush brushCornerP = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerP));
            gP.FillRectangle(brushCornerP, 1, 1, 1, 1);
            gP.FillRectangle(brushCornerP, 1, 48, 1, 1);
            gP.FillRectangle(brushCornerP, 148, 1, 1, 1);
            gP.FillRectangle(brushCornerP, 148, 48, 1, 1);

            SolidBrush brushCornerShadowP = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerShadowP));
            gP.FillRectangle(brushCornerShadowP, 0, 0, 1, 1);
            gP.FillRectangle(brushCornerShadowP, 0, 49, 1, 1);
            gP.FillRectangle(brushCornerShadowP, 149, 0, 1, 1);
            gP.FillRectangle(brushCornerShadowP, 149, 49, 1, 1);

        }






    } // class end
} // namespace end
