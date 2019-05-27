using System;
using System.Drawing;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class TimerButton : Button
    {
        private int Duration;
        private int TimerInterval = 100;
        private DateTime CurrentEndDate;
        private Timer UpdateLineTimer;

        public TimerButton()
        {
            InitializeComponent();
            UpdateLineTimer = new Timer();
            UpdateLineTimer.Interval = TimerInterval;
            UpdateLineTimer.Tick += UpdateLineTimer_Tick;
        }

        private void UpdateLineTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void ResetTimer()
        {
            CurrentEndDate = DateTime.Now.AddSeconds(Duration);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (UpdateLineTimer.Enabled)
            {
                Pen p = new Pen(Color.DarkRed, 3f);
                int dMs = (int) (CurrentEndDate - DateTime.Now).TotalMilliseconds;
                float xTo = ((Duration * 1000 - dMs) * this.Width) / (Duration);
                pe.Graphics.DrawLine(p, 2, this.Height - 1, Math.Min(xTo, this.Width - 2), this.Height - 1);
            }
        }

        public void SetEnabled(bool enabled, int duration)
        {
            Duration = duration;
            if (enabled)
            {
                ResetTimer();
                UpdateLineTimer.Start();
            } else
            {
                UpdateLineTimer.Stop();
            }
            Invalidate();
        }

    }
}
