using System;
using System.Collections.Generic;

namespace RandomImageViewer
{
    public enum KeybindSettings
    {
        None,
        ToggleZoom,
        ZoomIn,
        ZoomOut,
        HideOptions,
        HideThumbnails,
        QuitProgram,
        NextImage,
        PrevImage
    }

    public class KeybindSettingsData
    {
        private Dictionary<KeybindSettings, int> Settings;
        private bool SettingsContainArrowKeys;

        public KeybindSettingsData()
        {
            LoadSettings();
            CheckSettingsContainArrowKeys();
        }

        public bool GetSettingsContainArrowKeys()
        {
            return this.SettingsContainArrowKeys;
        }

        public void LoadSettings()
        {
            Settings = new Dictionary<KeybindSettings, int>();
            foreach (KeybindSettings s in (KeybindSettings[])Enum.GetValues(typeof(KeybindSettings)))
            {
                if (s != KeybindSettings.None)
                {
                    AddSetting(s);
                }
            }
        }

        public int GetSetting(KeybindSettings s)
        {
            return Settings[s];
        }

        private void AddSetting(KeybindSettings s)
        {
            Settings.Add(s, (int)Properties.Settings.Default[s.ToString()]);
        }

        public void SetSetting(KeybindSettings s, int value)
        {
            Settings[s] = value;
        }

        public void SaveSettings()
        {
            foreach (KeybindSettings s in Settings.Keys)
            {
                Properties.Settings.Default[s.ToString()] = Settings[s];
            }
            CheckSettingsContainArrowKeys();
            Properties.Settings.Default.Save();
        }

        private void CheckSettingsContainArrowKeys()
        {
            bool containArrowKeys = false;
            foreach (KeybindSettings s in Settings.Keys)
            {
                if (
                    Settings[s] == (int)System.Windows.Forms.Keys.Right ||
                    Settings[s] == (int)System.Windows.Forms.Keys.Left ||
                    Settings[s] == (int)System.Windows.Forms.Keys.Up ||
                    Settings[s] == (int)System.Windows.Forms.Keys.Down)
                {
                    containArrowKeys = true;
                    break;
                }
            }
            this.SettingsContainArrowKeys = containArrowKeys;
        }
    }
}
