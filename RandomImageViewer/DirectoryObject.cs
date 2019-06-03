using System.Collections.Generic;
using System.IO;

namespace RandomImageViewer
{
    public class DirectoryObject
    {
        private string Path;
        private SearchOption TraverseSubdirectories;
        private bool Enabled;

        public DirectoryObject(string path, bool traverseSubdirectories, bool enabled)
        {
            this.Path = path;
            this.Enabled = enabled;
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

        public override bool Equals(object obj)
        {
            return obj is DirectoryObject @object &&
                   Path == @object.Path &&
                   TraverseSubdirectories == @object.TraverseSubdirectories &&
                   Enabled == @object.Enabled;
        }

        public override int GetHashCode()
        {
            var hashCode = -850920300;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Path);
            hashCode = hashCode * -1521134295 + TraverseSubdirectories.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(Enabled);
            return hashCode;
        }

        public bool IsEnabled()
        {
            return this.Enabled;
        }
    }
}
