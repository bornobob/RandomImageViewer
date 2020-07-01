using System.Drawing;

namespace RandomImageViewer.Interfaces
{
    public interface IThumbnailCreator
    {
        Bitmap CreateThumbnail(IImage image, Size size);
    }
}
