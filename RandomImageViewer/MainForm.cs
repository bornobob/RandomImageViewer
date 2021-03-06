﻿using System;
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
        private bool InSlideshow = false;
        private Thumbnails Thumbnails;
        private KeybindSettingsData KeybindSettings = new KeybindSettingsData();
        private ContextMenu PictureBoxContextMenu = new ContextMenu();
        private ImageList ImageList;

        public MainForm()
        {
            InitializeComponent();
            this.ImageList = new ImageList(NrImagesChanged, 10);
            this.Thumbnails = new Thumbnails(ImageList, ThumbnailSelected);
            HistoryPanel.Controls.Add(Thumbnails);
            Thumbnails.Dock = DockStyle.Fill;
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

            // Set the slideshow timing
            decimal value = Properties.Settings.Default.WaitDuration / 1000;
            if (value < SlideshowTiming.Minimum || value > SlideshowTiming.Maximum)
            {
                value = 1.5m;
            }
            SlideshowTiming.Value = value;

            // Add saved directories
            LoadDirectoriesFromSettings();

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

        private void LoadDirectoriesFromSettings()
        {
            if (Properties.Settings.Default.Paths != null)
            {
                foreach (string s in Properties.Settings.Default.Paths)
                {
                    string path;
                    bool enabled, option;
                    if (s.Contains("?"))
                    {
                        string[] args = s.Split('?');
                        path = args[0];
                        enabled = bool.Parse(args[1]);
                        option = bool.Parse(args[2]);
                    }
                    else  // Backward compatibility
                    {
                        path = s;
                        enabled = true;
                        option = Properties.Settings.Default.SearchOption == SearchOption.AllDirectories;
                    }
                    if (Directory.Exists(path))
                    {
                        AddDirectoryDirect(path, option, enabled);
                    }
                }
            }
        }

        private void AddDirectoryDirect(string path, bool subdirectories, bool enabled)
        {
            var inputDir = new InputDirControl(path, this.ImageList);
            inputDir.SetArgs(subdirectories, enabled);
            InputDirsPanel.Controls.Add(inputDir);
        }


        private void SaveSettings()
        {
            Properties.Settings.Default.RandomMode = RadioRandom.Checked;
            Properties.Settings.Default.Paths = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.WaitDuration = (int)(SlideshowTiming.Value * 1000);
            foreach (InputDirControl inputDir in this.InputDirsPanel.Controls)
            {
                string dir = inputDir.GetPath() + "?" + inputDir.IsEnabled() + "?" + inputDir.IncludeSubdirectories();
                Properties.Settings.Default.Paths.Add(dir);
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
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.PrevImage))
            {
                PreviousImage();
            }
            else if (e.KeyCode == (Keys)KeybindSettings.GetSetting(RandomImageViewer.KeybindSettings.ToggleSlideshow))
            {
                SlideshowButton_Click(this, null);
            }
        }

        private void ToggleSizeMode()
        {
            MainPictureBox.SizeMode = (MainPictureBox.SizeMode == PictureBoxSizeMode.Normal) ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
            ZoomFactor = 1m;
            SetPictureZoomSize();
        }

        private void Zoom(Keys keyCode)
        {
            if (ImageList.GetCurrentImage() != null && ImageList.GetCurrentImage().CanZoom() && MainPictureBox.SizeMode == PictureBoxSizeMode.Normal)
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
            Thumbnails.ResizeThumbnails();
        }

        private void ToggleHistory()
        {
            HistoryPanel.Visible = !HistoryPanel.Visible;
            if (!HistoryPanel.Visible)
            {
                pnlMain.Location = new Point(2, 2);
                pnlMain.Height += HistoryPanel.Height;
                Thumbnails.ResizeThumbnails();
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
            Thumbnails.SelectNext();
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
            pnlMain.AutoScroll = MainPictureBox.SizeMode != PictureBoxSizeMode.Zoom;
            if (ImageList.GetCurrentImage().CanZoom() && MainPictureBox.Image != null && pnlMain.AutoScroll)
            {
                MainPictureBox.Size = MainPictureBox.Image.Size;
            }
            else
            {
                MainPictureBox.Size = pnlMain.Size;
            }
        }

        private void SetPictureZoomSize()
        {
            ImageObject img = ImageList.GetCurrentImage();
            if (img != null)
            {
                if (MainPictureBox.Image != null)
                {
                    MainPictureBox.Image.Dispose();
                }
                if (img.CanZoom())
                {
                    MainPictureBox.Image = img.GetImage(this.ZoomFactor);
                }
                else
                {
                    MainPictureBox.ImageLocation = img.GetPath();
                    MainPictureBox.Load();
                }
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
                Thumbnails.AddHistoryThumbnail(img);
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
            Thumbnails.ResizeThumbnails();
        }

        private void ButtonAddDir_Click(object sender, EventArgs e)
        {
            AddDirectory();
        }


        private void AddDirectory()
        {
            AddDirectoryForm AddDirDialog = new AddDirectoryForm();
            if (AddDirDialog.ShowDialog(this) == DialogResult.OK)
            {
                var inputDir = new InputDirControl(AddDirDialog.GetPath(), this.ImageList);
                InputDirsPanel.Controls.Add(inputDir);
            }
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
            else if (e.Button == MouseButtons.Right && this.ImageList.GetCurrentImage() != null)
            {
                PictureBoxContextMenu.Show(MainPictureBox, e.Location);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                pnlMain.MiddleMouseClicked(e.Location);
            }
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            ImageList.ReIndex();
            SinkLabel.Focus();
        }

        private void RadioRandom_CheckedChanged(object sender, EventArgs e)
        {
            RadioSeq.Checked = !RadioRandom.Checked;
            _Mode = RadioRandom.Checked ? Mode.Random : Mode.Sequential;
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
            KeybindSettings.LoadSettings();
        }

        private void MainPictureBoxContextMenu_ItemClicked(object sender, EventArgs e)
        {
            string path = Path.Combine(ImageList.GetCurrentImage().GetDirectory(), ImageList.GetCurrentImage().GetFileName());
            string arg = "/select, \"" + path.Replace('/', '\\') + "\"";
            System.Diagnostics.Process.Start("explorer.exe", arg);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (KeybindSettings.GetSettingsContainArrowKeys() &&
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

        private void ThumbnailSelected()
        {
            ZoomFactor = 1m;
            SetImageDetailLabels(this.ImageList.GetCurrentImage());
            SetPictureZoomSize();
        }

        private void InputDirsPanel_ControlChanged(object sender, ControlEventArgs e)
        {
            ResetDirectoryLocations();
        }

        private void NrImagesChanged()
        {
            NoImagesLabel.Text = ImageList.GetTotalImages().ToString();
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
    }
}
