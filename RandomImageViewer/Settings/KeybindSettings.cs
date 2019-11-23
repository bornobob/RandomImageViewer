using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomImageViewer.Settings
{
    public class KeybindSettings
    {
        private Dictionary<Enums.KeybindSettings, int> Settings;
        private readonly int[] arrowKeys = new int[] { (int)System.Windows.Forms.Keys.Right, (int)System.Windows.Forms.Keys.Left, (int)System.Windows.Forms.Keys.Up, (int)System.Windows.Forms.Keys.Down };
        
        public KeybindSettings()
        {
            LoadSettings();
        }

        public bool GetSettingsContainArrowKeys()
        {
            return Settings.Values.Where(s => arrowKeys.Contains(s)).Any();
        }

        public void LoadSettings()
        {
            Settings = new Dictionary<Enums.KeybindSettings, int>();
            foreach (Enums.KeybindSettings s in (Enums.KeybindSettings[])Enum.GetValues(typeof(Enums.KeybindSettings)))
            {
                if (s != Enums.KeybindSettings.None)
                {
                    Settings.Add(s, (int)Properties.Settings.Default[s.ToString()]);
                }
            }
        }

        public int GetSetting(Enums.KeybindSettings s)
        {
            return Settings[s];
        }

        public void SetSetting(Enums.KeybindSettings s, int value)
        {
            Settings[s] = value;
        }

        public void SaveSettings()
        {
            foreach (Enums.KeybindSettings s in Settings.Keys)
            {
                Properties.Settings.Default[s.ToString()] = Settings[s];
            }
            Properties.Settings.Default.Save();
        }
    }
}
