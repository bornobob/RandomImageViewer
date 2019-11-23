using RandomImageViewer.Enums;
using RandomImageViewer.Images;
using RandomImageViewer.Interfaces;
using RandomImageViewer.RandomGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace RandomImageViewer.ImagesSources
{
    public class LocalImagesSource : IImagesSource
    {
        private string _path;
        private List<LocalImage> _images;
        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
        private IRandomGenerator _randomGenerator;
        private DirectorySetting _directorySetting;

        public LocalImagesSource(string path, IEnumerable<string> indexedImages, DirectorySetting directorySetting) : this(path, indexedImages, directorySetting, new DefaultRandom())
        {
        }

        public LocalImagesSource(string path, IEnumerable<string> indexedImages, DirectorySetting directorySetting, IRandomGenerator randomGenerator)
        {
            _path = path;
            _randomGenerator = randomGenerator;
            _directorySetting = directorySetting;
            IndexImages(indexedImages);
        }

        public IEnumerable<IImage> GetImages()
        {
            return _images;
        }

        public Enums.ImageType GetImageType()
        {
            return Enums.ImageType.LocalImage;
        }

        public string GetSourcePath()
        {
            return _path;
        }

        public int GetTotalImages()
        {
            return _images.Count();
        }

        private SearchOption GetSearchOption()
        {
            switch (_directorySetting)
            {
                case DirectorySetting.ExcludeSubdirectories:
                    return SearchOption.TopDirectoryOnly;
                case DirectorySetting.IncludeSubdirectories:
                    return SearchOption.AllDirectories;
            }
            throw new Exception("Encountered unknown DirectorySetting value");
        }

        private void IndexImages(IEnumerable<string> indexedImages)
        {
            var files = Directory.EnumerateFiles(_path, "*", GetSearchOption())     // enumerate though all files in the path with the given searchoption
                .Where(i => !indexedImages.Contains(i))                             // filter out images that are already indexed
                .Where(i => allowedExtensions.Where(ext => i.EndsWith(ext)).Any())  // filter out images with an invalid extension
                .Select(i => new LocalImage(i));                                    // create LocalImages

            _images = new List<LocalImage>(files);
        }

        public void Reload(IEnumerable<string> indexedImages)
        {
            IndexImages(indexedImages);
        }

        public IImage GetRandomImage()
        {
            return _images[_randomGenerator.Next(GetTotalImages())];
        }
    }
}
