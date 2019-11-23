using System.Drawing;

namespace RandomImageViewer.Interfaces
{
    public interface IImage
    {
        string GetPath();

        bool IsDownloadable();

        Bitmap GetBitmap();
    }
}
