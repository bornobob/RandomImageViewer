using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class MainForm : Form
    {
        private enum Mode
        {
            Random,
            Sequential
        }

        private Mode _Mode;
        private decimal ZoomFactor = 1m;
        private List<InputDirControl> InputDirs = new List<InputDirControl>();
        private bool InSlideshow = false;
        private List<SelectablePictureBox> Thumbnails = new List<SelectablePictureBox>();
        private KeybindSettingsData KeybindSettings = new KeybindSettingsData();
        private ContextMenu PictureBoxContextMenu = new ContextMenu();
        private SearchOption ImageLoadingSearchOption;
        private ImageList ImageList;

        public MainForm()
        {
            InitializeComponent();
            this.ImageList = new ImageList(10);
            AddMenuItems();
            LoadSettings();
            SetImage();
        }

        private void AddMenuItems()
        {
            var menuItem = new MenuItem("Open image in folder");
            menuItem.Click += new EventHandler(MainPictureBoxContextMenu_ItemClicked);
            PictureBoxContextMenu.MenuItems.Add(menuItem);
        }

        private void LoadSettings()
        {
            _Mode = Properties.Settings.Default.RandomMode ? Mode.Random : Mode.Sequential; // Set mode to random or sequential 
            RadioRandom.Checked = Properties.Settings.Default.RandomMode; // Set random or sequential radio buttons
            RadioSeq.Checked = !RadioRandom.Checked;
            TraverseSubdirectoriesCheckBox.Checked = Properties.Settings.Default.SearchOption == SearchOption.AllDirectories; // Set traverse subdirectories

            // Set the slideshow timing
            decimal value = Properties.Settings.Default.WaitDuration / 1000; 
            if (value < SlideshowTiming.Minimum || value > SlideshowTiming.Maximum)
            {
                value = 1.5m;
            }
            SlideshowTiming.Value = value;

            // Add saved directories
            if (Properties.Settings.Default.Paths != null)
            {
                foreach (string s in Properties.Settings.Default.Paths)
                {
                    if (Directory.Exists(s))
                    {
                        AddDirectoryDirect(s);
                    }
                }
                ReloadDirectories();
            }

            // Set window position
            if (Properties.Settings.Default.Location.X != -1 && Properties.Settings.Default.Location.Y != -1)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Properties.Settings.Default.Location;
            }
            
            this.WindowState = Properties.Settings.Default.State;
            if (this.WindowState == FormWindowState.Normal) this.Size = Properties.Settings.Default.WindowSize;
            SinkLabel.Focus();
        }

        private void AddDirectoryDirect(string path)
        {
            var inputDir = new InputDirControl(this, path);
            inputDir.Location = new Point(0, inputDir.Height * InputDirs.Count);
            InputDirsPanel.Controls.Add(inputDir);
            InputDirs.Add(inputDir);
        }

        private void ReloadDirectories()
        {
            List<DirectoryObject> directories = new List<DirectoryObject>();
            foreach (InputDirControl ic in this.InputDirs)
            {
                directories.Add(new DirectoryObject(ic.GetPath(), this.ImageLoadingSearchOption == SearchOption.AllDirectories));
            }
            this.ImageList.SetDirectories(directories);
            NoImagesLabel.Text = this.ImageList.GetTotalImages().ToString();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.RandomMode = RadioRandom.Checked;
            Properties.Settings.Default.Paths = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.WaitDuration = (int)(SlideshowTiming.Value * 1000);
            foreach (InputDirControl inputDir in InputDirs)
            {
                Properties.Settings.Default.Paths.Add(inputDir.GetPath());
            }
            Properties.Settings.Default.WindowSize = this.Size;
            Properties.Settings.Default.State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowSize = this.Size;
                Properties.Settings.Default.Location = this.Location;
            }
            Properties.Settings.Default.Save();
            Properties.Settings.Default.SearchOption = ImageLoadingSearchOption;
        }

        public void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ToggleZoom))
            {
                ToggleSizeMode();
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ZoomIn) || e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ZoomOut))
            {
                Zoom(e.KeyCode);
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.NextImage))
            {
                SetImage(true);
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.HideOptions))
            {
                ToggleOptions();            
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.QuitProgram))
            {
                this.Close();
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.HideThumbnails))
            {
                ToggleHistory();
            } else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.PrevImage))
            {
                PreviousImage();
            }
        }

        private void ToggleSizeMode()
        {
            if (MainPictureBox.SizeMode == PictureBoxSizeMode.Normal)
            {
                MainPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MainPictureBox.SizeMode = PictureBoxSizeMode.Normal;
            }
            ZoomFactor = 1m;
            SetPictureZoomSize();
        }

        private void Zoom(Keys keyCode)
        {
            if (MainPictureBox.SizeMode == PictureBoxSizeMode.Normal)
            {
                if (keyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ZoomIn))
                {
                    ZoomFactor *= 1.1m;
                }
                else
                {
                    ZoomFactor *= .9m;
                }
                SetPictureZoomSize();
            }
        }

        private void ToggleOptions()
        {
            OptionsPanel.Visible = !OptionsPanel.Visible;
            if (!OptionsPanel.Visible)
            {
                pnlMain.Width += OptionsPanel.Width;
                HistoryPanel.Width += OptionsPanel.Width;
            }
            else
            {
                pnlMain.Width -= OptionsPanel.Width;
                HistoryPanel.Width -= OptionsPanel.Width;
            }
            SetPictureZoomSize();
            ResizeThumbnails();
        }

        private void ToggleHistory()
        {
            HistoryPanel.Visible = !HistoryPanel.Visible;
            if (!HistoryPanel.Visible)
            {
                pnlMain.Location = new Point(2, 2);
                pnlMain.Height += HistoryPanel.Height;
                ResizeThumbnails();
            }
            else
            {
                pnlMain.Height -= HistoryPanel.Height;
                pnlMain.Location = new Point(2, HistoryPanel.Height + HistoryPanel.Location.Y);
            }
            SetPictureZoomSize();
            SinkLabel.Focus();
            this.BringToFront();
        }

        private void PreviousImage()
        {
            ImageList.SelectPreviousImage();
            SetPictureZoomSize();
            for (int i = 0; i < this.Thumbnails.Count; i++)
            {
                if (this.Thumbnails[i].GetSelected() && i < this.Thumbnails.Count - 1)
                {
                    this.Thumbnails[i].SetSelected(false);
                    this.Thumbnails[i + 1].SetSelected(true);
                    break;
                }
            }
            ResetTimer();
        }

        private void ResetTimer()
        {
            if (InSlideshow)
            {
                SlideshowTimer.Enabled = false;
                SlideshowTimer.Enabled = true;
            }
        }

        private void SetPictureFieldSize()
        {    
            if (MainPictureBox.SizeMode == PictureBoxSizeMode.Zoom)
            {
                MainPictureBox.Size = pnlMain.Size;
                pnlMain.AutoScroll = false;
            }
            else
            {
                MainPictureBox.Size = MainPictureBox.Image.Size;
                pnlMain.AutoScroll = true;
            }
        }

        private void SetPictureZoomSize()
        {
            ImageObject img = ImageList.GetCurrentImage();
            if (img != null)
            {
                MainPictureBox.Image = img.GetImage(this.ZoomFactor);
                SetPictureFieldSize();
            }
        }

        private void SetImage(bool manual = false)
        {
            ImageObject img = ImageList.GetNextImage(this._Mode == Mode.Random);
            if (img != null)
            {
                ZoomFactor = 1m;
                SetPictureZoomSize();
                AddHistoryThumbnail(img);
                SetImageDetailLabels(img);
                if (manual) ResetTimer();
            }
        }

        private void SetImageDetailLabels(ImageObject image)
        {
            CurrentImageLabel.Text = image.GetFileName();
            CurrentDirLabel.Text = image.GetDirectory();
            this.Text = "Random Image Viewer - " + image.GetFileName();
            SinkLabel.Focus();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.ImageList.GetCurrentImage() != null)
            {
                SetPictureZoomSize();
            }
            ResizeThumbnails();
        }

        private void ButtonAddDir_Click(object sender, EventArgs e)
        {
            AddDirectory();
        }

        private void AddDirectory()
        {
            AddDirectoryForm AddDirDialog = new AddDirectoryForm();
            switch (AddDirDialog.ShowDialog(this))
            {
                case DialogResult.OK:
                    var inputDir = new InputDirControl(this, AddDirDialog.GetPath());
                    inputDir.Location = new Point(0, inputDir.Height * InputDirs.Count);
                    InputDirsPanel.Controls.Add(inputDir);
                    InputDirs.Add(inputDir);
                    ReloadDirectories();
                    break;
            }
            SinkLabel.Focus();
        }

        public void DeleteDirectory(InputDirControl directory)
        {
            directory.Visible = false;
            InputDirs.Remove(directory);
            ResetDirectoryLocations();
            ReloadDirectories();
        }

        private void ResetDirectoryLocations()
        {
            var counter = 0;
            foreach (InputDirControl inputDir in InputDirs)
            {
                inputDir.Location = new Point(0, inputDir.Height * counter);
                counter++;
            }
        }

        private void MainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SinkLabel.Focus();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (this.ImageList.GetCurrentImage() != null)
                {
                    PictureBoxContextMenu.Show(MainPictureBox, e.Location);
                }
            }
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            ReloadDirectories();
            SinkLabel.Focus();
        }

        private void RadioRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioRandom.Checked)
            {
                RadioSeq.Checked = false;
                _Mode = Mode.Random;
            }
            else
            {
                RadioSeq.Checked = true;
                _Mode = Mode.Sequential;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void SlideshowTimer_Tick(object sender, EventArgs e)
        {
            SetImage();
        }

        private void SlideshowButton_Click(object sender, EventArgs e)
        {
            SlideshowTimer.Enabled = !InSlideshow;
            SlideshowTimer.Interval = (int)(SlideshowTiming.Value * 1000);
            if (InSlideshow)
            {
                SlideshowButton.Text = "Begin Slideshow";
                
            }
            else
            {
                SlideshowButton.Text = "End SlideShow";
            }
            InSlideshow = !InSlideshow;
            SinkLabel.Focus();
        }

        private void AddHistoryThumbnail(ImageObject image)
        {
            SelectablePictureBox pictureBox = new SelectablePictureBox(image)
            {
                Width = HistoryPanel.Width / 10,
                Height = HistoryPanel.Height
            };
            DeselectThumbnails();
            pictureBox.SetSelected(true);
            pictureBox.MouseClick += new MouseEventHandler(HistoryPanel_MouseDown);
            HistoryPanel.Controls.Add(pictureBox);
            Thumbnails.Insert(0, pictureBox);
            
            if (Thumbnails.Count > 10)
            {
                SelectablePictureBox thumbnail = Thumbnails[Thumbnails.Count - 1];
                HistoryPanel.Controls.Remove(thumbnail);
                thumbnail.Dispose();
                Thumbnails.RemoveAt(Thumbnails.Count - 1);
            }
            ResizeThumbnails();
        }

        private void DeselectThumbnails()
        {
            foreach (Control c in HistoryPanel.Controls)
            {
                ((SelectablePictureBox)c).SetSelected(false);
            }
        }

        private void ResizeThumbnails()
        {
            int width = HistoryPanel.Width / 10;
            foreach (Control c in HistoryPanel.Controls)
            {
                c.Width = width;
            }
            int count = 0;
            foreach (SelectablePictureBox pictureBox in Thumbnails)
            {
                pictureBox.Location = new Point(count * pictureBox.Width, 0);
                count++;
            }
        }

        private void SelectThumbnail(SelectablePictureBox selected)
        {
            if (Thumbnails.IndexOf(selected) != this.ImageList.GetSelectedHistoryIndex())
            {
                DeselectThumbnails();
                selected.SetSelected(true);
                ImageList.SelectHistoryImage(Thumbnails.IndexOf(selected));
                ZoomFactor = 1m;
                SetImageDetailLabels(this.ImageList.GetCurrentImage());
                SetPictureZoomSize();
            }
        }

        private void HistoryPanel_MouseDown(object sender, MouseEventArgs e)
        {
            SelectThumbnail((SelectablePictureBox)sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new SettingsForm()).ShowDialog();
            SinkLabel.Focus();
            KeybindSettings.LoadSettings();
        }

        private void MainPictureBoxContextMenu_ItemClicked(object sender, EventArgs e)
        {
            string path = Path.Combine(ImageList.GetCurrentImage().GetDirectory(), ImageList.GetCurrentImage().GetFileName());
            string arg = "/select, \"" + path.Replace('/', '\\') + "\"";
            System.Diagnostics.Process.Start("explorer.exe", arg);
        }

        private void TraverseSubdirectoriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TraverseSubdirectoriesCheckBox.Checked)
            {
                ImageLoadingSearchOption = SearchOption.AllDirectories;
            }
            else
            {
                ImageLoadingSearchOption = SearchOption.TopDirectoryOnly;
            }
            ReloadDirectories();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (KeybindSettings.GetSettingsContainArrowKeys() &&
                (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down))
            {
                frmMain_KeyDown(null, new KeyEventArgs(keyData));
                return true;
            } else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
