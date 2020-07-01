using RandomImageViewer.SourceModels;
using System;
using System.Windows.Forms;

namespace RandomImageViewer
{
    public partial class InputDirControl : UserControl
    {
        private readonly ToolTip _pathToolTip;
        private LocalImagesModel _model;

        public InputDirControl(LocalImagesModel model)
        {
            InitializeComponent();
            _model = model;
            PathTextbox.Text = _model.Path;
            _pathToolTip = new ToolTip();
            EnabledCheckbox.Checked = _model.Enabled;
            SubdirectoriesCheckbox.Checked = _model.DirectorySetting == Enums.DirectorySetting.IncludeSubdirectories;
        }

        private void PathTextbox_MouseHover(object sender, EventArgs e)
        {
            _pathToolTip.Show(_model.Path, PathTextbox);
        }

        private void SubdirectoriesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _model.DirectorySetting = SubdirectoriesCheckbox.Checked ? Enums.DirectorySetting.IncludeSubdirectories : Enums.DirectorySetting.ExcludeSubdirectories;
        }

        private void EnabledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _model.Enabled = EnabledCheckbox.Checked;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _model.CallModelDelete();
        }
    }
}
