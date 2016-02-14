using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;

namespace PatkaPlayer
{
    public partial class frmSettings : Form
    {
        // storage for frmPlayer instance
        private readonly frmPlayer _frmPlayer;
        private string oldMp3Dir;
        private List<string> listMod = new List<string>();
        private bool txtChanged = false;
        private string txtOrig = "";
        Settings settings = new Settings();

        //[DllImport("user32.dll")]
        //static extern bool HideCaret(IntPtr hWnd);
        //HideCaret(txtSet1.Handle);

        // default constructor
        public frmSettings()
        {
            InitializeComponent();
        }

        // overloaded constructor
        public frmSettings(frmPlayer temp)
        {
            InitializeComponent();
            this._frmPlayer = temp;
            readConfig();
            this.oldMp3Dir = txtSetFolder.Text;
            if (temp.settingsPage == 1) this.tabControl1.SelectedTab = tabFolders;
            else if (temp.settingsPage == 2) this.tabControl1.SelectedTab = tabSettings;
            else if (temp.settingsPage == 3) this.tabControl1.SelectedTab = tabTimers;
            btnApply.Enabled = false;

        }

        // read values from config
        private void readConfig()
        {
            // folders
            txtSetFolder.Text = settings.LoadSetting("Mp3Dir");
            txtSet1.Text = settings.LoadSetting("Hotkey1");
            txtSet2.Text = settings.LoadSetting("Hotkey2");
            txtSet3.Text = settings.LoadSetting("Hotkey3");
            txtSet4.Text = settings.LoadSetting("Hotkey4");
            txtSet5.Text = settings.LoadSetting("Hotkey5");
            txtSet6.Text = settings.LoadSetting("Hotkey6");
            txtSet7.Text = settings.LoadSetting("Hotkey7");
            txtSet8.Text = settings.LoadSetting("Hotkey8");
            txtSet9.Text = settings.LoadSetting("Hotkey9");
            txtSet10.Text = settings.LoadSetting("Hotkey10");
            txtSet11.Text = settings.LoadSetting("Hotkey11");
            txtSet12.Text = settings.LoadSetting("Hotkey12");

            // timer 2 settings
            numericMinHour2.Value = Convert.ToInt32(settings.LoadSetting("Timer2MinHour"));
            numericMinMin2.Value = Convert.ToInt32(settings.LoadSetting("Timer2MinMin"));
            numericMinSec2.Value = Convert.ToInt32(settings.LoadSetting("Timer2MinSec"));
            numericMaxHour2.Value = Convert.ToInt32(settings.LoadSetting("Timer2MaxHour"));
            numericMaxMin2.Value = Convert.ToInt32(settings.LoadSetting("Timer2MaxMin"));
            numericMaxSec2.Value = Convert.ToInt32(settings.LoadSetting("Timer2MaxSec"));

            radioClipsAll2.Checked = Convert.ToBoolean(settings.LoadSetting("Timer2ClipsAll"));
            if (radioClipsAll2.Checked == false) radioClipsFilter2.Checked = true;

            // timer 1 settings
            numericMinHour1.Value = Convert.ToInt32(settings.LoadSetting("Timer1MinHour"));
            numericMinMin1.Value = Convert.ToInt32(settings.LoadSetting("Timer1MinMin"));
            numericMinSec1.Value = Convert.ToInt32(settings.LoadSetting("Timer1MinSec"));
            numericMaxHour1.Value = Convert.ToInt32(settings.LoadSetting("Timer1MaxHour"));
            numericMaxMin1.Value = Convert.ToInt32(settings.LoadSetting("Timer1MaxMin"));
            numericMaxSec1.Value = Convert.ToInt32(settings.LoadSetting("Timer1MaxSec"));

            radioClipsAll1.Checked = Convert.ToBoolean(settings.LoadSetting("Timer1ClipsAll"));
            if (radioClipsAll1.Checked == false) radioClipsFilter1.Checked = true;

            // log
            checkLog.Checked = Convert.ToBoolean(settings.LoadSetting("Logging"));
            checkDaily.Checked = Convert.ToBoolean(settings.LoadSetting("RememberDaily"));

            // tray
            checkTrayIcon.Checked = Convert.ToBoolean(settings.LoadSetting("TrayIcon"));
            checkBalloonPlay.Checked = Convert.ToBoolean(settings.LoadSetting("BalloonPlay"));
            checkBalloonTimer.Checked = Convert.ToBoolean(settings.LoadSetting("BalloonTimer"));
            
            // misc
            numericTransparency.Value = Convert.ToDecimal(settings.LoadSetting("Transparency") ?? "1");
            comboLatency.Text = settings.LoadSetting("Latency");
            if (comboLatency.Text == "") comboLatency.Text = "200";

            checkScrollLock.Checked = Convert.ToBoolean(settings.LoadSetting("ScrollLock"));

            // hotkeys
            txtPlayPreMod.Text = settings.LoadSetting("HotkeyPlayPreMod");
            txtRandomMod.Text = settings.LoadSetting("HotkeyRandomMod");
            txtRandomKey.Text = settings.LoadSetting("HotkeyRandomKey");
            txtStopMod.Text = settings.LoadSetting("HotkeyStopMod");
            txtStopKey.Text = settings.LoadSetting("HotkeyStopKey");
            txtReplayMod.Text = settings.LoadSetting("HotkeyReplayMod");
            txtReplayKey.Text = settings.LoadSetting("HotkeyReplayKey");
            txtTimer1Mod.Text = settings.LoadSetting("HotkeyTimer1Mod");
            txtTimer1Key.Text = settings.LoadSetting("HotkeyTimer1Key");
            txtTimer2Mod.Text = settings.LoadSetting("HotkeyTimer2Mod");
            txtTimer2Key.Text = settings.LoadSetting("HotkeyTimer2Key");
            txtStopTimerMod.Text = settings.LoadSetting("HotkeyStopTimerMod");
            txtStopTimerKey.Text = settings.LoadSetting("HotkeyStopTimerKey");
            checkGlobalKeyWarning.Checked = Convert.ToBoolean(settings.LoadSetting("HotkeyWarning"));

            // send keys
            txtKeystrokePlayMod.Text = settings.LoadSetting("SendkeyPlayMod");
            txtKeystrokePlayKey.Text = settings.LoadSetting("SendkeyPlayKey");
            txtKeystrokeStopMod.Text = settings.LoadSetting("SendkeyStopMod");
            txtKeystrokeStopKey.Text = settings.LoadSetting("SendkeyStopKey");
            checkSendKeystrokes.Checked = Convert.ToBoolean(settings.LoadSetting("SendKeystrokes"));
        }

