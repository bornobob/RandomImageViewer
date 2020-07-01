using RandomImageViewer.Enums;
using RandomImageViewer.Images;
using RandomImageViewer.Interfaces;
using RandomImageViewer.RandomGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using RandomImageViewer.SourceModels;

namespace RandomImageViewer.ImagesSources
{
    public class LocalImagesSource : BaseImagesSource<LocalImagesModel>
    {
        private List<LocalImage> _images;
        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
        private readonly IRandomGenerator _randomGenerator;
        private int _currentIndex;

        public LocalImagesSource(LocalImagesModel model) : this(model, new DefaultRandom())
        {
        }

        public LocalImagesSource(LocalImagesModel model, IRandomGenerator randomGenerator) : base(model)
        {
            _randomGenerator = randomGenerator;
            _currentIndex = -1;
            IndexImages();
        }

        public override IEnumerable<IImage> GetImages()
        {
            return _images;
        }

        public override SourceType GetImageType()
        {
            return SourceType.LocalImage;
        }

        public override string GetSourcePath()
        {
            return _model.Path;
        }

        protected override int NumberOfImages()
        {
            return _images.Count();
        }

        private SearchOption GetSearchOption()
        {
            switch (_model.DirectorySetting)
            {
                case DirectorySetting.ExcludeSubdirectories:
                    return SearchOption.TopDirectoryOnly;
                case DirectorySetting.IncludeSubdirectories:
                    return SearchOption.AllDirectories;
            }
            throw new Exception("Encountered unknown DirectorySetting value");
        }

        public override void IndexImages()
        {
            var files = Directory.EnumerateFiles(_model.Path, "*", GetSearchOption())               // enumerate though all files in the path with the given searchoption
                .Where(i => allowedExtensions.Where(ext => i.EndsWith(ext)).Any())                  // filter out images with an invalid extension
                .Select(i => new LocalImage(i, ImageIsGif(i) ? ImageType.Gif : ImageType.Image));   // create LocalImages

            _images = new List<LocalImage>(files);
        }

        private bool ImageIsGif(string filename)
        {
            return filename.EndsWith(".gif");
        }

        public override void PrepareRandomImage()
        {
            _currentIndex = _randomGenerator.Next(_images.Count);
        }

        public override bool PrepareNextSequentialImage()
        {
            bool startOver = _currentIndex >= _images.Count - 1 && _currentIndex != -1;
            if (startOver)
            {
                _currentIndex = -1;
            }
            else
            {
                _currentIndex = (_currentIndex + 1) % _images.Count;
            }
            return startOver;
        }

        public override IImage GetCurrentImage()
        {
            return GetImageAtIndex(_currentIndex);
        }

        private IImage GetImageAtIndex(int index)
        {
            if (index < 0 || index >= _images.Count) throw new Exceptions.IndexOutOfRangeException(index);

            return _images[index];
        }
    }
}
