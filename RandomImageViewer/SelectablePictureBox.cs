using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace RandomImageViewer
{
    public class SelectablePictureBox : PictureBox
    {
        private bool Selected = false;
        private string Path;

        public SelectablePictureBox(string path)
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            Path = path;
            if (File.Exists(path))
            {
                SetImage(Image.FromFile(path));
            }
            base.SizeChanged += new EventHandler(this.SizeChanged);
        }

        public void SetSelected(bool selected)
        {
            Selected = selected;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var color = Color.LightGray;
            if (Selected)
            {
                color = Color.Red;
            }
            pe.Graphics.DrawRectangle(new Pen(color, 4f), new Rectangle(0, 0, this.Width, this.Height));
        }

        private void SetImage(Image img)
        {
            decimal Factor;
            if (img.Width > img.Height)
            {
                Factor = (decimal)this.Width / (decimal)img.Width;
            }
            else
            {
                Factor = (decimal)this.Height / (decimal)img.Height;
            }
            Factor *= 2m;
            Bitmap thumbnail = new Bitmap(img, new Size((int)(img.Width * Factor), (int)(img.Height * Factor)));
            this.Image = thumbnail;
        }

        private new void SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public string GetPath()
        {
            return Path;
        }
    }
}
