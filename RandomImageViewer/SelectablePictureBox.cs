﻿using System.IO;
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
            var color = Selected ? Color.Red : Color.LightGray;
            pe.Graphics.DrawRectangle(new Pen(color, 4f), new Rectangle(0, 0, this.Width, this.Height));
            if (_Image.GetImageType() == ImageType.Gif)
                PaintGifText(pe);
        }

        private void PaintGifText(PaintEventArgs pe) {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.LineAlignment = StringAlignment.Far;
            Rectangle bounding = new Rectangle(new Point(0, 0), this.Size);
            Font f = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Point);
            pe.Graphics.DrawString("GIF", f, Brushes.Black, bounding, stringFormat);
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

        public bool GetSelected()
        {
            return this.Selected;
        }
    }
}
