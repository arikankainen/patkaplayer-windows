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
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PatkaPlayer
{
    public partial class frmPlayer
    {
        /**** FindWindow ****/

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

        /// <summary>Enumeration of the different ways of showing a window using 
        /// ShowWindow</summary>
        private enum WindowShowStyle : uint
        {
            /// <summary>Hides the window and activates another window.</summary>
            /// <remarks>See SW_HIDE</remarks>
            Hide = 0,
            /// <summary>Activates and displays a window. If the window is minimized 
            /// or maximized, the system restores it to its original size and 
            /// position. An application should specify this flag when displaying 
            /// the window for the first time.</summary>
            /// <remarks>See SW_SHOWNORMAL</remarks>
            ShowNormal = 1,
            /// <summary>Activates the window and displays it as a minimized window.</summary>
            /// <remarks>See SW_SHOWMINIMIZED</remarks>
            ShowMinimized = 2,
            /// <summary>Activates the window and displays it as a maximized window.</summary>
            /// <remarks>See SW_SHOWMAXIMIZED</remarks>
            ShowMaximized = 3,
            /// <summary>Maximizes the specified window.</summary>
            /// <remarks>See SW_MAXIMIZE</remarks>
            Maximize = 3,
            /// <summary>Displays a window in its most recent size and position. 
            /// This value is similar to "ShowNormal", except the window is not 
            /// actived.</summary>
            /// <remarks>See SW_SHOWNOACTIVATE</remarks>
            ShowNormalNoActivate = 4,
            /// <summary>Activates the window and displays it in its current size 
            /// and position.</summary>
            /// <remarks>See SW_SHOW</remarks>
            Show = 5,
            /// <summary>Minimizes the specified window and activates the next 
            /// top-level window in the Z order.</summary>
            /// <remarks>See SW_MINIMIZE</remarks>
            Minimize = 6,
            /// <summary>Displays the window as a minimized window. This value is 
            /// similar to "ShowMinimized", except the window is not activated.</summary>
            /// <remarks>See SW_SHOWMINNOACTIVE</remarks>
            ShowMinNoActivate = 7,
            /// <summary>Displays the window in its current size and position. This 
            /// value is similar to "Show", except the window is not activated.</summary>
            /// <remarks>See SW_SHOWNA</remarks>
            ShowNoActivate = 8,
            /// <summary>Activates and displays the window. If the window is 
            /// minimized or maximized, the system restores it to its original size 
            /// and position. An application should specify this flag when restoring 
            /// a minimized window.</summary>
            /// <remarks>See SW_RESTORE</remarks>
            Restore = 9,
            /// <summary>Sets the show state based on the SW_ value specified in the 
            /// STARTUPINFO structure passed to the CreateProcess function by the 
            /// program that started the application.</summary>
            /// <remarks>See SW_SHOWDEFAULT</remarks>
            ShowDefault = 10,
            /// <summary>Windows 2000/XP: Minimizes a window, even if the thread 
            /// that owns the window is hung. This flag should only be used when 
            /// minimizing windows from a different thread.</summary>
            /// <remarks>See SW_FORCEMINIMIZE</remarks>
            ForceMinimized = 11
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        // Delegate to filter which windows to include 
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary> Get the text for the window pointed to by hWnd </summary>
        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }

            return String.Empty;
        }

        /// <summary> Find all windows that match the given filter </summary>
        /// <param name="filter"> A delegate that returns true for windows
        ///    that should be returned and false for windows that should
        ///    not be returned </param>
        public static IEnumerable<IntPtr> FindWindows(EnumWindowsProc filter)
        {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();

            EnumWindows(delegate (IntPtr wnd, IntPtr param)
            {
                if (filter(wnd, param))
                {
                    // only add the windows that pass the filter
                    windows.Add(wnd);
                }

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        /// <summary> Find all windows that contain the given title text </summary>
        /// <param name="titleText"> The text that the window title must contain. </param>
        public static IEnumerable<IntPtr> FindWindowsWithText(string titleText)
        {
            return FindWindows(delegate (IntPtr wnd, IntPtr param)
            {
                return GetWindowText(wnd).Contains(titleText);
            });
        }

        /**** UPPER CODE - FindWindow ****/

        private const byte VK_SCROLL = 0x91;
        private const uint KEYEVENTF_KEYUP = 0x2;

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "GetKeyState", SetLastError = true)]
        static extern short GetKeyState(uint nVirtKey);

        public void SetScrollLockKeyAndScreamerRadioMute(bool newState)
        {
            bool scrollLockSet = GetKeyState(VK_SCROLL) != 0;
            if (scrollLockSet != newState)
            {
                keybd_event(VK_SCROLL, 0, 0, 0);
                keybd_event(VK_SCROLL, 0, KEYEVENTF_KEYUP, 0);
            }

            //volScreamer.Mute = newState;
            //volFirefox.Mute = newState;
        }

        public static bool GetScrollLockState()
        {
            return GetKeyState(VK_SCROLL) != 0;
        }

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

            if (m.Msg == NativeMethods.WM_AK_PP_SHOWME)
            {
                if (!this.Focused)
                {
                    if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                    this.Show();
                    this.Activate();
                    this.Focus();
                }

                else this.WindowState = FormWindowState.Minimized;
            }

            const int WM_COPYDATA = 0x004a;

            if (m.Msg == WM_COPYDATA)
            {
                MessageHelper.COPYDATASTRUCT mystr = new MessageHelper.COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (MessageHelper.COPYDATASTRUCT)m.GetLParam(mytype);
                string msg = mystr.lpData.ToString();

                if (msg == "PP_RANDOM") btnRandom.PerformClick();
                if (msg == "PP_REPLAY") btnReplay.PerformClick();
                if (msg == "PP_STOP") btnStop.PerformClick();

                if (msg.Contains("<distance>"))
                {
                    string dist = msg.Replace("<distance>", "").Replace("</distance>", "");
                    int value = -1;
                    Int32.TryParse(dist, out value);

                    if (value > 19)
                    {
                        double x = (double)(value - 20) / 130;
                        setPosition(x);
                    }
                }

                if (msg.Contains("<update>"))
                {
                    sendWindowsMessage("<pp_folder>" + lastPlayedFolder + "</pp_folder>");
                    sendWindowsMessage("<pp_file>" + lastPlayedFile + "</pp_file>");

                    getCount(false);
                }

                if (msg.Contains("<random>")) btnRandom.PerformClick();
            }

            base.WndProc(ref m);
        }

        private void setPosition(double percent)
        {
            try
            {
                if (waveOutDevice != null)
                {
                    double trackBarPercent = (((double)pbPosition.Value / (double)pbPosition.Maximum));

                    pbPosition.Value = (int)(pbPosition.Maximum * percent);
                    audioFileReader.SetPosition((double)pbPosition.Value / 1000);

                    if (!play)
                    {
                        playpressed = true;
                        if (!play && sendMessages) sendMessagePause();

                        playTrack();
                    }
                }
            }
            catch { }
        }

        private void sendWindowsMessage(string message)
        {
            try
            {
                /*
                IntPtr windowHandle = IntPtr.Zero;
                Process[] processes = Process.GetProcessesByName("arduinocontrol");
                foreach (Process p in processes)
                {
                    windowHandle = p.MainWindowHandle;
                    labelTimer1.Text = windowHandle.ToString();
                }

                MessageHelper h = new MessageHelper();
                h.sendWindowsStringMessage(windowHandle.ToInt32(), 0, message);
                */
                
                var windows = FindWindowsWithText("Arduino Control");
                labelTimer1.Text = "";
                foreach (IntPtr w in windows)
                {
                    MessageHelper h = new MessageHelper();
                    h.sendWindowsStringMessage(w.ToInt32(), 0, message);
                }
            }

            catch { }
        }

        // double buffering entire form to prevent flickering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        // mouse scrolls control under mouse
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

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




    }
}
