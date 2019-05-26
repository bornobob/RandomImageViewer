using System;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class InputDirControl : UserControl
    {
        public InputDirControl(string path)
        {
            InitializeComponent();
            PathTextbox.Text = path;
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
    }
}
