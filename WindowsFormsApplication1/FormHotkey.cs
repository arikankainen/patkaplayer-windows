using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatkaPlayer
{
    public partial class FormHotkey : Form
    {
        private readonly frmSettings form2;

        private List<string> listKeyValuesTemp = new List<string>();
        private string keyValues = null;

        private bool txtChanged = false;
        private string txtOrig = "";

        private bool firstEnter = true;

        bool acceptMore = true;

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
            set
            {
                if (value != "")
                {
                    keyValues = value;
                    hotkey = Hotkeys.ValueListToKeyList(value);
                }
            }
        }

        private bool global;
        public bool Global
        {
            get { return global; }
            set { global = value; }
        }

        private bool editMode;
        public bool EditMode
        {
            get { return editMode; }
            set { editMode = value; }
        }

        private string topic;
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public FormHotkey()
        {
            InitializeComponent();
        }

        public FormHotkey(frmSettings temp)
        {
            InitializeComponent();
            form2 = temp;
            txtOrig = Hotkey;
        }

        private void btnHotkeyOk_Click(object sender, EventArgs e)
        {
            if (comboAction.Text == "") MessageBox.Show("Action not defined", "Hotkeys", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (keyValues == null) MessageBox.Show("Hotkey not defined", "Hotkeys", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (EditMode && form2.HotkeyExist(keyValues, true)) MessageBox.Show("Hotkey '" + txtHotkey.Text + "' already exists", "Hotkeys", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (!EditMode && form2.HotkeyExist(keyValues, false)) MessageBox.Show("Hotkey '" + txtHotkey.Text + "' already exists", "Hotkeys", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                form2.Action = comboAction.Text;
                form2.Hotkey = keyValues;
                form2.Global = checkGlobal.Checked;
                this.Close();
            }
        }

        private void btnHotkeyCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHotkey_Shown(object sender, EventArgs e)
        {
            comboAction.Text = Action;
            txtHotkey.Text = Hotkey;
            checkGlobal.Checked = Global;
            labelTopic.Text = Topic;
            label1.Focus();
        }

        private void txtHotkey_Enter(object sender, EventArgs e)
        {
            txtChanged = false;
            txtOrig = txtHotkey.Text;
            txtHotkey.Text = "";
            listKeyValuesTemp.Clear();
            txtHotkey.BackColor = ColorTranslator.FromHtml("#ffffdd");
            txtHotkey.Tag = null;
        }

        private void txtHotkey_Leave(object sender, EventArgs e)
        {
            txtHotkey.BackColor = SystemColors.Window;
            if (!txtChanged) txtHotkey.Text = txtOrig;
            if (firstEnter)
            {
                txtHotkey.Text = Hotkey;
                firstEnter = false;
            }

            else
            {
                bool first = true;
                foreach (string val in listKeyValuesTemp)
                {
                    if (first) keyValues = val;
                    else keyValues += "|" + val;
                    first = false;
                }
            }

            listKeyValuesTemp.Clear();
        }

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txtHotkey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (
                e.KeyCode != Keys.Menu &&
                e.KeyCode != Keys.ShiftKey &&
                e.KeyCode != Keys.ControlKey
                ) acceptMore = false;

            else acceptMore = true;

            string key = e.KeyValue.ToString();
            txtChanged = true;

            if (!listKeyValuesTemp.Contains(key)) listKeyValuesTemp.Add(key);
            listKeyValuesTemp.Sort();

            txtHotkey.Text = "";
            for (int i = 0; i < listKeyValuesTemp.Count; i++)
            {
                if (i > 0) txtHotkey.Text += "+" + Hotkeys.GetKeyName(listKeyValuesTemp[i]);
                else txtHotkey.Text = Hotkeys.GetKeyName(listKeyValuesTemp[i]);
            }

            if (!acceptMore) label1.Focus();
        }

        private void txtHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            if (acceptMore) txtHotkey.Text = txtOrig;
            listKeyValuesTemp.Clear();
            if (txtChanged) label1.Focus();
        }
    }
}
