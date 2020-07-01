using System.Collections.Generic;

namespace RandomImageViewer.Interfaces
{
    public delegate void ImageSourceDeleteHandler();
    public delegate void ImageSourceUpdatedHandler();

    public interface IImagesSource
    {
        event ImageSourceDeleteHandler ImageSourceDelete;
        event ImageSourceUpdatedHandler ImageSourceUpdated;

        /// <summary>
        /// Retrieve all the images in the images source
        /// </summary>
        /// <returns>List of <see cref="IImage"/> objects</returns>
        IEnumerable<IImage> GetImages();

        Enums.SourceType GetImageType();

        string GetSourcePath();

        int GetNrImages();

        void IndexImages();

        void PrepareRandomImage();

        bool PrepareNextImage();

        IImage GetCurrentImage();

        string Serialize();
    }
}
