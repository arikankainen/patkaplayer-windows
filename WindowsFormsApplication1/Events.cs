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

        // main timer, updates statusbar and button locations
        private void timer_Tick(object sender, EventArgs e)
        {
            //labelTest.Text = DateTime.Now.ToString("HH:mm:ss");
            //buttonLocations();
        }

        // temp timer for setting focus off from buttons at load
        private void timerTemp_Tick(object sender, EventArgs e)
        {
            label1.Focus();
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
            Point pt = new Point(rect.Left - 107, rect.Bottom + 3);
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
                filterFile = txtFilterFile.Text;
                txtFilterFolder.Text = "";
                filterFolder = "";
                addPanel();
                Button button = this.Controls.Find("SoundButton1", true).FirstOrDefault() as Button;
                this.ActiveControl = button;
            }
            else
            {
                /*
                for (int i = 0; i <= array1.Length -1; i++)
                {
                    Application.DoEvents();
                    Button button = this.Controls.Find("SoundButton" + (i + 1).ToString(), true).FirstOrDefault() as Button;
                    if (array1[i].IndexOf(txtFilterFile.Text, StringComparison.OrdinalIgnoreCase) == -1) button.Visible = false;
                    else button.Visible = true;
                }
                */
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
            frmHelp helpForm = new frmHelp();
            helpForm.ShowDialog();
            helpForm.Dispose();
        }


        /*
        // keypress event, hotkeys
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFilterFolder.Selected == true || txtFilterFile.Selected == true) return;

            if (e.KeyChar == 120 || e.KeyChar == 88 || e.KeyChar == (char)Keys.Back) btnRandom.PerformClick(); // play random = x, X, backspace
            if (e.KeyChar == 114 || e.KeyChar == 82) btnReplay.PerformClick(); // replay = r, R
            if (e.KeyChar == 115 || e.KeyChar == 83) btnStop.PerformClick(); // stop = s, S

            if (e.KeyChar == 49 && File.Exists(mp3Dir + "\\" + hotkey1)) playFile(mp3Dir + "\\" + hotkey1); // 1
            if (e.KeyChar == 50 && File.Exists(mp3Dir + "\\" + hotkey2)) playFile(mp3Dir + "\\" + hotkey2); // 2
            if (e.KeyChar == 51 && File.Exists(mp3Dir + "\\" + hotkey3)) playFile(mp3Dir + "\\" + hotkey3); // 3
            if (e.KeyChar == 52 && File.Exists(mp3Dir + "\\" + hotkey4)) playFile(mp3Dir + "\\" + hotkey4); // 4
            if (e.KeyChar == 53 && File.Exists(mp3Dir + "\\" + hotkey5)) playFile(mp3Dir + "\\" + hotkey5); // 5
            if (e.KeyChar == 54 && File.Exists(mp3Dir + "\\" + hotkey6)) playFile(mp3Dir + "\\" + hotkey6); // 6
            if (e.KeyChar == 55 && File.Exists(mp3Dir + "\\" + hotkey7)) playFile(mp3Dir + "\\" + hotkey7); // 7
            if (e.KeyChar == 56 && File.Exists(mp3Dir + "\\" + hotkey8)) playFile(mp3Dir + "\\" + hotkey8); // 8
            if (e.KeyChar == 57 && File.Exists(mp3Dir + "\\" + hotkey9)) playFile(mp3Dir + "\\" + hotkey9); // 9
            if (e.KeyChar == 48 && File.Exists(mp3Dir + "\\" + hotkey0)) playFile(mp3Dir + "\\" + hotkey0); // 0

            if (e.KeyChar == 44 && File.Exists(mp3Dir + "\\" + hotkey1)) playFile(mp3Dir + "\\" + hotkey1); // ,
            if (e.KeyChar == 97 && File.Exists(mp3Dir + "\\" + hotkey2)) playFile(mp3Dir + "\\" + hotkey2); // a
            if (e.KeyChar == 100 && File.Exists(mp3Dir + "\\" + hotkey3)) playFile(mp3Dir + "\\" + hotkey3); // d
            if (e.KeyChar == 103 && File.Exists(mp3Dir + "\\" + hotkey4)) playFile(mp3Dir + "\\" + hotkey4); // g
            if (e.KeyChar == 106 && File.Exists(mp3Dir + "\\" + hotkey5)) playFile(mp3Dir + "\\" + hotkey5); // j
            if (e.KeyChar == 109 && File.Exists(mp3Dir + "\\" + hotkey6)) playFile(mp3Dir + "\\" + hotkey6); // m
            if (e.KeyChar == 112 && File.Exists(mp3Dir + "\\" + hotkey7)) playFile(mp3Dir + "\\" + hotkey7); // p
            if (e.KeyChar == 116 && File.Exists(mp3Dir + "\\" + hotkey8)) playFile(mp3Dir + "\\" + hotkey8); // t
            if (e.KeyChar == 119 && File.Exists(mp3Dir + "\\" + hotkey9)) playFile(mp3Dir + "\\" + hotkey9); // w
            if (e.KeyChar == 32 && File.Exists(mp3Dir + "\\" + hotkey0)) playFile(mp3Dir + "\\" + hotkey0); // space
        }
        */

        // keyup event, hotkeys
        private void Form1_KeyEvent(object sender, KeyEventArgs e)
        {
            if (txtFilterFolder.Selected == true || txtFilterFile.Selected == true) return;

            if (e.KeyCode == Keys.Space) btnRandom.PerformClick();
            if (e.KeyCode == Keys.R) btnReplay.PerformClick();
            if (e.KeyCode == Keys.S) btnStop.PerformClick();

            if (e.KeyCode == Keys.D1 && !timer1Started) startTimer1();
            if (e.KeyCode == Keys.D2 && !timer2Started) startTimer2();
            if (e.KeyCode == Keys.D3 && timer1Started) startTimer1();
            else if (e.KeyCode == Keys.D3 && timer2Started) startTimer2();

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
            if (_mp3Player != null) _mp3Player.Stop();
        }

        // sound button click
        private void SoundButton_Click(object sender, EventArgs e)
        {
            label1.Focus();
            Button temp = (Button)sender;
            string fileToPlay = temp.Tag.ToString();
            playFile(fileToPlay);
        }

        // sound button mouse enter
        private void SoundButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackHover;
        }

        // sound button mouse leave
        private void SoundButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBack;
        }

        // sound button mouse down
        private void SoundButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackPress;
        }

        // sound button mouse up
        private void SoundButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = buttonBackHover;

            if (e.Button == MouseButtons.Left)
            {
                label1.Focus();
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

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConfigurationManager.RefreshSection("appSettings");
            
            config.AppSettings.Settings.Remove("hotkey_" + hotkey);
            config.AppSettings.Settings.Add("hotkey_" + hotkey, clip);

            try
            {
                config.AppSettings.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
            }
            catch
            {
                MessageBox.Show("Can't save config, write access denied.", "Error Saving Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ReadSettings();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //MessageBox.Show(e.Modifier.ToString() + " + " + e.Key.ToString());

            if (e.Key == Keys.Space) btnRandom.PerformClick();
            if (e.Key == Keys.R) btnReplay.PerformClick();
            if (e.Key == Keys.S) btnStop.PerformClick();

            if (e.Key == Keys.D1 && !timer1Started) startTimer1();
            if (e.Key == Keys.D2 && !timer2Started) startTimer2();
            if (e.Key == Keys.D3 && timer1Started) startTimer1();
            else if (e.Key == Keys.D3 && timer2Started) startTimer2();

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



    } // class end
} // namespace end
