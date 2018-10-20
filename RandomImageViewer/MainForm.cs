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
        private Bitmap CurrentImage;
        private decimal ZoomFactor;
        private List<string> ImagePaths = new List<string>();
        private static Random rnd = new Random();
        private List<InputDirControl> InputDirs = new List<InputDirControl>();
        private int LastIndex = 0;
        private bool InSlideshow = false;
        private int NumberOfThumbnails = 10;
        private List<SelectablePictureBox> Thumbnails = new List<SelectablePictureBox>();
        private int SelectedThumbnail = 0;
        private KeybindSettingsData KeybindSettings = new KeybindSettingsData();

        public MainForm()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Location.X != -1 && Properties.Settings.Default.Location.Y != -1)
            {
                this.StartPosition = FormStartPosition.Manual;
            }
            this.KeyPreview = true;

            LoadSettings();
        }

        private void LoadSettings()
        {
            if (Properties.Settings.Default.RandomMode)
            {
                _Mode = Mode.Random;
            }
            else
            {
                _Mode = Mode.Sequential;
            }
            RadioRandom.Checked = Properties.Settings.Default.RandomMode;
            RadioSeq.Checked = !RadioRandom.Checked;
            decimal value = Properties.Settings.Default.WaitDuration / 1000;
            if (value < SlideshowTiming.Minimum || value > SlideshowTiming.Maximum)
            {
                value = 1.5m;
            }
            SlideshowTiming.Value = value;
            if (Properties.Settings.Default.Paths != null)
            {
                foreach (string s in Properties.Settings.Default.Paths)
                {
                    if (Directory.Exists(s))
                    {
                        AddDirectoryDirect(s);
                    }
                }
                LoadImages();
            }
            if (this.StartPosition == FormStartPosition.Manual)
            {
                this.Location = Properties.Settings.Default.Location;
            }
            this.WindowState = Properties.Settings.Default.State;
            if (this.WindowState == FormWindowState.Normal) this.Size = Properties.Settings.Default.WindowSize;
        }

        private void AddDirectoryDirect(string path)
        {
            var inputDir = new InputDirControl(this, path);
            inputDir.Location = new Point(0, inputDir.Height * InputDirs.Count);
            InputDirsPanel.Controls.Add(inputDir);
            InputDirs.Add(inputDir);
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
        }

        private void LoadImages()
        {
            List<string> imgList = new List<string>();
            foreach (InputDirControl inputDir in InputDirs)
            {
                string path = inputDir.GetPath();
                string[] imgArray = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

                foreach (string s in imgArray)
                {
                    if (s.EndsWith(".jpg") || s.EndsWith(".png"))
                    {
                        if (!imgList.Contains(s))
                        {
                            imgList.Add(s);
                        }
                    }
                }
            }
            ImagePaths = new List<string>(imgList);
            NoImagesLabel.Text = ImagePaths.Count.ToString();
            LastIndex = 0;
            SetImage();
        }

        public void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ToggleZoom))
            {
                if (MainPictureBox.SizeMode == PictureBoxSizeMode.Normal)
                {
                    MainPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MainPictureBox.SizeMode = PictureBoxSizeMode.Normal;
                }
                ZoomFactor = 1;
                SetPictureZoomSize();
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ZoomIn) || e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ZoomOut))
            {
                if (MainPictureBox.SizeMode == PictureBoxSizeMode.Normal)
                {
                    if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ZoomIn))
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
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.NextImage))
            {
                SetImage(true);
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.HideOptions))
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
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.QuitProgram))
            {
                this.Close();
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
            Size s = new Size((int)(CurrentImage.Width * ZoomFactor), (int)(CurrentImage.Height * ZoomFactor));
            Bitmap img = new Bitmap(CurrentImage, s);
            MainPictureBox.Image = null;
            MainPictureBox.Image = img;
            SetPictureFieldSize();
        }

        private void SetImage(bool manual = false)
        {
            if (ImagePaths.Count > 0)
            {
                string path;
                if (_Mode == Mode.Random)
                {
                    int randomIndex = rnd.Next(ImagePaths.Count);
                    LastIndex = randomIndex;
                }
                else
                {
                    LastIndex++;
                    if (LastIndex >= ImagePaths.Count) LastIndex = 0;
                }
                path = ImagePaths[LastIndex];
                CurrentImage = new Bitmap(path);
                ZoomFactor = 1;
                SetPictureZoomSize();
                int lastBackslash = path.LastIndexOf('\\');
                CurrentImageLabel.Text = path.Substring(lastBackslash + 1, path.Length-lastBackslash-1);
                CurrentDirLabel.Text = path.Substring(0, lastBackslash);
                AddHistoryThumbnail(path);
                this.Text = "Random Image Viewer - " + path;
                if (manual && InSlideshow)
                {
                    SlideshowTimer.Enabled = false;
                    SlideshowTimer.Enabled = true;
                }
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (CurrentImage != null)
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
            AddDirDialog.StartPosition = FormStartPosition.CenterParent;
            switch (AddDirDialog.ShowDialog(this))
            {
                case DialogResult.OK:
                    var inputDir = new InputDirControl(this, AddDirDialog.GetPath());
                    inputDir.Location = new Point(0, inputDir.Height * InputDirs.Count);
                    InputDirsPanel.Controls.Add(inputDir);
                    InputDirs.Add(inputDir);
                    LoadImages();
                    break;
            }
            SinkLabel.Focus();
        }

        public void DeleteDirectory(InputDirControl directory)
        {
            directory.Visible = false;
            InputDirs.Remove(directory);
            ResetDirectoryLocations();
            LoadImages();
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
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            LoadImages();
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

        private void AddHistoryThumbnail(string path)
        {
            SelectablePictureBox pictureBox = new SelectablePictureBox(path)
            {
                Width = HistoryPanel.Width / 10,
                Height = HistoryPanel.Height
            };
            DeselectThumbnails();
            pictureBox.SetSelected(true);
            pictureBox.MouseClick += new MouseEventHandler(HistoryPanel_MouseDown);
            HistoryPanel.Controls.Add(pictureBox);
            Thumbnails.Insert(0, pictureBox);
            SelectedThumbnail = 0;
            while (Thumbnails.Count > NumberOfThumbnails)
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
            int width = HistoryPanel.Width / NumberOfThumbnails;
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
            if (Thumbnails.IndexOf(selected) != SelectedThumbnail)
            {
                DeselectThumbnails();
                selected.SetSelected(true);
                string path = selected.GetPath();
                CurrentImage = new Bitmap(path);
                int lastBackslash = path.LastIndexOf('\\');
                CurrentImageLabel.Text = path.Substring(lastBackslash + 1, path.Length - lastBackslash - 1);
                CurrentDirLabel.Text = path.Substring(0, lastBackslash);
                ZoomFactor = 1;
                this.Text = "Random Image Viewer - " + path;
                SetPictureZoomSize();
                SelectedThumbnail = Thumbnails.IndexOf(selected);
            }
        }

        private void HistoryPanel_MouseDown(object sender, MouseEventArgs e)
        {
            SelectThumbnail((SelectablePictureBox)sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new SettingsForm()
            {
                StartPosition = FormStartPosition.CenterParent
            }).ShowDialog();
            SinkLabel.Focus();
            KeybindSettings.LoadSettings();
        }
    }
}
