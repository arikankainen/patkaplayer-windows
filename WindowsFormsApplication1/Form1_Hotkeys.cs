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

namespace PatkaPlayer
{
    public partial class frmPlayer
    {
        private string appPath = Application.ExecutablePath; // full path of exe
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath); // folder only
        private string appFile = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(Application.ExecutablePath)); // filename only, without extension

        private List<List<string>> hotkeyList = new List<List<string>>();

        private void readHotkeys()
        {
            try
            {
                hotkeyList.Clear();
                string file = Path.Combine(appDir, "hotkeys.cfg");

                using (StreamReader reader = File.OpenText(file))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        List<string> list = line.Split('|').ToList<string>();
                        hotkeyList.Add(list);
                    }
                }

            }

            catch { }

            hook.DisposeKeysOnly();
            hook.ClearErrors();

            foreach (List<string> set in hotkeyList)
            {
                string keyList = Hotkeys.GetHotkeyKey(set[1]);
                string modList = Hotkeys.GetHotkeyModifiers(set[1]);

                if (set[2] == "X") hookKey(modList, keyList);
            }

            if (hotkeyWarning && hook.ShowErrors() != "") MessageBox.Show("Following global hotkeys are currently registered to another application:\n" + hook.ShowErrors(), "Global Hotkey Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void hookKey(string mod, string key)
        {
            //if (!String.IsNullOrEmpty(mod) && !String.IsNullOrEmpty(key)) hook.RegisterHotKey((ModifierKeys)Hotkeys.GetGlobalHotkeyModNumber(mod), (Keys)Enum.Parse(typeof(Keys), key));

            if (String.IsNullOrEmpty(mod) && !String.IsNullOrEmpty(key)) hook.RegisterHotKey((ModifierKeys)0, (Keys)Enum.Parse(typeof(Keys), key));
            else if (!String.IsNullOrEmpty(mod) && !String.IsNullOrEmpty(key)) hook.RegisterHotKey((ModifierKeys)Hotkeys.GetGlobalHotkeyModNumber(mod), (Keys)Enum.Parse(typeof(Keys), key));
        }

        private void frmPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtFolderFilter.Focused || txtFileFilter.Focused || txtPlaylistFolderFilter.Focused || txtPlaylistFileFilter.Focused)
            {
                if (e.KeyCode == Keys.Escape)
                {
                }
            }

            else
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                if (e.KeyCode == Keys.Delete)
                {
                    //return;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    //return;
                }

                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    //return;
                }

                foreach (List<string> set in hotkeyList)
                {
                    string keyPressed = e.KeyData.ToString().Replace("Menu", "").Replace("Alt", "").Replace("ControlKey", "").Replace("Control", "").Replace("ShiftKey", "").Replace("Shift", "").Replace(", ", "");
                    string modPressed = e.Modifiers.ToString();
                    if (modPressed == "None") modPressed = null;

                    string keyList = Hotkeys.GetHotkeyKey(set[1]);
                    string modList = Hotkeys.GetHotkeyModifiers(set[1]);

                    if (modList == modPressed && keyList == keyPressed) hotkeyAction(set[0]);
                }


            }
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (!keyDown)
            {
                bool enableDelay = true;
                foreach (List<string> set in hotkeyList)
                {
                    string keyPressed = e.Key.ToString();
                    string modPressed = e.Modifier.ToString();
                    if (modPressed == "None" || modPressed == "0") modPressed = null;

                    string keyList = Hotkeys.GetHotkeyKey(set[1]);
                    string modList = Hotkeys.GetHotkeyModifiersGlobal(set[1]);

                    if (modList == modPressed && keyList == keyPressed)
                    {
                        if (set[0].Contains("Volume")) enableDelay = false;
                        hotkeyAction(set[0]);
                    }
                }

                if (enableDelay)
                {
                    keyDown = true;
                    timerKeyDown.Start();
                }
            }
        }

        private void hotkeyAction(string action)
        {
            switch (action)
            {
                case "Random":
                    btnRandom.PerformClick();
                    break;

                case "Replay":
                    btnReplay.PerformClick();
                    break;

                case "Stop":
                    btnStop.PerformClick();
                    break;

                case "Volume up":
                    increaseVol();
                    break;

                case "Volume down":
                    decreaseVol();
                    break;

                case "Quick filter":
                    quickFilter();
                    break;

                case "Focus application":
                    if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                    this.Show();
                    this.Activate();
                    this.Focus();
                    break;

                case "Playmode: Folder":
                    radioFolders.Checked = true;
                    break;

                case "Playmode: File":
                    radioFiles.Checked = true;
                    break;

                case "Playmode: Playlist":
                    radioPlaylist.Checked = true;
                    break;

                case "Start timer1":
                    if (!timer1Started) startTimer1();
                    break;

                case "Start timer2":
                    if (!timer2Started) startTimer2();
                    break;

                case "Stop timer":
                    if (timer1Started) startTimer1();
                    else if (timer2Started) startTimer2();
                    break;

                case "Play clip 1":
                    playFile(Path.Combine(mp3Dir, hotkey1));
                    break;

                case "Play clip 2":
                    playFile(Path.Combine(mp3Dir, hotkey2));
                    break;

                case "Play clip 3":
                    playFile(Path.Combine(mp3Dir, hotkey3));
                    break;

                case "Play clip 4":
                    playFile(Path.Combine(mp3Dir, hotkey4));
                    break;

                case "Play clip 5":
                    playFile(Path.Combine(mp3Dir, hotkey5));
                    break;

                case "Play clip 6":
                    playFile(Path.Combine(mp3Dir, hotkey6));
                    break;

                case "Play clip 7":
                    playFile(Path.Combine(mp3Dir, hotkey7));
                    break;

                case "Play clip 8":
                    playFile(Path.Combine(mp3Dir, hotkey8));
                    break;

                case "Play clip 9":
                    playFile(Path.Combine(mp3Dir, hotkey9));
                    break;

                case "Play clip 10":
                    playFile(Path.Combine(mp3Dir, hotkey10));
                    break;

                case "Play clip 11":
                    playFile(Path.Combine(mp3Dir, hotkey11));
                    break;

                case "Play clip 12":
                    playFile(Path.Combine(mp3Dir, hotkey12));
                    break;

                case "Play clip 13":
                    playFile(Path.Combine(mp3Dir, hotkey13));
                    break;

                case "Play clip 14":
                    playFile(Path.Combine(mp3Dir, hotkey14));
                    break;

                case "Play clip 15":
                    if (File.Exists(Path.Combine(mp3Dir, hotkey15))) playFile(Path.Combine(mp3Dir, hotkey15));
                    break;

                case "Spotify: Play/Pause":
                    //SpotifyPlayPause();
                    keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_KEYUP2, IntPtr.Zero);
                    break;

                case "Spotify: Previous":
                    //SpotifyPrevious();
                    keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_KEYUP2, IntPtr.Zero);
                    break;

                case "Spotify: Next":
                    //SpotifyNext();
                    keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_KEYUP2, IntPtr.Zero);
                    break;

                case "Speech: On":
                    //checkSpeech.Checked = true;
                    break;

                case "Speech: Off":
                    //checkSpeech.Checked = false;
                    break;
            }
        }

        private void frmPlayer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        /*
        private void readHotkeys()
        {
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

            hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(""), (Keys)Enum.Parse(typeof(Keys), "F7"));
            hook.RegisterHotKey((ModifierKeys)getHotkeyModNumber(""), (Keys)Enum.Parse(typeof(Keys), "F8"));

            if (hotkeyWarning && hook.ShowErrors() != "") MessageBox.Show("Following global hotkeys are currently registered to another application:\n" + hook.ShowErrors(), "Global Hotkey Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (!keyDown)
            {
                string mod = e.Modifier.ToString().Replace("Control", "Ctrl").Replace(", ", "+");
                string key = e.Key.ToString();

                if (key == "F7") btnRandom.PerformClick();
                if (key == "F8") btnReplay.PerformClick();
                if (mod == hotkeyRandomMod && key == hotkeyRandomKey) btnRandom.PerformClick();
                if (mod == hotkeyReplayMod && key == hotkeyReplayKey) btnReplay.PerformClick();
                if (mod == hotkeyStopMod && key == hotkeyStopKey) btnStop.PerformClick();

                if (mod == hotkeyTimer1Mod && key == hotkeyTimer1Key && !timer1Started) startTimer1();
                if (mod == hotkeyTimer2Mod && key == hotkeyTimer2Key && !timer2Started) startTimer2();
                if (mod == hotkeyStopTimerMod && key == hotkeyStopTimerKey)
                {
                    if (timer1Started) startTimer1();
                    else if (timer2Started) startTimer2();
                }

                if (e.Key == Keys.F1 && File.Exists(mp3Dir + "\\" + hotkey1)) playFile(mp3Dir + "\\" + hotkey1);
                if (e.Key == Keys.F2 && File.Exists(mp3Dir + "\\" + hotkey2)) playFile(mp3Dir + "\\" + hotkey2);
                if (e.Key == Keys.F3 && File.Exists(mp3Dir + "\\" + hotkey3)) playFile(mp3Dir + "\\" + hotkey3);
                if (e.Key == Keys.F4 && File.Exists(mp3Dir + "\\" + hotkey4)) playFile(mp3Dir + "\\" + hotkey4);
                if (e.Key == Keys.F5 && File.Exists(mp3Dir + "\\" + hotkey5)) playFile(mp3Dir + "\\" + hotkey5);
                if (e.Key == Keys.F6 && File.Exists(mp3Dir + "\\" + hotkey6)) playFile(mp3Dir + "\\" + hotkey6);
                //if (e.Key == Keys.F7 && File.Exists(mp3Dir + "\\" + hotkey7)) playFile(mp3Dir + "\\" + hotkey7);
                //if (e.Key == Keys.F8 && File.Exists(mp3Dir + "\\" + hotkey8)) playFile(mp3Dir + "\\" + hotkey8);
                if (e.Key == Keys.F9 && File.Exists(mp3Dir + "\\" + hotkey9)) playFile(mp3Dir + "\\" + hotkey9);
                if (e.Key == Keys.F10 && File.Exists(mp3Dir + "\\" + hotkey10)) playFile(mp3Dir + "\\" + hotkey10);
                if (e.Key == Keys.F11 && File.Exists(mp3Dir + "\\" + hotkey11)) playFile(mp3Dir + "\\" + hotkey11);
                if (e.Key == Keys.F12 && File.Exists(mp3Dir + "\\" + hotkey12)) playFile(mp3Dir + "\\" + hotkey12);

                keyDown = true;
                timerKeyDown.Start();
            }
        }



        */




    }
}
