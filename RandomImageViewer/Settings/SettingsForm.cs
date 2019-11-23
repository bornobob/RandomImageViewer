using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RandomImageViewer.Enums;


namespace RandomImageViewer.Settings
{ 
    public partial class SettingsForm : Form
    {
        private Enums.KeybindSettings Editing = Enums.KeybindSettings.None;
        private KeybindSettings SettingsData;

        public SettingsForm()
        {
            InitializeComponent();
            ToggleButton.Tag = ToggleDeleteButton.Tag = Enums.KeybindSettings.ToggleZoom;
            ZoomInButton.Tag = ZoomInDeleteButton.Tag = Enums.KeybindSettings.ZoomIn;
            ZoomOutButton.Tag = ZoomOutDeleteButton.Tag = Enums.KeybindSettings.ZoomOut;
            HideOptionsButton.Tag = HideOptionsDeleteButton.Tag = Enums.KeybindSettings.HideOptions;
            HideThumbnailsButton.Tag = HideThumbnailsDeleteButton.Tag = Enums.KeybindSettings.HideThumbnails;
            CloseProgramButton.Tag = CloseProgramDeleteButton.Tag = Enums.KeybindSettings.QuitProgram;
            NextImageButton.Tag = NextImageDeleteButton.Tag = Enums.KeybindSettings.NextImage;
            PrevImageButton.Tag = PrevImageDeleteButton.Tag = Enums.KeybindSettings.PrevImage;
            ToggleSlideshowButton.Tag = ToggleSlideshowDeleteButton.Tag = Enums.KeybindSettings.ToggleSlideshow;

            SettingsData = new KeybindSettings();
            LoadTextboxes();
        }

        private void LoadTextboxes()
        {
            foreach (Control c in KeybindsGroupBox.Controls)
            {
                try
                {
                    TextBox box = (TextBox)c;
                    int value = SettingsData.GetSetting((Enums.KeybindSettings)box.Tag);
                    string text = "NONE";
                    if (value != -1)
                    {
                        text = ((Keys)SettingsData.GetSetting((Enums.KeybindSettings)box.Tag)).ToString();
                    }
                    box.Text = text; 
                }
                catch (InvalidCastException) { }
            }
        }

        private void ClickedSetting(object sender, MouseEventArgs e)
        {
            if (Editing == Enums.KeybindSettings.None)
            {
                TextBox clicked = (TextBox)sender;
                Editing = (Enums.KeybindSettings)clicked.Tag;
                clicked.Text = "...";
            }
        }

        private void KeydownSetting(object sender, KeyEventArgs e)
        {
            if (Editing != Enums.KeybindSettings.None)
            {
                TextBox typed = GetTextBoxByTag(Editing);

                if (Editing == (Enums.KeybindSettings)typed.Tag)
                {
                    int value = (int)e.KeyCode;
                    typed.Text = e.KeyCode.ToString();
                    Editing = Enums.KeybindSettings.None;
                    SettingsData.SetSetting((Enums.KeybindSettings)typed.Tag, value);
                    CheckForDuplicates();
                }
            }
        }

        private TextBox GetTextBoxByTag(Enums.KeybindSettings tag)
        {
            switch (tag)
            {
                case Enums.KeybindSettings.HideOptions:
                    return HideOptionsButton;
                case Enums.KeybindSettings.HideThumbnails:
                    return HideThumbnailsButton;
                case Enums.KeybindSettings.NextImage:
                    return NextImageButton;
                case Enums.KeybindSettings.QuitProgram:
                    return CloseProgramButton;
                case Enums.KeybindSettings.ToggleZoom:
                    return ToggleButton;
                case Enums.KeybindSettings.ZoomIn:
                    return ZoomInButton;
                case Enums.KeybindSettings.ZoomOut:
                    return ZoomOutButton;
                case Enums.KeybindSettings.PrevImage:
                    return PrevImageButton;
                case Enums.KeybindSettings.ToggleSlideshow:
                    return ToggleSlideshowButton;
                default:
                    return null;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SettingsData.SaveSettings();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        private void DeleteSettingButton_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            TextBox text = GetTextBoxByTag((Enums.KeybindSettings)s.Tag);
            text.BackColor = System.Drawing.Color.White;
            text.Text = "NONE";
            SettingsData.SetSetting((Enums.KeybindSettings)s.Tag, -1);
            CheckForDuplicates();
        }

        private Dictionary<int, List<TextBox>> GetPickedKeys()
        {
            Dictionary<int, List<TextBox>> pickedKeys = new Dictionary<int, List<TextBox>>();
            
            foreach (Enums.KeybindSettings s in (Enums.KeybindSettings[])Enum.GetValues(typeof(Enums.KeybindSettings)))
            {
                if (s != Enums.KeybindSettings.None)
                {
                    int value = SettingsData.GetSetting(s);
                    if (value != -1)
                    {
                        if (pickedKeys.ContainsKey(value))
                        {
                            pickedKeys[value].Add(GetTextBoxByTag(s));
                        }
                        else
                        {
                            pickedKeys.Add(value, new List<TextBox> { GetTextBoxByTag(s) });
                        }
                    }
                }
            }

            return pickedKeys;
        }

        private void CheckForDuplicates()
        {
            bool doubleKeys = false;

            foreach (List<TextBox> list in GetPickedKeys().Values)
            {
                if (list.Count > 1)
                {
                    doubleKeys = true;
                    foreach (TextBox t in list)
                    {
                        t.BackColor = System.Drawing.Color.DarkRed;
                    }
                }
                else
                {
                    list[0].BackColor = System.Drawing.Color.White;
                }
            }

            SaveButton.Enabled = !doubleKeys;
        }
    }
}
