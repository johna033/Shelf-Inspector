namespace Demo.Forms
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.classBelongingLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressTextBox = new System.Windows.Forms.TextBox();
            this.progressReportLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfGenerationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.aboutButton = new System.Windows.Forms.Button();
            this.Research = new System.Windows.Forms.GroupBox();
            this.researchStatusLabel = new System.Windows.Forms.Label();
            this.researchProgressBar = new System.Windows.Forms.ProgressBar();
            this.ReasearchCheckBox = new System.Windows.Forms.CheckBox();
            this.researchUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfGenerationsUpDown)).BeginInit();
            this.Research.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.researchUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // classBelongingLabel
            // 
            this.classBelongingLabel.AutoSize = true;
            this.classBelongingLabel.Location = new System.Drawing.Point(275, 13);
            this.classBelongingLabel.Name = "classBelongingLabel";
            this.classBelongingLabel.Size = new System.Drawing.Size(0, 13);
            this.classBelongingLabel.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(275, 57);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(215, 19);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 199);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // progressTextBox
            // 
            this.progressTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressTextBox.Location = new System.Drawing.Point(7, 20);
            this.progressTextBox.Multiline = true;
            this.progressTextBox.Name = "progressTextBox";
            this.progressTextBox.ReadOnly = true;
            this.progressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.progressTextBox.Size = new System.Drawing.Size(465, 173);
            this.progressTextBox.TabIndex = 0;
            // 
            // progressReportLabel
            // 
            this.progressReportLabel.AutoSize = true;
            this.progressReportLabel.Location = new System.Drawing.Point(276, 38);
            this.progressReportLabel.Name = "progressReportLabel";
            this.progressReportLabel.Size = new System.Drawing.Size(0, 13);
            this.progressReportLabel.TabIndex = 4;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(275, 245);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 5;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter number of generations";
            // 
            // numberOfGenerationsUpDown
            // 
            this.numberOfGenerationsUpDown.Location = new System.Drawing.Point(422, 81);
            this.numberOfGenerationsUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberOfGenerationsUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numberOfGenerationsUpDown.Name = "numberOfGenerationsUpDown";
            this.numberOfGenerationsUpDown.Size = new System.Drawing.Size(68, 20);
            this.numberOfGenerationsUpDown.TabIndex = 7;
            this.numberOfGenerationsUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(414, 245);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 8;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // Research
            // 
            this.Research.Controls.Add(this.researchStatusLabel);
            this.Research.Controls.Add(this.researchProgressBar);
            this.Research.Controls.Add(this.ReasearchCheckBox);
            this.Research.Controls.Add(this.researchUpDown);
            this.Research.Controls.Add(this.label2);
            this.Research.Location = new System.Drawing.Point(279, 111);
            this.Research.Name = "Research";
            this.Research.Size = new System.Drawing.Size(200, 128);
            this.Research.TabIndex = 9;
            this.Research.TabStop = false;
            this.Research.Text = "Research";
            // 
            // researchStatusLabel
            // 
            this.researchStatusLabel.AutoSize = true;
            this.researchStatusLabel.Location = new System.Drawing.Point(7, 61);
            this.researchStatusLabel.Name = "researchStatusLabel";
            this.researchStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.researchStatusLabel.TabIndex = 12;
            // 
            // researchProgressBar
            // 
            this.researchProgressBar.Location = new System.Drawing.Point(7, 80);
            this.researchProgressBar.Name = "researchProgressBar";
            this.researchProgressBar.Size = new System.Drawing.Size(187, 14);
            this.researchProgressBar.TabIndex = 11;
            // 
            // ReasearchCheckBox
            // 
            this.ReasearchCheckBox.AutoSize = true;
            this.ReasearchCheckBox.Location = new System.Drawing.Point(9, 16);
            this.ReasearchCheckBox.Name = "ReasearchCheckBox";
            this.ReasearchCheckBox.Size = new System.Drawing.Size(84, 17);
            this.ReasearchCheckBox.TabIndex = 10;
            this.ReasearchCheckBox.Text = "Do research";
            this.ReasearchCheckBox.UseVisualStyleBackColor = true;
            this.ReasearchCheckBox.CheckedChanged += new System.EventHandler(this.ReasearchCheckBox_CheckedChanged);
            // 
            // researchUpDown
            // 
            this.researchUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.researchUpDown.Location = new System.Drawing.Point(143, 34);
            this.researchUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.researchUpDown.Name = "researchUpDown";
            this.researchUpDown.Size = new System.Drawing.Size(33, 20);
            this.researchUpDown.TabIndex = 9;
            this.researchUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Number of runs";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 504);
            this.Controls.Add(this.Research);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.numberOfGenerationsUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.progressReportLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.classBelongingLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ECO Feature Demonstration";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfGenerationsUpDown)).EndInit();
            this.Research.ResumeLayout(false);
            this.Research.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.researchUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label classBelongingLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox progressTextBox;
        private System.Windows.Forms.Label progressReportLabel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numberOfGenerationsUpDown;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.GroupBox Research;
        private System.Windows.Forms.Label researchStatusLabel;
        private System.Windows.Forms.ProgressBar researchProgressBar;
        private System.Windows.Forms.CheckBox ReasearchCheckBox;
        private System.Windows.Forms.NumericUpDown researchUpDown;
        private System.Windows.Forms.Label label2;
    }
}

