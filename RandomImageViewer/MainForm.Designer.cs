namespace RandomImageViewer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TraverseSubdirectoriesCheckBox = new System.Windows.Forms.CheckBox();
            this.SlideshowTiming = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.RadioSeq = new System.Windows.Forms.RadioButton();
            this.RadioRandom = new System.Windows.Forms.RadioButton();
            this.InputDirsPanel = new System.Windows.Forms.Panel();
            this.ButtonAddDir = new System.Windows.Forms.Button();
            this.SinkLabel = new System.Windows.Forms.Label();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
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
            this.MainPictureBox.Location = new System.Drawing.Point(3, 8);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(673, 356);
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
            this.pnlMain.Location = new System.Drawing.Point(2, 111);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(678, 364);
            this.pnlMain.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.TraverseSubdirectoriesCheckBox);
            this.groupBox1.Controls.Add(this.SlideshowTiming);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RadioSeq);
            this.groupBox1.Controls.Add(this.RadioRandom);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // TraverseSubdirectoriesCheckBox
            // 
            this.TraverseSubdirectoriesCheckBox.AutoSize = true;
            this.TraverseSubdirectoriesCheckBox.Location = new System.Drawing.Point(6, 68);
            this.TraverseSubdirectoriesCheckBox.Name = "TraverseSubdirectoriesCheckBox";
            this.TraverseSubdirectoriesCheckBox.Size = new System.Drawing.Size(136, 17);
            this.TraverseSubdirectoriesCheckBox.TabIndex = 9;
            this.TraverseSubdirectoriesCheckBox.Text = "Traverse subdirectories";
            this.TraverseSubdirectoriesCheckBox.UseVisualStyleBackColor = true;
            this.TraverseSubdirectoriesCheckBox.CheckedChanged += new System.EventHandler(this.TraverseSubdirectoriesCheckBox_CheckedChanged);
            // 
            // SlideshowTiming
            // 
            this.SlideshowTiming.DecimalPlaces = 1;
            this.SlideshowTiming.InterceptArrowKeys = false;
            this.SlideshowTiming.Location = new System.Drawing.Point(122, 40);
            this.SlideshowTiming.Maximum = new decimal(new int[] {
            7680,
            0,
            0,
            0});
            this.SlideshowTiming.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SlideshowTiming.Name = "SlideshowTiming";
            this.SlideshowTiming.Size = new System.Drawing.Size(62, 20);
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
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Slideshow time/image:";
            // 
            // RadioSeq
            // 
            this.RadioSeq.AutoSize = true;
            this.RadioSeq.Location = new System.Drawing.Point(77, 19);
            this.RadioSeq.Name = "RadioSeq";
            this.RadioSeq.Size = new System.Drawing.Size(75, 17);
            this.RadioSeq.TabIndex = 1;
            this.RadioSeq.TabStop = true;
            this.RadioSeq.Text = "Sequential";
            this.RadioSeq.UseVisualStyleBackColor = true;
            // 
            // RadioRandom
            // 
            this.RadioRandom.AutoSize = true;
            this.RadioRandom.Location = new System.Drawing.Point(6, 19);
            this.RadioRandom.Name = "RadioRandom";
            this.RadioRandom.Size = new System.Drawing.Size(65, 17);
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
            this.InputDirsPanel.Location = new System.Drawing.Point(7, 109);
            this.InputDirsPanel.Name = "InputDirsPanel";
            this.InputDirsPanel.Size = new System.Drawing.Size(190, 94);
            this.InputDirsPanel.TabIndex = 3;
            // 
            // ButtonAddDir
            // 
            this.ButtonAddDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddDir.Location = new System.Drawing.Point(122, 209);
            this.ButtonAddDir.Name = "ButtonAddDir";
            this.ButtonAddDir.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddDir.TabIndex = 4;
            this.ButtonAddDir.Text = "Add Source";
            this.ButtonAddDir.UseVisualStyleBackColor = true;
            this.ButtonAddDir.Click += new System.EventHandler(this.ButtonAddDir_Click);
            // 
            // SinkLabel
            // 
            this.SinkLabel.AutoSize = true;
            this.SinkLabel.Location = new System.Drawing.Point(1184, 728);
            this.SinkLabel.Name = "SinkLabel";
            this.SinkLabel.Size = new System.Drawing.Size(0, 13);
            this.SinkLabel.TabIndex = 5;
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsPanel.Controls.Add(this.button1);
            this.OptionsPanel.Controls.Add(this.SlideshowButton);
            this.OptionsPanel.Controls.Add(this.groupBox2);
            this.OptionsPanel.Controls.Add(this.ButtonReload);
            this.OptionsPanel.Controls.Add(this.groupBox1);
            this.OptionsPanel.Controls.Add(this.InputDirsPanel);
            this.OptionsPanel.Controls.Add(this.ButtonAddDir);
            this.OptionsPanel.Location = new System.Drawing.Point(688, 2);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(200, 473);
            this.OptionsPanel.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(115, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Options";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SlideshowButton
            // 
            this.SlideshowButton.Location = new System.Drawing.Point(7, 238);
            this.SlideshowButton.Name = "SlideshowButton";
            this.SlideshowButton.Size = new System.Drawing.Size(190, 23);
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
            this.groupBox2.Location = new System.Drawing.Point(3, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 121);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Current directory:";
            // 
            // CurrentDirLabel
            // 
            this.CurrentDirLabel.AutoSize = true;
            this.CurrentDirLabel.Location = new System.Drawing.Point(1, 102);
            this.CurrentDirLabel.Name = "CurrentDirLabel";
            this.CurrentDirLabel.Size = new System.Drawing.Size(13, 13);
            this.CurrentDirLabel.TabIndex = 16;
            this.CurrentDirLabel.Text = "--";
            // 
            // CurrentImageLabel
            // 
            this.CurrentImageLabel.AutoSize = true;
            this.CurrentImageLabel.Location = new System.Drawing.Point(1, 64);
            this.CurrentImageLabel.Name = "CurrentImageLabel";
            this.CurrentImageLabel.Size = new System.Drawing.Size(13, 13);
            this.CurrentImageLabel.TabIndex = 15;
            this.CurrentImageLabel.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Current image:";
            // 
            // NoImagesLabel
            // 
            this.NoImagesLabel.AutoSize = true;
            this.NoImagesLabel.Location = new System.Drawing.Point(1, 29);
            this.NoImagesLabel.Name = "NoImagesLabel";
            this.NoImagesLabel.Size = new System.Drawing.Size(13, 13);
            this.NoImagesLabel.TabIndex = 13;
            this.NoImagesLabel.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Images Loaded:";
            // 
            // ButtonReload
            // 
            this.ButtonReload.Location = new System.Drawing.Point(7, 209);
            this.ButtonReload.Name = "ButtonReload";
            this.ButtonReload.Size = new System.Drawing.Size(75, 23);
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
            this.HistoryPanel.Location = new System.Drawing.Point(3, 2);
            this.HistoryPanel.Name = "HistoryPanel";
            this.HistoryPanel.Size = new System.Drawing.Size(677, 111);
            this.HistoryPanel.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(890, 475);
            this.Controls.Add(this.HistoryPanel);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.SinkLabel);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(906, 513);
            this.Name = "MainForm";
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
        private System.Windows.Forms.Panel HistoryPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox TraverseSubdirectoriesCheckBox;
    }
}

