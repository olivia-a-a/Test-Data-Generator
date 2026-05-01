namespace TestDataGeneratorApp
{
    partial class TestGeneratorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            HeaderDGV = new DataGridView();
            FieldOptionsCMS = new ContextMenuStrip(components);
            generateDataBtn = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            AddHeaderRowBtn = new Button();
            tabPage2 = new TabPage();
            AddDataRowBtn = new Button();
            DataDGV = new DataGridView();
            tabPage3 = new TabPage();
            AddTrailerRowBtn = new Button();
            TrailerDGV = new DataGridView();
            FolderBrowserDialog = new FolderBrowserDialog();
            FolderPathTextBox = new TextBox();
            SelectFolderBtn = new Button();
            NameFileBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)HeaderDGV).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataDGV).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrailerDGV).BeginInit();
            SuspendLayout();
            // 
            // HeaderDGV
            // 
            HeaderDGV.AllowUserToAddRows = false;
            HeaderDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HeaderDGV.Location = new Point(3, 53);
            HeaderDGV.Name = "HeaderDGV";
            HeaderDGV.RowHeadersWidth = 62;
            HeaderDGV.Size = new Size(1630, 680);
            HeaderDGV.TabIndex = 0;
            HeaderDGV.CellEndEdit += HeaderDGV_CellEndEdit;
            HeaderDGV.CellMouseDown += HeaderDGV_CellMouseDown;
            HeaderDGV.UserDeletingRow += HeaderDGV_UserDeletingRow;
            // 
            // FieldOptionsCMS
            // 
            FieldOptionsCMS.Enabled = false;
            FieldOptionsCMS.ImageScalingSize = new Size(24, 24);
            FieldOptionsCMS.Name = "FieldOptionsCMS";
            FieldOptionsCMS.Size = new Size(61, 4);
            FieldOptionsCMS.Closing += FieldOptionsCMS_Closing;
            FieldOptionsCMS.ItemClicked += FieldOptionsCMS_ItemClicked;
            // 
            // generateDataBtn
            // 
            generateDataBtn.Font = new Font("Segoe UI", 9F);
            generateDataBtn.Location = new Point(12, 497);
            generateDataBtn.Name = "generateDataBtn";
            generateDataBtn.Size = new Size(150, 40);
            generateDataBtn.TabIndex = 12;
            generateDataBtn.Text = "Generate file";
            generateDataBtn.UseVisualStyleBackColor = true;
            generateDataBtn.Click += generateDataBtn_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(168, 56);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1644, 776);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(AddHeaderRowBtn);
            tabPage1.Controls.Add(HeaderDGV);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1636, 738);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Header Record";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // AddHeaderRowBtn
            // 
            AddHeaderRowBtn.Font = new Font("Segoe UI", 9F);
            AddHeaderRowBtn.Location = new Point(6, 6);
            AddHeaderRowBtn.Name = "AddHeaderRowBtn";
            AddHeaderRowBtn.RightToLeft = RightToLeft.No;
            AddHeaderRowBtn.Size = new Size(150, 40);
            AddHeaderRowBtn.TabIndex = 13;
            AddHeaderRowBtn.Text = "Add row";
            AddHeaderRowBtn.UseVisualStyleBackColor = true;
            AddHeaderRowBtn.Click += AddHeaderRowBtn_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(AddDataRowBtn);
            tabPage2.Controls.Add(DataDGV);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1636, 738);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Data Record";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // AddDataRowBtn
            // 
            AddDataRowBtn.Font = new Font("Segoe UI", 9F);
            AddDataRowBtn.Location = new Point(6, 6);
            AddDataRowBtn.Name = "AddDataRowBtn";
            AddDataRowBtn.RightToLeft = RightToLeft.No;
            AddDataRowBtn.Size = new Size(150, 40);
            AddDataRowBtn.TabIndex = 14;
            AddDataRowBtn.Text = "Add row";
            AddDataRowBtn.UseVisualStyleBackColor = true;
            AddDataRowBtn.Click += AddDataRowBtn_Click;
            // 
            // DataDGV
            // 
            DataDGV.AllowUserToAddRows = false;
            DataDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataDGV.Location = new Point(3, 53);
            DataDGV.Name = "DataDGV";
            DataDGV.RowHeadersWidth = 62;
            DataDGV.Size = new Size(1630, 680);
            DataDGV.TabIndex = 1;
            DataDGV.CellEndEdit += DataDGV_CellEndEdit;
            DataDGV.CellMouseDown += DataDGV_CellMouseDown;
            DataDGV.UserDeletingRow += DataDGV_UserDeletingRow;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(AddTrailerRowBtn);
            tabPage3.Controls.Add(TrailerDGV);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1636, 738);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Trailer Record";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // AddTrailerRowBtn
            // 
            AddTrailerRowBtn.Font = new Font("Segoe UI", 9F);
            AddTrailerRowBtn.Location = new Point(6, 6);
            AddTrailerRowBtn.Name = "AddTrailerRowBtn";
            AddTrailerRowBtn.RightToLeft = RightToLeft.No;
            AddTrailerRowBtn.Size = new Size(150, 40);
            AddTrailerRowBtn.TabIndex = 15;
            AddTrailerRowBtn.Text = "Add row";
            AddTrailerRowBtn.UseVisualStyleBackColor = true;
            AddTrailerRowBtn.Click += AddTrailerRowBtn_Click;
            // 
            // TrailerDGV
            // 
            TrailerDGV.AllowUserToAddRows = false;
            TrailerDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TrailerDGV.Location = new Point(3, 53);
            TrailerDGV.Name = "TrailerDGV";
            TrailerDGV.RowHeadersWidth = 62;
            TrailerDGV.Size = new Size(1630, 680);
            TrailerDGV.TabIndex = 2;
            TrailerDGV.CellEndEdit += TrailerDGV_CellEndEdit;
            TrailerDGV.CellMouseDown += TrailerDGV_CellMouseDown;
            TrailerDGV.UserDeletingRow += TrailerDGV_UserDeletingRow;
            // 
            // FolderPathTextBox
            // 
            FolderPathTextBox.Enabled = false;
            FolderPathTextBox.Location = new Point(218, 842);
            FolderPathTextBox.Name = "FolderPathTextBox";
            FolderPathTextBox.Size = new Size(1587, 31);
            FolderPathTextBox.TabIndex = 14;
            // 
            // SelectFolderBtn
            // 
            SelectFolderBtn.Location = new Point(12, 362);
            SelectFolderBtn.Name = "SelectFolderBtn";
            SelectFolderBtn.Size = new Size(150, 40);
            SelectFolderBtn.TabIndex = 15;
            SelectFolderBtn.Text = "Select folder";
            SelectFolderBtn.UseVisualStyleBackColor = true;
            SelectFolderBtn.Click += SelectFolderBtn_Click;
            // 
            // NameFileBtn
            // 
            NameFileBtn.Location = new Point(12, 429);
            NameFileBtn.Name = "NameFileBtn";
            NameFileBtn.Size = new Size(150, 40);
            NameFileBtn.TabIndex = 16;
            NameFileBtn.Text = "Name file";
            NameFileBtn.UseVisualStyleBackColor = true;
            NameFileBtn.Click += NameFileBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 848);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 19;
            label1.Text = "File Path:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.FromArgb(0, 51, 153);
            label2.Location = new Point(29, 15);
            label2.Name = "label2";
            label2.Size = new Size(1388, 32);
            label2.TabIndex = 20;
            label2.Text = "Add a row, then right click a cell to customise the format. Type your desired number of records into the Record Quantity column.\r\n";
            // 
            // TestGeneratorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1824, 904);
            ContextMenuStrip = FieldOptionsCMS;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NameFileBtn);
            Controls.Add(SelectFolderBtn);
            Controls.Add(FolderPathTextBox);
            Controls.Add(tabControl1);
            Controls.Add(generateDataBtn);
            Name = "TestGeneratorForm";
            Text = "Test Data Generator";
            Load += TestGeneratorForm_Load;
            ((System.ComponentModel.ISupportInitialize)HeaderDGV).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataDGV).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TrailerDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView HeaderDGV;
        private Button generateDataBtn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView DataDGV;
        private TabPage tabPage3;
        private DataGridView TrailerDGV;
        private ContextMenuStrip FieldOptionsCMS;
        private Button AddHeaderRowBtn;
        private Button AddDataRowBtn;
        private Button AddTrailerRowBtn;
        private FolderBrowserDialog FolderBrowserDialog;
        private TextBox FolderPathTextBox;
        private Button SelectFolderBtn;
        private Button NameFileBtn;
        private Label label1;
        private Label label2;
    }
}
