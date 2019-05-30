using System;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class InputDirControl : UserControl
    {
        private ToolTip PathToolTip;

        public InputDirControl(string path)
        {
            InitializeComponent();
            PathTextbox.Text = path;
            PathToolTip = new ToolTip();
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
    }
}
