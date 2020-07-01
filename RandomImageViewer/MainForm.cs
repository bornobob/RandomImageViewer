using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using RandomImageViewer.Settings;
using RandomImageViewer.Enums;
using RandomImageViewer.Interfaces;
using RandomImageViewer.ImagesSources;
using RandomImageViewer.SourceModels;
using RandomImageViewer.ThumbnailCreators;
using System.Text.Json;
using RandomImageViewer.SourceForms;
using RandomImageViewer.Controls;

namespace RandomImageViewer
{
    public partial class MainForm : Form
    {
        private ImageOrderMode _Mode;
        private ImageSizeMode _sizeMode = ImageSizeMode.FitToScreen;
        private decimal ZoomFactor = 1m;
        private bool InSlideshow = false;
        private readonly Thumbnails _thumbnails;
        private readonly Settings.KeybindSettings _keybindSettings = new Settings.KeybindSettings();
        private readonly ImageList _imageList;
        private string _openedSave = null;

        public MainForm()
        {
            InitializeComponent();
            this._imageList = new ImageList();
            _thumbnails = new Thumbnails(new DefaultThumbnailCreator());
            HistoryPanel.Controls.Add(_thumbnails);
            _thumbnails.Dock = DockStyle.Fill;
            _thumbnails.ImageSelected += ThumbnailSelected;
            LoadSettings();
            SetImage();
        }

        private void LoadSettings()
        {
            _Mode = Properties.Settings.Default.RandomMode ? ImageOrderMode.Random : ImageOrderMode.Sequential; // Set mode to random or sequential 
            RadioRandom.Checked = Properties.Settings.Default.RandomMode; // Set random or sequential radio buttons
            RadioSeq.Checked = !RadioRandom.Checked;

            // Set the slideshow timing
            decimal value = Properties.Settings.Default.WaitDuration / 1000;
            if (value < SlideshowTiming.Minimum || value > SlideshowTiming.Maximum)
            {
                value = 1.5m;
            }
            SlideshowTiming.Value = value;

            // Set window position
            if (Properties.Settings.Default.Location.X != -1 && Properties.Settings.Default.Location.Y != -1)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Properties.Settings.Default.Location;
            }

            // Open saved file
            if (Properties.Settings.Default.OpenedSave != null && File.Exists(Properties.Settings.Default.OpenedSave))
            {
                LoadFile(Properties.Settings.Default.OpenedSave);
            }

