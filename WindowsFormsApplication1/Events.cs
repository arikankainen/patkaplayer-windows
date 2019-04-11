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
using System.Globalization;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;

namespace PatkaPlayer
{
    public partial class frmPlayer
    {
        private void btnFolderFilterClear_Click(object sender, EventArgs e)
        {
            txtFolderFilter.Text = "";
        }

        private void btnFileFilterClear_Click(object sender, EventArgs e)
        {
            txtFileFilter.Text = "";
        }

        private void btnPlaylistFolderFilterClear_Click(object sender, EventArgs e)
        {
            txtPlaylistFolderFilter.Text = "";
        }

        private void btnPlaylistFileFilterClear_Click(object sender, EventArgs e)
        {
            txtPlaylistFileFilter.Text = "";
        }

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

        private int percentageOld;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!volumeJustSet) getVol();

            if (waveOutDevice != null && audioFileReader != null)
            {
                pbPosition.Maximum = Convert.ToInt32(audioFileReader.TotalTime.TotalMilliseconds);
                pbPosition.Value = Convert.ToInt32(audioFileReader.CurrentTime.TotalMilliseconds);

                double percentage = ((double)pbPosition.Value / (double)pbPosition.Maximum) * 100;
                sendPosition((int)percentage);
                //if ((int)percentage != percentageOld) sendWindowsMessage("<PP_PERCENT>" + ((int)percentage).ToString() + "</PP_PERCENT>");
                percentageOld = (int)percentage;

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
                    sendWindowsMessage("<pp_time>" + audioFileReader.CurrentTime.ToString(@"mm\:ss\.f") + "  " + audioFileReader.TotalTime.ToString(@"mm\:ss\.f") + "</pp_time>");

                    if (scrollLock) SetScrollLockKeyAndScreamerRadioMute(true);
                }

            }
        }

        private bool playOld;
        private void sendPosition(int pos)
        {
            if (play)
            {
                sendWindowsMessage("<pp_pos>" + pos.ToString() + "</pp_pos>");
                playOld = true;
            }

            else if (playOld)
            {
                sendWindowsMessage("<pp_pos>0</pp_pos>");
                playOld = false;
            }
        }

        private void frmPlayer_Shown(object sender, EventArgs e)
        {
            labelVolumePercent.Focus();
        }

        private void frmPlayer_Load(object sender, EventArgs e)
        {
            resizeColumns();

            vol.Value = settings.LoadSetting("Volume", "int", "100");
            setVol();

            randomTarget = settings.LoadSetting("Random", "string", "folder");

            if (randomTarget == "folder") radioFolders.Checked = true;
            else if (randomTarget == "file") radioFiles.Checked = true;
            else if (randomTarget == "playlist") radioPlaylist.Checked = true;

            this.Top = settings.LoadSetting("Top", "int", "0");
            this.Left = settings.LoadSetting("Left", "int", "0");
            this.Width = settings.LoadSetting("Width", "int", "1805");
            this.Height = settings.LoadSetting("Height", "int", "856");

            listLoad("autosave.lst");
            timer.Start();

            resizeColumns();
        }

        private void checkSpeech_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void lstFolders_Layout(object sender, LayoutEventArgs e)
        {
            if (!resizing)
            {
                lstFolders.BeginUpdate();
                clmFolder.Width = 0;
                clmFolderName.Width = lstFolders.ClientRectangle.Width;
                lstFolders.EndUpdate();
            }
        }

        private void lstFiles_Layout(object sender, LayoutEventArgs e)
        {
            if (!resizing)
            {
                lstFiles.BeginUpdate();
                clmFile.Width = 0;
                clmFileName.Width = lstFiles.ClientRectangle.Width;
                lstFiles.EndUpdate();
            }
        }

        private void lstPlaylist_Layout(object sender, LayoutEventArgs e)
        {
            if (!resizing)
            {
                lstPlaylist.BeginUpdate();
                clmPlaylist.Width = 0;
                clmPlaylistNum.Width = -1;
                clmPlaylistFolder.Width = -1;
                clmPlaylistFile.Width = -1;

                if (clmPlaylistNum.Width < 40) clmPlaylistNum.Width = 40;
                if (clmPlaylistFolder.Width < 100) clmPlaylistFolder.Width = 100;
                if (clmPlaylistFile.Width < 100) clmPlaylistFile.Width = 100;

                lstPlaylist.EndUpdate();
            }
        }

        private void frmPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;

            if (scrollLock) SetScrollLockKeyAndScreamerRadioMute(false);

            settings.SaveSetting("Volume", vol.Value.ToString());
            settings.SaveSetting("Random", randomTarget);

            if (this.WindowState == FormWindowState.Normal)
            {
                settings.SaveSetting("Top", this.Top.ToString());
                settings.SaveSetting("Left", this.Left.ToString());
                settings.SaveSetting("Width", this.Width.ToString());
                settings.SaveSetting("Height", this.Height.ToString());
            }

            listSave("autosave.lst");

            sendPosition(0);
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
            playRandom();
        }

        private void radioFolders_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFolders.Checked)
            {
                randomTarget = "folder";
                radioFiles.Checked = false;
                radioPlaylist.Checked = false;
            }
        }

        private void radioFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFiles.Checked)
            {
                randomTarget = "file";
                radioFolders.Checked = false;
                radioPlaylist.Checked = false;
            }
        }

        private void radioPlaylist_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPlaylist.Checked)
            {
                randomTarget = "playlist";
                radioFolders.Checked = false;
                radioFiles.Checked = false;
            }
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
            stopTrack();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            //buttonLocations();
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
        }

        private bool resizing = false;
        private void Form1_ResizeBegin(object sender, System.EventArgs e)
        {
            resizing = true;
        }

        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            resizing = false;

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            
            buttonLocations();
            lstFolders_Layout(null, null);
            lstFiles_Layout(null, null);
            lstPlaylist_Layout(null, null);
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
            try
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
            catch { }
        }

        private void pbPosition_MouseMove(object sender, MouseEventArgs e)
        {
            try
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
            catch { }
        }

        private void comboLatency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label1.Focus();

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
            try
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
            catch { }

        }


    }
}