        // save config file
        private void saveConfig()
        {
            // folders
            settings.SaveSetting("Mp3Dir", txtSetFolder.Text);
            settings.SaveSetting("Hotkey1", txtSet1.Text);
            settings.SaveSetting("Hotkey2", txtSet2.Text);
            settings.SaveSetting("Hotkey3", txtSet3.Text);
            settings.SaveSetting("Hotkey4", txtSet4.Text);
            settings.SaveSetting("Hotkey5", txtSet5.Text);
            settings.SaveSetting("Hotkey6", txtSet6.Text);
            settings.SaveSetting("Hotkey7", txtSet7.Text);
            settings.SaveSetting("Hotkey8", txtSet8.Text);
            settings.SaveSetting("Hotkey9", txtSet9.Text);
            settings.SaveSetting("Hotkey10", txtSet10.Text);
            settings.SaveSetting("Hotkey11", txtSet11.Text);
            settings.SaveSetting("Hotkey12", txtSet12.Text);

            // timer 1 settings
            settings.SaveSetting("Timer1MinHour", numericMinHour1.Value.ToString());
            settings.SaveSetting("Timer1MinMin", numericMinMin1.Value.ToString());
            settings.SaveSetting("Timer1MinSec", numericMinSec1.Value.ToString());
            settings.SaveSetting("Timer1MaxHour", numericMaxHour1.Value.ToString());
            settings.SaveSetting("Timer1MaxMin", numericMaxMin1.Value.ToString());
            settings.SaveSetting("Timer1MaxSec", numericMaxSec1.Value.ToString());
            settings.SaveSetting("Timer1ClipsAll", radioClipsAll1.Checked.ToString());

            // timer 2 settings
            settings.SaveSetting("Timer2MinHour", numericMinHour2.Value.ToString());
            settings.SaveSetting("Timer2MinMin", numericMinMin2.Value.ToString());
            settings.SaveSetting("Timer2MinSec", numericMinSec2.Value.ToString());
            settings.SaveSetting("Timer2MaxHour", numericMaxHour2.Value.ToString());
            settings.SaveSetting("Timer2MaxMin", numericMaxMin2.Value.ToString());
            settings.SaveSetting("Timer2MaxSec", numericMaxSec2.Value.ToString());
            settings.SaveSetting("Timer2ClipsAll", radioClipsAll2.Checked.ToString());

            // log
            settings.SaveSetting("Logging", checkLog.Checked.ToString());
            settings.SaveSetting("RememberDaily", checkDaily.Checked.ToString());

            // tray
            settings.SaveSetting("TrayIcon", checkTrayIcon.Checked.ToString());
            settings.SaveSetting("BalloonPlay", checkBalloonPlay.Checked.ToString());
            settings.SaveSetting("BalloonTimer", checkBalloonTimer.Checked.ToString());

            // misc
            settings.SaveSetting("Transparency", numericTransparency.Value.ToString());
            settings.SaveSetting("Latency", comboLatency.Text);
            settings.SaveSetting("ScrollLock", checkScrollLock.Checked.ToString());

            // hotkeys
            settings.SaveSetting("HotkeyPlayPreMod", txtPlayPreMod.Text);
            settings.SaveSetting("HotkeyRandomMod", txtRandomMod.Text);
            settings.SaveSetting("HotkeyRandomKey", txtRandomKey.Text);
            settings.SaveSetting("HotkeyStopMod", txtStopMod.Text);
            settings.SaveSetting("HotkeyStopKey", txtStopKey.Text);
            settings.SaveSetting("HotkeyReplayMod", txtReplayMod.Text);
            settings.SaveSetting("HotkeyReplayKey", txtReplayKey.Text);
            settings.SaveSetting("HotkeyTimer1Mod", txtTimer1Mod.Text);
            settings.SaveSetting("HotkeyTimer1Key", txtTimer1Key.Text);
            settings.SaveSetting("HotkeyTimer2Mod", txtTimer2Mod.Text);
            settings.SaveSetting("HotkeyTimer2Key", txtTimer2Key.Text);
            settings.SaveSetting("HotkeyStopTimerMod", txtStopTimerMod.Text);
            settings.SaveSetting("HotkeyStopTimerKey", txtStopTimerKey.Text);
            settings.SaveSetting("HotkeyWarning", checkGlobalKeyWarning.Checked.ToString());

            // send keys
            settings.SaveSetting("SendkeyPlayMod", txtKeystrokePlayMod.Text);
            settings.SaveSetting("SendkeyPlayKey", txtKeystrokePlayKey.Text);
            settings.SaveSetting("SendkeyStopMod", txtKeystrokeStopMod.Text);
            settings.SaveSetting("SendkeyStopKey", txtKeystrokeStopKey.Text);
            settings.SaveSetting("SendKeystrokes", checkSendKeystrokes.Checked.ToString());
        }

