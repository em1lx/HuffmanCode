namespace HuffmanCode
{
    partial class mainForm
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
            this.inputLabel = new System.Windows.Forms.Label();
            this.analysisLabel = new System.Windows.Forms.Label();
            this.compressButton = new System.Windows.Forms.Button();
            this.recoverButton = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.saveInputButton = new System.Windows.Forms.Button();
            this.saveOutputButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.analysisTextBox = new System.Windows.Forms.RichTextBox();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(12, 9);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(58, 13);
            this.inputLabel.TabIndex = 1;
            this.inputLabel.Text = "Input data:";
            // 
            // analysisLabel
            // 
            this.analysisLabel.AutoSize = true;
            this.analysisLabel.Location = new System.Drawing.Point(12, 154);
            this.analysisLabel.Name = "analysisLabel";
            this.analysisLabel.Size = new System.Drawing.Size(73, 13);
            this.analysisLabel.TabIndex = 2;
            this.analysisLabel.Text = "Data analysis:";
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(82, 107);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(115, 35);
            this.compressButton.TabIndex = 4;
            this.compressButton.Text = "Compress data";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // recoverButton
            // 
            this.recoverButton.Location = new System.Drawing.Point(203, 107);
            this.recoverButton.Name = "recoverButton";
            this.recoverButton.Size = new System.Drawing.Size(115, 35);
            this.recoverButton.TabIndex = 5;
            this.recoverButton.Text = "Recover data";
            this.recoverButton.UseVisualStyleBackColor = true;
            this.recoverButton.Click += new System.EventHandler(this.recoverButton_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(12, 318);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(66, 13);
            this.outputLabel.TabIndex = 7;
            this.outputLabel.Text = "Output data:";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(395, 25);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(115, 35);
            this.openButton.TabIndex = 8;
            this.openButton.Text = "Open file";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveInputButton
            // 
            this.saveInputButton.Location = new System.Drawing.Point(395, 66);
            this.saveInputButton.Name = "saveInputButton";
            this.saveInputButton.Size = new System.Drawing.Size(115, 35);
            this.saveInputButton.TabIndex = 9;
            this.saveInputButton.Text = "Save file";
            this.saveInputButton.UseVisualStyleBackColor = true;
            this.saveInputButton.Click += new System.EventHandler(this.saveInputButton_Click);
            // 
            // saveOutputButton
            // 
            this.saveOutputButton.Location = new System.Drawing.Point(395, 355);
            this.saveOutputButton.Name = "saveOutputButton";
            this.saveOutputButton.Size = new System.Drawing.Size(115, 35);
            this.saveOutputButton.TabIndex = 10;
            this.saveOutputButton.Text = "Save file";
            this.saveOutputButton.UseVisualStyleBackColor = true;
            this.saveOutputButton.Click += new System.EventHandler(this.saveOutputButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(15, 25);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(374, 76);
            this.inputTextBox.TabIndex = 11;
            this.inputTextBox.Text = "";
            // 
            // analysisTextBox
            // 
            this.analysisTextBox.Location = new System.Drawing.Point(15, 170);
            this.analysisTextBox.Name = "analysisTextBox";
            this.analysisTextBox.Size = new System.Drawing.Size(374, 135);
            this.analysisTextBox.TabIndex = 12;
            this.analysisTextBox.Text = "";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(15, 334);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(374, 76);
            this.outputTextBox.TabIndex = 13;
            this.outputTextBox.Text = "";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(324, 107);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(115, 35);
            this.clearButton.TabIndex = 14;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 421);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.analysisTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.saveOutputButton);
            this.Controls.Add(this.saveInputButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.recoverButton);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.analysisLabel);
            this.Controls.Add(this.inputLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Huffman Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Label analysisLabel;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Button recoverButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveInputButton;
        private System.Windows.Forms.Button saveOutputButton;
        private System.Windows.Forms.RichTextBox inputTextBox;
        private System.Windows.Forms.RichTextBox analysisTextBox;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Button clearButton;
    }
}