            this.WindowState = Properties.Settings.Default.State;
            if (this.WindowState == FormWindowState.Normal) this.Size = Properties.Settings.Default.WindowSize;
            SinkLabel.Focus();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.RandomMode = RadioRandom.Checked;
            Properties.Settings.Default.WaitDuration = (int)(SlideshowTiming.Value * 1000);
            Properties.Settings.Default.WindowSize = this.Size;
            Properties.Settings.Default.State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowSize = this.Size;
                Properties.Settings.Default.Location = this.Location;
            }
            Properties.Settings.Default.OpenedSave = _openedSave;
            Properties.Settings.Default.Save();
        }

        public void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.ToggleZoom))
            {
                ToggleSizeMode();
            }
            else if (e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.ZoomIn) || e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.ZoomOut))
            {
                Zoom(e.KeyCode);
            }
            else if (e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.NextImage))
            {
                SetImage(true);
            }
            else if (e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.HideOptions))
            {
                ToggleOptions();
            }
            else if (e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.QuitProgram))
            {
                this.Close();
            }
            else if (e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.HideThumbnails))
            {
                ToggleHistory();
            }
            else if (e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.PrevImage))
            {
                PreviousImage();
            }
            else if (e.KeyCode == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.ToggleSlideshow))
            {
                SlideshowButton_Click(this, null);
            }
        }

        private void Zoom(Keys key)
        {
            if (key == (Keys)_keybindSettings.GetSetting(Enums.KeybindSettings.ZoomIn))
            {
                ZoomFactor += (decimal)0.1;
            } else
            {
                ZoomFactor -= (decimal)0.1;
            }
            SetPictureFieldSize();
        }

        private void ToggleSizeMode()
        {
            _sizeMode = _sizeMode == ImageSizeMode.FitToScreen ? ImageSizeMode.Zoom : ImageSizeMode.FitToScreen;
            ZoomFactor = 1m;
            SetPictureFieldSize();
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
            SetPictureFieldSize();
        }

        private void ToggleHistory()
        {
            HistoryPanel.Visible = !HistoryPanel.Visible;
            if (!HistoryPanel.Visible)
            {
                pnlMain.Location = new Point(2, 2);
                pnlMain.Height += HistoryPanel.Height;
            }
            else
            {
                pnlMain.Height -= HistoryPanel.Height;
                pnlMain.Location = new Point(2, HistoryPanel.Height + HistoryPanel.Location.Y);
            }
            SetPictureFieldSize(); 
            SinkLabel.Focus();
            this.BringToFront();
        }

        private void PreviousImage()
        {
            _thumbnails.SelectNext();
            ResetTimer();
        }

        private void ResetTimer()
        {
            if (InSlideshow)
            {
                SlideshowTimer.Enabled = false;
                SlideshowTimer.Enabled = true;
                SlideshowButton.ResetTimer();
            }
        }

        private void SetPictureFieldSize()
        {
            pnlMain.AutoScroll = _sizeMode == ImageSizeMode.Zoom;
            if (MainPictureBox.Image != null && pnlMain.AutoScroll)
            {
                MainPictureBox.Size = CalculateZoomSize(MainPictureBox.Image.Size);
            }
            else
            {
                MainPictureBox.Size = pnlMain.Size;
            }
        }

        private Size CalculateZoomSize(Size baseSize)
        {
            return new Size(
                (int)(baseSize.Width * ZoomFactor), 
                (int)(baseSize.Height * ZoomFactor)
            );
        }

        private void LoadCurrentImage()
        {
            MainPictureBox.Image?.Dispose();
            MainPictureBox.ImageLocation = _imageList.GetCurrentImage().GetPath();
            MainPictureBox.Load();
            SetPictureFieldSize();
        }

        private void SetImage(bool manual = false)
        {
            bool success = _imageList.LoadNextImage(_Mode == ImageOrderMode.Random);
            if (success)
            {
                ZoomFactor = 1m;
                LoadCurrentImage();
                SetImageDetailLabels(_imageList.GetCurrentImage());
                _thumbnails.AddHistoryThumbnail(_imageList.GetCurrentImage());
                if (manual) ResetTimer();
            }
        }

        private void SetImageDetailLabels(IImage image)
        {
            CurrentImageLabel.Text = image.GetImageName();
            CurrentDirLabel.Text = image.GetDirectoryPath();
            this.Text = "Random Image Viewer - " + image.GetImageName();
            SinkLabel.Focus();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this._imageList.GetCurrentImage() != null)
            {
                SetPictureFieldSize();
            }
        }

        private void ButtonAddDir_Click(object sender, EventArgs e)
        {
            NewSourceForm newSource = new NewSourceForm();
            if (newSource.ShowDialog() == DialogResult.OK)
            {
                AddImagesSource(newSource.Model);
                _openedSave = null;
            }
        }

        private void AddImagesSource(BaseModel model)
        {
            Control newControl;
            if (model.GetType() == typeof(LocalImagesModel))
            {
                newControl = new InputDirControl((LocalImagesModel)model);
                model.ModelDelete += () => { InputDirsPanel.Controls.Remove(newControl); _openedSave = null; };
                IImagesSource imageSource = ImagesSourceFactory.CreateImagesSource(model);
                _imageList.AddImageSource(imageSource);
                imageSource.ImageSourceUpdated += NrImagesChanged;
            } 
            else
            {
                throw new Exception();
            }
            InputDirsPanel.Controls.Add(newControl);
            SinkLabel.Focus();
        }


        private void ResetDirectoryLocations()
        {
            var counter = 0;
            foreach (Control inputDir in InputDirsPanel.Controls)
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
            else if (e.Button == MouseButtons.Middle)
            {
                pnlMain.MiddleMouseClicked(e.Location);
            }
        }

        private void RadioRandom_CheckedChanged(object sender, EventArgs e)
        {
            RadioSeq.Checked = !RadioRandom.Checked;
            _Mode = RadioRandom.Checked ? ImageOrderMode.Random : ImageOrderMode.Sequential;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void SlideshowTimer_Tick(object sender, EventArgs e)
        {
            SetImage();
            SlideshowButton.ResetTimer();
        }

        private void SlideshowButton_Click(object sender, EventArgs e)
        {
            InSlideshow = !InSlideshow;
            SlideshowTimer.Interval = (int)(SlideshowTiming.Value * 1000);
            SlideshowButton.SetEnabled(InSlideshow, SlideshowTimer.Interval);
            SlideshowTimer.Enabled = InSlideshow;
            SlideshowButton.Text = InSlideshow ? "End Slideshow" : "Begin Slideshow";
            SinkLabel.Focus();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            (new SettingsForm()).ShowDialog();
            SinkLabel.Focus();
            _keybindSettings.LoadSettings();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_keybindSettings.GetSettingsContainArrowKeys() &&
                (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down))
            {
                frmMain_KeyDown(null, new KeyEventArgs(keyData));
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void ThumbnailSelected(IImage image)
        {
            ZoomFactor = 1m;
            SetImageDetailLabels(image);
            MainPictureBox.Image?.Dispose();
            MainPictureBox.ImageLocation = image.GetPath();
            MainPictureBox.Load();
            ResetTimer();
        }

        private void InputDirsPanel_ControlChanged(object sender, ControlEventArgs e)
        {
            ResetDirectoryLocations();
        }

        private void NrImagesChanged()
        {
            NoImagesLabel.Text = _imageList.GetTotalImages().ToString();
        }

        private void MainPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                pnlMain.MiddleMouseClicked(e.Location);
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            pnlMain.MouseMoved(e.Location);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "RIV Sources|*.json";
            saveFile.Title = "Save RIV Sources";
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFile.ShowDialog();

            if (saveFile.FileName != "")
            {
                var fs = new StreamWriter(saveFile.FileName);
                fs.Write(_imageList.Serialize());
                fs.Flush();
                fs.Close();
            }
            saveFile.Dispose();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "RIV Sources|*.json";
            openFile.Title = "Open RIV Sources";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFile.ShowDialog();

            if (openFile.FileName != "")
            {
                LoadFile(openFile.FileName);
            }
        }

        private void LoadFile(string path)
        {
            _imageList.DeleteAllSources();
            InputDirsPanel.Controls.Clear();

            var fs = new StreamReader(path);
            _openedSave = path;
            string data = fs.ReadToEnd();

            var settings = new JsonSerializerOptions
            {
                Converters = { new ImagesSourceModelConverter() }
            };

            List<BaseModel> models = (List<BaseModel>)JsonSerializer.Deserialize(data, typeof(List<BaseModel>), settings);
            foreach (var model in models)
            {
                IImagesSource imageSource = ImagesSourceFactory.CreateImagesSource(model);
                if (imageSource != null) // null if invalid
                {
                    _imageList.AddImageSource(imageSource);
                    imageSource.ImageSourceUpdated += NrImagesChanged;
                    AddImagesSource(model);
                }
            }
            fs.Close();
        }
    }
}