        // OK button, saves config and reloads frmPlayer
        private void btnSetOk_Click(object sender, EventArgs e)
        {
            int minTime1 = Convert.ToInt32((numericMinHour1.Value * 60 * 60) + (numericMinMin1.Value * 60) + numericMinSec1.Value);
            int maxTime1 = Convert.ToInt32((numericMaxHour1.Value * 60 * 60) + (numericMaxMin1.Value * 60) + numericMaxSec1.Value);
  
            int minTime2 = Convert.ToInt32((numericMinHour2.Value * 60 * 60) + (numericMinMin2.Value * 60) + numericMinSec2.Value);
            int maxTime2 = Convert.ToInt32((numericMaxHour2.Value * 60 * 60) + (numericMaxMin2.Value * 60) + numericMaxSec2.Value);

            if (minTime1 > maxTime1 || minTime2 > maxTime2) MessageBox.Show("Minimum delays for timer cannot be larger than maximum delays.", "Timer error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                saveConfig();
                if (this.oldMp3Dir != txtSetFolder.Text) this._frmPlayer.InsertPanelButtons();
                else this._frmPlayer.ReadSettings();
                this.Close();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int minTime1 = Convert.ToInt32((numericMinHour1.Value * 60 * 60) + (numericMinMin1.Value * 60) + numericMinSec1.Value);
            int maxTime1 = Convert.ToInt32((numericMaxHour1.Value * 60 * 60) + (numericMaxMin1.Value * 60) + numericMaxSec1.Value);

            int minTime2 = Convert.ToInt32((numericMinHour2.Value * 60 * 60) + (numericMinMin2.Value * 60) + numericMinSec2.Value);
            int maxTime2 = Convert.ToInt32((numericMaxHour2.Value * 60 * 60) + (numericMaxMin2.Value * 60) + numericMaxSec2.Value);

            if (minTime1 > maxTime1 || minTime2 > maxTime2) MessageBox.Show("Minimum delays for timer cannot be larger than maximum delays.", "Timer error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                saveConfig();
                if (this.oldMp3Dir != txtSetFolder.Text) this._frmPlayer.InsertPanelButtons();
                else this._frmPlayer.ReadSettings();
                btnApply.Enabled = false;
            }
        }

        // Cancel button, closes settings dialog
        private void btnSetCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // set folder button
        private void btnSetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (Directory.Exists(txtSetFolder.Text)) folder.SelectedPath = txtSetFolder.Text;
            folder.Description = "\nSelect root folder for MP3 files";
            folder.ShowNewFolderButton = false;
            //folder.RootFolder = Environment.SpecialFolder.MyComputer;

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtSetFolder.Text = folder.SelectedPath;
        }

