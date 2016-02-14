using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatkaPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static string appGuid = "50a76c53-12ab-43c5-a93a-8663f2a647b8";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    // send message to show old instance if new one is launched
                    NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_AK_PP_SHOWME, IntPtr.Zero, IntPtr.Zero);
                    return;
                }

                Application.Run(new frmPlayer());
            }

        }
    }
}
