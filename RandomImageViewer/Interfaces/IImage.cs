using System.Drawing;

namespace RandomImageViewer.Interfaces
{
    public interface IImage
    {
        string GetPath();

        string GetDirectoryPath();

        string GetImageName();

        Bitmap GetBitmap();

        Enums.ImageType GetImageType();
    }
}
