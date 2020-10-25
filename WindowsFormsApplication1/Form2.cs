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
        private string appPath = Application.ExecutablePath; // full path of exe
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath); // folder only
        private string appFile = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(Application.ExecutablePath)); // filename only, without extension

        public bool HotkeyExist(string key, bool editMode)
        {
            foreach (ListViewItem findItem in lstHotkeys.Items)
            {
                if (findItem.SubItems[1].Text == Hotkeys.ValueListToKeyList(key))
                {
                    if (editMode && !findItem.Selected) return true;
                    if (!editMode) return true;
                }
            }
            return false;
        }

        private string action;
        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        private string hotkey;
        public string Hotkey
        {
            get { return hotkey; }
            set { hotkey = value; }
        }

        private bool global;
        public bool Global
        {
            get { return global; }
            set { global = value; }
        }

        private readonly frmPlayer _frmPlayer;
        private string oldMp3Dir;
        private List<string> listMod = new List<string>();
        //private bool txtChanged = false;
        //private string txtOrig = "";
        private Settings settings = new Settings();

        public frmSettings()
        {
            InitializeComponent();
        }

        public frmSettings(frmPlayer temp)
        {
            InitializeComponent();
            _frmPlayer = temp;

            readConfig();

            oldMp3Dir = txtSetFolder.Text;

            if (temp.settingsPage == 1) this.tabControl1.SelectedTab = tabFolders;
            else if (temp.settingsPage == 2) this.tabControl1.SelectedTab = tabSettings;
            else if (temp.settingsPage == 3) this.tabControl1.SelectedTab = tabTimers;
            else if (temp.settingsPage == 4) this.tabControl1.SelectedTab = tabHotkeys;

            btnApply.Enabled = false;
        }

        private void readConfig()
        {
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
            txtSet13.Text = settings.LoadSetting("Hotkey13");
            txtSet14.Text = settings.LoadSetting("Hotkey14");
            txtSet15.Text = settings.LoadSetting("Hotkey15");

            numericMinHour1.Value = settings.LoadSetting("Timer1MinHour", "int", "0");
            numericMinMin1.Value = settings.LoadSetting("Timer1MinMin", "int", "1");
            numericMinSec1.Value = settings.LoadSetting("Timer1MinSec", "int", "0");
            numericMaxHour1.Value = settings.LoadSetting("Timer1MaxHour", "int", "0");
            numericMaxMin1.Value = settings.LoadSetting("Timer1MaxMin", "int", "2");
            numericMaxSec1.Value = settings.LoadSetting("Timer1MaxSec", "int", "0");

            numericMinHour2.Value = settings.LoadSetting("Timer2MinHour", "int", "0");
            numericMinMin2.Value = settings.LoadSetting("Timer2MinMin", "int", "1");
            numericMinSec2.Value = settings.LoadSetting("Timer2MinSec", "int", "0");
            numericMaxHour2.Value = settings.LoadSetting("Timer2MaxHour", "int", "0");
            numericMaxMin2.Value = settings.LoadSetting("Timer2MaxMin", "int", "2");
            numericMaxSec2.Value = settings.LoadSetting("Timer2MaxSec", "int", "0");

            checkLog.Checked = settings.LoadSetting("Logging", "bool", "false");
            checkDaily.Checked = settings.LoadSetting("RememberDaily", "bool", "true");

            checkTrayIcon.Checked = settings.LoadSetting("TrayIcon", "bool", "false");
            checkBalloonPlay.Checked = settings.LoadSetting("BalloonPlay", "bool", "false");
            checkBalloonTimer.Checked = settings.LoadSetting("BalloonTimer", "bool", "false");
            
            numericTransparency.Value = settings.LoadSetting("Transparency", "dec", "1");
            comboLatency.Text = settings.LoadSetting("Latency", "string", "100");

            //checkScrollLock.Checked = settings.LoadSetting("ScrollLock", "bool", "false");
            checkGlobalKeyWarning.Checked = settings.LoadSetting("HotkeyWarning", "bool", "true");

            try
            {
                lstHotkeys.Items.Clear();
                string file = Path.Combine(appDir, "hotkeys.cfg");

                using (StreamReader reader = File.OpenText(file))
                {
                    lstHotkeys.BeginUpdate();
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        List<string> list = line.Split('|').ToList<string>();

                        ListViewItem item = new ListViewItem(list[0]);

                        bool firstCol = true;
                        foreach (string column in list)
                        {
                            if (!firstCol) item.SubItems.Add(column);
                            firstCol = false;
                        }

                        lstHotkeys.Items.Add(item);

                    }
                    lstHotkeys.EndUpdate();
                }

            }

            catch { }

            resizeHotkeyColumns();
        }

        private void saveConfig()
        {
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
            settings.SaveSetting("Hotkey13", txtSet13.Text);
            settings.SaveSetting("Hotkey14", txtSet14.Text);
            settings.SaveSetting("Hotkey15", txtSet15.Text);

            settings.SaveSetting("Timer1MinHour", numericMinHour1.Value.ToString());
            settings.SaveSetting("Timer1MinMin", numericMinMin1.Value.ToString());
            settings.SaveSetting("Timer1MinSec", numericMinSec1.Value.ToString());
            settings.SaveSetting("Timer1MaxHour", numericMaxHour1.Value.ToString());
            settings.SaveSetting("Timer1MaxMin", numericMaxMin1.Value.ToString());
            settings.SaveSetting("Timer1MaxSec", numericMaxSec1.Value.ToString());

            settings.SaveSetting("Timer2MinHour", numericMinHour2.Value.ToString());
            settings.SaveSetting("Timer2MinMin", numericMinMin2.Value.ToString());
            settings.SaveSetting("Timer2MinSec", numericMinSec2.Value.ToString());
            settings.SaveSetting("Timer2MaxHour", numericMaxHour2.Value.ToString());
            settings.SaveSetting("Timer2MaxMin", numericMaxMin2.Value.ToString());
            settings.SaveSetting("Timer2MaxSec", numericMaxSec2.Value.ToString());

            settings.SaveSetting("Logging", checkLog.Checked.ToString());
            settings.SaveSetting("RememberDaily", checkDaily.Checked.ToString());

            settings.SaveSetting("TrayIcon", checkTrayIcon.Checked.ToString());
            settings.SaveSetting("BalloonPlay", checkBalloonPlay.Checked.ToString());
            settings.SaveSetting("BalloonTimer", checkBalloonTimer.Checked.ToString());

            settings.SaveSetting("Transparency", numericTransparency.Value.ToString());
            settings.SaveSetting("Latency", comboLatency.Text);
            //settings.SaveSetting("ScrollLock", checkScrollLock.Checked.ToString());

            settings.SaveSetting("HotkeyWarning", checkGlobalKeyWarning.Checked.ToString());

            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(appDir, "hotkeys.cfg")))
                {
                    if (lstHotkeys.Items.Count > 0)
                    {
                        foreach (ListViewItem item in lstHotkeys.Items)
                        {
                            bool firstRow = true;
                            string str = "";

                            foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                            {
                                if (firstRow) str = sub.Text;
                                else str += "|" + sub.Text;
                                firstRow = false;
                            }
                            sw.WriteLine(str);
                        }
                    }
                }
            }

            catch { }

        }

        private void btnSetOk_Click(object sender, EventArgs e)
        {
            checkSave();
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            checkSave();
            btnApply.Enabled = false;
        }

        private void checkSave()
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
            }
        }

        private void btnSetCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (Directory.Exists(txtSetFolder.Text)) folder.SelectedPath = txtSetFolder.Text;
            folder.Description = "\nSelect root folder for MP3 files";
            folder.ShowNewFolderButton = false;

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtSetFolder.Text = folder.SelectedPath;
        }

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

        private void btnSet13_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet13.Text = file;
        }

        private void btnSet14_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet14.Text = file;
        }

        private void btnSet15_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet15.Text = file;
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

        private void btnErase13_Click(object sender, EventArgs e)
        {
            txtSet13.Text = "";
        }

        private void btnErase14_Click(object sender, EventArgs e)
        {
            txtSet14.Text = "";
        }

        private void btnErase15_Click(object sender, EventArgs e)
        {
            txtSet15.Text = "";
        }

        private void numericLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void btnAddHotkey_Click(object sender, EventArgs e)
        {
            addHotkey();
        }

        private void btnEditHotkey_Click(object sender, EventArgs e)
        {
            editHotkey();
        }

        private void resizeHotkeyColumns()
        {
            lstHotkeys.BeginUpdate();
            clmAction.Width = 0;
            clmHotkey.Width = -1;
            clmGlobal.Width = -1;
            if (clmHotkey.Width < 60) clmHotkey.Width = 60;
            if (clmGlobal.Width < 60) clmGlobal.Width = 60;
            clmAction.Width = lstHotkeys.ClientRectangle.Width - clmHotkey.Width - clmGlobal.Width;
            lstHotkeys.EndUpdate();
        }

        private void btnRemoveHotkey_Click(object sender, EventArgs e)
        {
            if (lstHotkeys.SelectedItems.Count > 0)
            {
                int selected = lstHotkeys.SelectedItems[0].Index;

                lstHotkeys.Items[selected].Remove();

                if (lstHotkeys.Items.Count > selected) lstHotkeys.Items[selected].Selected = true;
                else if (lstHotkeys.Items.Count > 0) lstHotkeys.Items[lstHotkeys.Items.Count - 1].Selected = true;
                btnApply.Enabled = true;
                //folderChanged = true;
            }

            resizeHotkeyColumns();
        }

        private void editHotkey()
        {
            FormHotkey set = new FormHotkey(this);
            Action = lstHotkeys.SelectedItems[0].Text;
            Hotkey = Hotkeys.KeyListToValueList(lstHotkeys.SelectedItems[0].SubItems[1].Text);

            if (lstHotkeys.SelectedItems[0].SubItems[2].Text == "X") Global = true;
            else Global = false;

            set.Action = Action;
            set.Hotkey = Hotkey;
            set.Global = Global;
            set.EditMode = true;
            set.Topic = "Edit hotkey";

            set.ShowDialog();
            set.Dispose();

            if (Action != "")
            {
                lstHotkeys.BeginUpdate();
                lstHotkeys.SelectedItems[0].Remove();

                ListViewItem item = new ListViewItem(Action);
                item.SubItems.Add(Hotkeys.ValueListToKeyList(Hotkey));

                if (Global) item.SubItems.Add("X");
                else item.SubItems.Add("");

                lstHotkeys.Items.Add(item);
                lstHotkeys.EndUpdate();

                foreach (ListViewItem findItem in lstHotkeys.Items)
                {
                    if (findItem.Text == Action && findItem.SubItems[1].Text == Hotkeys.ValueListToKeyList(Hotkey))
                    {
                        findItem.Selected = true;
                    }
                }
                btnApply.Enabled = true;
            }

            resizeHotkeyColumns();
        }

        private void addHotkey()
        {
            FormHotkey set = new FormHotkey(this);

            Action = "";
            Hotkey = "";
            Global = false;

            set.Action = Action;
            set.Hotkey = Hotkey;
            set.Global = Global;
            set.EditMode = false;
            set.Topic = "Add new hotkey";

            set.ShowDialog();
            set.Dispose();

            if (Action != "")
            {
                lstHotkeys.BeginUpdate();
                ListViewItem item = new ListViewItem(Action);
                item.SubItems.Add(Hotkeys.ValueListToKeyList(Hotkey));

                if (Global) item.SubItems.Add("X");
                else item.SubItems.Add("");

                lstHotkeys.Items.Add(item);
                lstHotkeys.EndUpdate();

                foreach (ListViewItem findItem in lstHotkeys.Items)
                {
                    if (findItem.Text == Action && findItem.SubItems[1].Text == Hotkeys.ValueListToKeyList(Hotkey))
                    {
                        findItem.Selected = true;
                    }
                }
                btnApply.Enabled = true;
            }

            resizeHotkeyColumns();
        }

        private void lstHotkeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHotkeys.SelectedItems.Count > 0)
            {
                btnEditHotkey.Enabled = true;
                btnRemoveHotkey.Enabled = true;
            }

            else
            {
                btnEditHotkey.Enabled = false;
                btnRemoveHotkey.Enabled = false;
            }
        }

        private void lstHotkeys_DoubleClick(object sender, EventArgs e)
        {
            editHotkey();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            resizeHotkeyColumns();
        }

        private void frmSettings_Shown(object sender, EventArgs e)
        {
            resizeHotkeyColumns();
        }

    }
}
