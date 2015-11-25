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
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;

using NAudio;
using NAudio.Wave;

namespace PatkaPlayer
{
    public partial class frmPlayer : Form, IMessageFilter
    {

        private const byte VK_SCROLL = 0x91;
        private const uint KEYEVENTF_KEYUP = 0x2;

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "GetKeyState", SetLastError = true)]
        static extern short GetKeyState(uint nVirtKey);

        public static void SetScrollLockKey(bool newState)
        {
            bool scrollLockSet = GetKeyState(VK_SCROLL) != 0;
            if (scrollLockSet != newState)
            {
                keybd_event(VK_SCROLL, 0, 0, 0);
                keybd_event(VK_SCROLL, 0, KEYEVENTF_KEYUP, 0);
            }
        }

        public static bool GetScrollLockState() // true = set, false = not set
        {
            return GetKeyState(VK_SCROLL) != 0;
        }

        private TaskbarManager taskbar = TaskbarManager.Instance;
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;
        bool play = false;
        bool playpressed = false;
        bool pause = false;
        bool stop = true;
        bool randompressed = false;

        private string[] array1 = new string[] { };
        private List<string> randomSound = new List<string>();
        private List<string> folderList = new List<string>();

        private string mp3Dir, hotkey1, hotkey2, hotkey3, hotkey4, hotkey5, hotkey6, hotkey7, hotkey8, hotkey9, hotkey10, hotkey11, hotkey12;
        private int timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec, timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec;
        private string timer1Text, timer2Text;
        private decimal transNormal = 1;
        private bool timer1ClipsAll = true;
        private bool timer2ClipsAll = true;
        private bool logging, rememberDaily;
        private bool trayIcon, balloonPlay, balloonTimer;
        private string dailyDate;
        private int dailyCount;
        private string hotkeyPlayPreMod, hotkeyRandomMod, hotkeyRandomKey, hotkeyStopMod, hotkeyStopKey, hotkeyReplayMod, hotkeyReplayKey, hotkeyTimer1Mod, hotkeyTimer1Key, hotkeyTimer2Mod, hotkeyTimer2Key, hotkeyStopTimerMod, hotkeyStopTimerKey;
        private string sendkeyPlayMod, sendkeyPlayKey, sendkeyStopMod, sendkeyStopKey, sendkeyPlayString, sendkeyStopString;
        private bool sendkeyPlay, sendkeyStop;
        private bool hotkeyWarning, sendKeystrokes;
        private int latency;
        private bool scrollLock;
        private bool keyDown = false;

        private bool sendMessages = true;

        private bool timer1Started = false;
        private bool timer2Started = false;
        private string lastPlayed, lastPlayedFile;
        private string filterFolder = "";
        private string filterFile = "";
        private int numOfFolders;
        private int numOfButtons;
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
       
        private Bitmap buttonBackButton;
        private Bitmap buttonBackHoverButton;
        private Bitmap buttonBackPressButton;
        private Bitmap buttonBackFolder;
        private Bitmap buttonBackHoverFolder;
        private Bitmap buttonBackPressFolder;

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
        Settings settings = new Settings();

        ProgressBarEx pbPosition = new ProgressBarEx();

        // default constructor
        public frmPlayer()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);

            if (!File.Exists("naudio.dll"))
            {
                MessageBox.Show("Can't find NAudio.dll. It is required to run Pätkä Player.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (System.Windows.Forms.Application.MessageLoop)
                {
                  // Use this since we are a WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                  // Use this since we are a console app
                  System.Environment.Exit(1);
                }

            }

            labelVersion.Text = "v1.4";

            notifyIcon1.Visible = false;
            notifyIcon1.MouseUp += new MouseEventHandler(NotifyIcon1_Click);

            //this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            this.Layout += new LayoutEventHandler(Form1_Layout);
            this.KeyUp += new KeyEventHandler(Form1_KeyEvent);
            txtFilterFolder.KeyDown += new KeyEventHandler(txtFilterFolder_KeyDown);
            txtFilterFile.KeyDown += new KeyEventHandler(txtFilterFile_KeyDown);

            //this.ContextMenu = contextMenu1;
            contextMenu1.Popup += new EventHandler(contextMenu1_Popup);
            contextMenu1.Collapse += new EventHandler(contextMenu1_Collapse);
            

            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Interval = 100;
            timer.Start();

            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer2.Tick += new System.EventHandler(timer2_Tick);

            timerTemp.Tick += new System.EventHandler(timerTemp_Tick);
            timerTemp.Interval = 400;

            lastWidth = this.Width;
            LastWindowState = this.WindowState;

            btnReplay.Enabled = false;

            splitContainer1.SplitterWidth = 1;

            // correcting a bug in the "system" renderer (white bottom line in toolstrip)
            toolStripPlay.Renderer = new MySR();
            toolStripSettings.Renderer = new MySR();

            //txtFilterFolder.Size = new Size(100, 31);
            //txtFilterFile.Size = new Size(100, 31);

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

            renderButtons(150, 50, out buttonBackButton, out buttonBackHoverButton, out buttonBackPressButton);

            /* 
            // green
            buttonColorShadow = "#e3e3e3";
            buttonColorCorner = "#7fb895";
            buttonColorCornerShadow = "#ffffff";
            buttonColorBorder = "#4a9667";
            buttonColorBorderGradientTop = "#b4dac4";
            buttonColorBorderGradientBottom = "#a3d3b7";
            buttonColorBackGradientUpperTop = "#83c69d";
            buttonColorBackGradientUpperBottom = "#77bd92";
            buttonColorBackGradientLowerTop = "#68b384";
            buttonColorBackGradientLowerBottom = "#69b485";

            buttonColorShadowH = "#e3e3e3";
            buttonColorCornerH = "#69ac84";
            buttonColorCornerShadowH = "#ffffff";
            buttonColorBorderH = "#338353";
            buttonColorBorderGradientTopH = "#a6d7b9";
            buttonColorBorderGradientBottomH = "#92cfab";
            buttonColorBackGradientUpperTopH = "#6dbe90";
            buttonColorBackGradientUpperBottomH = "#61b281";
            buttonColorBackGradientLowerTopH = "#51a773";
            buttonColorBackGradientLowerBottomH = "#52a874";

            buttonColorShadowP = "#e3e3e3";
            buttonColorCornerP = "#4a9c6d";
            buttonColorCornerShadowP = "#ffffff";
            buttonColorBorderP = "#338353";
            buttonColorBorderGradientTopP = "#93cfac";
            buttonColorBorderGradientBottomP = "#a7d7ba";
            buttonColorBackGradientUpperTopP = "#63b484";
            buttonColorBackGradientUpperBottomP = "#6fc091";
            buttonColorBackGradientLowerTopP = "#61b281";
            buttonColorBackGradientLowerBottomP = "#6ebf91";
            */

            renderButtons(296, 30, out buttonBackFolder, out buttonBackHoverFolder, out buttonBackPressFolder);

            pbPosition.Left = 330;
            //pbPosition.Top = 21;
            pbPosition.Top = 9;
            //pbPosition.Width = 357;
            pbPosition.Width = 250;
            pbPosition.Height = 23;
            pbPosition.ForeColor = ColorTranslator.FromHtml("#8ab3da");
            pbPosition.BackColor = ColorTranslator.FromHtml("#7fa9d2");
            pbPosition.Value = 0;
            pbPosition.Name = "progressPosition";
            pbPosition.ProgressText = "";
            this.Controls.Add(pbPosition);

            pbPosition.MouseDown += new MouseEventHandler(pbPosition_MouseDown);
            pbPosition.MouseMove += new MouseEventHandler(pbPosition_MouseMove);

            buttonLocations();
            InsertPanelButtons();

        }

        // reset toolstrip button locations
        private void buttonLocations()
        {
            toolStripSettings.Left = this.Width - toolStripSettings.Width - 20;
            toolStripPlay.Left = 4;

            int fL = trackBarVolume.Right + 45;
            int fR = toolStripSettings.Left;

            toolStripSettings.Top = 2;
            toolStripPlay.Top = 2;

            if (panelFolders.VerticalScroll.Visible)
            {
                splitContainer1.SplitterDistance = 329;
            }
            else
            {
                splitContainer1.SplitterDistance = 312;
            }

        }

        // read settings for adding sound buttons
        public void InsertPanelButtons()
        {
            ReadSettings();

            if (Directory.Exists(mp3Dir))
            {
                array1 = Directory.GetFiles(@mp3Dir, "*.mp3", SearchOption.AllDirectories);
                
                addFolderPanel();
                addPanel();
            }
            else if (mp3Dir != null) errorText("Selected audio folder does not exist. Go to the settings and reselect folder.");
            else errorText("No audio folder selected. Go to the settings and select a folder.");
        }

        private void addFolderPanel()
        {
            panelFolders.SuspendLayout();
            panelFolders.Controls.Clear();

            string lastPath = "";
            string currentPath = "";
            string currentPathOnly = "";
            numOfFolders = 0;

            // show all button
            Button allbutton = new Button();
            allbutton.Text = "Show all folders";
            allbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            allbutton.Width = 296;
            allbutton.Height = 30;
            allbutton.Font = new Font("Segoe UI", 10);
            allbutton.Tag = "";

            allbutton.FlatStyle = FlatStyle.Flat;
            allbutton.FlatAppearance.BorderSize = 0;
            allbutton.ForeColor = ColorTranslator.FromHtml("#fff");
            allbutton.BackColor = ColorTranslator.FromHtml("#ccc");
            allbutton.BackgroundImage = buttonBackFolder;
            allbutton.Margin = new Padding(3, 4, 3, 3);

            allbutton.MouseEnter += new EventHandler(panelFolders_MouseEnter);
            allbutton.MouseEnter += new EventHandler(FolderButton_MouseEnter);
            allbutton.MouseLeave += new EventHandler(FolderButton_MouseLeave);
            allbutton.MouseDown += new MouseEventHandler(FolderButton_MouseDown);
            allbutton.MouseUp += new MouseEventHandler(FolderButton_MouseUp);

            panelFolders.Controls.Add(allbutton);
            panelFolders.SetFlowBreak(allbutton, true);

            Panel allpanel = new Panel();
            allpanel.AutoSize = false;
            allpanel.Height = 1;
            allpanel.Width = 276;
            allpanel.BorderStyle = BorderStyle.None;
            //allpanel.BackColor = ColorTranslator.FromHtml("#aec8e8");
            allpanel.BackColor = ColorTranslator.FromHtml("#bbb");
            allpanel.Margin = new Padding(13, 6, 13, 6);

            panelFolders.Controls.Add(allpanel);
            panelFolders.SetFlowBreak(allpanel, true);

            // loop for adding folder buttons
            for (int i = 0; i < array1.Length; i++)
            {

                currentPath = Path.GetDirectoryName(array1[i]);

                if (currentPath != lastPath)
                {
                    numOfFolders++;
                    currentPathOnly = currentPath.Substring(currentPath.LastIndexOf("\\") + 1);

                    // folder button
                    Button lbutton = new Button();
                    lbutton.Text = currentPathOnly;
                    lbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lbutton.Width = 296;
                    lbutton.Height = 30;
                    lbutton.Font = new Font("Segoe UI", 10);
                    lbutton.Tag = currentPathOnly;

                    lbutton.FlatStyle = FlatStyle.Flat;
                    lbutton.FlatAppearance.BorderSize = 0;
                    lbutton.ForeColor = ColorTranslator.FromHtml("#fff");
                    lbutton.BackColor = ColorTranslator.FromHtml("#ccc");
                    lbutton.BackgroundImage = buttonBackFolder;

                    lbutton.MouseEnter += new EventHandler(panelFolders_MouseEnter);
                    lbutton.MouseEnter += new EventHandler(FolderButton_MouseEnter);
                    lbutton.MouseLeave += new EventHandler(FolderButton_MouseLeave);
                    lbutton.MouseDown += new MouseEventHandler(FolderButton_MouseDown);
                    lbutton.MouseUp += new MouseEventHandler(FolderButton_MouseUp);

                    panelFolders.Controls.Add(lbutton);
                    panelFolders.SetFlowBreak(lbutton, true);

                }

                lastPath = currentPath;
            }
            
            Label labelBottom = new Label();
            labelBottom.AutoSize = false;
            labelBottom.Height = 0;
            labelBottom.Margin = new Padding(0, 0, 0, 11);
            labelBottom.BorderStyle = BorderStyle.Fixed3D;
            panelFolders.Controls.Add(labelBottom);
            
            panelFolders.ResumeLayout();
        }
        
        // add panel and sound buttons
        private void addPanel()
        {
            if (filterFolder != "" || filterFile != "") btnClearFilters.Enabled = true;
            else btnClearFilters.Enabled = false;

            panelButtons.SuspendLayout();
            panelButtons.Controls.Clear();
            
            string lastPath = "";
            string currentPath = "";
            string currentPathOnly = "";
            string fileName = "";
            string folderName = "";
            numOfButtons = 0;

            if (array1.Length == 0) errorText("No audio clips found. Go to the settings and select another audio folder.");

            randomSound.Clear();

            // loop for adding buttons
            for (int i = 0; i < array1.Length; i++)
            {

                if (filterFolder != "") folderName = Path.GetDirectoryName(array1[i]).Substring(Path.GetDirectoryName(array1[i]).LastIndexOf("\\") + 1);
                if (filterFile != "") fileName = Path.GetFileNameWithoutExtension(array1[i]);

                if (filterFile != "" && fileName.IndexOf(filterFile, StringComparison.OrdinalIgnoreCase) == -1) continue;
                if (filterFolder != "" && folderName.IndexOf(filterFolder, StringComparison.OrdinalIgnoreCase) == -1) continue;

                currentPath = Path.GetDirectoryName(array1[i]);
                currentPathOnly = currentPath.Substring(currentPath.LastIndexOf("\\") + 1);

                bool found = true;
                if (folderList.Count > 0)
                {
                    found = false;
                    foreach (string f in folderList)
                    {
                        if (currentPathOnly == f) found = true;
                    }
                }
                if (!found) continue;
                //if (selectFolder != "" && currentPathOnly != selectFolder) continue;

                numOfButtons++;
                randomSound.Add(array1[i]);

                if (currentPath != lastPath)
                {
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
                    folderLabel.Font = new Font("Segoe UI", 12);
                    folderLabel.ForeColor = ColorTranslator.FromHtml("#384b5d");

                    if (numOfButtons > 1) folderLabel.Margin = new Padding(0, 20, 0, 2);
                    else folderLabel.Margin = new Padding(0, 10, 0, 2);

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
                button.BackgroundImage = buttonBackButton;

                button.MouseEnter += new EventHandler(panelButtons_MouseEnter);
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

            panelButtons.ResumeLayout();
            buttonLocations();
            labelVolume.Focus();

        }

        // play file
        private void playFile(string fileToPlay)
        {
            int comboLatencyInt;
            if (scrollLock) SetScrollLockKey(false);

            try
            {
                comboLatencyInt = Convert.ToInt32(comboLatency.Text);
            }
            catch
            {
                comboLatencyInt = latency;
            }

            latency = comboLatencyInt;

            string pathToPlay = Path.GetDirectoryName(fileToPlay);

            btnReplay.Tag = fileToPlay;
            btnReplay.Enabled = true;

            lastPlayedFile = Path.GetFileNameWithoutExtension(fileToPlay);
            lastPlayed = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(fileToPlay);

            this.Text = lastPlayedFile;
            labelLastPlayed.Text = lastPlayed;
            //pbPosition.ProgressText = lastPlayed;

            playpressed = true;
            if (sendkeyPlay && !play && sendKeystrokes) SendKeys.Send(sendkeyPlayString);
            if (!play && sendMessages) sendMessagePause();
            closeTrack();

            loadTrack(fileToPlay, latency * 2);
            playTrack();

            if (logging)
            {
                string originalPath = Application.ExecutablePath;
                string pathname = Path.GetDirectoryName(originalPath);
                string filename = Path.GetFileNameWithoutExtension(originalPath);
                string customPath = pathname + "\\" + filename + ".log";

                string logFolder = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1);
                string logFile = Path.GetFileNameWithoutExtension(fileToPlay);
                string log = DateTime.Now.ToString("dd.MM.yyyy|HH:mm:ss") + "|" + logFolder + "|" + logFile + "|" + lastPlayed;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@customPath, true, System.Text.Encoding.Default))
                {
                    file.WriteLine(log);
                }
            }

            if (tray || trayIcon)
            {
                if (balloonPlay)
                {
                    string balloonFolder = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1);
                    string balloonFile = Path.GetFileNameWithoutExtension(fileToPlay);
                    notifyIcon1.BalloonTipText = balloonFolder + " - " + balloonFile;
                    notifyIcon1.ShowBalloonTip(100);
                }
            }

            playCount++;
            if (rememberDaily) saveDailyDate();
            labelClipsPlayed.Text = "Play Count: " + playCount.ToString();
        }

        // save date for daily play count
        private void saveDailyDate()
        {
            dailyDate = settings.LoadSetting("DailyDate");
            dailyCount = Convert.ToInt32(settings.LoadSetting("DailyCount"));

            if (dailyCount > playCount) playCount = dailyCount;
            
            if (dailyDate != DateTime.Now.ToString("yyyyMMdd"))
            {
                dailyDate = DateTime.Now.ToString("yyyyMMdd");
                playCount = 0;
            }

            settings.SaveSetting("DailyDate", dailyDate);
            settings.SaveSetting("DailyCount", playCount.ToString());
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
                    notifyIcon1.Icon = PatkaPlayer.Properties.Resources.patka_taskbar_red;
                    timer1.Interval = randomTime(timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec);
                    timer1.Start();
                    timer2.Stop();

                    if (tray || trayIcon)
                    {
                        if (balloonTimer)
                        {
                            notifyIcon1.BalloonTipText = "Timer 1 started";
                            notifyIcon1.ShowBalloonTip(100);
                        }
                    }

                    labelTimer1.Text = "Timer 1: On" + timer1Text;
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#dd0000");
                    timer1Started = true;
                    timer2Started = false;

                    labelTimer2.Text = "Timer 2: Off" + timer2Text;
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#404040");
                    timer2Started = false;
                }
                else
                {
                    notifyIcon1.Icon = PatkaPlayer.Properties.Resources.patka_taskbar;
                    timer1.Stop();

                    if (tray || trayIcon)
                    {
                        if (balloonTimer)
                        {
                            notifyIcon1.BalloonTipText = "Timer stopped";
                            notifyIcon1.ShowBalloonTip(100);
                        }
                    }

                    labelTimer1.Text = "Timer 1: Off" + timer1Text;
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#404040");
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
                    notifyIcon1.Icon = PatkaPlayer.Properties.Resources.patka_taskbar_red;
                    timer2.Interval = randomTime(timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec);
                    timer2.Start();
                    timer1.Stop();

                    if (tray || trayIcon)
                    {
                        if (balloonTimer)
                        {
                            notifyIcon1.BalloonTipText = "Timer 2 started";
                            notifyIcon1.ShowBalloonTip(100);
                        }
                    }

                    labelTimer2.Text = "Timer 2: On" + timer2Text;
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#dd0000");
                    timer2Started = true;

                    labelTimer1.Text = "Timer 1: Off" + timer1Text;
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#404040");
                    timer1Started = false;
                }
                else
                {
                    notifyIcon1.Icon = PatkaPlayer.Properties.Resources.patka_taskbar;
                    
                    timer2.Stop();

                    if (tray || trayIcon)
                    {
                        if (balloonTimer)
                        {
                            notifyIcon1.BalloonTipText = "Timer stopped";
                            notifyIcon1.ShowBalloonTip(100);
                        }
                    }

                    labelTimer2.Text = "Timer 2: Off" + timer2Text;
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#404040");
                    timer2Started = false;
                }
            }
        }

        // read application settings from config file
        public void ReadSettings()
        {
            // folders
            mp3Dir = settings.LoadSetting("Mp3Dir");
            hotkey1 = settings.LoadSetting("Hotkey1");
            hotkey2 = settings.LoadSetting("Hotkey2");
            hotkey3 = settings.LoadSetting("Hotkey3");
            hotkey4 = settings.LoadSetting("Hotkey4");
            hotkey5 = settings.LoadSetting("Hotkey5");
            hotkey6 = settings.LoadSetting("Hotkey6");
            hotkey7 = settings.LoadSetting("Hotkey7");
            hotkey8 = settings.LoadSetting("Hotkey8");
            hotkey9 = settings.LoadSetting("Hotkey9");
            hotkey10 = settings.LoadSetting("Hotkey10");
            hotkey11 = settings.LoadSetting("Hotkey11");
            hotkey12 = settings.LoadSetting("Hotkey12");

            // timer 1 settings
            timer1MinHour = Convert.ToInt32(settings.LoadSetting("Timer1MinHour"));
            timer1MinMin = Convert.ToInt32(settings.LoadSetting("Timer1MinMin"));
            timer1MinSec = Convert.ToInt32(settings.LoadSetting("Timer1MinSec"));
            timer1MaxHour = Convert.ToInt32(settings.LoadSetting("Timer1MaxHour"));
            timer1MaxMin = Convert.ToInt32(settings.LoadSetting("Timer1MaxMin"));
            timer1MaxSec = Convert.ToInt32(settings.LoadSetting("Timer1MaxSec"));
            timer1ClipsAll = Convert.ToBoolean(settings.LoadSetting("Timer1ClipsAll"));

            // timer 2 settings
            timer2MinHour = Convert.ToInt32(settings.LoadSetting("Timer2MinHour"));
            timer2MinMin = Convert.ToInt32(settings.LoadSetting("Timer2MinMin"));
            timer2MinSec = Convert.ToInt32(settings.LoadSetting("Timer2MinSec"));
            timer2MaxHour = Convert.ToInt32(settings.LoadSetting("Timer2MaxHour"));
            timer2MaxMin = Convert.ToInt32(settings.LoadSetting("Timer2MaxMin"));
            timer2MaxSec = Convert.ToInt32(settings.LoadSetting("Timer2MaxSec"));
            timer2ClipsAll = Convert.ToBoolean(settings.LoadSetting("Timer2ClipsAll"));
            
            // log
            logging = Convert.ToBoolean(settings.LoadSetting("Logging"));
            rememberDaily = Convert.ToBoolean(settings.LoadSetting("RememberDaily"));

            // tray
            trayIcon = Convert.ToBoolean(settings.LoadSetting("TrayIcon"));
            balloonPlay = Convert.ToBoolean(settings.LoadSetting("BalloonPlay"));
            balloonTimer = Convert.ToBoolean(settings.LoadSetting("BalloonTimer"));
            
            // misc
            transNormal = Convert.ToDecimal(settings.LoadSetting("Transparency") ?? "1");
            latency = Convert.ToInt32(settings.LoadSetting("Latency"));
            if (latency < 50) latency = 200;
            if (latency > 900) latency = 200;
            comboLatency.Text = latency.ToString();
            scrollLock = Convert.ToBoolean(settings.LoadSetting("ScrollLock"));

            // loading complete, setting things
            if (trayIcon) notifyIcon1.Visible = true;
            else notifyIcon1.Visible = false;

            if (rememberDaily) saveDailyDate();
            labelClipsPlayed.Text = "Play Count: " + playCount.ToString();

            this.Opacity = Convert.ToDouble(transNormal);
            
            readSendkeys();
            readHotkeys();

            timer1Text = " (";
            timer1Text += (timer1MinHour < 10) ? "0" + timer1MinHour.ToString() : timer1MinHour.ToString();
            timer1Text += ":";
            timer1Text += (timer1MinMin < 10) ? "0" + timer1MinMin.ToString() : timer1MinMin.ToString();
            timer1Text += ":";
            timer1Text += (timer1MinSec < 10) ? "0" + timer1MinSec.ToString() : timer1MinSec.ToString();
            timer1Text += " - ";
            timer1Text += (timer1MaxHour < 10) ? "0" + timer1MaxHour.ToString() : timer1MaxHour.ToString();
            timer1Text += ":";
            timer1Text += (timer1MaxMin < 10) ? "0" + timer1MaxMin.ToString() : timer1MaxMin.ToString();
            timer1Text += ":";
            timer1Text += (timer1MaxSec < 10) ? "0" + timer1MaxSec.ToString() : timer1MaxSec.ToString();
            timer1Text += ")";

            timer2Text = " (";
            timer2Text += (timer2MinHour < 10) ? "0" + timer2MinHour.ToString() : timer2MinHour.ToString();
            timer2Text += ":";
            timer2Text += (timer2MinMin < 10) ? "0" + timer2MinMin.ToString() : timer2MinMin.ToString();
            timer2Text += ":";
            timer2Text += (timer2MinSec < 10) ? "0" + timer2MinSec.ToString() : timer2MinSec.ToString();
            timer2Text += " - ";
            timer2Text += (timer2MaxHour < 10) ? "0" + timer2MaxHour.ToString() : timer2MaxHour.ToString();
            timer2Text += ":";
            timer2Text += (timer2MaxMin < 10) ? "0" + timer2MaxMin.ToString() : timer2MaxMin.ToString();
            timer2Text += ":";
            timer2Text += (timer2MaxSec < 10) ? "0" + timer2MaxSec.ToString() : timer2MaxSec.ToString();
            timer2Text += ")";

            if (timer1Started) labelTimer1.Text = "Timer 1: On" + timer1Text;
            else labelTimer1.Text = "Timer 1: Off" + timer1Text;

            if (timer2Started) labelTimer2.Text = "Timer 2: On" + timer2Text;
            else labelTimer2.Text = "Timer 2: Off" + timer2Text;
        }

        private int getHotkeyModNumber(string keyname)
        {
            int i = 0;
                if (keyname.IndexOf("Alt") != -1) i += 1;
                if (keyname.IndexOf("Ctrl") != -1) i += 2;
                if (keyname.IndexOf("Shift") != -1) i += 4;
                if (keyname.IndexOf("Win") != -1) i += 8;
            return i;
        }

        private string getHotkeyModChars(string keyname)
        {
            string i = null;
            if (keyname.IndexOf("Alt") != -1) i += "%";
            if (keyname.IndexOf("Ctrl") != -1) i += "^";
            if (keyname.IndexOf("Shift") != -1) i += "+";
            return i;
        }

        private string getHotkeyChar(string i)
        {
            if (i == "D1") i = "1";
            if (i == "D2") i = "2";
            if (i == "D3") i = "3";
            if (i == "D4") i = "4";
            if (i == "D5") i = "5";
            if (i == "D6") i = "6";
            if (i == "D7") i = "7";
            if (i == "D8") i = "8";
            if (i == "D9") i = "9";
            if (i == "D0") i = "0";
            return i.ToLower();
        }

        private void readSendkeys()
        {
            // send keys
            sendkeyPlayMod = settings.LoadSetting("SendkeyPlayMod");
            sendkeyPlayKey = settings.LoadSetting("SendkeyPlayKey");
            sendkeyStopMod = settings.LoadSetting("SendkeyStopMod");
            sendkeyStopKey = settings.LoadSetting("SendkeyStopKey");
            sendKeystrokes = Convert.ToBoolean(settings.LoadSetting("SendKeystrokes"));

            if (sendkeyPlayMod != "" && sendkeyPlayKey != "") sendkeyPlay = true;
            else sendkeyPlay = false;

            if (sendkeyStopMod != "" && sendkeyStopKey != "") sendkeyStop = true;
            else sendkeyStop = false;

            if (!String.IsNullOrEmpty(sendkeyPlayMod)) sendkeyPlayString = getHotkeyModChars(sendkeyPlayMod) + getHotkeyChar(sendkeyPlayKey);
            if (!String.IsNullOrEmpty(sendkeyStopMod)) sendkeyStopString = getHotkeyModChars(sendkeyStopMod) + getHotkeyChar(sendkeyStopKey);

            if (sendKeystrokes) labelSendKeystrokes.Text = "Send Keystrokes: On";
            else labelSendKeystrokes.Text = "Send Keystrokes: Off";

        }

        private void readHotkeys()
        {
            // hotkeys
            hotkeyPlayPreMod = settings.LoadSetting("HotkeyPlayPreMod");
            hotkeyRandomMod = settings.LoadSetting("HotkeyRandomMod");
            hotkeyRandomKey = settings.LoadSetting("HotkeyRandomKey");
            hotkeyStopMod = settings.LoadSetting("HotkeyStopMod");
            hotkeyStopKey = settings.LoadSetting("HotkeyStopKey");
            hotkeyReplayMod = settings.LoadSetting("HotkeyReplayMod");
            hotkeyReplayKey = settings.LoadSetting("HotkeyReplayKey");
            hotkeyTimer1Mod = settings.LoadSetting("HotkeyTimer1Mod");
            hotkeyTimer1Key = settings.LoadSetting("HotkeyTimer1Key");
            hotkeyTimer2Mod = settings.LoadSetting("HotkeyTimer2Mod");
            hotkeyTimer2Key = settings.LoadSetting("HotkeyTimer2Key");
            hotkeyStopTimerMod = settings.LoadSetting("HotkeyStopTimerMod");
            hotkeyStopTimerKey = settings.LoadSetting("HotkeyStopTimerKey");
            hotkeyWarning = Convert.ToBoolean(settings.LoadSetting("HotkeyWarning"));

            hook.DisposeKeysOnly();
            hook.ClearErrors();

            if (!String.IsNullOrEmpty(hotkeyPlayPreMod))
            {
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F1);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F2);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F3);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F4);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F5);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F6);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F7);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F8);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F9);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F10);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F11);
                hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyPlayPreMod), Keys.F12);
            }

            if (!String.IsNullOrEmpty(hotkeyRandomMod)) hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyRandomMod), (Keys)Enum.Parse(typeof(Keys), hotkeyRandomKey));
            if (!String.IsNullOrEmpty(hotkeyStopMod)) hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyStopMod), (Keys)Enum.Parse(typeof(Keys), hotkeyStopKey));
            if (!String.IsNullOrEmpty(hotkeyReplayMod)) hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyReplayMod), (Keys)Enum.Parse(typeof(Keys), hotkeyReplayKey));
            if (!String.IsNullOrEmpty(hotkeyTimer1Mod)) hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyTimer1Mod), (Keys)Enum.Parse(typeof(Keys), hotkeyTimer1Key));
            if (!String.IsNullOrEmpty(hotkeyTimer2Mod)) hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyTimer2Mod), (Keys)Enum.Parse(typeof(Keys), hotkeyTimer2Key));
            if (!String.IsNullOrEmpty(hotkeyStopTimerMod)) hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(hotkeyStopTimerMod), (Keys)Enum.Parse(typeof(Keys), hotkeyStopTimerKey));

            if (hotkeyWarning && hook.ShowErrors() != "") MessageBox.Show("Following global hotkeys are currently registered to another application, so they do not work with this instance of Pätkä Player.\n" + hook.ShowErrors(), "Global Hotkey Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void renderButtons(int x, int y, out Bitmap buttonBack, out Bitmap buttonBackHover, out Bitmap buttonBackPress)
        {
            // button normal
            buttonBack = new Bitmap(x, y);
            Graphics g = Graphics.FromImage(buttonBack);

            SolidBrush brushBackShadow = new SolidBrush(ColorTranslator.FromHtml(buttonColorShadow));
            g.FillRectangle(brushBackShadow, 0, 0, x, y);

            SolidBrush brushBackOuter = new SolidBrush(ColorTranslator.FromHtml(buttonColorBorder));
            g.FillRectangle(brushBackOuter, 1, 1, x - 2, y - 2);

            LinearGradientBrush gradBackInner = new LinearGradientBrush(new Point(0, 0), new Point(0, y - 2), ColorTranslator.FromHtml(buttonColorBorderGradientTop), ColorTranslator.FromHtml(buttonColorBorderGradientBottom));
            g.FillRectangle(gradBackInner, 2, 2, x - 4, y - 4);

            LinearGradientBrush gradUpper = new LinearGradientBrush(new Point(0, 0), new Point(0, y / 2 - 1), ColorTranslator.FromHtml(buttonColorBackGradientUpperTop), ColorTranslator.FromHtml(buttonColorBackGradientUpperBottom));
            LinearGradientBrush gradLower = new LinearGradientBrush(new Point(0, 0), new Point(0, y / 2 - 1), ColorTranslator.FromHtml(buttonColorBackGradientLowerTop), ColorTranslator.FromHtml(buttonColorBackGradientLowerBottom));

            g.FillRectangle(gradUpper, 3, 3, x - 6, y / 2 - 2);
            g.FillRectangle(gradLower, 3, y / 2 - 1, x - 6, y / 2 - 2);

            SolidBrush brushCorner = new SolidBrush(ColorTranslator.FromHtml(buttonColorCorner));
            g.FillRectangle(brushCorner, 1, 1, 1, 1);
            g.FillRectangle(brushCorner, 1, y - 2, 1, 1);
            g.FillRectangle(brushCorner, x - 2, 1, 1, 1);
            g.FillRectangle(brushCorner, x - 2, y - 2, 1, 1);

            SolidBrush brushCornerShadow = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerShadow));
            g.FillRectangle(brushCornerShadow, 0, 0, 1, 1);
            g.FillRectangle(brushCornerShadow, 0, y - 1, 1, 1);
            g.FillRectangle(brushCornerShadow, x - 1, 0, 1, 1);
            g.FillRectangle(brushCornerShadow, x - 1, y - 1, 1, 1);

            // button hover
            buttonBackHover = new Bitmap(x, y);
            Graphics gH = Graphics.FromImage(buttonBackHover);

            SolidBrush brushBackShadowH = new SolidBrush(ColorTranslator.FromHtml(buttonColorShadowH));
            gH.FillRectangle(brushBackShadowH, 0, 0, x, y);

            SolidBrush brushBackOuterH = new SolidBrush(ColorTranslator.FromHtml(buttonColorBorderH));
            gH.FillRectangle(brushBackOuterH, 1, 1, x - 2, y - 2);

            LinearGradientBrush gradBackInnerH = new LinearGradientBrush(new Point(0, 0), new Point(0, y - 2), ColorTranslator.FromHtml(buttonColorBorderGradientTopH), ColorTranslator.FromHtml(buttonColorBorderGradientBottomH));
            gH.FillRectangle(gradBackInnerH, 2, 2, x - 4, y - 4);

            LinearGradientBrush gradUpperH = new LinearGradientBrush(new Point(0, 0), new Point(0, y / 2 - 1), ColorTranslator.FromHtml(buttonColorBackGradientUpperTopH), ColorTranslator.FromHtml(buttonColorBackGradientUpperBottomH));
            LinearGradientBrush gradLowerH = new LinearGradientBrush(new Point(0, 0), new Point(0, y / 2 - 1), ColorTranslator.FromHtml(buttonColorBackGradientLowerTopH), ColorTranslator.FromHtml(buttonColorBackGradientLowerBottomH));

            gH.FillRectangle(gradUpperH, 3, 3, x - 6, y / 2 - 2);
            gH.FillRectangle(gradLowerH, 3, y / 2 - 1, x - 6, y / 2 - 2);

            SolidBrush brushCornerH = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerH));
            gH.FillRectangle(brushCornerH, 1, 1, 1, 1);
            gH.FillRectangle(brushCornerH, 1, y - 2, 1, 1);
            gH.FillRectangle(brushCornerH, x - 2, 1, 1, 1);
            gH.FillRectangle(brushCornerH, x - 2, y - 2, 1, 1);

            SolidBrush brushCornerShadowH = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerShadowH));
            gH.FillRectangle(brushCornerShadowH, 0, 0, 1, 1);
            gH.FillRectangle(brushCornerShadowH, 0, y - 1, 1, 1);
            gH.FillRectangle(brushCornerShadowH, x - 1, 0, 1, 1);
            gH.FillRectangle(brushCornerShadowH, x - 1, y - 1, 1, 1);

            // button press
            buttonBackPress = new Bitmap(x, y);
            Graphics gP = Graphics.FromImage(buttonBackPress);

            SolidBrush brushBackShadowP = new SolidBrush(ColorTranslator.FromHtml(buttonColorShadowP));
            gP.FillRectangle(brushBackShadowP, 0, 0, x, y);

            SolidBrush brushBackOuterP = new SolidBrush(ColorTranslator.FromHtml(buttonColorBorderP));
            gP.FillRectangle(brushBackOuterP, 1, 1, x - 2, y - 2);

            LinearGradientBrush gradBackInnerP = new LinearGradientBrush(new Point(0, 0), new Point(0, y - 2), ColorTranslator.FromHtml(buttonColorBorderGradientTopP), ColorTranslator.FromHtml(buttonColorBorderGradientBottomP));
            gP.FillRectangle(gradBackInnerP, 2, 2, x - 4, y - 4);

            LinearGradientBrush gradUpperP = new LinearGradientBrush(new Point(0, 0), new Point(0, y / 2 - 1), ColorTranslator.FromHtml(buttonColorBackGradientUpperTopP), ColorTranslator.FromHtml(buttonColorBackGradientUpperBottomP));
            LinearGradientBrush gradLowerP = new LinearGradientBrush(new Point(0, 0), new Point(0, y / 2 - 1), ColorTranslator.FromHtml(buttonColorBackGradientLowerTopP), ColorTranslator.FromHtml(buttonColorBackGradientLowerBottomP));

            gP.FillRectangle(gradUpperP, 3, 3, x - 6, y / 2 - 2);
            gP.FillRectangle(gradLowerP, 3, y / 2 - 1, x - 6, y / 2 - 2);

            SolidBrush brushCornerP = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerP));
            gP.FillRectangle(brushCornerP, 1, 1, 1, 1);
            gP.FillRectangle(brushCornerP, 1, y - 2, 1, 1);
            gP.FillRectangle(brushCornerP, x - 2, 1, 1, 1);
            gP.FillRectangle(brushCornerP, x - 2, y - 2, 1, 1);

            SolidBrush brushCornerShadowP = new SolidBrush(ColorTranslator.FromHtml(buttonColorCornerShadowP));
            gP.FillRectangle(brushCornerShadowP, 0, 0, 1, 1);
            gP.FillRectangle(brushCornerShadowP, 0, y - 1, 1, 1);
            gP.FillRectangle(brushCornerShadowP, x - 1, 0, 1, 1);
            gP.FillRectangle(brushCornerShadowP, x - 1, y - 1, 1, 1);

        }

        private void sendMessagePlay()
        {
            NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_AK_PLAYPLAYER, IntPtr.Zero, IntPtr.Zero);
        }

        private void sendMessagePause()
        {
            NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_AK_PAUSEPLAYER, IntPtr.Zero, IntPtr.Zero);
        }

        // catch click even if form is not active
        protected override void WndProc(ref Message m)
        {
            int WM_PARENTNOTIFY = 0x0210;
            if (!this.Focused && m.Msg == WM_PARENTNOTIFY)
            {
                this.Activate();
            }

            if (m.Msg == NativeMethods.WM_AK_TRACKCHANGED)
            {
                btnRandom.PerformClick();
            }
            
            base.WndProc(ref m);
        }

        // double buffering entire form to prevent flickering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        // mouse scrolls control under mouse
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_MOUSEWHEEL = 0x20a;

            if (m.Msg == WM_MOUSEWHEEL)
            {
                // find the control at screen position m.LParam
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                IntPtr hWnd = WindowFromPoint(pos);
                if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null)
                {
                    SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                    return true;
                }
            }
            return false;
        }

        // P/Invoke declarations / mouse scrolls control under mouse
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);




    } // class end

    // custom paint for ProgressBar as ProgressBarEx
    public class ProgressBarEx : ProgressBar
    {
        public string ProgressText { get; set; }

        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // none, helps for flicker
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            /*
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
            if (ProgressBarRenderer.IsSupported) ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            e.Graphics.FillRectangle(new SolidBrush(Color.White), 2, 2, rec.Width - 4, rec.Height - 4);

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            rec.Height = rec.Height - 4;

            e.Graphics.FillRectangle(brushFore, 2, 2, rec.Width, rec.Height / 2);
            e.Graphics.FillRectangle(brushBack, 2, 2 + rec.Height / 2, rec.Width, rec.Height / 2);
            */

            using (Image offscreenImage = new Bitmap(this.Width, this.Height))
            {
                using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                {
                    Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

                    offscreen.FillRectangle(new SolidBrush(SystemColors.ButtonFace), 0, 0, 1, 1);
                    offscreen.FillRectangle(new SolidBrush(SystemColors.ButtonFace), rec.Width - 1, 0, 1, 1);
                    offscreen.FillRectangle(new SolidBrush(SystemColors.ButtonFace), rec.Width - 1, rec.Height - 1, 1, 1);
                    offscreen.FillRectangle(new SolidBrush(SystemColors.ButtonFace), 0, rec.Height - 1, 1, 1);

                    //offscreen.FillRectangle(new SolidBrush(SystemColors.ControlLight), 0, 0, rec.Width, rec.Height);
                    offscreen.FillRectangle(new SolidBrush(Color.FromArgb(255, 200, 200, 200)), 0, 0, rec.Width, rec.Height);
                    offscreen.FillRectangle(new SolidBrush(Color.White), 1, 1, rec.Width - 2, rec.Height - 2);

                    if (Value > 0)
                    {
                        rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 2;
                        rec.Height = rec.Height - 2;

                        // progressbar gradients

                        // blue
                        //offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#aac9e7")), 2, 2, rec.Width - 2, (rec.Height - 2) / 2);
                        //offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#9dbddc")), 2, rec.Height / 2 + 1, rec.Width - 2, (rec.Height - 1) / 2);

                        // red
                        //offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#f2c0c0")), 2, 2, rec.Width - 2, (rec.Height - 2) / 2);
                        //offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#e6b3b3")), 2, rec.Height / 2 + 1, rec.Width - 2, (rec.Height - 1) / 2);

                        // gray
                        //offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#ccc")), 2, 2, rec.Width - 2, (rec.Height - 2) / 2);
                        //offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#bbb")), 2, rec.Height / 2 + 1, rec.Width - 2, (rec.Height - 1) / 2);

                        //green
                        offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#50d350")), 2, 2, rec.Width - 2, (rec.Height - 2) / 2);
                        offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#2dc82d")), 2, rec.Height / 2 + 1, rec.Width - 2, (rec.Height - 1) / 2);


                    }

                    using (Font f = new Font("Segoe UI", 8))
                    {
                        SizeF len = offscreen.MeasureString(ProgressText, f);
                        Point location = new Point(Convert.ToInt32((Width / 2) - len.Width / 2), 5);

                        //offscreen.DrawString(ProgressText, f, Brushes.Black, new PointF(3, 5));
                        offscreen.DrawString(ProgressText, f, Brushes.Black, location);
                    }

                    e.Graphics.DrawImage(offscreenImage, 0, 0);
                    offscreenImage.Dispose();
                }
            }


            
        }
    }



} // namespace end
