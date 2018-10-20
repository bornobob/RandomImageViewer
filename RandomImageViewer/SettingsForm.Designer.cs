namespace RandomImageViewer
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ToggleButton = new System.Windows.Forms.TextBox();
            this.ZoomInButton = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ZoomOutButton = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toggle normal size/fit to screen";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ToggleButton
            // 
            this.ToggleButton.Location = new System.Drawing.Point(224, 53);
            this.ToggleButton.Name = "ToggleButton";
            this.ToggleButton.ReadOnly = true;
            this.ToggleButton.Size = new System.Drawing.Size(181, 22);
            this.ToggleButton.TabIndex = 1;
            this.ToggleButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToggleButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.ToggleButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.Location = new System.Drawing.Point(224, 81);
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.ReadOnly = true;
            this.ZoomInButton.Size = new System.Drawing.Size(181, 22);
            this.ZoomInButton.TabIndex = 3;
            this.ZoomInButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zoom in";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.Location = new System.Drawing.Point(224, 110);
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.ReadOnly = true;
            this.ZoomOutButton.Size = new System.Drawing.Size(181, 22);
            this.ZoomOutButton.TabIndex = 5;
            this.ZoomOutButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Zoom out";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ZoomOutButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ZoomInButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ToggleButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ToggleButton;
        private System.Windows.Forms.TextBox ZoomInButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ZoomOutButton;
        private System.Windows.Forms.Label label3;
    }
}