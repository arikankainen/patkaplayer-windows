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
    public partial class frmPlayer
    {
        // center player
        private void menuCenter_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.FromPoint(Cursor.Position);
            this.Left = screen.WorkingArea.Left + (screen.Bounds.Size.Width / 2 - this.Width / 2);
            this.Top = screen.WorkingArea.Top + (screen.Bounds.Size.Height / 2 - this.Height / 2);
        }

        // erase last played clip when clicked
        private void labelLastPlayed_Click(object sender, EventArgs e)
        {
            labelLastPlayed.Text = "-";
            btnReplay.Tag = "";
            btnReplay.Enabled = false;
        }

        // timer 1 click
        private void menuTimer1_Click(object sender, EventArgs e)
        {
            startTimer1();
        }

        // timer 2 click
        private void menuTimer2_Click(object sender, EventArgs e)
        {
            startTimer2();
        }

        // left click start timer, right click configure it
        private void labelTimer1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) startTimer1();
            if (e.Button == MouseButtons.Right) menuTimers.PerformClick();
        }

        // left click start timer, right click configure it
        private void labelTimer2_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) startTimer2();
            if (e.Button == MouseButtons.Right) menuTimers.PerformClick();
        }

        private void labelSendKeystrokes_MouseUp(object sender, MouseEventArgs e)
        {
            if (sendKeystrokes) 
            {
                labelSendKeystrokes.Text = "Send Keystrokes: Off";
                sendKeystrokes = false;
            }
            else
            {
                labelSendKeystrokes.Text = "Send Keystrokes: On";
                sendKeystrokes = true;
            }
        }

        // main timer, updates statusbar and button locations
        private void timer_Tick(object sender, EventArgs e)
        {
            if (waveOutDevice != null)
            {
                pbPosition.Maximum = Convert.ToInt32(audioFileReader.TotalTime.TotalMilliseconds);
                pbPosition.Value = Convert.ToInt32(audioFileReader.CurrentTime.TotalMilliseconds);

                if (Convert.ToInt32(audioFileReader.TotalTime.ToString(@"mm")) > 0)
                    labelPosition.Text = audioFileReader.CurrentTime.ToString(@"mm\:ss\:ff") + " / " + audioFileReader.TotalTime.ToString(@"mm\:ss\:ff");
                
                else labelPosition.Text = audioFileReader.CurrentTime.ToString(@"ss\:ff") + " / " + audioFileReader.TotalTime.ToString(@"ss\:ff");
            }
        }

        // temp timer for setting focus off from buttons at load
        private void timerTemp_Tick(object sender, EventArgs e)
        {
            labelVolume.Focus();
            timerTemp.Stop();
        }

        // timer 1, plays clips
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = randomTime(timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec);
            if (timer1ClipsAll) playRandomAll();
            else playRandom();
        }

        // timer 2, plays clips
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = randomTime(timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec);
            if (timer2ClipsAll) playRandomAll();
            else playRandom();
        }

        // dropdown options menu
        private void btnDropdown_Click(object sender, EventArgs e)
        {
            //btnDropdown.Checked = true;
            Rectangle rect = this.btnDropdown.Bounds;
            Point pt = new Point(rect.Left - 106, rect.Bottom + 4);
            contextMenu1.Show(toolStripSettings, pt);
        }

        // show settings dialog: folders
        private void menuFolders_Click(object sender, EventArgs e)
        {
            settingsPage = 1;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        // show settings dialog: settings
        private void menuSettings_Click(object sender, EventArgs e)
        {
            settingsPage = 2;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        // show settings dialog: timers
        private void menuTimers_Click(object sender, EventArgs e)
        {
            settingsPage = 3;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        // reload buttons
        private void menuReload_Click(object sender, EventArgs e)
        {
            InsertPanelButtons();
        }

        // show settings dialog ****** TURHA???
        private void btnSettingsPage1_Click(object sender, EventArgs e)
        {
            settingsPage = 1;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        // folder filter key down
        private void txtFilterFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                folderList.Clear();
                filterFolder = txtFilterFolder.Text;
                txtFilterFile.Text = "";
                filterFile = "";
                addPanel();
                Button button = this.Controls.Find("SoundButton1", true).FirstOrDefault() as Button;
                this.ActiveControl = button;
            }
        }

        // file filter key down
        private void txtFilterFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                folderList.Clear();
                filterFile = txtFilterFile.Text;
                txtFilterFolder.Text = "";
                filterFolder = "";
                addPanel();
                Button button = this.Controls.Find("SoundButton1", true).FirstOrDefault() as Button;
                this.ActiveControl = button;
            }
        }

        // clear filters
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtFilterFile.Text = "";
            filterFile = "";
            txtFilterFolder.Text = "";
            filterFolder = "";
            addPanel();
        }

        // replay button
        private void btnReplay_Click(object sender, EventArgs e)
        {
            string fileToPlay = btnReplay.Tag.ToString();
            if (fileToPlay != "nofile") playFile(fileToPlay);
        }

        // random button
        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (array1.Length > 0) playRandom();
        }

        // help button
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmPopup helpForm = new frmPopup();
            helpForm.ShowDialog();
            helpForm.Dispose();
        }

        // keyup event, hotkeys
        private void Form1_KeyEvent(object sender, KeyEventArgs e)
        {
            if (txtFilterFolder.Selected == true || txtFilterFile.Selected == true) return;

            string key = e.KeyCode.ToString();

            if (key == hotkeyRandomKey) btnRandom.PerformClick();
            if (key == hotkeyReplayKey) btnReplay.PerformClick();
            if (key == hotkeyStopKey) btnStop.PerformClick();

            if (key == hotkeyTimer1Key && !timer1Started) startTimer1();
            if (key == hotkeyTimer2Key && !timer2Started) startTimer2();
            if (key == hotkeyStopTimerKey)
            {
                if (timer1Started) startTimer1();
                else if (timer2Started) startTimer2();
            }
            
            if (e.KeyCode == Keys.F1 && File.Exists(mp3Dir + "\\" + hotkey1)) playFile(mp3Dir + "\\" + hotkey1);
            if (e.KeyCode == Keys.F2 && File.Exists(mp3Dir + "\\" + hotkey2)) playFile(mp3Dir + "\\" + hotkey2);
            if (e.KeyCode == Keys.F3 && File.Exists(mp3Dir + "\\" + hotkey3)) playFile(mp3Dir + "\\" + hotkey3);
            if (e.KeyCode == Keys.F4 && File.Exists(mp3Dir + "\\" + hotkey4)) playFile(mp3Dir + "\\" + hotkey4);
            if (e.KeyCode == Keys.F5 && File.Exists(mp3Dir + "\\" + hotkey5)) playFile(mp3Dir + "\\" + hotkey5);
            if (e.KeyCode == Keys.F6 && File.Exists(mp3Dir + "\\" + hotkey6)) playFile(mp3Dir + "\\" + hotkey6);
            if (e.KeyCode == Keys.F7 && File.Exists(mp3Dir + "\\" + hotkey7)) playFile(mp3Dir + "\\" + hotkey7);
            if (e.KeyCode == Keys.F8 && File.Exists(mp3Dir + "\\" + hotkey8)) playFile(mp3Dir + "\\" + hotkey8);
            if (e.KeyCode == Keys.F9 && File.Exists(mp3Dir + "\\" + hotkey9)) playFile(mp3Dir + "\\" + hotkey9);
            if (e.KeyCode == Keys.F10 && File.Exists(mp3Dir + "\\" + hotkey10)) playFile(mp3Dir + "\\" + hotkey10);
            if (e.KeyCode == Keys.F11 && File.Exists(mp3Dir + "\\" + hotkey11)) playFile(mp3Dir + "\\" + hotkey11);
            if (e.KeyCode == Keys.F12 && File.Exists(mp3Dir + "\\" + hotkey12)) playFile(mp3Dir + "\\" + hotkey12);
        }

        // stop button
        private void btnStop_Click(object sender, EventArgs e)
        {
            playpressed = false;
            stopTrack();
        }

        // sound button click
        private void SoundButton_Click(object sender, EventArgs e)
        {
            labelVolume.Focus();
            Button temp = (Button)sender;
            string fileToPlay = temp.Tag.ToString();
            playFile(fileToPlay);
        }

        // sound button mouse enter
        private void SoundButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackHoverButton;
        }

        // sound button mouse leave
        private void SoundButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackButton;
        }

        // sound button mouse down
        private void SoundButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackPressButton;
        }

        // sound button mouse up
        private void SoundButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackHoverButton;

            if (e.Button == MouseButtons.Left)
            {
                panelButtons.Focus();
                Button temp = (Button)sender;
                string fileToPlay = temp.Tag.ToString();
                playFile(fileToPlay);
            }

            if (e.Button == MouseButtons.Right)
            {
                // context menu for soundbutton

                string hotkey1Text = "";
                string hotkey2Text = "";
                string hotkey3Text = "";
                string hotkey4Text = "";
                string hotkey5Text = "";
                string hotkey6Text = "";
                string hotkey7Text = "";
                string hotkey8Text = "";
                string hotkey9Text = "";
                string hotkey10Text = "";
                string hotkey11Text = "";
                string hotkey12Text = "";

                if (hotkey1 != "") hotkey1Text = Path.GetDirectoryName(hotkey1).Substring(Path.GetDirectoryName(hotkey1).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey1);
                if (hotkey2 != "") hotkey2Text = Path.GetDirectoryName(hotkey2).Substring(Path.GetDirectoryName(hotkey2).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey2);
                if (hotkey3 != "") hotkey3Text = Path.GetDirectoryName(hotkey3).Substring(Path.GetDirectoryName(hotkey3).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey3);
                if (hotkey4 != "") hotkey4Text = Path.GetDirectoryName(hotkey4).Substring(Path.GetDirectoryName(hotkey4).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey4);
                if (hotkey5 != "") hotkey5Text = Path.GetDirectoryName(hotkey5).Substring(Path.GetDirectoryName(hotkey5).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey5);
                if (hotkey6 != "") hotkey6Text = Path.GetDirectoryName(hotkey6).Substring(Path.GetDirectoryName(hotkey6).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey6);
                if (hotkey7 != "") hotkey7Text = Path.GetDirectoryName(hotkey7).Substring(Path.GetDirectoryName(hotkey7).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey7);
                if (hotkey8 != "") hotkey8Text = Path.GetDirectoryName(hotkey8).Substring(Path.GetDirectoryName(hotkey8).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey8);
                if (hotkey9 != "") hotkey9Text = Path.GetDirectoryName(hotkey9).Substring(Path.GetDirectoryName(hotkey9).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey9);
                if (hotkey10 != "") hotkey10Text = Path.GetDirectoryName(hotkey10).Substring(Path.GetDirectoryName(hotkey10).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey10);
                if (hotkey11 != "") hotkey11Text = Path.GetDirectoryName(hotkey11).Substring(Path.GetDirectoryName(hotkey11).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey11);
                if (hotkey12 != "") hotkey12Text = Path.GetDirectoryName(hotkey12).Substring(Path.GetDirectoryName(hotkey12).LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(hotkey12);
                
                menuItemF1.Text = "Set to hotkey F1         " + (hotkey1 != "" ? hotkey1Text : "(Empty)");
                menuItemF2.Text = "Set to hotkey F2         " + (hotkey2 != "" ? hotkey2Text : "(Empty)");
                menuItemF3.Text = "Set to hotkey F3         " + (hotkey3 != "" ? hotkey3Text : "(Empty)");
                menuItemF4.Text = "Set to hotkey F4         " + (hotkey4 != "" ? hotkey4Text : "(Empty)");
                menuItemF5.Text = "Set to hotkey F5         " + (hotkey5 != "" ? hotkey5Text : "(Empty)");
                menuItemF6.Text = "Set to hotkey F6         " + (hotkey6 != "" ? hotkey6Text : "(Empty)");
                menuItemF7.Text = "Set to hotkey F7         " + (hotkey7 != "" ? hotkey7Text : "(Empty)");
                menuItemF8.Text = "Set to hotkey F8         " + (hotkey8 != "" ? hotkey8Text : "(Empty)");
                menuItemF9.Text = "Set to hotkey F9         " + (hotkey9 != "" ? hotkey9Text : "(Empty)");
                menuItemF10.Text = "Set to hotkey F10       " + (hotkey10 != "" ? hotkey10Text : "(Empty)");
                menuItemF11.Text = "Set to hotkey F11       " + (hotkey11 != "" ? hotkey11Text : "(Empty)");
                menuItemF12.Text = "Set to hotkey F12       " + (hotkey12 != "" ? hotkey12Text : "(Empty)");

                menuItemF1.Tag = button.Tag;
                menuItemF2.Tag = button.Tag;
                menuItemF3.Tag = button.Tag;
                menuItemF4.Tag = button.Tag;
                menuItemF5.Tag = button.Tag;
                menuItemF6.Tag = button.Tag;
                menuItemF7.Tag = button.Tag;
                menuItemF8.Tag = button.Tag;
                menuItemF9.Tag = button.Tag;
                menuItemF10.Tag = button.Tag;
                menuItemF11.Tag = button.Tag;
                menuItemF12.Tag = button.Tag;

                menuItemF1.Name = "1";
                menuItemF2.Name = "2";
                menuItemF3.Name = "3";
                menuItemF4.Name = "4";
                menuItemF5.Name = "5";
                menuItemF6.Name = "6";
                menuItemF7.Name = "7";
                menuItemF8.Name = "8";
                menuItemF9.Name = "9";
                menuItemF10.Name = "10";
                menuItemF11.Name = "11";
                menuItemF12.Name = "12";

                contextButton.MenuItems.Clear();
                contextButton.MenuItems.Add(menuItemF1);
                contextButton.MenuItems.Add(menuItemF2);
                contextButton.MenuItems.Add(menuItemF3);
                contextButton.MenuItems.Add(menuItemF4);
                contextButton.MenuItems.Add(menuItemF5);
                contextButton.MenuItems.Add(menuItemF6);
                contextButton.MenuItems.Add(menuItemF7);
                contextButton.MenuItems.Add(menuItemF8);
                contextButton.MenuItems.Add(menuItemF9);
                contextButton.MenuItems.Add(menuItemF10);
                contextButton.MenuItems.Add(menuItemF11);
                contextButton.MenuItems.Add(menuItemF12);
                // **************

                contextButton.Show(button, e.Location);
            }

        }

        private void FolderButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackHoverFolder;
        }

        private void FolderButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackFolder;
        }

        private void FolderButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackPressFolder;
        }

        private void FolderButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackHoverFolder;

            txtFilterFolder.Text = "";
            filterFolder = "";
            txtFilterFile.Text = "";
            filterFile = "";

            if (e.Button == MouseButtons.Left)
            {
                folderList.Clear();
                if (button.Tag.ToString() != "") folderList.Add(button.Tag.ToString());
                addPanel();
                panelFolders.Focus();
            }

            if (e.Button == MouseButtons.Middle)
            {
                if (button.Tag.ToString() != "") folderList.Add(button.Tag.ToString());
                else folderList.Clear();
                addPanel();
                panelFolders.Focus();
            }

        }

        // sets focus to panelbuttons on mousescroll
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            panelButtons.Focus();
        }

        // window size changes
        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            buttonLocations();
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            buttonLocations();
        }

        // window resize end
        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
        }

        private void menuItemSet_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            string clip = menuItem.Tag.ToString().Replace(mp3Dir + "\\", "");
            string hotkey = menuItem.Name;

            settings.SaveSetting("Hotkey" + hotkey, clip);

            string pathToPlay = Path.GetDirectoryName(menuItem.Tag.ToString());
            lastPlayed = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " - " + Path.GetFileNameWithoutExtension(menuItem.Tag.ToString());
            labelLastPlayed.Text = "Hotkey F" + hotkey + " updated with: " + lastPlayed;

            ReadSettings();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            string mod = e.Modifier.ToString().Replace("Control", "Ctrl").Replace(", ", "+");
            string key = e.Key.ToString();

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
            if (e.Key == Keys.F7 && File.Exists(mp3Dir + "\\" + hotkey7)) playFile(mp3Dir + "\\" + hotkey7);
            if (e.Key == Keys.F8 && File.Exists(mp3Dir + "\\" + hotkey8)) playFile(mp3Dir + "\\" + hotkey8);
            if (e.Key == Keys.F9 && File.Exists(mp3Dir + "\\" + hotkey9)) playFile(mp3Dir + "\\" + hotkey9);
            if (e.Key == Keys.F10 && File.Exists(mp3Dir + "\\" + hotkey10)) playFile(mp3Dir + "\\" + hotkey10);
            if (e.Key == Keys.F11 && File.Exists(mp3Dir + "\\" + hotkey11)) playFile(mp3Dir + "\\" + hotkey11);
            if (e.Key == Keys.F12 && File.Exists(mp3Dir + "\\" + hotkey12)) playFile(mp3Dir + "\\" + hotkey12);
        }

        private void NotifyIcon1_Click(object sender, MouseEventArgs e)
        {
            tray = false;
            if (!trayIcon) notifyIcon1.Visible = false;

            this.Opacity = 0;
            this.Show();
            fadeIn(1);
        }
        
        private void btnHide_Click(object sender, EventArgs e)
        {
            tray = true;
            notifyIcon1.Visible = true;

            fadeOut(1);
            this.Hide();
        }

        private void menuTrayOpen_Click(object sender, EventArgs e)
        {
            if (tray)
            {
                tray = false;
                if (!trayIcon) notifyIcon1.Visible = false;

                this.Opacity = 0;
                this.Show();
                fadeIn(1);
            }
        }

        private void menuTrayClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelFolders_MouseEnter(object sender, EventArgs e)
        {
            panelFolders.Focus();
        }

        private void panelButtons_MouseEnter(object sender, EventArgs e)
        {
            panelButtons.Focus();
        }
        
        private void txtFilterFolder_Enter(object sender, EventArgs e)
        {
            txtFilterFolder.SelectAll();
        }

        private void txtFilterFile_Enter(object sender, EventArgs e)
        {
            txtFilterFile.SelectAll();
        }

        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            labelVolume.Text = trackBarVolume.Value.ToString() + "%";
            if (waveOutDevice != null) audioFileReader.Volume = (float)trackBarVolume.Value / 100;
        }

        private void trackBarVolume_MouseEnter(object sender, EventArgs e)
        {
            trackBarVolume.Focus();
        }

        private void trackBarVolume_MouseLeave(object sender, EventArgs e)
        {
            labelVolume.Focus();
        }

        private void pbPosition_MouseDown(object sender, MouseEventArgs e)
        {
            if (waveOutDevice != null)
            {

                int mouseX = e.Location.X + 2;
                if (mouseX < 0) mouseX = 0;
                if (mouseX > pbPosition.Width) mouseX = pbPosition.Width;

                double trackBarPercent = (((double)pbPosition.Value / (double)pbPosition.Maximum));
                double mousePercent = (((double)mouseX / ((double)pbPosition.Width)));

                pbPosition.Value = (int)(pbPosition.Maximum * mousePercent);
                audioFileReader.SetPosition((double)pbPosition.Value / 1000);
                if (!play)
                {
                    playpressed = true;
                    if (sendkeyPlay && !play && sendKeystrokes) SendKeys.Send(sendkeyPlayString);
                    playTrack();
                }
            }
        }





    } // class end
} // namespace end
