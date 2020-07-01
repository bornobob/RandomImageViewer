namespace RandomImageViewer.SourceModels
{
    public class LocalImagesModel : BaseModel
    {
        private Enums.DirectorySetting _directorySetting;
        public Enums.DirectorySetting DirectorySetting
        {
            get { return _directorySetting; }
            set { _directorySetting = value; CallModelChanged(); }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; CallModelChanged(); }
        }

        public override bool IsValid()
        {
            return System.IO.Directory.Exists(_path);
        }
    }
}
