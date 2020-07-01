namespace RandomImageViewer.SourceModels
{
    public delegate void ModelChangedEventHandler();
    public delegate void ModelDeleted();
    public abstract class BaseModel
    {
        public event ModelChangedEventHandler ModelChanged;

        public event ModelDeleted ModelDelete;

        protected void CallModelChanged() {
            ModelChanged?.Invoke();
        }

        public void CallModelDelete()
        {
            ModelDelete?.Invoke();
        }

        private bool _enabled;
        public bool Enabled {
            get { return _enabled; }
            set { _enabled = value; CallModelChanged(); } 
        }

        public abstract bool IsValid();
    }
}
