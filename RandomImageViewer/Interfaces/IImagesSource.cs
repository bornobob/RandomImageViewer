using System.Collections.Generic;

namespace RandomImageViewer.Interfaces
{
    public interface IImagesSource
    {
        /// <summary>
        /// Retrieve all the images in the iamges source
        /// </summary>
        /// <returns>List of <see cref="IImage"/> objects</returns>
        IEnumerable<IImage> GetImages();

        Enums.ImageType GetImageType();

        string GetSourcePath();

        int GetTotalImages();

        void Reload(IEnumerable<string> indexedImages);

        IImage GetRandomImage();
    }
}
