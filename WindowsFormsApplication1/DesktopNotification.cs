using System;
using System.Drawing;
using System.Windows.Forms;

namespace AK
{
    #region EventHandlers

    public delegate void NotificationClickEventHandler(object sender, NotificationClickEventArgs e);
    public class NotificationClickEventArgs : EventArgs
    {
        private string address;
        public string Address
        {
            get { return address; }
        }

        public NotificationClickEventArgs(string address)
        {
            this.address = address;
        }
    }

    public delegate void NotificationProgressEventHandler(object sender, NotificationProgressEventArgs e);
    public class NotificationProgressEventArgs : EventArgs
    {
        private int progressValue;
        public int ProgressValue
        {
            get { return progressValue; }
        }

        private bool mousePressed;
        public bool MousePressed
        {
            get { return mousePressed; }
        }

        public NotificationProgressEventArgs(int progressValue, bool mousePressed)
        {
            this.progressValue = progressValue;
            this.mousePressed = mousePressed;
        }
    }

    partial class DesktopNotification
    {
        public event NotificationClickEventHandler NotificationClickEvent;
        public void SendClickEvent()
        {
            NotificationClickEvent(this, new NotificationClickEventArgs(setAddress));
        }

        public event NotificationProgressEventHandler NotificationProgressEvent;
        public void SendProgressEvent(int progress, bool pressed)
        {
            NotificationProgressEvent(this, new NotificationProgressEventArgs(progress, pressed));
        }

        public event EventHandler NotificationHideEvent;
        public void SendHideEvent()
        {
            NotificationHideEvent(this, new EventArgs());
        }
    }

    #endregion

    partial class DesktopNotification
    {
        private Color setBorderHighlightColor = Color.FromArgb(114, 114, 114);
        public Color SetBorderHighlightColor
        {
            get { return setBorderHighlightColor; }
            set { setBorderHighlightColor = value; }
        }

        private Color setBorderColor = Color.FromArgb(74, 74, 74);
        public Color SetBorderColor
        {
            get { return setBorderColor; }
            set { form.BackColor = setBorderColor = value; }
        }

        private Color setProgressForeColor = Color.FromArgb(150, 150, 150);
        public Color SetProgressForeColor
        {
            get { return setProgressForeColor; }
            set { progress.ForeColor = setProgressForeColor = value; }
        }

        private Color setProgressBackColor = Color.FromArgb(50, 50, 50);
        public Color SetProgressBackColor
        {
            get { return setProgressBackColor; }
            set { progress.BackColor = setProgressBackColor = value; }
        }

        private Color setBackColor = Color.FromArgb(30, 30, 30);
        public Color SetBackColor
        {
            get { return setBackColor; }
            set { panelContainer.BackColor = setBackColor = value; }
        }

        private Color setTopicColor = Color.FromArgb(255, 255, 255);
        public Color SetTopicColor
        {
            get { return setTopicColor; }
            set { labelTopic.ForeColor = setTopicColor = value; }
        }

        private Color setBodyColor = Color.FromArgb(180, 180, 180);
        public Color SetBodyColor
        {
            get { return setBodyColor; }
            set { labelBody.ForeColor = setBodyColor = value; }
        }

        public int SetWidth
        {
            get { return form.Width; }
            set
            {
                form.Width = value;
                GenerateLayout();
            }
        }

        public int SetDuration
        {
            get { return timerHideForm.Interval; }
            set { timerHideForm.Interval = value; }
        }

        public string SetTopicText
        {
            get { return labelTopic.Text; }
            set { labelTopic.Text = value; }
        }

        public string SetBodyText
        {
            get { return labelBody.Text; }
            set
            {
                labelBody.Text = value;
                GenerateLayout();
            }
        }

        private string setAddress = null;
        public string SetAddress
        {
            get { return setAddress; }
            set
            {
                setAddress = value;
                GenerateLayout();
            }
        }

