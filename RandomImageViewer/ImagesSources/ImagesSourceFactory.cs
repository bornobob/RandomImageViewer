using RandomImageViewer.Interfaces;
using RandomImageViewer.SourceModels;
using System;

namespace RandomImageViewer.ImagesSources
{
    public static class ImagesSourceFactory
    {
        public static IImagesSource CreateImagesSource(BaseModel model)
        {
            if (!model.IsValid())
            {
                return null;
            }

            if (model.GetType() == typeof(LocalImagesModel))
            {
                return new LocalImagesSource((LocalImagesModel)model);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
