using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatkaPlayer
{
    public class ProgressBarEx : ProgressBar
    {
        public string ProgressText { get; set; }

        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Image offscreenImage = new Bitmap(this.Width, this.Height))
            {
                using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                {
                    Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

                    offscreen.FillRectangle(new SolidBrush(SystemColors.ButtonFace), 0, 0, 1, 1);
                    offscreen.FillRectangle(new SolidBrush(SystemColors.ButtonFace), rec.Width - 1, 0, 1, 1);
                    offscreen.FillRectangle(new SolidBrush(SystemColors.ButtonFace), rec.Width - 1, rec.Height - 1, 1, 1);
                    offscreen.FillRectangle(new SolidBrush(SystemColors.ButtonFace), 0, rec.Height - 1, 1, 1);

                    offscreen.FillRectangle(new SolidBrush(Color.FromArgb(255, 174, 174, 174)), 0, 0, rec.Width, rec.Height);
                    offscreen.FillRectangle(new SolidBrush(Color.White), 1, 1, rec.Width - 2, rec.Height - 2);

                    if (Value > 0)
                    {
                        rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 2;
                        rec.Height = rec.Height - 2;

                        //offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#ccc")), 2, 2, rec.Width - 2, (rec.Height - 2));
                        //offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#b1d4f2")), 2, 2, rec.Width - 2, (rec.Height - 2));
                        offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#b1d4f2")), 1, 1, rec.Width, (rec.Height));

                    }

                    using (Font f = new Font("Segoe UI", 8))
                    {
                        SizeF len = offscreen.MeasureString(ProgressText, f);
                        Point location = new Point(Convert.ToInt32((Width / 2) - len.Width / 2), 5);

                        offscreen.DrawString(ProgressText, f, Brushes.Black, location);
                    }

                    e.Graphics.DrawImage(offscreenImage, 0, 0);
                    offscreenImage.Dispose();
                }
            }



        }
    }

    class ProgressBarEx3 : ProgressBar // volume bar
    {
        public bool MouseButtonDown { get; set; }

        public ProgressBarEx3()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // none, helps for flicker
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Image offscreenImage = new Bitmap(this.Width, this.Height))
            {
                using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                {
                    Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

                    offscreen.FillRectangle(new SolidBrush(SystemColors.Control), 0, 0, rec.Width, rec.Height);

                    offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#bbb")), 3, 5, rec.Width - 6, 1);
                    offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#e5e5e5")), 3, 6, rec.Width - 6, 1);
                    offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#e5e5e5")), 3, 7, rec.Width - 6, 1);
                    offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#e5e5e5")), 3, 8, rec.Width - 6, 1);
                    offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#fff")), 3, 9, rec.Width - 6, 1);

                    offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#bbb")), 3, 5, 1, 4);
                    offscreen.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#fff")), rec.Width - 4, 5, 1, 4);

                    int location = (int)((rec.Width - 14) * ((double)Value / Maximum));

                    Bitmap img;

                    if (MouseButtonDown)
                    {
                        img = new Bitmap(Properties.Resources.round_volume_hover, new Size(14, 14));
                    }

                    else
                    {
                        img = new Bitmap(Properties.Resources.round_volume_normal, new Size(14, 14));
                    }

                    offscreen.DrawImage(img, new Point(location, 0));

                    e.Graphics.DrawImage(offscreenImage, 0, 0);
                    offscreenImage.Dispose();
                }
            }

        }


    }
}
