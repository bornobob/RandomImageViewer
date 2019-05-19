using System.Drawing;

namespace RandomImageViewer
{
    public enum ImageType
    {
        Image,
        Gif,
        Invalid
    }

    public class ImageObject
    {
        private readonly string Path;
        private ImageType Type;

        public ImageObject(string path)
        {
            this.Path = path;
            SetType();
        }

        private void SetType()
        {
            if (
                this.Path.EndsWith(".jpg") ||
                this.Path.EndsWith(".png") ||
                this.Path.EndsWith(".jpeg") ||
                this.Path.EndsWith(".tiff")
                )
            {
                this.Type = ImageType.Image;
            }
            else if (
              this.Path.EndsWith(".gif")
              )
            {
                this.Type = ImageType.Gif;
            }
            else
            {
                this.Type = ImageType.Invalid;
            }

        }

        public Bitmap GetImage(decimal zoomfactor)
        {
            Bitmap original = new Bitmap(this.Path);
            Size s = new Size((int)(original.Width * zoomfactor), (int)(original.Height * zoomfactor));
            Bitmap resized = new Bitmap(original, s);
            original.Dispose();
            return resized;
        }

        public Bitmap GetThumbnail(Size size, decimal factor = 2m)
        {
            decimal sizeFactor;
            var original = new Bitmap(this.Path);
            if (original.Width > original.Height)
            {
                sizeFactor = (decimal)size.Width / (decimal)original.Width;
            }
            else
            {
                sizeFactor = (decimal)size.Height / (decimal)original.Height;
            }
            sizeFactor *= 2m; // In case the user later increases the window size
            Bitmap thumbnail = new Bitmap(original, new Size((int)(original.Width * sizeFactor), (int)(original.Height * sizeFactor)));
            original.Dispose();
            return thumbnail;
        }

        public bool ValidImage()
        {
            return Type != ImageType.Invalid;
        }

        public bool CanZoom()
        {
            return Type != ImageType.Gif;
        }

        public string GetFileName()
        {
            return System.IO.Path.GetFileName(this.Path);
        }

        public string GetDirectory()
        {
            return System.IO.Path.GetDirectoryName(this.Path);
        }
    }
}