        public Image SetImage
        {
            get { return pictureIcon.Image; }
            set
            {
                pictureIcon.Image = value;
                GenerateLayout();
            }
        }

        private bool setShowProgress = false;
        public bool SetShowProgress
        {
            get { return setShowProgress; }
            set
            {
                setShowProgress = value;
                GenerateLayout();
            }
        }

        public int SetProgress
        {
            get { return progress.Value; }
            set
            {
                progress.Value = value;
                GenerateLayout();
            }
        }

        private NotificationPosition setAlign = NotificationPosition.BottomRight;
        public NotificationPosition SetAlign
        {
            get { return setAlign; }
            set
            {
                setAlign = value;
                GenerateLayout();
            }
        }

        public enum NotificationPosition
        {
            MiddleCenter,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        private Font fontTopic = new Font("Segoe UI", 12F, FontStyle.Regular);
        private Font fontBody = new Font("Segoe UI", 10F, FontStyle.Regular);

        private int marginNotification = 10;

        private bool mouseIsIn = false;
        private bool formIsOpen = false;
        private int fadeDelay = 25;
        private double fadeSpeed = 0.1f;

        private Timer timerHideForm = new Timer();
        private Timer timerMousePosition = new Timer();

        private FormWithoutActivation form = new FormWithoutActivation();
        private Panel panelContainer = new Panel();
        private Label labelTopic = new Label();
        private Label labelBody = new Label();
        private PictureBox pictureIcon = new PictureBox();
        private FlatProgressBar progress = new FlatProgressBar();

        public DesktopNotification()
        {
            timerHideForm.Interval = 5000;
            timerHideForm.Tick += new EventHandler(timerHide_Tick);

            timerMousePosition.Interval = 50;
            timerMousePosition.Tick += new EventHandler(timerMouse_Tick);

            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.Manual;
            form.BackColor = setBorderColor;
            form.AutoScaleMode = AutoScaleMode.Dpi;
            form.ShowInTaskbar = false;
            form.Height = 100;
            form.Width = 340;
            form.MouseClick += new MouseEventHandler(form_Click);

            panelContainer.Top = 1;
            panelContainer.Left = 1;
            panelContainer.Width = form.Width - 2;
            panelContainer.Height = form.Height - 2;
            panelContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            panelContainer.BackColor = setBackColor;
            panelContainer.MouseClick += new MouseEventHandler(form_Click);

            labelTopic.AutoSize = false;
            labelTopic.Left = 0;
            labelTopic.Top = 0;
            labelTopic.Width = form.Width - marginLabelLeft - marginLabelRight;
            labelTopic.Height = 25;
            labelTopic.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            labelTopic.TextAlign = ContentAlignment.MiddleLeft;
            labelTopic.ForeColor = setTopicColor;
            //labelTopic.BackColor = Color.Red;
            labelTopic.Font = fontTopic;
            labelTopic.MouseClick += new MouseEventHandler(form_Click);

            labelBody.AutoSize = false;
            labelBody.Left = 0;
            labelBody.Top = 0;
            labelBody.Width = form.Width - marginLabelLeft - marginLabelRight;
            labelBody.Height = 25;
            labelBody.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            labelBody.TextAlign = ContentAlignment.MiddleLeft;
            labelBody.ForeColor = setBodyColor;
            //labelBody.BackColor = Color.Red;
            labelBody.Font = fontBody;
            labelBody.MouseClick += new MouseEventHandler(form_Click);

            pictureIcon.Width = 32;
            pictureIcon.Height = 32;
            pictureIcon.Left = 0;
            pictureIcon.Top = 0;
            pictureIcon.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            pictureIcon.SizeMode = PictureBoxSizeMode.Normal;
            pictureIcon.Image = null;
            pictureIcon.MouseClick += new MouseEventHandler(form_Click);

            progress.Width = form.Width - (marginProgressLeftRight * 2);
            progress.Height = 12;
            progress.Left = 0;
            progress.Top = 0;
            progress.Maximum = 100;
            progress.Value = 0;
            progress.ForeColor = setProgressForeColor;
            progress.BackColor = setProgressBackColor;
            progress.MouseDown += new MouseEventHandler(progress_MouseDown);
            progress.MouseUp += new MouseEventHandler(progress_MouseUp);
            progress.MouseMove += new MouseEventHandler(progress_MouseMove);

            form.Controls.Add(panelContainer);
            panelContainer.Controls.Add(labelTopic);
            panelContainer.Controls.Add(labelBody);
            panelContainer.Controls.Add(pictureIcon);
            panelContainer.Controls.Add(progress);

            form.Opacity = 0.0f;
            form.Show();
        }

