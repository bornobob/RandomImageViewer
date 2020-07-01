namespace RandomImageViewer
{
    partial class InputDirControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PathTextbox = new System.Windows.Forms.TextBox();
            this.SubdirectoriesCheckbox = new System.Windows.Forms.CheckBox();
            this.EnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(3, 30);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(47, 20);
            this.DeleteButton.TabIndex = 0;
            this.DeleteButton.Text = "X";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // PathTextbox
            // 
            this.PathTextbox.Location = new System.Drawing.Point(26, 3);
            this.PathTextbox.Name = "PathTextbox";
            this.PathTextbox.ReadOnly = true;
            this.PathTextbox.Size = new System.Drawing.Size(159, 20);
            this.PathTextbox.TabIndex = 1;
            this.PathTextbox.MouseHover += new System.EventHandler(this.PathTextbox_MouseHover);
            // 
            // SubdirectoriesCheckbox
            // 
            this.SubdirectoriesCheckbox.AutoSize = true;
            this.SubdirectoriesCheckbox.Location = new System.Drawing.Point(56, 33);
            this.SubdirectoriesCheckbox.Name = "SubdirectoriesCheckbox";
            this.SubdirectoriesCheckbox.Size = new System.Drawing.Size(129, 17);
            this.SubdirectoriesCheckbox.TabIndex = 2;
            this.SubdirectoriesCheckbox.Text = "Include subdirectories";
            this.SubdirectoriesCheckbox.UseVisualStyleBackColor = true;
            this.SubdirectoriesCheckbox.CheckedChanged += new System.EventHandler(this.SubdirectoriesCheckbox_CheckedChanged);
            // 
            // EnabledCheckbox
            // 
            this.EnabledCheckbox.AutoSize = true;
            this.EnabledCheckbox.Checked = true;
            this.EnabledCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnabledCheckbox.Location = new System.Drawing.Point(3, 6);
            this.EnabledCheckbox.Name = "EnabledCheckbox";
            this.EnabledCheckbox.Size = new System.Drawing.Size(15, 14);
            this.EnabledCheckbox.TabIndex = 3;
            this.EnabledCheckbox.UseVisualStyleBackColor = true;
            this.EnabledCheckbox.CheckedChanged += new System.EventHandler(this.EnabledCheckbox_CheckedChanged);
            // 
            // InputDirControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.EnabledCheckbox);
            this.Controls.Add(this.SubdirectoriesCheckbox);
            this.Controls.Add(this.PathTextbox);
            this.Controls.Add(this.DeleteButton);
            this.Name = "InputDirControl";
            this.Size = new System.Drawing.Size(186, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox PathTextbox;
        private System.Windows.Forms.CheckBox SubdirectoriesCheckbox;
        private System.Windows.Forms.CheckBox EnabledCheckbox;
    }
}
