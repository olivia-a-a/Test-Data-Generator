namespace TestDataGeneratorApp
{
    partial class StringFieldForm
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
            label1 = new Label();
            MaxStringLength = new NumericUpDown();
            MinStringLength = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            PrefixTextBox = new TextBox();
            FieldNameLbl = new Label();
            AddressCheckBox = new CheckBox();
            FirstNameCheckBox = new CheckBox();
            LastNameCheckBox = new CheckBox();
            NumbersCheckBox = new CheckBox();
            UppercaseCheckBox = new CheckBox();
            LowercaseCheckBox = new CheckBox();
            FullNameCheckBox = new CheckBox();
            RandomCharCheckBox = new CheckBox();
            CustomTextBox = new TextBox();
            label4 = new Label();
            StaysSameCheckBox = new CheckBox();
            groupBox1 = new GroupBox();
            TrueFalseCheckBox = new CheckBox();
            YesNoCheckBox = new CheckBox();
            CompanyCheckBox = new CheckBox();
            NINOCheckBox = new CheckBox();
            EmailCheckBox = new CheckBox();
            PhoneNumCheckBox = new CheckBox();
            PostcodeCheckBox = new CheckBox();
            groupBox2 = new GroupBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)MaxStringLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinStringLength).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 32);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 0;
            label1.Text = "Maximum length:";
            // 
            // MaxStringLength
            // 
            MaxStringLength.Location = new Point(199, 30);
            MaxStringLength.Maximum = new decimal(new int[] { 4000, 0, 0, 0 });
            MaxStringLength.Name = "MaxStringLength";
            MaxStringLength.Size = new Size(76, 31);
            MaxStringLength.TabIndex = 2;
            // 
            // MinStringLength
            // 
            MinStringLength.Location = new Point(199, 68);
            MinStringLength.Maximum = new decimal(new int[] { 4000, 0, 0, 0 });
            MinStringLength.Name = "MinStringLength";
            MinStringLength.Size = new Size(76, 31);
            MinStringLength.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 71);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 3;
            label2.Text = "Minimum length:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 128);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 5;
            label3.Text = "Prefix:";
            // 
            // PrefixTextBox
            // 
            PrefixTextBox.Location = new Point(102, 125);
            PrefixTextBox.Name = "PrefixTextBox";
            PrefixTextBox.Size = new Size(173, 31);
            PrefixTextBox.TabIndex = 6;
            // 
            // FieldNameLbl
            // 
            FieldNameLbl.AutoSize = true;
            FieldNameLbl.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FieldNameLbl.ForeColor = Color.FromArgb(0, 51, 153);
            FieldNameLbl.Location = new Point(41, 25);
            FieldNameLbl.Name = "FieldNameLbl";
            FieldNameLbl.Size = new Size(71, 30);
            FieldNameLbl.TabIndex = 7;
            FieldNameLbl.Text = "label4";
            // 
            // AddressCheckBox
            // 
            AddressCheckBox.AutoSize = true;
            AddressCheckBox.Location = new Point(19, 30);
            AddressCheckBox.Name = "AddressCheckBox";
            AddressCheckBox.Size = new Size(132, 29);
            AddressCheckBox.TabIndex = 8;
            AddressCheckBox.Text = "Full address";
            AddressCheckBox.UseVisualStyleBackColor = true;
            AddressCheckBox.CheckStateChanged += AddressCheckBox_CheckStateChanged;
            // 
            // FirstNameCheckBox
            // 
            FirstNameCheckBox.AutoSize = true;
            FirstNameCheckBox.Location = new Point(19, 100);
            FirstNameCheckBox.Name = "FirstNameCheckBox";
            FirstNameCheckBox.Size = new Size(120, 29);
            FirstNameCheckBox.TabIndex = 9;
            FirstNameCheckBox.Text = "First name";
            FirstNameCheckBox.UseVisualStyleBackColor = true;
            FirstNameCheckBox.CheckStateChanged += FirstNameCheckBox_CheckStateChanged;
            // 
            // LastNameCheckBox
            // 
            LastNameCheckBox.AutoSize = true;
            LastNameCheckBox.Location = new Point(19, 135);
            LastNameCheckBox.Name = "LastNameCheckBox";
            LastNameCheckBox.Size = new Size(118, 29);
            LastNameCheckBox.TabIndex = 10;
            LastNameCheckBox.Text = "Last name";
            LastNameCheckBox.UseVisualStyleBackColor = true;
            LastNameCheckBox.CheckStateChanged += LastNameCheckBox_CheckStateChanged;
            // 
            // NumbersCheckBox
            // 
            NumbersCheckBox.AutoSize = true;
            NumbersCheckBox.Location = new Point(36, 214);
            NumbersCheckBox.Name = "NumbersCheckBox";
            NumbersCheckBox.Size = new Size(182, 29);
            NumbersCheckBox.TabIndex = 11;
            NumbersCheckBox.Text = "Contains numbers";
            NumbersCheckBox.UseVisualStyleBackColor = true;
            // 
            // UppercaseCheckBox
            // 
            UppercaseCheckBox.AutoSize = true;
            UppercaseCheckBox.Location = new Point(36, 249);
            UppercaseCheckBox.Name = "UppercaseCheckBox";
            UppercaseCheckBox.Size = new Size(277, 29);
            UppercaseCheckBox.TabIndex = 12;
            UppercaseCheckBox.Text = "Contains uppercase characters";
            UppercaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // LowercaseCheckBox
            // 
            LowercaseCheckBox.AutoSize = true;
            LowercaseCheckBox.Location = new Point(36, 284);
            LowercaseCheckBox.Name = "LowercaseCheckBox";
            LowercaseCheckBox.Size = new Size(273, 29);
            LowercaseCheckBox.TabIndex = 13;
            LowercaseCheckBox.Text = "Contains lowercase characters";
            LowercaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // FullNameCheckBox
            // 
            FullNameCheckBox.AutoSize = true;
            FullNameCheckBox.Location = new Point(19, 170);
            FullNameCheckBox.Name = "FullNameCheckBox";
            FullNameCheckBox.Size = new Size(114, 29);
            FullNameCheckBox.TabIndex = 14;
            FullNameCheckBox.Text = "Full name";
            FullNameCheckBox.UseVisualStyleBackColor = true;
            FullNameCheckBox.CheckStateChanged += FullNameCheckBox_CheckStateChanged;
            // 
            // RandomCharCheckBox
            // 
            RandomCharCheckBox.AutoSize = true;
            RandomCharCheckBox.Location = new Point(19, 205);
            RandomCharCheckBox.Name = "RandomCharCheckBox";
            RandomCharCheckBox.Size = new Size(190, 29);
            RandomCharCheckBox.TabIndex = 15;
            RandomCharCheckBox.Text = "Random characters";
            RandomCharCheckBox.UseVisualStyleBackColor = true;
            RandomCharCheckBox.CheckStateChanged += RandomCharCheckBox_CheckStateChanged;
            // 
            // CustomTextBox
            // 
            CustomTextBox.Location = new Point(19, 281);
            CustomTextBox.Name = "CustomTextBox";
            CustomTextBox.Size = new Size(260, 31);
            CustomTextBox.TabIndex = 17;
            CustomTextBox.TextChanged += CustomTextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 253);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 16;
            label4.Text = "Custom string:";
            // 
            // StaysSameCheckBox
            // 
            StaysSameCheckBox.AutoSize = true;
            StaysSameCheckBox.Location = new Point(19, 328);
            StaysSameCheckBox.Name = "StaysSameCheckBox";
            StaysSameCheckBox.Size = new Size(202, 29);
            StaysSameCheckBox.TabIndex = 18;
            StaysSameCheckBox.Text = "Value stays the same";
            StaysSameCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TrueFalseCheckBox);
            groupBox1.Controls.Add(YesNoCheckBox);
            groupBox1.Controls.Add(CompanyCheckBox);
            groupBox1.Controls.Add(NINOCheckBox);
            groupBox1.Controls.Add(EmailCheckBox);
            groupBox1.Controls.Add(PhoneNumCheckBox);
            groupBox1.Controls.Add(PostcodeCheckBox);
            groupBox1.Controls.Add(AddressCheckBox);
            groupBox1.Controls.Add(FirstNameCheckBox);
            groupBox1.Controls.Add(LastNameCheckBox);
            groupBox1.Controls.Add(StaysSameCheckBox);
            groupBox1.Controls.Add(FullNameCheckBox);
            groupBox1.Controls.Add(RandomCharCheckBox);
            groupBox1.Controls.Add(CustomTextBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(432, 375);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "String value";
            // 
            // TrueFalseCheckBox
            // 
            TrueFalseCheckBox.AutoSize = true;
            TrueFalseCheckBox.Location = new Point(246, 203);
            TrueFalseCheckBox.Name = "TrueFalseCheckBox";
            TrueFalseCheckBox.Size = new Size(115, 29);
            TrueFalseCheckBox.TabIndex = 25;
            TrueFalseCheckBox.Text = "True/False";
            TrueFalseCheckBox.UseVisualStyleBackColor = true;
            TrueFalseCheckBox.CheckStateChanged += TrueFalseCheckBox_CheckStateChanged;
            // 
            // YesNoCheckBox
            // 
            YesNoCheckBox.AutoSize = true;
            YesNoCheckBox.Location = new Point(246, 168);
            YesNoCheckBox.Name = "YesNoCheckBox";
            YesNoCheckBox.Size = new Size(94, 29);
            YesNoCheckBox.TabIndex = 24;
            YesNoCheckBox.Text = "Yes/No";
            YesNoCheckBox.UseVisualStyleBackColor = true;
            YesNoCheckBox.CheckStateChanged += YesNoCheckBox_CheckStateChanged;
            // 
            // CompanyCheckBox
            // 
            CompanyCheckBox.AutoSize = true;
            CompanyCheckBox.Location = new Point(246, 28);
            CompanyCheckBox.Name = "CompanyCheckBox";
            CompanyCheckBox.Size = new Size(164, 29);
            CompanyCheckBox.TabIndex = 23;
            CompanyCheckBox.Text = "Company name";
            CompanyCheckBox.UseVisualStyleBackColor = true;
            CompanyCheckBox.CheckStateChanged += CompanyCheckBox_CheckStateChanged;
            // 
            // NINOCheckBox
            // 
            NINOCheckBox.AutoSize = true;
            NINOCheckBox.Location = new Point(246, 63);
            NINOCheckBox.Name = "NINOCheckBox";
            NINOCheckBox.Size = new Size(83, 29);
            NINOCheckBox.TabIndex = 22;
            NINOCheckBox.Text = "NINO";
            NINOCheckBox.UseVisualStyleBackColor = true;
            NINOCheckBox.CheckStateChanged += NINOCheckBox_CheckStateChanged;
            // 
            // EmailCheckBox
            // 
            EmailCheckBox.AutoSize = true;
            EmailCheckBox.Location = new Point(246, 133);
            EmailCheckBox.Name = "EmailCheckBox";
            EmailCheckBox.Size = new Size(80, 29);
            EmailCheckBox.TabIndex = 21;
            EmailCheckBox.Text = "Email";
            EmailCheckBox.UseVisualStyleBackColor = true;
            EmailCheckBox.CheckStateChanged += EmailCheckBox_CheckStateChanged;
            // 
            // PhoneNumCheckBox
            // 
            PhoneNumCheckBox.AutoSize = true;
            PhoneNumCheckBox.Location = new Point(246, 98);
            PhoneNumCheckBox.Name = "PhoneNumCheckBox";
            PhoneNumCheckBox.Size = new Size(155, 29);
            PhoneNumCheckBox.TabIndex = 20;
            PhoneNumCheckBox.Text = "Phone number";
            PhoneNumCheckBox.UseVisualStyleBackColor = true;
            PhoneNumCheckBox.CheckStateChanged += PhoneNumCheckBox_CheckStateChanged;
            // 
            // PostcodeCheckBox
            // 
            PostcodeCheckBox.AutoSize = true;
            PostcodeCheckBox.Location = new Point(19, 65);
            PostcodeCheckBox.Name = "PostcodeCheckBox";
            PostcodeCheckBox.Size = new Size(111, 29);
            PostcodeCheckBox.TabIndex = 19;
            PostcodeCheckBox.Text = "Postcode";
            PostcodeCheckBox.UseVisualStyleBackColor = true;
            PostcodeCheckBox.CheckStateChanged += PostcodeCheckBox_CheckStateChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(MaxStringLength);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(LowercaseCheckBox);
            groupBox2.Controls.Add(UppercaseCheckBox);
            groupBox2.Controls.Add(MinStringLength);
            groupBox2.Controls.Add(NumbersCheckBox);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(PrefixTextBox);
            groupBox2.Location = new Point(450, 72);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(338, 375);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "String constraints";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 184);
            label5.Name = "label5";
            label5.Size = new Size(127, 25);
            label5.TabIndex = 19;
            label5.Text = "Other options:";
            // 
            // StringFieldForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 467);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(FieldNameLbl);
            Name = "StringFieldForm";
            Text = "Test Data Generator - String Format";
            FormClosing += StringFieldOptionForm_FormClosing;
            Load += StringFieldOptionForm_Load;
            ((System.ComponentModel.ISupportInitialize)MaxStringLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinStringLength).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown MaxStringLength;
        private NumericUpDown MinStringLength;
        private Label label2;
        private Label label3;
        private TextBox PrefixTextBox;
        private Label FieldNameLbl;
        private CheckBox AddressCheckBox;
        private CheckBox FirstNameCheckBox;
        private CheckBox LastNameCheckBox;
        private CheckBox NumbersCheckBox;
        private CheckBox UppercaseCheckBox;
        private CheckBox LowercaseCheckBox;
        private CheckBox FullNameCheckBox;
        private CheckBox RandomCharCheckBox;
        private TextBox CustomTextBox;
        private Label label4;
        private CheckBox StaysSameCheckBox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label5;
        private CheckBox PhoneNumCheckBox;
        private CheckBox PostcodeCheckBox;
        private CheckBox EmailCheckBox;
        private CheckBox CompanyCheckBox;
        private CheckBox NINOCheckBox;
        private CheckBox YesNoCheckBox;
        private CheckBox TrueFalseCheckBox;
    }
}