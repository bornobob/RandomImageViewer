using RandomImageViewer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomImageViewer
{
    public class ImageList
    {
        private readonly List<IImagesSource> _imageSources;
        private IImagesSource _currentImageSource;
        private readonly WeightedRandom _weightedRandom;

        public ImageList()
        {
            _imageSources = new List<IImagesSource>();
            _currentImageSource = null;
            _weightedRandom = new WeightedRandom();
        }

        public IImage GetCurrentImage()
        {
            return _currentImageSource?.GetCurrentImage();
        }

        public string Serialize()
        {
            var serializedSources = new string[_imageSources.Count];
            for (int i=0; i < _imageSources.Count; i++) 
            {
                serializedSources[i] = _imageSources[i].Serialize();
            }
            return "[" + string.Join(",", serializedSources) + "]";
        }

        private void LoadRandomImage()
        {
            _currentImageSource = _weightedRandom.Random(_imageSources.ToArray(), _imageSources.Select(i => i.GetNrImages()).ToArray());
            _currentImageSource.PrepareRandomImage();
        }

        private void LoadNextImage()
        {
            if (_currentImageSource == null) _currentImageSource = _imageSources.First();

            bool nextSource = _currentImageSource.PrepareNextImage();
            if (nextSource)
            {
                _currentImageSource = _imageSources[(_imageSources.IndexOf(_currentImageSource) + 1) % _imageSources.Count];
                LoadNextImage();
            }
        }

        public bool LoadNextImage(bool random)
        {
            if (_imageSources.All(i => i.GetNrImages() == 0)) return false;
            if (random)
            {
                LoadRandomImage();
            } else
            {
                LoadNextImage();
            }
            return true;
        }

        public void AddImageSource(IImagesSource imageSource)
        {
            imageSource.ImageSourceDelete += () => { _imageSources.Remove(imageSource); if (_currentImageSource == imageSource) _currentImageSource = null; };
            _imageSources.Add(imageSource);
        }

        public int GetTotalImages()
        {
            return _imageSources.Sum(i => i.GetNrImages());
        }

        public void DeleteImagesSource(IImagesSource imagesSource)
        {
            if (_currentImageSource.Equals(imagesSource))
            {
                _currentImageSource = _imageSources[(_imageSources.IndexOf(_currentImageSource) + 1) % _imageSources.Count];
            }
            this._imageSources.Remove(imagesSource);
        }

        public void DeleteAllSources()
        {
            _imageSources.Clear();
            _currentImageSource = null;
        }
    }
}
