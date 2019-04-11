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
using System.Runtime.InteropServices;

namespace PatkaPlayer
{
    public partial class frmPlayer
    {
        private bool volumeJustSet = false;

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        private void vol_MouseDown(object sender, MouseEventArgs e)
        {
            vol.MouseButtonDown = true;

            int mouseX = e.Location.X;
            if (mouseX < 0) mouseX = 0;
            if (mouseX > vol.Width) mouseX = vol.Width;

            double mousePercent = (((double)(mouseX - 6) / ((double)vol.Width - 14)));
            if (mousePercent < 0) mousePercent = 0;
            if (mousePercent > 1) mousePercent = 1;

            vol.Value = (int)((vol.Maximum) * mousePercent);
            setVol();
        }

        private void vol_MouseUp(object sender, MouseEventArgs e)
        {
            vol.MouseButtonDown = false;
        }

        private void vol_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int mouseX = e.Location.X;
                if (mouseX < 0) mouseX = 0;
                if (mouseX > vol.Width) mouseX = vol.Width;

                double mousePercent = (((double)(mouseX - 6) / ((double)vol.Width - 14)));
                if (mousePercent < 0) mousePercent = 0;
                if (mousePercent > 1) mousePercent = 1;

                vol.Value = (int)(vol.Maximum * mousePercent);
                setVol();
            }
        }

        private void getVol()
        {
            uint CurrVol = 0;
            waveOutGetVolume(IntPtr.Zero, out CurrVol);

            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            vol.Value = CalcVol / (ushort.MaxValue / 100);
            //labelVolume.Text = "Volume: " + vol.Value.ToString() + "%";
            labelVolumePercent.Text = vol.Value.ToString() + "%";
        }

        private void setVol()
        {
            volumeJustSet = true;
            timerVol.Stop();
            timerVol.Start();

            int NewVolume = ((ushort.MaxValue / 100) * vol.Value);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);

            //labelVolume.Text = "Volume: " + vol.Value.ToString() + "%";
            labelVolumePercent.Text = vol.Value.ToString() + "%";
        }

        private void timerVol_Tick(object sender, EventArgs e)
        {
            timerVol.Stop();
            volumeJustSet = false;
        }

        private void vol_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs ee = (HandledMouseEventArgs)e;
            ee.Handled = true;

            int x = e.Delta;

            if (x < -1)
            {
                if (vol.Value > 9) vol.Value -= 5;
                else vol.Value = 0;
                setVol();
            }

            if (x > 1)
            {
                if (vol.Value < 91) vol.Value += 5;
                else vol.Value = 100;
                setVol();
            }
        }

        private void increaseVol()
        {
            if (vol.Value < 91) vol.Value += 5;
            else vol.Value = 100;

            dnVolume.SetBodyText = "Volume: " + vol.Value.ToString() + "%";
            dnVolume.SetProgress = vol.Value;
            dnVolume.ShowNotification();

            setVol();
        }

        private void decreaseVol()
        {
            if (vol.Value > 9) vol.Value -= 5;
            else vol.Value = 0;

            dnVolume.SetBodyText = "Volume: " + vol.Value.ToString() + "%";
            dnVolume.SetProgress = vol.Value;
            dnVolume.ShowNotification();

            setVol();
        }




    }
}
