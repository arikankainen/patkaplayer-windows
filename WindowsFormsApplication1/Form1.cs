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

namespace WindowsFormsApplication1
{
    public partial class frmPlayer : Form
    {
        private Mp3Player _mp3Player;
        
        public frmPlayer()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(panelButtons_MouseWheel);

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

        public void AddPanel(string mp3Dir)
        {
            panelButtons.Controls.Clear();
            int top = 5;
            int left = 10;

            string lastPath = "";
            string currentPath = "";
            string currentPathOnly = "";
            int cols = 0;
            txtPath.Text = mp3Dir;
            string[] array1 = Directory.GetFiles(@mp3Dir, "*.mp3", SearchOption.AllDirectories);

            if (array1.Length == 0) NoClips("No clips found.");

            for (int i = 0; i < array1.Length; i++)
            {
                cols++;
                currentPath = Path.GetDirectoryName(array1[i]);

                if (currentPath != lastPath)
                {
                    if (i > 0 && cols > 1) top += 45;
                    else if (i > 1 && cols == 1) top += 16;

                    currentPathOnly = currentPath.Substring(currentPath.LastIndexOf("\\") + 1);

                    if (i > 0)
                    {
                        Label label = new Label();
                        label.Top = top - 6;
                        label.Left = 12;
                        label.AutoSize = false;
                        label.Height = 2;
                        label.Width = 1300;
                        label.BorderStyle = BorderStyle.Fixed3D;
                        panelButtons.Controls.Add(label);
                    }

                    top += 5;

                    TextBox textbox = new TextBox();
                    textbox.Top = top;
                    textbox.Left = 12;
                    textbox.Text = currentPathOnly;
                    textbox.Width = 1300;
                    //textbox.Multiline = true;
                    //textbox.Height = 23;
                    textbox.BorderStyle = BorderStyle.None;
                    textbox.ReadOnly = true;
                    textbox.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    textbox.BackColor = Color.FromName("ControlLight");
                    textbox.ForeColor = ColorTranslator.FromHtml("#333");
                    
                    panelButtons.Controls.Add(textbox);
                    
                    top += textbox.Height + 11;
                    left = 10;
                    cols = 1;
                }

                Button button = new Button();
                button.Top = top;
                button.Left = left;
                button.Text = Path.GetFileNameWithoutExtension(array1[i]); // filename only
                //button.TextAlign = ContentAlignment.MiddleLeft;
                button.Tag = array1[i]; // filepath + filename + ext
                button.Width = 125;

                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = Color.White;
                button.ForeColor = ColorTranslator.FromHtml("#222"); ;
                button.BackColor = Color.LightGray;
                
                button.Click += new System.EventHandler(btnSound_Click);

                if (cols % 10 == 0)
                {
                    left = 10;
                    top += button.Height + 6;
                    cols = 0;
                }
                else left += button.Width + 6;

                panelButtons.Controls.Add(button);

                lastPath = currentPath;

            }

            // Dummy invisible label to add space to bottom
            Label labelBottom = new Label();
            labelBottom.Top = top + 35;
            labelBottom.Left = 12;
            labelBottom.AutoSize = false;
            labelBottom.Height = 0;
            labelBottom.Width = 1300;
            labelBottom.BorderStyle = BorderStyle.Fixed3D;
            panelButtons.Controls.Add(labelBottom);
        }

        // Stop button
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_mp3Player != null)
            _mp3Player.Stop();
        }

        // Generated play buttons
        private void btnSound_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            string fileToPlay = temp.Tag.ToString();

            if (_mp3Player != null) _mp3Player.Dispose();
            _mp3Player = new Mp3Player(fileToPlay);

            if (checkRepeat.Checked) _mp3Player.Repeat = true;
            else _mp3Player.Repeat = false;

            _mp3Player.Play();
        }

        // Select folder button
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
        
        // Sets focus to buttonpanel on scroll
        private void panelButtons_MouseWheel(object sender, MouseEventArgs e)
        {
            panelButtons.Focus();
        }
        
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
    }
}