        private int marginLabelTop = 8;
        private int marginLabelLeft = 8;
        private int marginLabelRight = 8;
        //private int marginLabelBottom = 8;

        private int marginLabelTopicBottom = 5;
        private int marginLabelBodyBottom = 12;
        private int marginProgressBottom = 16;
        private int marginProgressLeftRight = 16;

        private int marginPicture = 14;

        private void GenerateLayout()
        {
            int totalHeight = marginLabelTop;

            labelTopic.Top = totalHeight;
            Size labelTopicSize = TextRenderer.MeasureText(labelTopic.Text, fontTopic, new Size(labelTopic.Width, 0), TextFormatFlags.WordBreak);
            labelTopic.Height = labelTopicSize.Height;
            totalHeight += labelTopicSize.Height + marginLabelTopicBottom;

            labelBody.Top = totalHeight;
            Size labelBodySize = TextRenderer.MeasureText(labelBody.Text, fontBody, new Size(labelBody.Width, 0), TextFormatFlags.WordBreak);
            labelBody.Height = labelBodySize.Height;
            totalHeight += labelBodySize.Height + marginLabelBodyBottom;

            if (setShowProgress)
            {
                progress.Visible = true;
                progress.Top = totalHeight;
                totalHeight += progress.Height + marginProgressBottom;
            }

            else
            {
                progress.Visible = false;
            }

            form.Height = totalHeight;

            if (pictureIcon.Image == null)
            {
                pictureIcon.Width = 0;
                pictureIcon.Height = 0;
                progress.Width = form.Width - (marginProgressLeftRight * 2);
                progress.Left = marginProgressLeftRight;

                labelTopic.Width = labelBody.Width = form.Width - marginLabelLeft - marginLabelRight;
                labelTopic.Left = labelBody.Left = marginLabelLeft;
                
            }

            else
            {
                pictureIcon.Width = pictureIcon.Image.Width;
                pictureIcon.Height = pictureIcon.Image.Height;
                pictureIcon.Left = marginPicture;
                pictureIcon.Top = marginPicture;

                progress.Width = form.Width - (marginProgressLeftRight * 2);
                progress.Left = marginProgressLeftRight;

                labelTopic.Width = labelBody.Width = form.Width - marginLabelLeft - marginLabelRight - marginLabelLeft - pictureIcon.Width;
                labelTopic.Left = labelBody.Left = pictureIcon.Right + marginLabelLeft;
            }

            Screen screen = Screen.PrimaryScreen;

            if (setAlign == NotificationPosition.MiddleCenter)
            {
                form.Left = screen.WorkingArea.Left + (screen.WorkingArea.Width / 2) - (form.Width / 2);
                form.Top = screen.WorkingArea.Top + (screen.WorkingArea.Height / 2) - (form.Height / 2);
            }

            else if (setAlign == NotificationPosition.BottomLeft)
            {
                form.Left = screen.WorkingArea.Left + marginNotification;
                form.Top = screen.WorkingArea.Top + (screen.WorkingArea.Height - form.Height - marginNotification);
            }

            else if (setAlign == NotificationPosition.BottomCenter)
            {
                form.Left = screen.WorkingArea.Left + (screen.WorkingArea.Width / 2) - (form.Width / 2);
                form.Top = screen.WorkingArea.Top + (screen.WorkingArea.Height - form.Height - marginNotification);
            }

            else if (setAlign == NotificationPosition.BottomRight)
            {
                form.Left = screen.WorkingArea.Left + (screen.WorkingArea.Width - form.Width - marginNotification);
                form.Top = screen.WorkingArea.Top + (screen.WorkingArea.Height - form.Height - marginNotification);
            }
        }

