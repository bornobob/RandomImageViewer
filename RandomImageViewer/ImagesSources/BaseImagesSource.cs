using RandomImageViewer.Enums;
using RandomImageViewer.Interfaces;
using RandomImageViewer.SourceModels;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomImageViewer.ImagesSources
{
    public abstract class BaseImagesSource<T> : IImagesSource where T: BaseModel 
    {
        public event ImageSourceDeleteHandler ImageSourceDelete;
        public event ImageSourceUpdatedHandler ImageSourceUpdated;

        protected T _model;
        protected BaseImagesSource(T model)
        {
            _model = model;
            _model.ModelChanged += ModelChanged;
            _model.ModelDelete += ImageSourceDeleteHandler;
        }

        private void ImageSourceDeleteHandler()
        {
            ImageSourceDelete?.Invoke();
        }

        private void ModelChanged()
        {
            IndexImages();
            ImageSourceUpdated?.Invoke();
        }

        [JsonPropertyName("SourceType")]
        public SourceType SourceType
        {
            get { return GetImageType(); }
        }

        [JsonPropertyName("Data")]
        public T Model {
            get { return _model; } 
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public int GetNrImages()
        {
            if (_model.Enabled) return NumberOfImages();
            return 0;
        }

        public bool PrepareNextImage()
        {
            if (_model.Enabled) return PrepareNextSequentialImage();
            return true;
        }

        public abstract IImage GetCurrentImage();
        public abstract IEnumerable<IImage> GetImages();
        public abstract SourceType GetImageType();
        protected abstract int NumberOfImages();
        public abstract string GetSourcePath();
        public abstract void IndexImages();
        public abstract bool PrepareNextSequentialImage();
        public abstract void PrepareRandomImage();
    }
}
