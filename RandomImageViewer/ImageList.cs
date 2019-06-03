using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public class ImageList
    {
        private List<DirectoryObject> Directories;
        private List<ImageObject> Images;
        private int CurrentIndex;
        private readonly Random Random;
        private int HistoryIndex;
        private int NrHistory;
        private ImageObject[] HistoryImages;
        private ContentChangedDelegate ContentChanged;

        public delegate void ContentChangedDelegate();
        public ImageList(ContentChangedDelegate contentChanged, int nrHistory = 10)
        {
            this.Directories = new List<DirectoryObject>();
            this.Images = new List<ImageObject>();
            this.CurrentIndex = 0;
            this.Random = new Random();
            this.HistoryIndex = 0;
            this.NrHistory = nrHistory;
            this.HistoryImages = new ImageObject[nrHistory];
            this.ContentChanged = contentChanged;
        }

        private void IndexImages()
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();

            this.Images.Clear();
            this.CurrentIndex = this.HistoryIndex = 0;

            HashSet<string> addedPaths = new HashSet<string>();
            foreach (DirectoryObject directory in this.Directories)
            {
                if (directory.IsEnabled())
                {
                    string path = directory.GetPath();
                    string[] pathsArray = Directory.GetFiles(path, "*", directory.GetSearchOption());

                    foreach (string p in pathsArray)
                    {
                        if (!addedPaths.Contains(p))
                        {
                            ImageObject temp = new ImageObject(p);
                            if (temp.ValidImage())
                            {
                                addedPaths.Add(p);
                                this.Images.Add(temp);
                            }
                        }
                    }
                }
            }

            Cursor.Current = Cursors.Default;

            ContentChanged();
        }

        public ImageObject GetCurrentImage()
        {
            return this.HistoryImages[this.HistoryIndex];
        }

        public ImageObject GetNextImage(bool random)
        {
            if (this.Images.Count == 0)
            {
                return null;
            } else
            {
                this.HistoryIndex = 0;
                Array.Copy(HistoryImages, 0, HistoryImages, 1, NrHistory - 1);
                if (!random)
                {
                    this.CurrentIndex = (this.CurrentIndex + 1) % this.Images.Count;
                } else
                {
                    this.CurrentIndex = this.Random.Next(this.Images.Count);
                }
                this.HistoryImages[0] = this.Images[this.CurrentIndex];
                return this.Images[this.CurrentIndex];
            }
        }

        public void SetDirectories(List<DirectoryObject> directories)
        {
            this.Directories = directories;
            IndexImages();
        }

        public void SelectHistoryImage(int index)
        {
            this.HistoryIndex = index;
        }

        public int GetSelectedHistoryIndex()
        {
            return this.HistoryIndex;
        }

        public int GetTotalImages()
        {
            return this.Images.Count;
        }

        public void SelectPreviousImage()
        {
            if (this.HistoryIndex < this.NrHistory - 1)
            {
                this.HistoryIndex += 1;
            }
        }

        public void DeleteDirectory(DirectoryObject directory)
        {
            this.Directories.Remove(directory);
            IndexImages();
        }

        public void AddDirectory(DirectoryObject directory)
        {
            if (!this.Directories.Contains(directory))
            {
                this.Directories.Add(directory);
                IndexImages();
            }
        }

        public void DirectoryChanged(DirectoryObject oldObject, DirectoryObject newObject)
        {
            this.Directories.Remove(oldObject);
            this.Directories.Add(newObject);
            IndexImages();
        }

        public void ReIndex()
        {
            IndexImages();
        }
    }
}
