using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace RandomImageViewer
{
    public class SelectablePictureBox : PictureBox
    {
        private bool Selected = false;
        private ImageObject _Image;

        public SelectablePictureBox(ImageObject image)
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this._Image = image;
            SetImage();
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

        private void SetImage()
        {
            Bitmap thumbnail = this._Image.GetThumbnail(this.Size);
            this.Image = thumbnail;
        }

        private new void SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public string GetPath()
        {
            return Path.Combine(this._Image.GetDirectory(), this._Image.GetFileName());
        }
    }
}
