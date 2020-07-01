using RandomImageViewer.Interfaces;
using System.Drawing;

namespace RandomImageViewer.ThumbnailCreators
{
    public class DefaultThumbnailCreator : IThumbnailCreator
    {
        public Bitmap CreateThumbnail(IImage image, Size size)
        {
            decimal sizeFactor;
            using (var original = image.GetBitmap())
            {
                if (original.Width > original.Height)
                {
                    sizeFactor = size.Width / (decimal)original.Width;
                }
                else
                {
                    sizeFactor = size.Height / (decimal)original.Height;
                }
                sizeFactor *= 2m;
                return new Bitmap(original, new Size((int)(original.Width * sizeFactor), (int)(original.Height * sizeFactor)));
            }
        }
    }
}
