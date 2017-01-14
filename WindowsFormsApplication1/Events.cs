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

namespace PatkaPlayer
{
    public partial class frmPlayer
    {
        private void menuCenter_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.FromPoint(Cursor.Position);
            this.Left = screen.WorkingArea.Left + (screen.Bounds.Size.Width / 2 - this.Width / 2);
            this.Top = screen.WorkingArea.Top + (screen.Bounds.Size.Height / 2 - this.Height / 2);
        }

        private void labelLastPlayed_Click(object sender, EventArgs e)
        {
            labelLastPlayed.Text = "-";
            btnReplay.Tag = "";
            btnReplay.Enabled = false;
        }

        private void menuTimer1_Click(object sender, EventArgs e)
        {
            startTimer1();
        }

        private void menuTimer2_Click(object sender, EventArgs e)
        {
            startTimer2();
        }

        private void labelTimer1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) startTimer1();
            if (e.Button == MouseButtons.Right) menuTimers.PerformClick();
        }

        private void labelTimer2_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) startTimer2();
            if (e.Button == MouseButtons.Right) menuTimers.PerformClick();
        }

        
        private void labelSendKeystrokes_MouseUp(object sender, MouseEventArgs e)
        {
            if (sendKeystrokes) 
            {
                labelSendKeystrokes.Text = "Send Keystrokes: off";
                sendKeystrokes = false;
            }
            else
            {
                labelSendKeystrokes.Text = "Send Keystrokes: on";
                sendKeystrokes = true;
            }
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!volumeJustSet) getVol();

            if (waveOutDevice != null)
            {
                pbPosition.Maximum = Convert.ToInt32(audioFileReader.TotalTime.TotalMilliseconds);
                pbPosition.Value = Convert.ToInt32(audioFileReader.CurrentTime.TotalMilliseconds);

                double percentage = ((double)pbPosition.Value / (double)pbPosition.Maximum) * 100;
                sendPosition((int)percentage);

                if (waveOutDevice.PlaybackState == NAudio.Wave.PlaybackState.Stopped)
                {
                    this.Text = "Pätkä Player";
                    taskbar.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
                    pbPosition.ProgressText = "";
                    if (scrollLock) SetScrollLockKeyAndScreamerRadioMute(false);
                }
                else
                {
                    taskbar.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
                    taskbar.SetProgressValue(Convert.ToInt32(audioFileReader.CurrentTime.TotalMilliseconds), Convert.ToInt32(audioFileReader.TotalTime.TotalMilliseconds));
                    pbPosition.ProgressText = audioFileReader.CurrentTime.ToString(@"mm\:ss\.ff") + " / " + audioFileReader.TotalTime.ToString(@"mm\:ss\.ff");
                    if (scrollLock) SetScrollLockKeyAndScreamerRadioMute(true);
                }

            }
        }

        private void frmPlayer_Shown(object sender, EventArgs e)
        {
            labelVolume.Focus();
        }

        private void frmPlayer_Load(object sender, EventArgs e)
        {
            resizeColumns();

            string volume = settings.LoadSetting("Volume");
            if (volume == null) volume = "100";
            int intVolume = Convert.ToInt32(volume);
            vol.Value = intVolume;
            setVol();

            string port = settings.LoadSetting("Port");
            if (port == null) port = "-";
            if (comboPort.Items.Contains(port)) comboPort.Text = port;

            string random = settings.LoadSetting("Random");
            if (random == null) random = "folder";
            if (random == "folder") btnFolder.PerformClick();
            else if (random == "file") btnFile.PerformClick();
            else if (random == "playlist") btnPlaylist.PerformClick();

            listLoad("autosave.lst");
            timer.Start();
        }

        private void frmPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scrollLock) SetScrollLockKeyAndScreamerRadioMute(false);

            settings.SaveSetting("Volume", vol.Value.ToString());
            settings.SaveSetting("Port", comboPort.Text);
            settings.SaveSetting("Random", randomTarget);

            listSave("autosave.lst");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = randomTime(timer1MinHour, timer1MinMin, timer1MinSec, timer1MaxHour, timer1MaxMin, timer1MaxSec);
            //if (timer1ClipsAll) playRandomAll();
            //else playRandom();
            playRandom();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = randomTime(timer2MinHour, timer2MinMin, timer2MinSec, timer2MaxHour, timer2MaxMin, timer2MaxSec);
            //if (timer2ClipsAll) playRandomAll();
            //else playRandom();
            playRandom();
        }

        private void btnDropdown_Click(object sender, EventArgs e)
        {
            Rectangle rect = this.btnDropdown.Bounds;
            Point pt = new Point(rect.Left - 106, rect.Bottom + 4);
            contextMenu1.Show(toolStripSettings, pt);
        }

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

        private void menuTimers_Click(object sender, EventArgs e)
        {
            settingsPage = 3;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        private void menuHotkeys_Click(object sender, EventArgs e)
        {
            settingsPage = 4;
            frmSettings settingsForm = new frmSettings(this);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        private void menuReload_Click(object sender, EventArgs e)
        {
            InsertPanelButtons();
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            string fileToPlay = btnReplay.Tag.ToString();
            if (fileToPlay != "nofile") playFile(fileToPlay);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            randompressed = true;
            playRandom();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            randomTarget = "folder";
            btnFolder.Checked = true;
            btnFile.Checked = false;
            btnPlaylist.Checked = false;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            randomTarget = "file";
            btnFolder.Checked = false;
            btnFile.Checked = true;
            btnPlaylist.Checked = false;
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            randomTarget = "playlist";
            btnFolder.Checked = false;
            btnFile.Checked = false;
            btnPlaylist.Checked = true;
        }

        private void Form1_KeyEvent(object sender, KeyEventArgs e)
        {
            //if (txtFilterFolder.Selected == true || txtFilterFile.Selected == true) return;
            /*
            if (txtFilterFolder.Focused == true || txtFilterFile.Focused == true) return;

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
            */
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            playpressed = false;
            randompressed = false;
            stopTrack();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            buttonLocations();
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            buttonLocations();
            resizeColumns();
        }

        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
        }

        private void timerKeyDown_Tick(object sender, EventArgs e)
        {
            timerKeyDown.Stop();
            keyDown = false;
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

        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            //labelVolume.Text = trackBarVolume.Value.ToString() + "%";
            //if (waveOutDevice != null) audioFileReader.Volume = (float)trackBarVolume.Value / 100;
        }

        private void trackBarVolume_MouseEnter(object sender, EventArgs e)
        {
            //trackBarVolume.Focus();
        }

        private void trackBarVolume_MouseLeave(object sender, EventArgs e)
        {
            //labelVolume.Focus();
        }

        private void pbPosition_MouseDown(object sender, MouseEventArgs e)
        {
            if (waveOutDevice != null)
            {

                int mouseX = e.Location.X + 2;
                if (mouseX < 0) mouseX = 0;
                //if (mouseX > pbPosition.Width) mouseX = pbPosition.Width;
                if (mouseX > pbPosition.Width - 7) mouseX = pbPosition.Width - 7;

                double trackBarPercent = (((double)pbPosition.Value / (double)pbPosition.Maximum));
                double mousePercent = (((double)mouseX / ((double)pbPosition.Width)));

                pbPosition.Value = (int)(pbPosition.Maximum * mousePercent);
                audioFileReader.SetPosition((double)pbPosition.Value / 1000);

                if (!play)
                {
                    playpressed = true;
                    if (!play && sendMessages) sendMessagePause();

                    playTrack();
                }
            }
        }

        private void pbPosition_MouseMove(object sender, MouseEventArgs e)
        {
            if (waveOutDevice != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int mouseX = e.Location.X + 2;
                    if (mouseX < 0) mouseX = 0;
                    if (mouseX > pbPosition.Width - 7) mouseX = pbPosition.Width - 7;

                    double trackBarPercent = (((double)pbPosition.Value / (double)pbPosition.Maximum));
                    double mousePercent = (((double)mouseX / ((double)pbPosition.Width)));

                    pbPosition.Value = (int)(pbPosition.Maximum * mousePercent);
                    audioFileReader.SetPosition((double)pbPosition.Value / 1000);

                    if (!play)
                    {
                        playpressed = true;
                        if (!play && sendMessages) sendMessagePause();

                        playTrack();
                        
                    }
                }
            }
        }

        private void comboLatency_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Focus();

            int comboLatencyInt;
            
            try
            {
                comboLatencyInt = Convert.ToInt32(comboLatency.Text);
            }
            catch
            {
                comboLatencyInt = latency;
            }

            latency = comboLatencyInt;

            closeTrack();
            if (btnReplay.Tag.ToString() != "") loadTrack(btnReplay.Tag.ToString(), latency * 2);
        }

        private void timerWriteTime_Tick(object sender, EventArgs e)
        {
            string originalPath = Application.ExecutablePath;
            string pathname = Path.GetDirectoryName(originalPath);
            string customPath = pathname + "\\" + "dummy.log";

            string dummy = DateTime.Now.ToString("dd.MM.yyyy|HH:mm:ss");
            using (StreamWriter file = new StreamWriter(@customPath, true, System.Text.Encoding.Default))
            {
                file.WriteLine(dummy);
            }

        }


    }
}
