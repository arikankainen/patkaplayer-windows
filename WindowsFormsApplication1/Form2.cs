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
            txtVersion.Text = "Pätkä Player v0.14.03.28 © 2014 Ari Kankainen";
            ReadConfig();
        }

        // read values from config
        public void ReadConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConfigurationManager.RefreshSection("appSettings");

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

            config.AppSettings.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }

        private void frmHotkeys_Load(object sender, EventArgs e)
        {

        }

        // OK button, saves config and reloads frmPlayer
        private void btnSetOk_Click(object sender, EventArgs e)
        {
            SaveConfig();
            this._frmPlayer.InsertPanelButtons();
            this.Close();
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

    }
}
