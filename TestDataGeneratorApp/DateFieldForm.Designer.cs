namespace TestDataGeneratorApp
{
    partial class DateFieldForm
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
            components = new System.ComponentModel.Container();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            CustomDateTextBox = new TextBox();
            DateFormatTextBox = new TextBox();
            label3 = new Label();
            MaxDateTimePicker = new DateTimePicker();
            MinDateTimePicker = new DateTimePicker();
            FieldNameLbl = new Label();
            FormatExplainToolTip = new ToolTip(components);
            StaysSameCheckBox = new CheckBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            DateFormatLinkLbl = new LinkLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 30);
            label4.Name = "label4";
            label4.Size = new Size(78, 25);
            label4.TabIndex = 24;
            label4.Text = "Custom:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 75);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 20;
            label2.Text = "Minimum:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 30);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 18;
            label1.Text = "Maximum:";
            // 
            // CustomDateTextBox
            // 
            CustomDateTextBox.Location = new Point(17, 64);
            CustomDateTextBox.Name = "CustomDateTextBox";
            CustomDateTextBox.Size = new Size(231, 31);
            CustomDateTextBox.TabIndex = 25;
            CustomDateTextBox.TextChanged += CustomDateTextBox_TextChanged;
            // 
            // DateFormatTextBox
            // 
            DateFormatTextBox.Location = new Point(9, 160);
            DateFormatTextBox.Name = "DateFormatTextBox";
            DateFormatTextBox.Size = new Size(352, 31);
            DateFormatTextBox.TabIndex = 27;
            DateFormatTextBox.TextChanged += DateFormatTextBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 132);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 26;
            label3.Text = "Format:";
            // 
            // MaxDateTimePicker
            // 
            MaxDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            MaxDateTimePicker.Format = DateTimePickerFormat.Custom;
            MaxDateTimePicker.Location = new Point(107, 25);
            MaxDateTimePicker.Name = "MaxDateTimePicker";
            MaxDateTimePicker.Size = new Size(254, 31);
            MaxDateTimePicker.TabIndex = 28;
            MaxDateTimePicker.Value = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // MinDateTimePicker
            // 
            MinDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            MinDateTimePicker.Format = DateTimePickerFormat.Custom;
            MinDateTimePicker.Location = new Point(107, 75);
            MinDateTimePicker.Name = "MinDateTimePicker";
            MinDateTimePicker.Size = new Size(254, 31);
            MinDateTimePicker.TabIndex = 29;
            MinDateTimePicker.Value = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // FieldNameLbl
            // 
            FieldNameLbl.AutoSize = true;
            FieldNameLbl.Font = new Font("Segoe UI", 11F);
            FieldNameLbl.ForeColor = Color.FromArgb(0, 51, 153);
            FieldNameLbl.Location = new Point(41, 25);
            FieldNameLbl.Name = "FieldNameLbl";
            FieldNameLbl.Size = new Size(71, 30);
            FieldNameLbl.TabIndex = 30;
            FieldNameLbl.Text = "label5";
            // 
            // StaysSameCheckBox
            // 
            StaysSameCheckBox.AutoSize = true;
            StaysSameCheckBox.Location = new Point(17, 118);
            StaysSameCheckBox.Name = "StaysSameCheckBox";
            StaysSameCheckBox.Size = new Size(202, 29);
            StaysSameCheckBox.TabIndex = 31;
            StaysSameCheckBox.Text = "Value stays the same";
            StaysSameCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CustomDateTextBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(StaysSameCheckBox);
            groupBox1.Location = new Point(52, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(262, 165);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Date value";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DateFormatLinkLbl);
            groupBox2.Controls.Add(MaxDateTimePicker);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(MinDateTimePicker);
            groupBox2.Controls.Add(DateFormatTextBox);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(369, 72);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(377, 243);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            groupBox2.Text = "Date constraints";
            // 
            // DateFormatLinkLbl
            // 
            DateFormatLinkLbl.AutoSize = true;
            DateFormatLinkLbl.LinkColor = SystemColors.HotTrack;
            DateFormatLinkLbl.Location = new Point(113, 194);
            DateFormatLinkLbl.Name = "DateFormatLinkLbl";
            DateFormatLinkLbl.Size = new Size(248, 25);
            DateFormatLinkLbl.TabIndex = 34;
            DateFormatLinkLbl.TabStop = true;
            DateFormatLinkLbl.Text = "Use the .NET format specifiers";
            DateFormatLinkLbl.LinkClicked += DateFormatLinkLbl_LinkClicked;
            // 
            // DateFieldForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 361);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(FieldNameLbl);
            Name = "DateFieldForm";
            Text = "Test Data Generator - Date Format";
            FormClosing += DateFieldOptionForm_FormClosing;
            Load += DateFieldOptionForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox CustomDateTextBox;
        private TextBox DateFormatTextBox;
        private Label label3;
        private DateTimePicker MaxDateTimePicker;
        private DateTimePicker MinDateTimePicker;
        private Label FieldNameLbl;
        private ToolTip FormatExplainToolTip;
        private CheckBox StaysSameCheckBox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private LinkLabel DateFormatLinkLbl;
    }
}