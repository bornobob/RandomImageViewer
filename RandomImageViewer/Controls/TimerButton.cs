using System;
using System.Drawing;
using System.Windows.Forms;

namespace RandomImageViewer.Controls
{
    public partial class TimerButton : Button
    {
        private int _duration;
        private const int TIMER_INTERVAL = 100;
        private DateTime _currentEndDate;
        private readonly Timer _updateTimeTimer;

        public TimerButton()
        {
            InitializeComponent();
            _updateTimeTimer = new Timer();
            _updateTimeTimer.Interval = TIMER_INTERVAL;
            _updateTimeTimer.Tick += UpdateLineTimer_Tick;
        }

        private void UpdateLineTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void ResetTimer()
        {
            _currentEndDate = DateTime.Now.AddSeconds(_duration);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (_updateTimeTimer.Enabled)
            {
                Pen p = new Pen(Color.DarkRed, 3f);
                int dMs = (int) (_currentEndDate - DateTime.Now).TotalMilliseconds;
                float xTo = ((_duration * 1000 - dMs) * this.Width) / (_duration);
                pe.Graphics.DrawLine(p, 2, this.Height - 1, Math.Min(xTo, this.Width - 2), this.Height - 1);
            }
        }

        public void SetEnabled(bool enabled, int duration)
        {
            _duration = duration;
            if (enabled)
            {
                ResetTimer();
                _updateTimeTimer.Start();
            } else
            {
                _updateTimeTimer.Stop();
            }
            Invalidate();
        }

    }
}
