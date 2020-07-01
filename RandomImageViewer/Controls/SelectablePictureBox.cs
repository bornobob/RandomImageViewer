using System.Windows.Forms;
using System.Drawing;
using System;
using RandomImageViewer.Interfaces;
using RandomImageViewer.Enums;

namespace RandomImageViewer.Controls
{
    public class SelectablePictureBox : PictureBox
    {
        private bool _selected = false;
        private readonly IImage _image;
        public IThumbnailCreator _thumbnailCreator;

        public SelectablePictureBox(IImage image, IThumbnailCreator thumbnailCreator)
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            _image = image;
            _thumbnailCreator = thumbnailCreator;
            SetImage();
            base.SizeChanged += new EventHandler(SizeChanged);
        }

        public void SetSelected(bool selected)
        {
            _selected = selected;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var color = _selected ? Color.Red : Color.LightGray;
            pe.Graphics.DrawRectangle(new Pen(color, 4f), new Rectangle(0, 0, this.Width, this.Height));
            if (_image.GetImageType() == ImageType.Gif)
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
            Bitmap thumbnail = _thumbnailCreator.CreateThumbnail(_image, new Size(this.Width, this.Height));
            this.Image = thumbnail;
        }

        private new void SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        public bool GetSelected()
        {
            return _selected;
        }

        public IImage GetImage()
        {
            return _image;
        }
    }
}
