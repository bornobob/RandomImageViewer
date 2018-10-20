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
        NextImage
    }

    public class KeybindSettingsData
    {
        private Dictionary<KeybindSettings, int> Settings;

        public KeybindSettingsData()
        {
            LoadSettings();
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
            Properties.Settings.Default.Save();
        }
    }
}
