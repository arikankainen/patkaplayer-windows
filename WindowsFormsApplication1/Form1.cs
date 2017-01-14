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
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;

using NAudio;
using NAudio.Wave;
using System.IO.Ports;

namespace PatkaPlayer
{
    public partial class frmPlayer : Form, IMessageFilter
    {
        private VolumeControl volScreamer = new VolumeControl("screamer");
        private VolumeControl volFirefox = new VolumeControl("opera");

        private TaskbarManager taskbar = TaskbarManager.Instance;
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;

        private bool play = false;
        private bool playpressed = false;
        private bool pause = false;
        private bool stop = true;
        private bool randompressed = false;

        private string mp3Dir, hotkey1, hotkey2, hotkey3, hotkey4, hotkey5, hotkey6, hotkey7, hotkey8, hotkey9, hotkey10, hotkey11, hotkey12;
        private int timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec, timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec;
        private string timer1Text, timer2Text;
        private decimal transNormal = 1;
        private bool logging, rememberDaily;
        private bool trayIcon, balloonPlay, balloonTimer;
        private string dailyDate;
        private int dailyCount;
        private string sendkeyPlayMod, sendkeyPlayKey, sendkeyStopMod, sendkeyStopKey, sendkeyPlayString, sendkeyStopString;

        private bool hotkeyWarning, sendKeystrokes;
        private int latency;
        private bool scrollLock;
        private bool keyDown = false;

        private bool sendMessages = true;

        private bool timer1Started = false;
        private bool timer2Started = false;
        private string lastPlayed, lastPlayedFile;
        private int lastRandomNumber = 0;
        private FormWindowState LastWindowState;
        private int lastWidth;
        private int playCount = 0;
        public int settingsPage;
        private bool tray = false;

        private static Timer timer = new Timer();
        private static Timer timer1 = new Timer();
        private static Timer timer2 = new Timer();
        private static Timer timerVol = new Timer();
        private Random randomT = new Random(); // random timer delay
        private Random randomA = new Random(); // random clip from all clips
        private Random randomF = new Random(); // random clip from filtered clips

        private KeyboardHook hook = new KeyboardHook();
        private Settings settings = new Settings();
        private ProgressBarEx pbPosition = new ProgressBarEx();
        private ProgressBarEx3 vol = new ProgressBarEx3();

        private string randomTarget = "folder";

        public frmPlayer()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);

            if (!File.Exists("naudio.dll"))
            {
                MessageBox.Show("Can't find NAudio.dll", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Application.MessageLoop) Application.Exit();
                else Environment.Exit(1);
            }

            labelVersion.Text = "v2.0";

            notifyIcon1.Visible = false;
            notifyIcon1.MouseUp += new MouseEventHandler(NotifyIcon1_Click);

