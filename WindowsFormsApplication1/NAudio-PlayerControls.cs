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
using System.Drawing.Drawing2D;

using NAudio;
using NAudio.Wave;

namespace PatkaPlayer
{
    public partial class frmPlayer
    {

        private void loadTrack(string file, int latency)
        {

            if (waveOutDevice == null)
            {
                waveOutDevice = new WaveOut() 
                { 
                    DesiredLatency = latency,
                    NumberOfBuffers = 2
                };

                audioFileReader = new AudioFileReader(file);
                waveOutDevice.Init(audioFileReader);
                audioFileReader.Volume = 1; //(float)trackBarVolume.Value / 100;
                //audioFileReader.Volume = (float)0.2;

                waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(waveOutDevice_PlaybackStopped);
                pbPosition.Maximum = Convert.ToInt32(audioFileReader.TotalTime.TotalMilliseconds);
                pbPosition.Value = 0;
            }
        }

        private void playTrack()
        {
            if (waveOutDevice != null)
            {
                if (pause || stop)
                {
                    this.Text = lastPlayedFile;
                    waveOutDevice.Play();
                    stop = pause = false;
                    play = true;
                    playpressed = false;
                }

                else if (play)
                {
                    waveOutDevice.Pause();
                    stop = play = false;
                    pause = true;
                }
            }
        }

        private void stopTrack()
        {
            if (waveOutDevice != null)
            {
                //if (playpressed == false && sendMessages && stop == false) sendMessagePlay();

                waveOutDevice.Stop();
                audioFileReader.SetPosition((double)0);
                pbPosition.Value = 0;
                pause = play = false;
                stop = true;
            }
        }

        private void closeTrack()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                pause = play = false;
                stop = true;
            }
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }

        }

        private void waveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            stopTrack();
            //if (checkRepeat.Checked && randompressed) playRandom();
        }


    }
}