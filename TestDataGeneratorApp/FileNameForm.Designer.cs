namespace TestDataGeneratorApp
{
    partial class FileNameForm
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
            FileNameTextBox = new TextBox();
            label1 = new Label();
            DefaultFileTypeExplainLbl = new Label();
            SuspendLayout();
            // 
            // FileNameTextBox
            // 
            FileNameTextBox.Location = new Point(52, 75);
            FileNameTextBox.Name = "FileNameTextBox";
            FileNameTextBox.Size = new Size(417, 31);
            FileNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = Color.FromArgb(0, 51, 153);
            label1.Location = new Point(41, 25);
            label1.Name = "label1";
            label1.Size = new Size(287, 30);
            label1.TabIndex = 1;
            label1.Text = "Enter a name for the test file";
            // 
            // DefaultFileTypeExplainLbl
            // 
            DefaultFileTypeExplainLbl.Location = new Point(52, 109);
            DefaultFileTypeExplainLbl.Name = "DefaultFileTypeExplainLbl";
            DefaultFileTypeExplainLbl.Size = new Size(397, 58);
            DefaultFileTypeExplainLbl.TabIndex = 3;
            DefaultFileTypeExplainLbl.Text = "Include the file type in the name (e.g. myfile.txt). The default is";
            // 
            // FileNameForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 187);
            Controls.Add(DefaultFileTypeExplainLbl);
            Controls.Add(label1);
            Controls.Add(FileNameTextBox);
            Name = "FileNameForm";
            Text = "FileNameForm";
            FormClosing += FileNameForm_FormClosing;
            Load += FileNameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FileNameTextBox;
        private Label label1;
        private Label DefaultFileTypeExplainLbl;
    }
}