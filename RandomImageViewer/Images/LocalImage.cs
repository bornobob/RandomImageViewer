using System.Drawing;
using RandomImageViewer.Enums;
using System.Linq;
using RandomImageViewer.Interfaces;

namespace RandomImageViewer.Images
{
    public class LocalImage : IImage
    {
        private readonly string _path;
        private readonly ImageType _imageType;

        public LocalImage(string path, ImageType imageType)
        {
            _path = path;
            _imageType = imageType;
        }

        public Bitmap GetBitmap()
        {
            return new Bitmap(_path);
        }

        public string GetDirectoryPath()
        {
            var splitPath = GetPath().Split(new char[] { '/', '\\' });
            return string.Join(System.IO.Path.DirectorySeparatorChar.ToString(), splitPath.Take(splitPath.Length - 1));
        }

        public string GetImageName()
        {
            var splitPath = GetPath().Split(new char[] { '/', '\\' });
            return splitPath[splitPath.Length - 1];
        }

        public SourceType GetImageType()
        {
            return SourceType.LocalImage;
        }

        public string GetPath()
        {
            return _path;
        }

        Enums.ImageType IImage.GetImageType()
        {
            return _imageType;
        }
    }
}