        // dialog for choosing mp3 to hotkey
        private string setHotkeyFile()
        {
            if (Directory.Exists(txtSetFolder.Text))
            {
                OpenFileDialog file = new OpenFileDialog();
                file.InitialDirectory = txtSetFolder.Text;
                file.Filter = "MP3 files|*.mp3";

                DialogResult result = file.ShowDialog();

                if (file.FileName.Replace("/", "\\").IndexOf(txtSetFolder.Text.Replace("/", "\\") + "\\") != -1)
                {
                    return file.FileName.Replace(txtSetFolder.Text + "\\", "");
                }
                else if (file.FileName != "")
                {
                    MessageBox.Show("Clip must be selected inside audio folder.\n\nAudio Folder:\n" + txtSetFolder.Text + "\n\nFile you tried to select:\n" + file.FileName, "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return "";
                }
                else return "";
            }
            else return "";
        }

        private void valueChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void btnSet1_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet1.Text = file;
        }

        private void btnSet2_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet2.Text = file;
        }

        private void btnSet3_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet3.Text = file;
        }

        private void btnSet4_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet4.Text = file;
        }

        private void btnSet5_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet5.Text = file;
        }

        private void btnSet6_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet6.Text = file;
        }

        private void btnSet7_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet7.Text = file;
        }

        private void btnSet8_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet8.Text = file;
        }

        private void btnSet9_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet9.Text = file;
        }

        private void btnSet10_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet10.Text = file;
        }

        private void btnSet11_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet11.Text = file;
        }
        
        private void btnSet12_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet12.Text = file;
        }

        private void btnErase1_Click(object sender, EventArgs e)
        {
            txtSet1.Text = "";
        }

        private void btnErase2_Click(object sender, EventArgs e)
        {
            txtSet2.Text = "";
        }

        private void btnErase3_Click(object sender, EventArgs e)
        {
            txtSet3.Text = "";
        }

        private void btnErase4_Click(object sender, EventArgs e)
        {
            txtSet4.Text = "";
        }

        private void btnErase5_Click(object sender, EventArgs e)
        {
            txtSet5.Text = "";
        }

        private void btnErase6_Click(object sender, EventArgs e)
        {
            txtSet6.Text = "";
        }

        private void btnErase7_Click(object sender, EventArgs e)
        {
            txtSet7.Text = "";
        }

        private void btnErase8_Click(object sender, EventArgs e)
        {
            txtSet8.Text = "";
        }

        private void btnErase9_Click(object sender, EventArgs e)
        {
            txtSet9.Text = "";
        }

        private void btnErase0_Click(object sender, EventArgs e)
        {
            txtSet10.Text = "";
        }

        private void btnErase10_Click(object sender, EventArgs e)
        {
            txtSet10.Text = "";
        }

        private void btnErase11_Click(object sender, EventArgs e)
        {
            txtSet11.Text = "";
        }

        private void btnErase12_Click(object sender, EventArgs e)
        {
            txtSet12.Text = "";
        }

        private void numericLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void txtKey_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            txtChanged = false;
            txtOrig = textBox.Text;
            textBox.Text = "";
            listMod.Clear();
            textBox.BackColor = ColorTranslator.FromHtml("#b2d0ef");
            textBox.Tag = null;
        }

        private void txtKey_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = SystemColors.Window;
            if (!txtChanged) textBox.Text = txtOrig;
            else if (textBox.Text != txtOrig) btnApply.Enabled = true;
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txtKey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (
                e.KeyCode != Keys.Menu &&
                e.KeyCode != Keys.ShiftKey &&
                e.KeyCode != Keys.ControlKey &&
                e.KeyCode != Keys.LWin &&
                e.KeyCode != Keys.RWin &&
                e.KeyCode != Keys.F1 &&
                e.KeyCode != Keys.F2 &&
                e.KeyCode != Keys.F3 &&
                e.KeyCode != Keys.F4 &&
                e.KeyCode != Keys.F5 &&
                e.KeyCode != Keys.F6 &&
                e.KeyCode != Keys.F7 &&
                e.KeyCode != Keys.F8 &&
                e.KeyCode != Keys.F9 &&
                e.KeyCode != Keys.F10 &&
                e.KeyCode != Keys.F11 &&
                e.KeyCode != Keys.F12 &&
                e.KeyCode.ToString() != txtRandomKey.Text &&
                e.KeyCode.ToString() != txtReplayKey.Text &&
                e.KeyCode.ToString() != txtStopKey.Text &&
                e.KeyCode.ToString() != txtTimer1Key.Text &&
                e.KeyCode.ToString() != txtTimer2Key.Text &&
                e.KeyCode.ToString() != txtStopTimerKey.Text
                )
            {
                txtChanged = true;
                textBox.Text = e.KeyCode.ToString();
                txtVersion.Focus();
            }
        }

        private void txtSendKey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (
                e.KeyCode != Keys.Menu &&
                e.KeyCode != Keys.ShiftKey &&
                e.KeyCode != Keys.ControlKey &&
                e.KeyCode != Keys.LWin &&
                e.KeyCode != Keys.RWin &&
                e.KeyCode != Keys.F1 &&
                e.KeyCode != Keys.F2 &&
                e.KeyCode != Keys.F3 &&
                e.KeyCode != Keys.F4 &&
                e.KeyCode != Keys.F5 &&
                e.KeyCode != Keys.F6 &&
                e.KeyCode != Keys.F7 &&
                e.KeyCode != Keys.F8 &&
                e.KeyCode != Keys.F9 &&
                e.KeyCode != Keys.F10 &&
                e.KeyCode != Keys.F11 &&
                e.KeyCode != Keys.F12 &&
                char.IsLetterOrDigit((char)e.KeyCode) &&
                e.KeyCode.ToString().IndexOf("Oem") == -1 &&
                e.KeyCode.ToString().IndexOf("NumPad") == -1
                )
            {
                txtChanged = true;
                textBox.Text = e.KeyCode.ToString();
                txtVersion.Focus();
            }
        }

        private void txtMod_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Menu || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin || e.KeyCode == Keys.Escape)
            {
                txtChanged = true;
                string key = "";
                switch (e.KeyCode)
                {
                    case Keys.Menu:
                        key = "Alt";
                        break;
                    case Keys.ShiftKey:
                        key = "Shift";
                        break;
                    case Keys.ControlKey:
                        key = "Ctrl";
                        break;
                    case Keys.LWin:
                        key = "Win";
                        break;
                    case Keys.RWin:
                        key = "Win";
                        break;
                    case Keys.Escape:
                        key = "";
                        break;
                }

                if (!listMod.Contains(key)) listMod.Add(key);
                listMod.Sort();

                textBox.Text = "";
                for (int i = 0; i < listMod.Count; i++)
                {
                    if (i > 0) textBox.Text += "+" + listMod[i];
                    else textBox.Text = listMod[i];
                }
            }
        }

        private void txtSendMod_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Menu || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
            {
                txtChanged = true;
                string key = "";
                switch (e.KeyCode)
                {
                    case Keys.Menu:
                        key = "Alt";
                        break;
                    case Keys.ShiftKey:
                        key = "Shift";
                        break;
                    case Keys.ControlKey:
                        key = "Ctrl";
                        break;
                }

                if (!listMod.Contains(key)) listMod.Add(key);
                listMod.Sort();

                textBox.Text = "";
                for (int i = 0; i < listMod.Count; i++)
                {
                    if (i > 0) textBox.Text += "+" + listMod[i];
                    else textBox.Text = listMod[i];
                }
            }
        }

        private void txtMod_KeyUp(object sender, KeyEventArgs e)
        {
            listMod.Clear();
            if (txtChanged) txtVersion.Focus();
        }

        private void txtKey_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Tag != null)
            {
                textBox.Text = txtOrig;
                txtVersion.Focus();
            }
            textBox.Tag = "clicked";
        }

        private void txtKey_DoubleClick(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";
            txtOrig = "";
            txtChanged = true;
            txtVersion.Focus();
        }

    } // class end
} // namespace end
