using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomImageViewer
{ 
    public partial class SettingsForm : Form
    {
        private enum KeybindSettings
        {
            None,
            ToggleZoom,
            ZoomIn,
            ZoomOut,
            HideOptions,
            HideThumbnails,
            QuitProgram
        }

        private KeybindSettings Editing = KeybindSettings.None;

        public SettingsForm()
        {
            InitializeComponent();
            ToggleButton.Tag = KeybindSettings.ToggleZoom;
            ZoomInButton.Tag = KeybindSettings.ZoomIn;
            ZoomOutButton.Tag = KeybindSettings.ZoomOut;
        }

        private void ClickedSetting(Object sender, MouseEventArgs e)
        {
            TextBox clicked = (TextBox)sender;
            Editing = (KeybindSettings)clicked.Tag;
            clicked.Text = "Click a button to assign it";
        }

        private void KeydownSetting(object sender, KeyEventArgs e)
        {
            TextBox typed = (TextBox)sender;
            if (Editing == (KeybindSettings)typed.Tag)
            {
                int temp = (int)e.KeyCode;
                typed.Text = e.KeyCode.ToString();
                Editing = KeybindSettings.None;
            }
        }
    }
}