            this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            this.Layout += new LayoutEventHandler(Form1_Layout);
            this.KeyUp += new KeyEventHandler(Form1_KeyEvent);

            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 100;

            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);

            timerVol.Tick += new EventHandler(timerVol_Tick);
            timerVol.Interval = 3000;

            lastWidth = this.Width;
            LastWindowState = this.WindowState;

            btnReplay.Enabled = false;

            toolStripPlay.Renderer = new MySR();
            toolStripSettings.Renderer = new MySR();

            pbPosition.Left = panelFileFilterG.Left;
            pbPosition.Top = 9;
            pbPosition.Width = panelFileFilterG.Width;
            pbPosition.Height = 23;

            pbPosition.ForeColor = ColorTranslator.FromHtml("#8ab3da");
            pbPosition.BackColor = ColorTranslator.FromHtml("#7fa9d2");
            pbPosition.Value = 0;
            pbPosition.Name = "progressPosition";
            pbPosition.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pbPosition.ProgressText = "";
            this.Controls.Add(pbPosition);

            pbPosition.MouseDown += new MouseEventHandler(pbPosition_MouseDown);
            pbPosition.MouseMove += new MouseEventHandler(pbPosition_MouseMove);

            vol.Left = labelVolumeName.Right + 5;
            vol.Top = 14;
            vol.Width = 100;
            vol.Height = 14;
            vol.Value = 100;
            vol.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Controls.Add(vol);
            vol.BringToFront();

            vol.MouseDown += new MouseEventHandler(vol_MouseDown);
            vol.MouseUp += new MouseEventHandler(vol_MouseUp);
            vol.MouseWheel += new MouseEventHandler(vol_MouseWheel);
            vol.MouseMove += new MouseEventHandler(vol_MouseMove);

            labelVolume.Left = vol.Right + 5;

            buttonLocations();
            InsertPanelButtons();
            getPorts();
        }

        private void buttonLocations()
        {
            toolStripSettings.Left = this.Width - toolStripSettings.Width - 20;
            toolStripPlay.Left = 4;

            //int fL = trackBarVolume.Right + 45;
            int fR = toolStripSettings.Left;

            toolStripSettings.Top = 2;
            toolStripPlay.Top = 2;
        }

        public void InsertPanelButtons()
        {
            ReadSettings();

            if (Directory.Exists(mp3Dir))
            {
                string[] files = Directory.GetFiles(mp3Dir, "*.mp3", SearchOption.AllDirectories);
                labelTotalClips.Text = "Clips: " + files.Count().ToString();
                addFolders();
            }
        }

        private void playFile(string fileToPlay)
        {
            int comboLatencyInt;
            if (scrollLock) SetScrollLockKeyAndScreamerRadioMute(false);

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

            playpressed = true;
            if (!play && sendMessages) sendMessagePause();
            closeTrack();

            loadTrack(fileToPlay, latency * 2);
            playTrack();

            sendName("<row1>" + Path.GetFileNameWithoutExtension(fileToPlay) + "</row1>");

            if (logging)
            {
                string originalPath = Application.ExecutablePath;
                string pathname = Path.GetDirectoryName(originalPath);
                string filename = Path.GetFileNameWithoutExtension(originalPath);
                string customPath = pathname + "\\" + filename + ".log";

                string logFolder = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1);
                string logFile = Path.GetFileNameWithoutExtension(fileToPlay);
                string log = DateTime.Now.ToString("dd.MM.yyyy|HH:mm:ss") + "|" + logFolder + "|" + logFile + "|" + lastPlayed;
                using (StreamWriter file = new StreamWriter(@customPath, true, Encoding.Default))
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
            labelClipsPlayed.Text = "Play count: " + playCount.ToString();
        }

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

        private void playRandom()
        {
            List<string> clips = getList();
            int clipCount = clips.Count;
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

            string fileToPlay = clips[randomNumber];
            playFile(fileToPlay);
        }

        private void fadeIn(double max)
        {
            for (double i = 0.0; i <= max; i += 0.1)
            {
                System.Threading.Thread.Sleep(10);
                this.Opacity = i;
            }
        }

        private void fadeOut(double max)
        {
            for (double i = max; i >= 0.0; i -= 0.1)
            {
                System.Threading.Thread.Sleep(10);
                this.Opacity = i;
            }
        }

        private int randomTime(int minHour, int minMin, int minSec, int maxHour, int maxMin, int maxSec)
        {
            int minTime = (minHour * 60 * 60) + (minMin * 60) + minSec;
            int maxTime = (maxHour * 60 * 60) + (maxMin * 60) + maxSec;

            int rnd = randomT.Next(minTime, maxTime);
            if (rnd == 0) rnd = 1;

            return rnd * 1000;
        }

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
                    notifyIcon1.Icon = Properties.Resources.patka_taskbar_red;
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

                    labelTimer1.Text = "Timer 1: on" + timer1Text;
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#dd0000");
                    timer1Started = true;
                    timer2Started = false;

                    labelTimer2.Text = "Timer 2: off" + timer2Text;
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#404040");
                    timer2Started = false;
                }
                else
                {
                    notifyIcon1.Icon = Properties.Resources.patka_taskbar;
                    timer1.Stop();

                    if (tray || trayIcon)
                    {
                        if (balloonTimer)
                        {
                            notifyIcon1.BalloonTipText = "Timer stopped";
                            notifyIcon1.ShowBalloonTip(100);
                        }
                    }

                    labelTimer1.Text = "Timer 1: off" + timer1Text;
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#404040");
                    timer1Started = false;
                }
            }
        }
 
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
                    notifyIcon1.Icon = Properties.Resources.patka_taskbar_red;
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

                    labelTimer2.Text = "Timer 2: on" + timer2Text;
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#dd0000");
                    timer2Started = true;

                    labelTimer1.Text = "Timer 1: off" + timer1Text;
                    labelTimer1.ForeColor = ColorTranslator.FromHtml("#404040");
                    timer1Started = false;
                }
                else
                {
                    notifyIcon1.Icon = Properties.Resources.patka_taskbar;
                    
                    timer2.Stop();

                    if (tray || trayIcon)
                    {
                        if (balloonTimer)
                        {
                            notifyIcon1.BalloonTipText = "Timer stopped";
                            notifyIcon1.ShowBalloonTip(100);
                        }
                    }

                    labelTimer2.Text = "Timer 2: off" + timer2Text;
                    labelTimer2.ForeColor = ColorTranslator.FromHtml("#404040");
                    timer2Started = false;
                }
            }
        }

        public void ReadSettings()
        {
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

            timer1MinHour = Convert.ToInt32(settings.LoadSetting("Timer1MinHour"));
            timer1MinMin = Convert.ToInt32(settings.LoadSetting("Timer1MinMin"));
            timer1MinSec = Convert.ToInt32(settings.LoadSetting("Timer1MinSec"));
            timer1MaxHour = Convert.ToInt32(settings.LoadSetting("Timer1MaxHour"));
            timer1MaxMin = Convert.ToInt32(settings.LoadSetting("Timer1MaxMin"));
            timer1MaxSec = Convert.ToInt32(settings.LoadSetting("Timer1MaxSec"));

            timer2MinHour = Convert.ToInt32(settings.LoadSetting("Timer2MinHour"));
            timer2MinMin = Convert.ToInt32(settings.LoadSetting("Timer2MinMin"));
            timer2MinSec = Convert.ToInt32(settings.LoadSetting("Timer2MinSec"));
            timer2MaxHour = Convert.ToInt32(settings.LoadSetting("Timer2MaxHour"));
            timer2MaxMin = Convert.ToInt32(settings.LoadSetting("Timer2MaxMin"));
            timer2MaxSec = Convert.ToInt32(settings.LoadSetting("Timer2MaxSec"));
            
            logging = Convert.ToBoolean(settings.LoadSetting("Logging"));
            rememberDaily = Convert.ToBoolean(settings.LoadSetting("RememberDaily"));

            trayIcon = Convert.ToBoolean(settings.LoadSetting("TrayIcon"));
            balloonPlay = Convert.ToBoolean(settings.LoadSetting("BalloonPlay"));
            balloonTimer = Convert.ToBoolean(settings.LoadSetting("BalloonTimer"));
            
            transNormal = Convert.ToDecimal(settings.LoadSetting("Transparency") ?? "1");
            latency = Convert.ToInt32(settings.LoadSetting("Latency"));
            if (latency < 50) latency = 200;
            if (latency > 900) latency = 200;
            comboLatency.Text = latency.ToString();
            scrollLock = Convert.ToBoolean(settings.LoadSetting("ScrollLock"));

            hotkeyWarning = Convert.ToBoolean(settings.LoadSetting("HotkeyWarning"));

            if (trayIcon) notifyIcon1.Visible = true;
            else notifyIcon1.Visible = false;

            if (rememberDaily) saveDailyDate();
            labelClipsPlayed.Text = "Play count: " + playCount.ToString();

            this.Opacity = Convert.ToDouble(transNormal);
            
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

            if (timer1Started) labelTimer1.Text = "Timer 1: on" + timer1Text;
            else labelTimer1.Text = "Timer 1: off" + timer1Text;

            if (timer2Started) labelTimer2.Text = "Timer 2: on" + timer2Text;
            else labelTimer2.Text = "Timer 2: off" + timer2Text;
        }

        private void sendMessagePlay()
        {
            NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_AK_PLAYPLAYER, IntPtr.Zero, IntPtr.Zero);
        }

        private void sendMessagePause()
        {
            NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_AK_PAUSEPLAYER, IntPtr.Zero, IntPtr.Zero);
        }


    }
}
