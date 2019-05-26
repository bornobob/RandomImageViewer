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
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(167, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(20, 20);
            this.DeleteButton.TabIndex = 0;
            this.DeleteButton.Text = "X";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // PathTextbox
            // 
            this.PathTextbox.Enabled = false;
            this.PathTextbox.Location = new System.Drawing.Point(2, 2);
            this.PathTextbox.Name = "PathTextbox";
            this.PathTextbox.Size = new System.Drawing.Size(159, 20);
            this.PathTextbox.TabIndex = 1;
            // 
            // InputDirControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PathTextbox);
            this.Controls.Add(this.DeleteButton);
            this.Name = "InputDirControl";
            this.Size = new System.Drawing.Size(188, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox PathTextbox;
    }
}
