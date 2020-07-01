using RandomImageViewer.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RandomImageViewer.Controls
{
    public delegate void ImageSelectedEventHandler(IImage image);

    public partial class Thumbnails : UserControl
    {
        public event ImageSelectedEventHandler ImageSelected;
        private readonly List<SelectablePictureBox> _images;
        private SelectablePictureBox _selected;
        private readonly IThumbnailCreator _thumbnailCreator;

        public Thumbnails(IThumbnailCreator thumbnailCreator)
        {
            InitializeComponent();
            this._images = new List<SelectablePictureBox>();
            _selected = null;
            _thumbnailCreator = thumbnailCreator;
        }

        public void AddHistoryThumbnail(IImage image)
        {
            SelectablePictureBox pictureBox = new SelectablePictureBox(image, _thumbnailCreator)
            {
                Width = this.Width / 10,
                Height = this.Height
            };
            _selected?.SetSelected(false);
            pictureBox.SetSelected(true);
            _selected = pictureBox;
            pictureBox.MouseClick += new MouseEventHandler(HistoryPanel_MouseDown);
            Controls.Add(pictureBox);
            _images.Insert(0, pictureBox);

            if (_images.Count > 10)
            {
                SelectablePictureBox thumbnail = _images[_images.Count - 1];
                Controls.Remove(thumbnail);
                thumbnail.Image.Dispose();
                thumbnail.Dispose();
                _images.RemoveAt(_images.Count - 1);
            }
            ResizeThumbnails();
        }

        private void ResizeThumbnails()
        {
            int width = this.Width / 10;
            foreach (Control c in Controls)
            {
                c.Width = width;
            }
            int count = 0;
            foreach (SelectablePictureBox pictureBox in _images)
            {
                pictureBox.Location = new Point(count * pictureBox.Width, 0);
                count++;
            }
        }

        private void SelectThumbnail(SelectablePictureBox newSelection)
        {
            if (newSelection != _selected)
            {
                _selected?.SetSelected(false);
                newSelection.SetSelected(true);
                _selected = newSelection;
                ImageSelected?.Invoke(newSelection.GetImage());
            }
        }

        private void HistoryPanel_MouseDown(object sender, MouseEventArgs e)
        {
            var pictureBox = (SelectablePictureBox)sender;
            SelectThumbnail(pictureBox);
        }

        public void SelectNext()
        {
            for (int i = 0; i < _images.Count; i++)
            {
                if (_images[i].GetSelected() && i < this._images.Count - 1)
                {
                    _images[i].SetSelected(false);
                    _images[i + 1].SetSelected(true);
                    _selected = _images[i + 1];
                    ImageSelected?.Invoke(_images[i + 1].GetImage());
                    break;
                }
            }
        }

        public void SelectPrevious()
        {
            for (int i = 1; i < _images.Count; i++)
            {
                if (_images[i].GetSelected())
                {
                    _images[i].SetSelected(false);
                    _images[i - 1].SetSelected(true);
                    break;
                }
            }
        }

        private void Thumbnails_Resize(object sender, System.EventArgs e)
        {
            ResizeThumbnails();
        }
    }
}
