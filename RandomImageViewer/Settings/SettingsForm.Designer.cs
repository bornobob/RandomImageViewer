namespace RandomImageViewer.Settings
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
            this.KeybindsGroupBox = new System.Windows.Forms.GroupBox();
            this.ToggleSlideshowDeleteButton = new System.Windows.Forms.Button();
            this.ToggleSlideshowButton = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PrevImageDeleteButton = new System.Windows.Forms.Button();
            this.PrevImageButton = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NextImageDeleteButton = new System.Windows.Forms.Button();
            this.NextImageButton = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CloseProgramDeleteButton = new System.Windows.Forms.Button();
            this.HideThumbnailsDeleteButton = new System.Windows.Forms.Button();
            this.HideOptionsDeleteButton = new System.Windows.Forms.Button();
            this.ZoomOutDeleteButton = new System.Windows.Forms.Button();
            this.ZoomInDeleteButton = new System.Windows.Forms.Button();
            this.ToggleDeleteButton = new System.Windows.Forms.Button();
            this.CloseProgramButton = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.HideThumbnailsButton = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HideOptionsButton = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.KeybindsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toggle normal size/fit to screen";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ToggleButton
            // 
            this.ToggleButton.Location = new System.Drawing.Point(164, 13);
            this.ToggleButton.Margin = new System.Windows.Forms.Padding(2);
            this.ToggleButton.Name = "ToggleButton";
            this.ToggleButton.ReadOnly = true;
            this.ToggleButton.Size = new System.Drawing.Size(68, 20);
            this.ToggleButton.TabIndex = 1;
            this.ToggleButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToggleButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.ToggleButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.ToggleButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.Location = new System.Drawing.Point(164, 35);
            this.ZoomInButton.Margin = new System.Windows.Forms.Padding(2);
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.ReadOnly = true;
            this.ZoomInButton.Size = new System.Drawing.Size(68, 20);
            this.ZoomInButton.TabIndex = 3;
            this.ZoomInButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ZoomInButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.ZoomInButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.ZoomInButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zoom in";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.Location = new System.Drawing.Point(164, 57);
            this.ZoomOutButton.Margin = new System.Windows.Forms.Padding(2);
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.ReadOnly = true;
            this.ZoomOutButton.Size = new System.Drawing.Size(68, 20);
            this.ZoomOutButton.TabIndex = 5;
            this.ZoomOutButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ZoomOutButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.ZoomOutButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.ZoomOutButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Zoom out";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // KeybindsGroupBox
            // 
            this.KeybindsGroupBox.Controls.Add(this.ToggleSlideshowDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.ToggleSlideshowButton);
            this.KeybindsGroupBox.Controls.Add(this.label9);
            this.KeybindsGroupBox.Controls.Add(this.PrevImageDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.PrevImageButton);
            this.KeybindsGroupBox.Controls.Add(this.label8);
            this.KeybindsGroupBox.Controls.Add(this.NextImageDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.NextImageButton);
            this.KeybindsGroupBox.Controls.Add(this.label7);
            this.KeybindsGroupBox.Controls.Add(this.CloseProgramDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.HideThumbnailsDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.HideOptionsDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.ZoomOutDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.ZoomInDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.ToggleDeleteButton);
            this.KeybindsGroupBox.Controls.Add(this.CloseProgramButton);
            this.KeybindsGroupBox.Controls.Add(this.label6);
            this.KeybindsGroupBox.Controls.Add(this.HideThumbnailsButton);
            this.KeybindsGroupBox.Controls.Add(this.label5);
            this.KeybindsGroupBox.Controls.Add(this.HideOptionsButton);
            this.KeybindsGroupBox.Controls.Add(this.label4);
            this.KeybindsGroupBox.Controls.Add(this.label1);
            this.KeybindsGroupBox.Controls.Add(this.ZoomOutButton);
            this.KeybindsGroupBox.Controls.Add(this.ToggleButton);
            this.KeybindsGroupBox.Controls.Add(this.label3);
            this.KeybindsGroupBox.Controls.Add(this.label2);
            this.KeybindsGroupBox.Controls.Add(this.ZoomInButton);
            this.KeybindsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.KeybindsGroupBox.Name = "KeybindsGroupBox";
            this.KeybindsGroupBox.Size = new System.Drawing.Size(262, 219);
            this.KeybindsGroupBox.TabIndex = 6;
            this.KeybindsGroupBox.TabStop = false;
            this.KeybindsGroupBox.Text = "Key bindings";
            // 
            // ToggleSlideshowDeleteButton
            // 
            this.ToggleSlideshowDeleteButton.Location = new System.Drawing.Point(237, 190);
            this.ToggleSlideshowDeleteButton.Name = "ToggleSlideshowDeleteButton";
            this.ToggleSlideshowDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.ToggleSlideshowDeleteButton.TabIndex = 26;
            this.ToggleSlideshowDeleteButton.Text = "X";
            this.ToggleSlideshowDeleteButton.UseVisualStyleBackColor = true;
            this.ToggleSlideshowDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // ToggleSlideshowButton
            // 
            this.ToggleSlideshowButton.Location = new System.Drawing.Point(164, 190);
            this.ToggleSlideshowButton.Margin = new System.Windows.Forms.Padding(2);
            this.ToggleSlideshowButton.Name = "ToggleSlideshowButton";
            this.ToggleSlideshowButton.ReadOnly = true;
            this.ToggleSlideshowButton.Size = new System.Drawing.Size(68, 20);
            this.ToggleSlideshowButton.TabIndex = 25;
            this.ToggleSlideshowButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToggleSlideshowButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.ToggleSlideshowButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.ToggleSlideshowButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 193);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Toggle slideshow";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PrevImageDeleteButton
            // 
            this.PrevImageDeleteButton.Location = new System.Drawing.Point(237, 168);
            this.PrevImageDeleteButton.Name = "PrevImageDeleteButton";
            this.PrevImageDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.PrevImageDeleteButton.TabIndex = 23;
            this.PrevImageDeleteButton.Text = "X";
            this.PrevImageDeleteButton.UseVisualStyleBackColor = true;
            this.PrevImageDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // PrevImageButton
            // 
            this.PrevImageButton.Location = new System.Drawing.Point(164, 168);
            this.PrevImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.PrevImageButton.Name = "PrevImageButton";
            this.PrevImageButton.ReadOnly = true;
            this.PrevImageButton.Size = new System.Drawing.Size(68, 20);
            this.PrevImageButton.TabIndex = 22;
            this.PrevImageButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PrevImageButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.PrevImageButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.PrevImageButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 171);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Previous image";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NextImageDeleteButton
            // 
            this.NextImageDeleteButton.Location = new System.Drawing.Point(237, 146);
            this.NextImageDeleteButton.Name = "NextImageDeleteButton";
            this.NextImageDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.NextImageDeleteButton.TabIndex = 20;
            this.NextImageDeleteButton.Text = "X";
            this.NextImageDeleteButton.UseVisualStyleBackColor = true;
            this.NextImageDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // NextImageButton
            // 
            this.NextImageButton.Location = new System.Drawing.Point(164, 146);
            this.NextImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.NextImageButton.Name = "NextImageButton";
            this.NextImageButton.ReadOnly = true;
            this.NextImageButton.Size = new System.Drawing.Size(68, 20);
            this.NextImageButton.TabIndex = 19;
            this.NextImageButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NextImageButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.NextImageButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.NextImageButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Next image";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CloseProgramDeleteButton
            // 
            this.CloseProgramDeleteButton.Location = new System.Drawing.Point(237, 123);
            this.CloseProgramDeleteButton.Name = "CloseProgramDeleteButton";
            this.CloseProgramDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.CloseProgramDeleteButton.TabIndex = 17;
            this.CloseProgramDeleteButton.Text = "X";
            this.CloseProgramDeleteButton.UseVisualStyleBackColor = true;
            this.CloseProgramDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // HideThumbnailsDeleteButton
            // 
            this.HideThumbnailsDeleteButton.Location = new System.Drawing.Point(237, 100);
            this.HideThumbnailsDeleteButton.Name = "HideThumbnailsDeleteButton";
            this.HideThumbnailsDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.HideThumbnailsDeleteButton.TabIndex = 16;
            this.HideThumbnailsDeleteButton.Text = "X";
            this.HideThumbnailsDeleteButton.UseVisualStyleBackColor = true;
            this.HideThumbnailsDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // HideOptionsDeleteButton
            // 
            this.HideOptionsDeleteButton.Location = new System.Drawing.Point(237, 79);
            this.HideOptionsDeleteButton.Name = "HideOptionsDeleteButton";
            this.HideOptionsDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.HideOptionsDeleteButton.TabIndex = 15;
            this.HideOptionsDeleteButton.Text = "X";
            this.HideOptionsDeleteButton.UseVisualStyleBackColor = true;
            this.HideOptionsDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // ZoomOutDeleteButton
            // 
            this.ZoomOutDeleteButton.Location = new System.Drawing.Point(237, 57);
            this.ZoomOutDeleteButton.Name = "ZoomOutDeleteButton";
            this.ZoomOutDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.ZoomOutDeleteButton.TabIndex = 14;
            this.ZoomOutDeleteButton.Text = "X";
            this.ZoomOutDeleteButton.UseVisualStyleBackColor = true;
            this.ZoomOutDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // ZoomInDeleteButton
            // 
            this.ZoomInDeleteButton.Location = new System.Drawing.Point(237, 35);
            this.ZoomInDeleteButton.Name = "ZoomInDeleteButton";
            this.ZoomInDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.ZoomInDeleteButton.TabIndex = 13;
            this.ZoomInDeleteButton.Text = "X";
            this.ZoomInDeleteButton.UseVisualStyleBackColor = true;
            this.ZoomInDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // ToggleDeleteButton
            // 
            this.ToggleDeleteButton.Location = new System.Drawing.Point(237, 13);
            this.ToggleDeleteButton.Name = "ToggleDeleteButton";
            this.ToggleDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.ToggleDeleteButton.TabIndex = 12;
            this.ToggleDeleteButton.Text = "X";
            this.ToggleDeleteButton.UseVisualStyleBackColor = true;
            this.ToggleDeleteButton.Click += new System.EventHandler(this.DeleteSettingButton_Click);
            // 
            // CloseProgramButton
            // 
            this.CloseProgramButton.Location = new System.Drawing.Point(164, 123);
            this.CloseProgramButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseProgramButton.Name = "CloseProgramButton";
            this.CloseProgramButton.ReadOnly = true;
            this.CloseProgramButton.Size = new System.Drawing.Size(68, 20);
            this.CloseProgramButton.TabIndex = 11;
            this.CloseProgramButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CloseProgramButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.CloseProgramButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.CloseProgramButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Close program";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HideThumbnailsButton
            // 
            this.HideThumbnailsButton.Location = new System.Drawing.Point(164, 101);
            this.HideThumbnailsButton.Margin = new System.Windows.Forms.Padding(2);
            this.HideThumbnailsButton.Name = "HideThumbnailsButton";
            this.HideThumbnailsButton.ReadOnly = true;
            this.HideThumbnailsButton.Size = new System.Drawing.Size(68, 20);
            this.HideThumbnailsButton.TabIndex = 9;
            this.HideThumbnailsButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HideThumbnailsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.HideThumbnailsButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.HideThumbnailsButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hide thumbnails";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HideOptionsButton
            // 
            this.HideOptionsButton.Location = new System.Drawing.Point(164, 79);
            this.HideOptionsButton.Margin = new System.Windows.Forms.Padding(2);
            this.HideOptionsButton.Name = "HideOptionsButton";
            this.HideOptionsButton.ReadOnly = true;
            this.HideOptionsButton.Size = new System.Drawing.Size(68, 20);
            this.HideOptionsButton.TabIndex = 7;
            this.HideOptionsButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HideOptionsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickedSetting);
            this.HideOptionsButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.HideOptionsButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SettingsPreviewKeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hide options";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(200, 331);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(119, 331);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 366);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.KeybindsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(303, 405);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeydownSetting);
            this.KeybindsGroupBox.ResumeLayout(false);
            this.KeybindsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ToggleButton;
        private System.Windows.Forms.TextBox ZoomInButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ZoomOutButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox KeybindsGroupBox;
        private System.Windows.Forms.TextBox HideThumbnailsButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox HideOptionsButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CloseProgramButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseProgramDeleteButton;
        private System.Windows.Forms.Button HideThumbnailsDeleteButton;
        private System.Windows.Forms.Button HideOptionsDeleteButton;
        private System.Windows.Forms.Button ZoomOutDeleteButton;
        private System.Windows.Forms.Button ZoomInDeleteButton;
        private System.Windows.Forms.Button ToggleDeleteButton;
        private System.Windows.Forms.Button NextImageDeleteButton;
        private System.Windows.Forms.TextBox NextImageButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button PrevImageDeleteButton;
        private System.Windows.Forms.TextBox PrevImageButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ToggleSlideshowDeleteButton;
        private System.Windows.Forms.TextBox ToggleSlideshowButton;
        private System.Windows.Forms.Label label9;
    }
}