namespace RandomImageViewer
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CloseOnEsc = new System.Windows.Forms.CheckBox();
            this.SlideshowTiming = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.RadioSeq = new System.Windows.Forms.RadioButton();
            this.RadioRandom = new System.Windows.Forms.RadioButton();
            this.InputDirsPanel = new System.Windows.Forms.Panel();
            this.ButtonAddDir = new System.Windows.Forms.Button();
            this.SinkLabel = new System.Windows.Forms.Label();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.SlideshowButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CurrentDirLabel = new System.Windows.Forms.Label();
            this.CurrentImageLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NoImagesLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonReload = new System.Windows.Forms.Button();
            this.SlideshowTimer = new System.Windows.Forms.Timer(this.components);
            this.HistoryPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlideshowTiming)).BeginInit();
            this.OptionsPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MainPictureBox.Location = new System.Drawing.Point(4, 10);
            this.MainPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(897, 438);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseClick);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.MainPictureBox);
            this.pnlMain.Location = new System.Drawing.Point(3, 137);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(905, 448);
            this.pnlMain.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CloseOnEsc);
            this.groupBox1.Controls.Add(this.SlideshowTiming);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RadioSeq);
            this.groupBox1.Controls.Add(this.RadioRandom);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(253, 123);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // CloseOnEsc
            // 
            this.CloseOnEsc.AutoSize = true;
            this.CloseOnEsc.Checked = true;
            this.CloseOnEsc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CloseOnEsc.Location = new System.Drawing.Point(8, 84);
            this.CloseOnEsc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseOnEsc.Name = "CloseOnEsc";
            this.CloseOnEsc.Size = new System.Drawing.Size(129, 21);
            this.CloseOnEsc.TabIndex = 9;
            this.CloseOnEsc.Text = "ESC closes app";
            this.CloseOnEsc.UseVisualStyleBackColor = true;
            // 
            // SlideshowTiming
            // 
            this.SlideshowTiming.DecimalPlaces = 1;
            this.SlideshowTiming.InterceptArrowKeys = false;
            this.SlideshowTiming.Location = new System.Drawing.Point(163, 49);
            this.SlideshowTiming.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SlideshowTiming.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.SlideshowTiming.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SlideshowTiming.Name = "SlideshowTiming";
            this.SlideshowTiming.Size = new System.Drawing.Size(83, 22);
            this.SlideshowTiming.TabIndex = 8;
            this.SlideshowTiming.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Slideshow time/image:";
            // 
            // RadioSeq
            // 
            this.RadioSeq.AutoSize = true;
            this.RadioSeq.Location = new System.Drawing.Point(103, 23);
            this.RadioSeq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioSeq.Name = "RadioSeq";
            this.RadioSeq.Size = new System.Drawing.Size(96, 21);
            this.RadioSeq.TabIndex = 1;
            this.RadioSeq.TabStop = true;
            this.RadioSeq.Text = "Sequential";
            this.RadioSeq.UseVisualStyleBackColor = true;
            // 
            // RadioRandom
            // 
            this.RadioRandom.AutoSize = true;
            this.RadioRandom.Location = new System.Drawing.Point(8, 23);
            this.RadioRandom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioRandom.Name = "RadioRandom";
            this.RadioRandom.Size = new System.Drawing.Size(82, 21);
            this.RadioRandom.TabIndex = 0;
            this.RadioRandom.TabStop = true;
            this.RadioRandom.Text = "Random";
            this.RadioRandom.UseVisualStyleBackColor = true;
            this.RadioRandom.CheckedChanged += new System.EventHandler(this.RadioRandom_CheckedChanged);
            // 
            // InputDirsPanel
            // 
            this.InputDirsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InputDirsPanel.AutoScroll = true;
            this.InputDirsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputDirsPanel.Location = new System.Drawing.Point(9, 134);
            this.InputDirsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InputDirsPanel.Name = "InputDirsPanel";
            this.InputDirsPanel.Size = new System.Drawing.Size(253, 115);
            this.InputDirsPanel.TabIndex = 3;
            // 
            // ButtonAddDir
            // 
            this.ButtonAddDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddDir.Location = new System.Drawing.Point(163, 257);
            this.ButtonAddDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonAddDir.Name = "ButtonAddDir";
            this.ButtonAddDir.Size = new System.Drawing.Size(100, 28);
            this.ButtonAddDir.TabIndex = 4;
            this.ButtonAddDir.Text = "Add Source";
            this.ButtonAddDir.UseVisualStyleBackColor = true;
            this.ButtonAddDir.Click += new System.EventHandler(this.ButtonAddDir_Click);
            // 
            // SinkLabel
            // 
            this.SinkLabel.AutoSize = true;
            this.SinkLabel.Location = new System.Drawing.Point(1579, 896);
            this.SinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SinkLabel.Name = "SinkLabel";
            this.SinkLabel.Size = new System.Drawing.Size(0, 17);
            this.SinkLabel.TabIndex = 5;
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsPanel.Controls.Add(this.SlideshowButton);
            this.OptionsPanel.Controls.Add(this.groupBox2);
            this.OptionsPanel.Controls.Add(this.ButtonReload);
            this.OptionsPanel.Controls.Add(this.groupBox1);
            this.OptionsPanel.Controls.Add(this.InputDirsPanel);
            this.OptionsPanel.Controls.Add(this.ButtonAddDir);
            this.OptionsPanel.Location = new System.Drawing.Point(919, 2);
            this.OptionsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(267, 582);
            this.OptionsPanel.TabIndex = 8;
            // 
            // SlideshowButton
            // 
            this.SlideshowButton.Location = new System.Drawing.Point(9, 293);
            this.SlideshowButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SlideshowButton.Name = "SlideshowButton";
            this.SlideshowButton.Size = new System.Drawing.Size(253, 28);
            this.SlideshowButton.TabIndex = 14;
            this.SlideshowButton.Text = "Begin Slideshow";
            this.SlideshowButton.UseVisualStyleBackColor = true;
            this.SlideshowButton.Click += new System.EventHandler(this.SlideshowButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CurrentDirLabel);
            this.groupBox2.Controls.Add(this.CurrentImageLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.NoImagesLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(4, 430);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(259, 149);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Current directory:";
            // 
            // CurrentDirLabel
            // 
            this.CurrentDirLabel.AutoSize = true;
            this.CurrentDirLabel.Location = new System.Drawing.Point(1, 126);
            this.CurrentDirLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentDirLabel.Name = "CurrentDirLabel";
            this.CurrentDirLabel.Size = new System.Drawing.Size(18, 17);
            this.CurrentDirLabel.TabIndex = 16;
            this.CurrentDirLabel.Text = "--";
            // 
            // CurrentImageLabel
            // 
            this.CurrentImageLabel.AutoSize = true;
            this.CurrentImageLabel.Location = new System.Drawing.Point(1, 79);
            this.CurrentImageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentImageLabel.Name = "CurrentImageLabel";
            this.CurrentImageLabel.Size = new System.Drawing.Size(18, 17);
            this.CurrentImageLabel.TabIndex = 15;
            this.CurrentImageLabel.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Current image:";
            // 
            // NoImagesLabel
            // 
            this.NoImagesLabel.AutoSize = true;
            this.NoImagesLabel.Location = new System.Drawing.Point(1, 36);
            this.NoImagesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NoImagesLabel.Name = "NoImagesLabel";
            this.NoImagesLabel.Size = new System.Drawing.Size(18, 17);
            this.NoImagesLabel.TabIndex = 13;
            this.NoImagesLabel.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Images Loaded:";
            // 
            // ButtonReload
            // 
            this.ButtonReload.Location = new System.Drawing.Point(9, 257);
            this.ButtonReload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonReload.Name = "ButtonReload";
            this.ButtonReload.Size = new System.Drawing.Size(100, 28);
            this.ButtonReload.TabIndex = 12;
            this.ButtonReload.Text = "Reload";
            this.ButtonReload.UseVisualStyleBackColor = true;
            this.ButtonReload.Click += new System.EventHandler(this.ButtonReload_Click);
            // 
            // SlideshowTimer
            // 
            this.SlideshowTimer.Tick += new System.EventHandler(this.SlideshowTimer_Tick);
            // 
            // HistoryPanel
            // 
            this.HistoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryPanel.Location = new System.Drawing.Point(4, 2);
            this.HistoryPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HistoryPanel.Name = "HistoryPanel";
            this.HistoryPanel.Size = new System.Drawing.Size(904, 137);
            this.HistoryPanel.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1188, 585);
            this.Controls.Add(this.HistoryPanel);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.SinkLabel);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1203, 622);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Random Image Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlideshowTiming)).EndInit();
            this.OptionsPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel InputDirsPanel;
        private System.Windows.Forms.Button ButtonAddDir;
        private System.Windows.Forms.Label SinkLabel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.RadioButton RadioSeq;
        private System.Windows.Forms.RadioButton RadioRandom;
        private System.Windows.Forms.Button ButtonReload;
        private System.Windows.Forms.Timer SlideshowTimer;
        private System.Windows.Forms.NumericUpDown SlideshowTiming;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SlideshowButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CurrentDirLabel;
        private System.Windows.Forms.Label CurrentImageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NoImagesLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CloseOnEsc;
        private System.Windows.Forms.Panel HistoryPanel;
    }
}

