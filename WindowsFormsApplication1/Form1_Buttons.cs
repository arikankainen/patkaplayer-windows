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
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btn_DragDrop(object sender, DragEventArgs e)
        {
            if (dragFromLV == lstFiles && lstFiles.Items.Count > 0)
            {
                string file = lstFiles.SelectedItems[0].Text;
                Button button = (Button)sender;
                setButton(button, file);
            }

            else if (dragFromLV == lstPlaylist && lstPlaylist.Items.Count > 0)
            {
                string file = lstPlaylist.SelectedItems[0].Text;
                Button button = (Button)sender;
                setButton(button, file);
            }

            dragFromLV = null;
        }

        private void btn_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void btn_DragOver(object sender, DragEventArgs e)
        {

        }

        private void btn_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string file = null;
            if (button.Tag != null) file = button.Tag.ToString();

            if (file != null && File.Exists(file)) playFile(file);
        }

        private void setButton(Button button, string file)
        {
            button.Tag = file;
            button.Text = Path.GetFileNameWithoutExtension(file) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(file));

            string keyName = "temp";
            if (button.Name == "btn1") keyName = "Hotkey1";
            else if (button.Name == "btn2") keyName = "Hotkey2";
            else if (button.Name == "btn3") keyName = "Hotkey3";
            else if (button.Name == "btn4") keyName = "Hotkey4";
            else if (button.Name == "btn5") keyName = "Hotkey5";
            else if (button.Name == "btn6") keyName = "Hotkey6";
            else if (button.Name == "btn7") keyName = "Hotkey7";
            else if (button.Name == "btn8") keyName = "Hotkey8";
            else if (button.Name == "btn9") keyName = "Hotkey9";
            else if (button.Name == "btn10") keyName = "Hotkey10";
            else if (button.Name == "btn11") keyName = "Hotkey11";
            else if (button.Name == "btn12") keyName = "Hotkey12";
            else if (button.Name == "btn13") keyName = "Hotkey13";
            else if (button.Name == "btn14") keyName = "Hotkey14";
            else if (button.Name == "btn15") keyName = "Hotkey15";

            settings.SaveSetting(keyName, file);

            hotkey1 = settings.LoadSetting("Hotkey1");
            hotkey2 = settings.LoadSetting("Hotkey2");
            hotkey3 = settings.LoadSetting("Hotkey3");
            hotkey4 = settings.LoadSetting("Hotkey4");
            hotkey5 = settings.LoadSetting("Hotkey5");
            hotkey6 = settings.LoadSetting("Hotkey6");
            hotkey7 = settings.LoadSetting("Hotkey7");
            hotkey8 = settings.LoadSetting("Hotkey8");
            hotkey9 = settings.LoadSetting("Hotkey9");
            hotkey10 = settings.LoadSetting("Hotkey10");
            hotkey11 = settings.LoadSetting("Hotkey11");
            hotkey12 = settings.LoadSetting("Hotkey12");
            hotkey13 = settings.LoadSetting("Hotkey13");
            hotkey14 = settings.LoadSetting("Hotkey14");
            hotkey15 = settings.LoadSetting("Hotkey15");
        }

        private void loadButtons()
        {
            hotkey1 = settings.LoadSetting("Hotkey1");
            hotkey2 = settings.LoadSetting("Hotkey2");
            hotkey3 = settings.LoadSetting("Hotkey3");
            hotkey4 = settings.LoadSetting("Hotkey4");
            hotkey5 = settings.LoadSetting("Hotkey5");
            hotkey6 = settings.LoadSetting("Hotkey6");
            hotkey7 = settings.LoadSetting("Hotkey7");
            hotkey8 = settings.LoadSetting("Hotkey8");
            hotkey9 = settings.LoadSetting("Hotkey9");
            hotkey10 = settings.LoadSetting("Hotkey10");
            hotkey11 = settings.LoadSetting("Hotkey11");
            hotkey12 = settings.LoadSetting("Hotkey12");
            hotkey13 = settings.LoadSetting("Hotkey13");
            hotkey14 = settings.LoadSetting("Hotkey14");
            hotkey15 = settings.LoadSetting("Hotkey15");

            btn1.Text = "";
            btn1.Tag = null;
            btn2.Text = "";
            btn2.Tag = null;
            btn3.Text = "";
            btn3.Tag = null;
            btn4.Text = "";
            btn4.Tag = null;
            btn5.Text = "";
            btn5.Tag = null;
            btn6.Text = "";
            btn6.Tag = null;
            btn7.Text = "";
            btn7.Tag = null;
            btn8.Text = "";
            btn8.Tag = null;
            btn9.Text = "";
            btn9.Tag = null;
            btn10.Text = "";
            btn10.Tag = null;
            btn11.Text = "";
            btn11.Tag = null;
            btn12.Text = "";
            btn12.Tag = null;
            btn13.Text = "";
            btn13.Tag = null;
            btn14.Text = "";
            btn14.Tag = null;
            btn15.Text = "";
            btn15.Tag = null;

            if (File.Exists(Path.Combine(mp3Dir, hotkey1)))
            {
                btn1.Tag = Path.Combine(mp3Dir, hotkey1);
                btn1.Text = Path.GetFileNameWithoutExtension(hotkey1) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey1));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey2)))
            {
                btn2.Tag = Path.Combine(mp3Dir, hotkey2);
                btn2.Text = Path.GetFileNameWithoutExtension(hotkey2) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey2));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey3)))
            {
                btn3.Tag = Path.Combine(mp3Dir, hotkey3);
                btn3.Text = Path.GetFileNameWithoutExtension(hotkey3) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey3));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey4)))
            {
                btn4.Tag = Path.Combine(mp3Dir, hotkey4);
                btn4.Text = Path.GetFileNameWithoutExtension(hotkey4) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey4));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey5)))
            {
                btn5.Tag = Path.Combine(mp3Dir, hotkey5);
                btn5.Text = Path.GetFileNameWithoutExtension(hotkey5) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey5));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey6)))
            {
                btn6.Tag = Path.Combine(mp3Dir, hotkey6);
                btn6.Text = Path.GetFileNameWithoutExtension(hotkey6) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey6));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey7)))
            {
                btn7.Tag = Path.Combine(mp3Dir, hotkey7);
                btn7.Text = Path.GetFileNameWithoutExtension(hotkey7) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey7));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey8)))
            {
                btn8.Tag = Path.Combine(mp3Dir, hotkey8);
                btn8.Text = Path.GetFileNameWithoutExtension(hotkey8) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey8));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey9)))
            {
                btn9.Tag = Path.Combine(mp3Dir, hotkey9);
                btn9.Text = Path.GetFileNameWithoutExtension(hotkey9) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey9));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey10)))
            {
                btn10.Tag = Path.Combine(mp3Dir, hotkey10);
                btn10.Text = Path.GetFileNameWithoutExtension(hotkey10) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey10));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey11)))
            {
                btn11.Tag = Path.Combine(mp3Dir, hotkey11);
                btn11.Text = Path.GetFileNameWithoutExtension(hotkey11) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey11));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey12)))
            {
                btn12.Tag = Path.Combine(mp3Dir, hotkey12);
                btn12.Text = Path.GetFileNameWithoutExtension(hotkey12) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey12));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey13)))
            {
                btn13.Tag = Path.Combine(mp3Dir, hotkey13);
                btn13.Text = Path.GetFileNameWithoutExtension(hotkey13) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey13));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey14)))
            {
                btn14.Tag = Path.Combine(mp3Dir, hotkey14);
                btn14.Text = Path.GetFileNameWithoutExtension(hotkey14) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey14));
            }

            if (File.Exists(Path.Combine(mp3Dir, hotkey15)))
            {
                btn15.Tag = Path.Combine(mp3Dir, hotkey15);
                btn15.Text = Path.GetFileNameWithoutExtension(hotkey15) + Environment.NewLine + Path.GetFileName(Path.GetDirectoryName(hotkey15));
            }
        }




    }
}
