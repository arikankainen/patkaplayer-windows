using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.PowerPacks;
using System.Configuration;
using System.Windows;

namespace WindowsFormsApplication1
{
    public partial class frmPlayer : Form
    {
        private Mp3Player _mp3Player;

        public string[] array1 { get; set; }
        public bool Minimized { get; set; }

        public frmPlayer()
        {
            InitializeComponent();
            
            this.MouseWheel += new MouseEventHandler(panelButtons_MouseWheel);
            this.SizeChanged += new EventHandler(Form1_Layout);
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            InsertPanelButtons();
        }

        // get mp3dir from config file or display 'no folder selected' text
        public void InsertPanelButtons()
        {
            string mp3Dir = "";

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["mp3dir"]))
            {
                mp3Dir = ConfigurationManager.AppSettings["mp3dir"];
            }

            if (mp3Dir != "") AddPanel(mp3Dir);
            else
            {
                NoClips("No folder selected");
                txtPath.Text = "No folder selected";
            }
        }

        // add panel for soundbuttons
        public void AddPanel(string mp3Dir)
        {
            panelButtons.Controls.Clear();

            //panelButtons.BackColor = ColorTranslator.FromHtml("#c5deeb");

            int top = 5;
            int left = 10;

            string lastPath = "";
            string currentPath = "";
            string currentPathOnly = "";
            int cols = 0;
            int even = 0;
            int numColor = 0;
            int numOfButtons = 0;
            
            int numOfCols;
            if (panelButtons.Width > 200) numOfCols = panelButtons.Width / 150;
            else numOfCols = 2;

            txtPath.Text = mp3Dir;
            //string[] array1 = Directory.GetFiles(@mp3Dir, "*.mp3", SearchOption.AllDirectories);
            array1 = Directory.GetFiles(@mp3Dir, "*.mp3", SearchOption.AllDirectories);

            if (array1.Length == 0) NoClips("No clips found.");

            // loop for adding buttons
            for (int i = 0; i < array1.Length; i++)
            {
                
                cols++;
                numOfButtons++;

                currentPath = Path.GetDirectoryName(array1[i]);

                if (currentPath != lastPath)
                {

                    even++;
                    numColor++;
                    if (i > 0 && cols > 1) top += 85;
                    else if (i > 1 && cols == 1) top += 16;

                    currentPathOnly = currentPath.Substring(currentPath.LastIndexOf("\\") + 1);

                    // add new separator line between folders, but not before first one
                    if (i > 0)
                    {
                        Label label = new Label();
                        label.Top = top - 6;
                        label.Left = 12;
                        label.AutoSize = false;
                        label.Height = 2;
                        label.Width = panelButtons.Width - 45;
                        label.BorderStyle = BorderStyle.Fixed3D;
                        panelButtons.Controls.Add(label);
                    }

                    top += 10;

                    // label for folder name
                    Label folderLabel = new Label();
                    folderLabel.Top = top;
                    folderLabel.Left = 12;
                    folderLabel.Text = currentPathOnly;
                    folderLabel.Width = panelButtons.Width - 45;
                    folderLabel.Height = 30;
                    folderLabel.BorderStyle = BorderStyle.None;
                    folderLabel.Font = new Font("Candara", 18); //, FontStyle.Italic);
                    folderLabel.ForeColor = ColorTranslator.FromHtml("#222");

                    panelButtons.Controls.Add(folderLabel);

                    
                    top += folderLabel.Height + 18;
                    left = 10;
                    cols = 1;
                }

                // soundbutton
                Button button = new Button();
                button.Top = top;
                button.Left = left;
                button.Text = Path.GetFileNameWithoutExtension(array1[i]); // filename only
                button.TextAlign = ContentAlignment.TopCenter;
                button.Tag = array1[i]; // filepath + filename + ext
                button.Width = (panelButtons.Width - ((numOfCols - 1) * 6 + 40)) / numOfCols;
                button.Height = 60;
                button.Padding = new Padding(5);
                button.Font = new Font("Segoe UI", 10); //, FontStyle.Normal);

                // different colors for even and odd folders
                if (numColor > 4) numColor = 1;

                switch (numColor)
                {
                    case 1:
                        // orange
                        button.BackColor = ColorTranslator.FromHtml("#e27a25");
                        button.ForeColor = ColorTranslator.FromHtml("#fff");
                        break;

                    case 2:
                        // green
                        button.BackColor = ColorTranslator.FromHtml("#1dbe6f");
                        button.ForeColor = ColorTranslator.FromHtml("#fff");
                        break;
                    
                    case 3:
                        // red
                        button.BackColor = ColorTranslator.FromHtml("#dc3c44");
                        button.ForeColor = ColorTranslator.FromHtml("#fff");
                        break;

                    case 4:
                        // blue
                        button.BackColor = ColorTranslator.FromHtml("#3185a7");
                        button.ForeColor = ColorTranslator.FromHtml("#fff");
                        break;
                }

                button.Click += new System.EventHandler(btnSound_Click);

                // new row for buttons
                if (cols % numOfCols == 0)
                {
                    left = 10;
                    top += button.Height + 6;
                    cols = 0;
                }
                else left += button.Width + 6;

                panelButtons.Controls.Add(button);

                lastPath = currentPath;

            }

            // dummy invisible label to add space to bottom
            Label labelBottom = new Label();
            labelBottom.Top = top + 71;
            labelBottom.Left = 12;
            labelBottom.AutoSize = false;
            labelBottom.Height = 0;
            labelBottom.Width = panelButtons.Width - 45;
            labelBottom.BorderStyle = BorderStyle.Fixed3D;
            panelButtons.Controls.Add(labelBottom);
        }

        // stop-button action
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_mp3Player != null)
            _mp3Player.Stop();
        }

        // generated play-buttons action
        private void btnSound_Click(object sender, EventArgs e)
        {

            Button temp = (Button)sender;
            string fileToPlay = temp.Tag.ToString();
            string pathToPlay = Path.GetDirectoryName(fileToPlay);

            Button button = this.Controls.Find("btnReplay", true).FirstOrDefault() as Button;
            button.Tag = fileToPlay;            

            txtPlaying.Text = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " / " + temp.Text;

            if (_mp3Player != null) _mp3Player.Dispose();
            _mp3Player = new Mp3Player(fileToPlay);

            if (checkRepeat.Checked) _mp3Player.Repeat = true;
            else _mp3Player.Repeat = false;

            _mp3Player.Play();
        }

        // select folder-button
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            
            if (folder.SelectedPath != "")
            {
                string mp3Dir = folder.SelectedPath;
                txtPath.Text = mp3Dir;

                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("mp3dir");
                config.AppSettings.Settings.Add("mp3dir", mp3Dir);
                config.Save(ConfigurationSaveMode.Minimal);

                AddPanel(mp3Dir);
            }
        }
        
        // text to panelbuttons form, eg. no clips
        public void NoClips(string clipText)
        {
            TextBox textboxNoDir = new TextBox();
            textboxNoDir.Top = 10;
            textboxNoDir.Left = 10;
            textboxNoDir.Text = clipText;
            textboxNoDir.Width = 100;
            textboxNoDir.BorderStyle = BorderStyle.None;
            textboxNoDir.ReadOnly = true;
            textboxNoDir.BackColor = Color.FromName("ControlLight");
            panelButtons.Controls.Add(textboxNoDir);
        }

        // sets focus to panelButtons on mousescroll
        private void panelButtons_MouseWheel(object sender, MouseEventArgs e)
        {
            panelButtons.Focus();
        }

        // window size changes
        private void Form1_Layout(object sender, System.EventArgs e)
        {
            //Button button = this.Controls.Find("btnSound1", true).FirstOrDefault() as Button;
            //button.Width = (panelButtons.Width / 8) - 19;

            if (panelButtons.Width == 0) Minimized = true;
            if (!Minimized && panelButtons.Width > 0) InsertPanelButtons();
            if (panelButtons.Width > 0) Minimized = false;

        }

        // keypress event
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 120) PlayRandom();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            InsertPanelButtons();
        }

        // replay button
        private void btnReplay_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            string fileToPlay = temp.Tag.ToString();

            if (fileToPlay != "nofile")
            {
                if (_mp3Player != null) _mp3Player.Dispose();
                _mp3Player = new Mp3Player(fileToPlay);

                if (checkRepeat.Checked) _mp3Player.Repeat = true;
                else _mp3Player.Repeat = false;
                _mp3Player.Play();
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            PlayRandom();
        }

        public void PlayRandom()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, array1.Length);

            string fileToPlay = array1[randomNumber].ToString();
            string pathToPlay = Path.GetDirectoryName(fileToPlay);

            Button button = this.Controls.Find("btnReplay", true).FirstOrDefault() as Button;
            button.Tag = fileToPlay;

            txtPlaying.Text = pathToPlay.Substring(pathToPlay.LastIndexOf("\\") + 1) + " / " + Path.GetFileNameWithoutExtension(fileToPlay);

            if (_mp3Player != null) _mp3Player.Dispose();
            _mp3Player = new Mp3Player(fileToPlay);

            if (checkRepeat.Checked) _mp3Player.Repeat = true;
            else _mp3Player.Repeat = false;

            _mp3Player.Play();

        }
    }
}
