using System;
using System.IO;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class frmAddDirDirect : Form
    {
        private string Path;

        public frmAddDirDirect()
        {
            InitializeComponent();
        }

        private void BrowseFolderButton_Click(object sender, EventArgs e)
        {
            switch (FolderBrowser.ShowDialog(this))
            {
                case DialogResult.OK:
                    PathBox.Text = FolderBrowser.SelectedPath;
                    break;
                default:
                    break;
            }
        }

        private void PathBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(PathBox.Text))
            {
                OkButton.Enabled = true;
                Path = PathBox.Text;
                ErrorLabel.Text = "";
            }
            else
            {
                OkButton.Enabled = false;
                ErrorLabel.Text = "Unknown directory";
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetPath()
        {
            return Path;
        }
    }
}
