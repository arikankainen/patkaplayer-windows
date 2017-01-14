using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;

namespace PatkaPlayer
{
    class NativeMethods
    {
        // enable visual styles listview
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        // enable listening messages (used to show old instance if new one is launched
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_AK_TRACKCHANGED = RegisterWindowMessage("WM_AK_TRACKCHANGED");
        public static readonly int WM_AK_PAUSEPLAYER = RegisterWindowMessage("WM_AK_PAUSEPLAYER");
        public static readonly int WM_AK_PLAYPLAYER = RegisterWindowMessage("WM_AK_PLAYPLAYER");
        public static readonly int WM_AK_PP_SHOWME = RegisterWindowMessage("WM_AK_PP_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

    }

    public class MessageHelper
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        public const int WM_COPYDATA = 0x4A;

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        public int sendWindowsStringMessage(int hWnd, int wParam, string msg)
        {
            int result = 0;

            if (hWnd > 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(msg);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = msg;
                cds.cbData = len + 1;
                result = SendMessage(hWnd, WM_COPYDATA, wParam, ref cds);
            }

            return result;
        }
    }




}
