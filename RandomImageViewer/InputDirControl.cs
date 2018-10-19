using System;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class InputDirControl : UserControl
    {
        private MainForm MainForm;

        public InputDirControl(MainForm main, string path)
        {
            InitializeComponent();
            MainForm = main;
            PathTextbox.Text = path;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            MainForm.DeleteDirectory(this);
        }

        public string GetPath()
        {
            return PathTextbox.Text;
        }
    }
}
