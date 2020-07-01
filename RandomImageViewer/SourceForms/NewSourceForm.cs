using RandomImageViewer.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RandomImageViewer.SourceModels;

namespace RandomImageViewer.SourceForms
{
    public partial class NewSourceForm : Form
    {
        private readonly Dictionary<SourceType, string> SOURCE_TYPES = new Dictionary<SourceType, string> { 
            { SourceType.LocalImage, "Local Source" } 
        };

        public NewSourceForm()
        {
            InitializeComponent();
            AddSourceTypes();
        }

        public BaseModel Model { get; set; }

        private void AddSourceTypes()
        {
            SelectSourceBox.DataSource = new BindingSource(SOURCE_TYPES, null);
            SelectSourceBox.DisplayMember = "Value";
            SelectSourceBox.ValueMember = "Key";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            BaseModel model;
            switch (SelectSourceBox.SelectedValue)
            {
                case SourceType.LocalImage:
                    model = GetLocalImagesModel();
                    break;
                default:
                    throw new Exception();
            }
            if (model != null)
            {
                Model = model;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private LocalImagesModel GetLocalImagesModel()
        {
            AddDirectoryForm AddDirDialog = new AddDirectoryForm();
            if (AddDirDialog.ShowDialog(this) == DialogResult.OK)
            {
                return new LocalImagesModel()
                {
                    DirectorySetting = DirectorySetting.ExcludeSubdirectories,
                    Enabled = true,
                    Path = AddDirDialog.GetPath()
                };
            }
            return null;
        }
    }
}
