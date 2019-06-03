using System;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class InputDirControl : UserControl
    {
        private ToolTip PathToolTip;
        private ImageList ImageList;
        private DirectoryObject OldDirectoryObject;

        public InputDirControl(string path, ImageList imageList)
        {
            InitializeComponent();
            PathTextbox.Text = path;
            PathToolTip = new ToolTip();
            ImageList = imageList;
            OldDirectoryObject = CreateDirectory();
            ImageList.AddDirectory(OldDirectoryObject);
        }

        public void SetArgs(bool subdirectories, bool enabled)
        {
            SubdirectoriesCheckbox.Checked = subdirectories;
            EnabledCheckbox.Checked = enabled;
        }

        public string GetPath()
        {
            return PathTextbox.Text;
        }

        public delegate void DeleteInputDir(InputDirControl inputDirControl);
        public void AddHandler(DeleteInputDir func)
        {
            DeleteButton.Click += (s, e) => { func(this); };
        }

        private void PathTextbox_MouseHover(object sender, EventArgs e)
        {
            PathToolTip.Show(GetPath(), PathTextbox);
        }

        private DirectoryObject CreateDirectory()
        {
            return new DirectoryObject(PathTextbox.Text, SubdirectoriesCheckbox.Checked, EnabledCheckbox.Checked);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ImageList.DeleteDirectory(CreateDirectory());
            this.Parent.Controls.Remove(this);
        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            AlertDirectoryChanged();
        }

        private void AlertDirectoryChanged()
        {
            DirectoryObject newDirectoryObject = CreateDirectory();
            ImageList.DirectoryChanged(OldDirectoryObject, newDirectoryObject);
            OldDirectoryObject = newDirectoryObject;
        }

        private void Checkbox_EnabledChanged(object sender, EventArgs e)
        {
            PathTextbox.Enabled = EnabledCheckbox.Checked;
            DeleteButton.Enabled = EnabledCheckbox.Checked;
            SubdirectoriesCheckbox.Enabled = EnabledCheckbox.Checked;
            AlertDirectoryChanged();
        }

        public bool IsEnabled()
        {
            return EnabledCheckbox.Checked;
        }

        public bool IncludeSubdirectories()
        {
            return SubdirectoriesCheckbox.Checked;
        }
    }
}
