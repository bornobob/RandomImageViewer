using System.IO;

namespace RandomImageViewer
{
    public class DirectoryObject
    {
        private string Path;
        private SearchOption TraverseSubdirectories;

        public DirectoryObject(string path, bool traverseSubdirectories)
        {
            this.Path = path;
            SetTraverseSubdirectoriers(traverseSubdirectories);
        }

        public void SetTraverseSubdirectoriers(bool traverseSubdirectories)
        {
            this.TraverseSubdirectories = traverseSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        }

        public string GetPath()
        {
            return this.Path;
        }

        public SearchOption GetSearchOption()
        {
            return this.TraverseSubdirectories;
        }
    }
}
