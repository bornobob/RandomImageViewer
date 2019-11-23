using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class Thumbnails : UserControl
    {
        private List<SelectablePictureBox> Images;
        private ImageList ImageList;
        private ThumbnailClicked SelectedThumbnail;

        public Thumbnails(ImageList imageList, ThumbnailClicked thumbnailClicked)
        {
            InitializeComponent();
            this.ImageList = imageList;
            this.Images = new List<SelectablePictureBox>();
            this.SelectedThumbnail = thumbnailClicked;
        }

        public void AddHistoryThumbnail(ImageObject image)
        {
            SelectablePictureBox pictureBox = new SelectablePictureBox(image)
            {
                Width = this.Width / 10,
                Height = this.Height
            };
            DeselectThumbnails();
            pictureBox.SetSelected(true);
            pictureBox.MouseClick += new MouseEventHandler(HistoryPanel_MouseDown);
            this.Controls.Add(pictureBox);
            Images.Insert(0, pictureBox);

            if (Images.Count > 10)
            {
                SelectablePictureBox thumbnail = Images[Images.Count - 1];
                this.Controls.Remove(thumbnail);
                thumbnail.Dispose();
                Images.RemoveAt(Images.Count - 1);
            }
            ResizeThumbnails();
        }

        private void DeselectThumbnails()
        {
            foreach (Control c in this.Controls)
            {
                ((SelectablePictureBox)c).SetSelected(false);
            }
        }

        public void ResizeThumbnails()
        {
            int width = this.Width / 10;
            foreach (Control c in this.Controls)
            {
                c.Width = width;
            }
            int count = 0;
            foreach (SelectablePictureBox pictureBox in Images)
            {
                pictureBox.Location = new Point(count * pictureBox.Width, 0);
                count++;
            }
        }

        public delegate void ThumbnailClicked();
        private void SelectThumbnail(SelectablePictureBox selected)
        {
            if (Images.IndexOf(selected) != this.ImageList.GetSelectedHistoryIndex())
            {
                DeselectThumbnails();
                selected.SetSelected(true);
                ImageList.SelectHistoryImage(Images.IndexOf(selected));
                SelectedThumbnail();
            }
        }

        private void HistoryPanel_MouseDown(object sender, MouseEventArgs e)
        {
            SelectThumbnail((SelectablePictureBox)sender);
        }

        public void SelectNext()
        {
            for (int i = 0; i < this.Images.Count; i++)
            {
                if (Images[i].GetSelected() && i < this.Images.Count - 1)
                {
                    this.Images[i].SetSelected(false);
                    this.Images[i + 1].SetSelected(true);
                    break;
                }
            }
        }
    }
}
