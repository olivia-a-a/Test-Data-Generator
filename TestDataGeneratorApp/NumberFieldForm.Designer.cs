namespace TestDataGeneratorApp
{
    partial class NumberFieldForm
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
            FieldNameLbl = new Label();
            groupBox1 = new GroupBox();
            CustomNumTextBox = new TextBox();
            label4 = new Label();
            StaysSameCheckBox = new CheckBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            DecimalPlaces = new NumericUpDown();
            MinNumTextBox = new TextBox();
            MaxNumTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DecimalPlaces).BeginInit();
            SuspendLayout();
            // 
            // FieldNameLbl
            // 
            FieldNameLbl.AutoSize = true;
            FieldNameLbl.Font = new Font("Segoe UI", 11F);
            FieldNameLbl.ForeColor = Color.FromArgb(0, 51, 153);
            FieldNameLbl.Location = new Point(41, 25);
            FieldNameLbl.Name = "FieldNameLbl";
            FieldNameLbl.Size = new Size(71, 30);
            FieldNameLbl.TabIndex = 31;
            FieldNameLbl.Text = "label5";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CustomNumTextBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(StaysSameCheckBox);
            groupBox1.Location = new Point(58, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(232, 166);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Number value";
            // 
            // CustomNumTextBox
            // 
            CustomNumTextBox.Location = new Point(27, 58);
            CustomNumTextBox.Name = "CustomNumTextBox";
            CustomNumTextBox.Size = new Size(114, 31);
            CustomNumTextBox.TabIndex = 36;
            CustomNumTextBox.TextChanged += CustomNumTextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 30);
            label4.Name = "label4";
            label4.Size = new Size(78, 25);
            label4.TabIndex = 35;
            label4.Text = "Custom:";
            // 
            // StaysSameCheckBox
            // 
            StaysSameCheckBox.AutoSize = true;
            StaysSameCheckBox.Location = new Point(17, 122);
            StaysSameCheckBox.Name = "StaysSameCheckBox";
            StaysSameCheckBox.Size = new Size(202, 29);
            StaysSameCheckBox.TabIndex = 34;
            StaysSameCheckBox.Text = "Value stays the same";
            StaysSameCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(DecimalPlaces);
            groupBox2.Controls.Add(MinNumTextBox);
            groupBox2.Controls.Add(MaxNumTextBox);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(404, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(320, 220);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            groupBox2.Text = "Number constraints";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 158);
            label3.Name = "label3";
            label3.Size = new Size(133, 25);
            label3.TabIndex = 5;
            label3.Text = "Decimal places:";
            // 
            // DecimalPlaces
            // 
            DecimalPlaces.Location = new Point(186, 156);
            DecimalPlaces.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            DecimalPlaces.Name = "DecimalPlaces";
            DecimalPlaces.Size = new Size(61, 31);
            DecimalPlaces.TabIndex = 4;
            // 
            // MinNumTextBox
            // 
            MinNumTextBox.Location = new Point(133, 86);
            MinNumTextBox.Name = "MinNumTextBox";
            MinNumTextBox.Size = new Size(114, 31);
            MinNumTextBox.TabIndex = 3;
            MinNumTextBox.TextChanged += MinNumTextBox_TextChanged;
            // 
            // MaxNumTextBox
            // 
            MaxNumTextBox.Location = new Point(133, 44);
            MaxNumTextBox.Name = "MaxNumTextBox";
            MaxNumTextBox.Size = new Size(114, 31);
            MaxNumTextBox.TabIndex = 2;
            MaxNumTextBox.TextChanged += MaxNumTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 89);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 1;
            label2.Text = "Minimum:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 44);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 0;
            label1.Text = "Maximum:";
            // 
            // NumberFieldForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 361);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(FieldNameLbl);
            Name = "NumberFieldForm";
            Text = "Test Data Generator - Number Format";
            FormClosing += NumberFieldOptionForm_FormClosing;
            Load += NumberFieldOptionForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DecimalPlaces).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FieldNameLbl;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox MinNumTextBox;
        private TextBox MaxNumTextBox;
        private Label label2;
        private Label label1;
        private CheckBox StaysSameCheckBox;
        private TextBox CustomNumTextBox;
        private Label label4;
        private Label label3;
        private NumericUpDown DecimalPlaces;
    }
}