        public void ShowNotification()
        {
            form.Show();
            Application.DoEvents();

            timerHideForm.Stop();
            timerHideForm.Start();
            timerMousePosition.Start();

            if (!formIsOpen) FadeIn();
            formIsOpen = true;
        }

        public void HideNotification()
        {
            timerHideForm.Stop();
            timerMousePosition.Stop();

            if (formIsOpen)
            {
                SendHideEvent();
                FadeOut();
            }

            formIsOpen = false;
            form.Hide();
        }

        private void FadeIn()
        {
            for (double i = 0.0f; i < 1.0f; i += fadeSpeed)
            {
                form.Opacity = i;
                System.Threading.Thread.Sleep(fadeDelay);
            }

            form.Opacity = 1.0f;
        }

        private void FadeOut()
        {
            for (double i = 1.0f; i > 0.0f; i -= fadeSpeed)
            {
                form.Opacity = i;
                System.Threading.Thread.Sleep(fadeDelay);
            }

            form.Opacity = 0.0f;
        }

        private void progress_MouseDown(Object sender, MouseEventArgs e)
        {
            SendProgressValue(e.Location.X, true);
        }

        private void progress_MouseUp(Object sender, MouseEventArgs e)
        {
            SendProgressValue(e.Location.X, false);
        }

        private void progress_MouseMove(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) SendProgressValue(e.Location.X, true);
        }

        private void SendProgressValue(int location, bool pressed)
        {
            if (location < 0) location = 0;
            else if (location > progress.Width) location = progress.Width;

            int prog = (int)(((double)location / (double)progress.Width) * 100);
            SendProgressEvent(prog, pressed);
        }

        private void form_Click(Object sender, MouseEventArgs e)
        {
            SendClickEvent();
        }

        private void timerHide_Tick (Object sender, EventArgs e)
        {
            HideNotification();
        }

        private void timerMouse_Tick(Object sender, EventArgs e)
        {
            Point position = form.PointToClient(Cursor.Position);

            if (form.ClientRectangle.Contains(position))
            {
                if (!mouseIsIn)
                {
                    form.BackColor = setBorderHighlightColor;
                    timerHideForm.Stop();
                }

                mouseIsIn = true;
            }

            else
            {
                if (mouseIsIn)
                {
                    form.BackColor = setBorderColor;
                    timerHideForm.Start();
                }

                mouseIsIn = false;
            }


        }

    }

    /// <summary>
    /// Custom form to open notification without stealing focus
    /// </summary>
    class FormWithoutActivation : Form
    {
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        }
    }

    /// <summary>
    /// Custom drawn flat style progressbar
    /// </summary>
    class FlatProgressBar : ProgressBar
    {
        public FlatProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Image offscreenImage = new Bitmap(this.Width, this.Height))
            {
                using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                {
                    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                    SolidBrush brushWhite = new SolidBrush(this.ForeColor);
                    SolidBrush brushGray = new SolidBrush(this.BackColor);

                    offscreen.FillRectangle(brushGray, 0, 0, rect.Width, rect.Height);

                    rect.Width = (int)(rect.Width * ((double)this.Value / this.Maximum));
                    if (rect.Width == 0) rect.Width = 1;
                    if (Value > 0) offscreen.FillRectangle(brushWhite, 0, 0, rect.Width, rect.Height);

                    e.Graphics.DrawImage(offscreenImage, 0, 0);
                    offscreenImage.Dispose();
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }
    }
}