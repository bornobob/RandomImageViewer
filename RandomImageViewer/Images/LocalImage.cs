using System.Drawing;
using RandomImageViewer.Interfaces;

namespace RandomImageViewer.Images
{
    public class LocalImage : IImage
    {
        private readonly string _path;

        public LocalImage(string path)
        {
            _path = path;
        }

        public Bitmap GetBitmap()
        {
            return new Bitmap(_path);
        }

        public Enums.ImageType GetImageType()
        {
            return Enums.ImageType.LocalImage;
        }

        public string GetPath()
        {
            return _path;
        }

        public bool IsDownloadable()
        {
            return false;
        }
    }
}
