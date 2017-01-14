using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatkaPlayer
{
    public partial class frmPlayer
    {
        private SerialPort serial = new SerialPort();

        private int oldValue = 0;
        private bool disabled = false;
        private bool playOld = false;

        private void getPorts()
        {
            string[] ports = SerialPort.GetPortNames();

            comboPort.Items.Clear();
            comboPort.Items.Add("-");
            comboPort.Text = "-";

            foreach (string port in ports)
            {
                comboPort.Items.Add(port);
            }
        }
        
        private void comboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Focus();
            Application.DoEvents();
            openPort();

            if (comboPort.Text != "-")
            {
                if (!timerArduinoPort.Enabled) timerArduinoPort.Start();
            }

            else
            {
                if (timerArduinoPort.Enabled) timerArduinoPort.Stop();
            }
        }

        private void openPort()
        {
            if (comboPort.Text != "-")
            {
                try
                {
                    if (serial.IsOpen)
                    {
                        serial.DataReceived -= serial_DataReceived;
                        serial.Close();
                    }

                    serial.PortName = comboPort.Text;
                    serial.BaudRate = 9600;
                    serial.DtrEnable = true;

                    serial.DataReceived += serial_DataReceived;

                    serial.Open();
                }

                catch { }
            }
        }

        private void timerArduinoPort_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!serial.IsOpen)
                {
                    openPort();
                }
            }

            catch { }
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string line = serial.ReadLine();
                this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
            }

            catch { }
        }

        private delegate void LineReceivedEvent(string line);
        private void LineReceived(string line)
        {
            try
            {
                labelDistance.Text = line + "cm";

                int value = -1;
                Int32.TryParse(line, out value);

                if (value < 0) value = 0;
                if (value > 150) value = 150;

                if (value < 33)
                {
                    double x = (double)value * 3 / 100;
                    setPosition(x);
                }

                oldValue = value;
            }

            catch { }
        }

        private void timerArduino_Tick(object sender, EventArgs e)
        {
            timerArduino.Stop();
            disabled = false;

        }

        private void setPosition(double percent)
        {
            if (waveOutDevice != null)
            {
                double trackBarPercent = (((double)pbPosition.Value / (double)pbPosition.Maximum));

                pbPosition.Value = (int)(pbPosition.Maximum * percent);
                audioFileReader.SetPosition((double)pbPosition.Value / 1000);

                if (!play)
                {
                    playpressed = true;
                    if (!play && sendMessages) sendMessagePause();

                    playTrack();
                }
            }

        }

        private string replaceChars(string str)
        {
            str = str.Replace("å", "-#1#-");
            str = str.Replace("Å", "-#2#-");
            str = str.Replace("ä", "-#3#-");
            str = str.Replace("Ä", "-#4#-");
            str = str.Replace("ö", "-#5#-");
            str = str.Replace("Ö", "-#6#-");

            return str;
        }

        private void sendName(string name)
        {
            if (comboPort.Text != "-")
            {
                try
                {
                    if (serial.IsOpen)
                    {
                        serial.Write(replaceChars(name));
                    }
                }

                catch { }
            }
        }

        private void sendPosition(int pos)
        {
            if (comboPort.Text != "-")
            {
                try
                {
                    if (serial.IsOpen)
                    {
                        if (play)
                        {
                            serial.WriteLine("<row2>" + pos.ToString() + "</row2>");
                            playOld = true;
                        }

                        else if (playOld)
                        {
                            serial.WriteLine("<row2>0</row2>");
                            playOld = false;
                        }
                    }
                }

                catch { }
            }
        }

    }
}
