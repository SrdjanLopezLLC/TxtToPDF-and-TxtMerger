namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ToolStripStatusLabel = new System.Windows.Forms.StatusStrip();
            this.btnConvertToPdf = new System.Windows.Forms.Button();
            this.btnMergeTxt = new System.Windows.Forms.Button();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkPageNumbers = new System.Windows.Forms.CheckBox();
            this.nudMargin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkInsertFilenameSeparator = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 15;
            this.lstFiles.Location = new System.Drawing.Point(14, 14);
            this.lstFiles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(284, 259);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(14, 285);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(139, 27);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(14, 385);
            this.btnAddFiles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(139, 27);
            this.btnAddFiles.TabIndex = 5;
            this.btnAddFiles.Text = "Add .txt files";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(14, 352);
            this.btnRemoveSelected.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(139, 27);
            this.btnRemoveSelected.TabIndex = 6;
            this.btnRemoveSelected.Text = "Remove selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(14, 318);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(139, 27);
            this.btnMoveUp.TabIndex = 7;
            this.btnMoveUp.Text = "Move up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(160, 285);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(139, 27);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear list";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ToolStripStatusLabel);
            this.groupBox1.Controls.Add(this.btnConvertToPdf);
            this.groupBox1.Controls.Add(this.btnMergeTxt);
            this.groupBox1.Controls.Add(this.btnBrowseOutput);
            this.groupBox1.Controls.Add(this.txtOutputFolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkPageNumbers);
            this.groupBox1.Controls.Add(this.nudMargin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudFontSize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkInsertFilenameSeparator);
            this.groupBox1.Location = new System.Drawing.Point(306, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(302, 331);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Location = new System.Drawing.Point(2, 306);
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(298, 22);
            this.ToolStripStatusLabel.TabIndex = 21;
            this.ToolStripStatusLabel.Text = "statusStrip1";
            this.ToolStripStatusLabel.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStripStatusLabel_ItemClicked);
            // 
            // btnConvertToPdf
            // 
            this.btnConvertToPdf.Location = new System.Drawing.Point(156, 210);
            this.btnConvertToPdf.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConvertToPdf.Name = "btnConvertToPdf";
            this.btnConvertToPdf.Size = new System.Drawing.Size(139, 27);
            this.btnConvertToPdf.TabIndex = 20;
            this.btnConvertToPdf.Text = "Convert to PDF";
            this.btnConvertToPdf.UseVisualStyleBackColor = true;
            this.btnConvertToPdf.Click += new System.EventHandler(this.btnConvertToPdf_Click);
            // 
            // btnMergeTxt
            // 
            this.btnMergeTxt.Location = new System.Drawing.Point(7, 243);
            this.btnMergeTxt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMergeTxt.Name = "btnMergeTxt";
            this.btnMergeTxt.Size = new System.Drawing.Size(139, 27);
            this.btnMergeTxt.TabIndex = 19;
            this.btnMergeTxt.Text = "Merge to TXT";
            this.btnMergeTxt.UseVisualStyleBackColor = true;
            this.btnMergeTxt.Click += new System.EventHandler(this.btnMergeTxt_Click);
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(7, 210);
            this.btnBrowseOutput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(139, 27);
            this.btnBrowseOutput.TabIndex = 18;
            this.btnBrowseOutput.Text = "Browse";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(7, 180);
            this.txtOutputFolder.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(286, 22);
            this.txtOutputFolder.TabIndex = 17;
            this.txtOutputFolder.TextChanged += new System.EventHandler(this.txtOutputFolder_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Output folder:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // chkPageNumbers
            // 
            this.chkPageNumbers.AutoSize = true;
            this.chkPageNumbers.Checked = true;
            this.chkPageNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPageNumbers.Location = new System.Drawing.Point(7, 138);
            this.chkPageNumbers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkPageNumbers.Name = "chkPageNumbers";
            this.chkPageNumbers.Size = new System.Drawing.Size(129, 19);
            this.chkPageNumbers.TabIndex = 15;
            this.chkPageNumbers.Text = "Add page numbers";
            this.chkPageNumbers.UseVisualStyleBackColor = true;
            this.chkPageNumbers.CheckedChanged += new System.EventHandler(this.chkPageNumbers_CheckedChanged);
            // 
            // nudMargin
            // 
            this.nudMargin.Location = new System.Drawing.Point(7, 108);
            this.nudMargin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudMargin.Maximum = new decimal(new int[] {
            144,
            0,
            0,
            0});
            this.nudMargin.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudMargin.Name = "nudMargin";
            this.nudMargin.Size = new System.Drawing.Size(140, 22);
            this.nudMargin.TabIndex = 14;
            this.nudMargin.Value = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.nudMargin.ValueChanged += new System.EventHandler(this.nudMargin_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Page margin (pt):";
            // 
            // nudFontSize
            // 
            this.nudFontSize.Location = new System.Drawing.Point(7, 63);
            this.nudFontSize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudFontSize.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.nudFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(140, 22);
            this.nudFontSize.TabIndex = 12;
            this.nudFontSize.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nudFontSize.ValueChanged += new System.EventHandler(this.nudFontSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Font size (pt):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chkInsertFilenameSeparator
            // 
            this.chkInsertFilenameSeparator.AutoSize = true;
            this.chkInsertFilenameSeparator.Checked = true;
            this.chkInsertFilenameSeparator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsertFilenameSeparator.Location = new System.Drawing.Point(7, 22);
            this.chkInsertFilenameSeparator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkInsertFilenameSeparator.Name = "chkInsertFilenameSeparator";
            this.chkInsertFilenameSeparator.Size = new System.Drawing.Size(243, 19);
            this.chkInsertFilenameSeparator.TabIndex = 10;
            this.chkInsertFilenameSeparator.Text = "Insert separator (filename) between files";
            this.chkInsertFilenameSeparator.UseVisualStyleBackColor = true;
            this.chkInsertFilenameSeparator.CheckedChanged += new System.EventHandler(this.chkInsertFilenameSeparator_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(160, 318);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(139, 27);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(622, 426);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.lstFiles);
            this.Font = new System.Drawing.Font("Noto Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TXT Merger and TXT to PDF - By SL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkInsertFilenameSeparator;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPageNumbers;
        private System.Windows.Forms.NumericUpDown nudMargin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip ToolStripStatusLabel;
        private System.Windows.Forms.Button btnConvertToPdf;
        private System.Windows.Forms.Button btnMergeTxt;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

