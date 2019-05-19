using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RandomImageViewer
{ 
    public partial class SettingsForm : Form
    {
        private KeybindSettings Editing = KeybindSettings.None;
        private KeybindSettingsData SettingsData;

        public SettingsForm()
        {
            InitializeComponent();
            ToggleButton.Tag = ToggleDeleteButton.Tag = KeybindSettings.ToggleZoom;
            ZoomInButton.Tag = ZoomInDeleteButton.Tag = KeybindSettings.ZoomIn;
            ZoomOutButton.Tag = ZoomOutDeleteButton.Tag = KeybindSettings.ZoomOut;
            HideOptionsButton.Tag = HideOptionsDeleteButton.Tag = KeybindSettings.HideOptions;
            HideThumbnailsButton.Tag = HideThumbnailsDeleteButton.Tag = KeybindSettings.HideThumbnails;
            CloseProgramButton.Tag = CloseProgramDeleteButton.Tag = KeybindSettings.QuitProgram;
            NextImageButton.Tag = NextImageDeleteButton.Tag = KeybindSettings.NextImage;

            SettingsData = new KeybindSettingsData();
            LoadTextboxes();
        }

        private void LoadTextboxes()
        {
            foreach (Control c in KeybindsGroupBox.Controls)
            {
                try
                {
                    TextBox box = (TextBox)c;
                    int value = SettingsData.GetSetting((KeybindSettings)box.Tag);
                    string text = "NONE";
                    if (value != -1)
                    {
                        text = ((Keys)SettingsData.GetSetting((KeybindSettings)box.Tag)).ToString();
                    }
                    box.Text = text; 
                }
                catch (InvalidCastException) { }
            }
        }

        private void ClickedSetting(object sender, MouseEventArgs e)
        {
            if (Editing == KeybindSettings.None)
            {
                TextBox clicked = (TextBox)sender;
                Editing = (KeybindSettings)clicked.Tag;
                clicked.Text = "...";
            }
        }

        private void KeydownSetting(object sender, KeyEventArgs e)
        {
            if (Editing != KeybindSettings.None)
            {
                TextBox typed = GetTextBoxByTag(Editing);

                if (Editing == (KeybindSettings)typed.Tag)
                {
                    int value = (int)e.KeyCode;
                    typed.Text = e.KeyCode.ToString();
                    Editing = KeybindSettings.None;
                    SettingsData.SetSetting((KeybindSettings)typed.Tag, value);
                    CheckForDuplicates();
                }
            }
        }

        private TextBox GetTextBoxByTag(KeybindSettings tag)
        {
            switch (tag)
            {
                case KeybindSettings.HideOptions:
                    return HideOptionsButton;
                case KeybindSettings.HideThumbnails:
                    return HideThumbnailsButton;
                case KeybindSettings.NextImage:
                    return NextImageButton;
                case KeybindSettings.QuitProgram:
                    return CloseProgramButton;
                case KeybindSettings.ToggleZoom:
                    return ToggleButton;
                case KeybindSettings.ZoomIn:
                    return ZoomInButton;
                case KeybindSettings.ZoomOut:
                    return ZoomOutButton;
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
            TextBox text = GetTextBoxByTag((KeybindSettings)s.Tag);
            text.BackColor = System.Drawing.Color.White;
            text.Text = "NONE";
            SettingsData.SetSetting((KeybindSettings)s.Tag, -1);
            CheckForDuplicates();
        }

        private Dictionary<int, List<TextBox>> GetPickedKeys()
        {
            Dictionary<int, List<TextBox>> pickedKeys = new Dictionary<int, List<TextBox>>();
            
            foreach (KeybindSettings s in (KeybindSettings[])Enum.GetValues(typeof(KeybindSettings)))
            {
                if (s != KeybindSettings.None)
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
