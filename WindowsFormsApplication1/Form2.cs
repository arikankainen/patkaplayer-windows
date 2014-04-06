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

namespace PatkaPlayer
{
    public partial class frmSettings : Form
    {



        // storage for frmPlayer instance
        private readonly frmPlayer _frmPlayer;
        private string oldMp3Dir;

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
            txtVersion.Text = "Pätkä Player v0.14.04.06 © 2014 Ari Kankainen";
            ReadConfig();
            this.oldMp3Dir = txtSetFolder.Text;
            if (temp.settingsPage == 1) this.tabControl1.SelectedTab = tabPage1;
            else if (temp.settingsPage == 2) this.tabControl1.SelectedTab = tabPage2;
            
            //string exePath = System.Windows.Forms.Application.ExecutablePath;
            //labelSaveLog.Text = "Save play history to CSV file\n\"" + Path.GetFileName(exePath) + ".log\".";
        }

        // read values from config
        public void ReadConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConfigurationManager.RefreshSection("appSettings");

            // folders
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["mp3dir"])) txtSetFolder.Text = config.AppSettings.Settings["mp3dir"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_1"])) txtSet1.Text = config.AppSettings.Settings["hotkey_1"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_2"])) txtSet2.Text = config.AppSettings.Settings["hotkey_2"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_3"])) txtSet3.Text = config.AppSettings.Settings["hotkey_3"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_4"])) txtSet4.Text = config.AppSettings.Settings["hotkey_4"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_5"])) txtSet5.Text = config.AppSettings.Settings["hotkey_5"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_6"])) txtSet6.Text = config.AppSettings.Settings["hotkey_6"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_7"])) txtSet7.Text = config.AppSettings.Settings["hotkey_7"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_8"])) txtSet8.Text = config.AppSettings.Settings["hotkey_8"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_9"])) txtSet9.Text = config.AppSettings.Settings["hotkey_9"].Value;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["hotkey_0"])) txtSet0.Text = config.AppSettings.Settings["hotkey_0"].Value;

            // timer 2 settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minhour"])) numericMinHour2.Value = Convert.ToInt32(config.AppSettings.Settings["timer2minhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minmin"])) numericMinMin2.Value = Convert.ToInt32(config.AppSettings.Settings["timer2minmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2minsec"])) numericMinSec2.Value = Convert.ToInt32(config.AppSettings.Settings["timer2minsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxhour"])) numericMaxHour2.Value = Convert.ToInt32(config.AppSettings.Settings["timer2maxhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxmin"])) numericMaxMin2.Value = Convert.ToInt32(config.AppSettings.Settings["timer2maxmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2maxsec"])) numericMaxSec2.Value = Convert.ToInt32(config.AppSettings.Settings["timer2maxsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer2playall"])) radioClipsAll2.Checked = true;
            else radioClipsFilter2.Checked = true;

            // timer 1 settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minhour"])) numericMinHour1.Value = Convert.ToInt32(config.AppSettings.Settings["timer1minhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minmin"])) numericMinMin1.Value = Convert.ToInt32(config.AppSettings.Settings["timer1minmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1minsec"])) numericMinSec1.Value = Convert.ToInt32(config.AppSettings.Settings["timer1minsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxhour"])) numericMaxHour1.Value = Convert.ToInt32(config.AppSettings.Settings["timer1maxhour"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxmin"])) numericMaxMin1.Value = Convert.ToInt32(config.AppSettings.Settings["timer1maxmin"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1maxsec"])) numericMaxSec1.Value = Convert.ToInt32(config.AppSettings.Settings["timer1maxsec"].Value);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["timer1playall"])) radioClipsAll1.Checked = true;
            else radioClipsFilter1.Checked = true;

            // misc Settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["log"])) checkLog.Checked = true;
            else checkLog.Checked = false;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["daily"])) checkDaily.Checked = true;
            else checkDaily.Checked = false;
        }

        // save config file
        public void SaveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConfigurationManager.RefreshSection("appSettings");

            config.AppSettings.Settings.Remove("mp3dir");
            config.AppSettings.Settings.Remove("hotkey_1");
            config.AppSettings.Settings.Remove("hotkey_2");
            config.AppSettings.Settings.Remove("hotkey_3");
            config.AppSettings.Settings.Remove("hotkey_4");
            config.AppSettings.Settings.Remove("hotkey_5");
            config.AppSettings.Settings.Remove("hotkey_6");
            config.AppSettings.Settings.Remove("hotkey_7");
            config.AppSettings.Settings.Remove("hotkey_8");
            config.AppSettings.Settings.Remove("hotkey_9");
            config.AppSettings.Settings.Remove("hotkey_0");
            config.AppSettings.Settings.Remove("timer1minhour");
            config.AppSettings.Settings.Remove("timer1minmin");
            config.AppSettings.Settings.Remove("timer1minsec");
            config.AppSettings.Settings.Remove("timer1maxhour");
            config.AppSettings.Settings.Remove("timer1maxmin");
            config.AppSettings.Settings.Remove("timer1maxsec");
            config.AppSettings.Settings.Remove("timer1playall");
            config.AppSettings.Settings.Remove("timer2minhour");
            config.AppSettings.Settings.Remove("timer2minmin");
            config.AppSettings.Settings.Remove("timer2minsec");
            config.AppSettings.Settings.Remove("timer2maxhour");
            config.AppSettings.Settings.Remove("timer2maxmin");
            config.AppSettings.Settings.Remove("timer2maxsec");
            config.AppSettings.Settings.Remove("timer2playall");
            config.AppSettings.Settings.Remove("log");
            config.AppSettings.Settings.Remove("daily");

            // folders
            if (txtSetFolder.Text != "") config.AppSettings.Settings.Add("mp3dir", txtSetFolder.Text);
            if (txtSet1.Text != "") config.AppSettings.Settings.Add("hotkey_1", txtSet1.Text);
            if (txtSet2.Text != "") config.AppSettings.Settings.Add("hotkey_2", txtSet2.Text);
            if (txtSet3.Text != "") config.AppSettings.Settings.Add("hotkey_3", txtSet3.Text);
            if (txtSet4.Text != "") config.AppSettings.Settings.Add("hotkey_4", txtSet4.Text);
            if (txtSet5.Text != "") config.AppSettings.Settings.Add("hotkey_5", txtSet5.Text);
            if (txtSet6.Text != "") config.AppSettings.Settings.Add("hotkey_6", txtSet6.Text);
            if (txtSet7.Text != "") config.AppSettings.Settings.Add("hotkey_7", txtSet7.Text);
            if (txtSet8.Text != "") config.AppSettings.Settings.Add("hotkey_8", txtSet8.Text);
            if (txtSet9.Text != "") config.AppSettings.Settings.Add("hotkey_9", txtSet9.Text);
            if (txtSet0.Text != "") config.AppSettings.Settings.Add("hotkey_0", txtSet0.Text);

            // timer 1 settings
            if (numericMinHour1.Value > 0) config.AppSettings.Settings.Add("timer1minhour", numericMinHour1.Value.ToString());
            if (numericMinMin1.Value > 0) config.AppSettings.Settings.Add("timer1minmin", numericMinMin1.Value.ToString());
            if (numericMinSec1.Value > 0) config.AppSettings.Settings.Add("timer1minsec", numericMinSec1.Value.ToString());
            if (numericMaxHour1.Value > 0) config.AppSettings.Settings.Add("timer1maxhour", numericMaxHour1.Value.ToString());
            if (numericMaxMin1.Value > 0) config.AppSettings.Settings.Add("timer1maxmin", numericMaxMin1.Value.ToString());
            if (numericMaxSec1.Value > 0) config.AppSettings.Settings.Add("timer1maxsec", numericMaxSec1.Value.ToString());
            if (radioClipsAll1.Checked == true) config.AppSettings.Settings.Add("timer1playall", "true");

            // timer 2 settings
            if (numericMinHour2.Value > 0) config.AppSettings.Settings.Add("timer2minhour", numericMinHour2.Value.ToString());
            if (numericMinMin2.Value > 0) config.AppSettings.Settings.Add("timer2minmin", numericMinMin2.Value.ToString());
            if (numericMinSec2.Value > 0) config.AppSettings.Settings.Add("timer2minsec", numericMinSec2.Value.ToString());
            if (numericMaxHour2.Value > 0) config.AppSettings.Settings.Add("timer2maxhour", numericMaxHour2.Value.ToString());
            if (numericMaxMin2.Value > 0) config.AppSettings.Settings.Add("timer2maxmin", numericMaxMin2.Value.ToString());
            if (numericMaxSec2.Value > 0) config.AppSettings.Settings.Add("timer2maxsec", numericMaxSec2.Value.ToString());
            if (radioClipsAll2.Checked == true) config.AppSettings.Settings.Add("timer2playall", "true");

            // misc Settings
            if (checkLog.Checked == true) config.AppSettings.Settings.Add("log", "true");
            if (checkDaily.Checked == true) config.AppSettings.Settings.Add("daily", "true");

            config.AppSettings.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }

        private void frmHotkeys_Load(object sender, EventArgs e)
        {

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
                SaveConfig();
                if (this.oldMp3Dir != txtSetFolder.Text) this._frmPlayer.InsertPanelButtons();
                else this._frmPlayer.ReadSettings();
                this.Close();
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
            folder.RootFolder = Environment.SpecialFolder.MyComputer;

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtSetFolder.Text = folder.SelectedPath;
        }

        // dialog for choosing mp3 to hotkey
        private string setHotkeyFile()
        {
            OpenFileDialog file = new OpenFileDialog();

            if (Directory.Exists(txtSetFolder.Text)) file.InitialDirectory = txtSetFolder.Text;
            else file.InitialDirectory = "c:\\";
            file.Filter = "MP3 files|*.mp3";

            DialogResult result = file.ShowDialog();
            return file.FileName;
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

        private void btnSet0_Click(object sender, EventArgs e)
        {
            string file = setHotkeyFile();
            if (file != "") txtSet0.Text = file;
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
            txtSet0.Text = "";
        }

        private void numericMinHour1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericMinMin1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericMinSec1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMaxHour1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMaxMin1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMaxSec1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMinHour2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMinMin2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMinSec2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMaxHour2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMaxMin2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericMaxSec2_ValueChanged(object sender, EventArgs e)
        {
            
        }

    }
}
