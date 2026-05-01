using System.Data.Common;
using System.Linq;
using System.Text.Json;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Presenters;
using TestDataGeneratorApp.Views;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TestDataGeneratorApp
{
    public partial class TestGeneratorForm : Form, ITestGeneratorView
    {
        private string _msg = "";
        private string _file_name = "";
        private List<string> _editable_columns = [];
        private object _selected_cell_value = "";
        private (int Row, int Column) _selected_cell_coords = (-1, -1);
        private string _selected_field_option = "";
        private string _selected_column_name = "";
        private DataGridView _selected_table;

        private TestGeneratorPresenter Presenter;

        public event EventHandler? LoadView;
        public event EventHandler? GenerateFile;
        public event EventHandler? ShowFileName;
        public event EventHandler? SelectedStringFieldOption;
        public event EventHandler? EditedCellValue;
        public event EventHandler? FieldOptionsCMSEnabler;
        public event EventHandler? RowAdded;
        public event EventHandler? RowDeleted;

        public string Msg { get => _msg; set => _msg = value; }

        public string SelectedFieldOption { get => _selected_field_option; set => _selected_field_option = value; }

        public Tables SelectedTable { get; set; }

        public (int Row, int Column) SelectedCellCoords { get => _selected_cell_coords; set => _selected_cell_coords = value; }
        public object SelectedCellValue { get => _selected_cell_value; set => _selected_cell_value = value; }

        public string FieldOptions { set => FieldOptionsCMS.Items.Add(value); }

        public object HeaderCellValue { get => HeaderDGV.Rows[SelectedCellCoords.Row].Cells[SelectedCellCoords.Column].Value;  set => HeaderDGV.Rows[SelectedCellCoords.Row].Cells[SelectedCellCoords.Column].Value = value; }
        public object DataCellValue { get => DataDGV.Rows[SelectedCellCoords.Row].Cells[SelectedCellCoords.Column].Value; set => DataDGV.Rows[SelectedCellCoords.Row].Cells[SelectedCellCoords.Column].Value = value; }

        public object TrailerCellValue { get => TrailerDGV.Rows[SelectedCellCoords.Row].Cells[SelectedCellCoords.Column].Value;  set => TrailerDGV.Rows[SelectedCellCoords.Row].Cells[SelectedCellCoords.Column].Value = value; }

        public bool AddHeaderRowEnabled { get => AddHeaderRowBtn.Enabled; set => AddHeaderRowBtn.Enabled = value; }
        public bool AddTrailerRowEnabled { get => AddTrailerRowBtn.Enabled; set => AddTrailerRowBtn.Enabled = value; }
        public bool AddDataRowEnabled { get => AddDataRowBtn.Enabled; set => AddDataRowBtn.Enabled = value; }

        public bool EnableFieldOptions { set => FieldOptionsCMS.Enabled = value; }
        public List<string> EditableColumns { get => _editable_columns; set => _editable_columns = value; }

        public string FileName { get => _file_name; set => _file_name = value; }

        public string FolderPath { get; set; }
        public string FullPath { get => FolderPathTextBox.Text; set => FolderPathTextBox.Text = value; }

        public bool GenerateBtnEnabled { get => generateDataBtn.Enabled; set => generateDataBtn.Enabled = value; }

        public IOptionView OptionForm { get; set; }

        public IFileNameView FileNameForm { get; set; }

        public TestGeneratorForm()
        {
            this.Presenter = new TestGeneratorPresenter(this);
            InitializeComponent();
        }

        public void TestGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        public void show_Message()
        {
            MessageBox.Show(Msg);
        }

        private void SelectFolderBtn_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FolderPath = FolderBrowserDialog.SelectedPath;
                FullPath = FolderPath + FileName;
            }
        }

        private void NameFileBtn_Click(object sender, EventArgs e)
        {
            ShowFileName?.Invoke(this, EventArgs.Empty);
        }

        private void generateDataBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GenerateFile?.Invoke(this, EventArgs.Empty);
            Cursor = Cursors.Default;
        }

        private void FieldOptionsCMS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SelectedFieldOption = e.ClickedItem.Text;

            SelectedStringFieldOption?.Invoke(this, EventArgs.Empty);
        }

        private void FieldOptionsCMS_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            EnableFieldOptions = false; //resetting the cms to be false before it closes so that it doesn't stay true after valid click
        }

        private void Draw_Table(DataGridView dataGridView, Table table)
        {
            dataGridView.Rows.Clear();

            // add all the column names for the data record
            for (int i = 0; i < table.columns.Count; i++)
            {
                dataGridView.Columns.Add(table.columns[i], table.columns[i]);

                if (EditableColumns.Contains(dataGridView.Columns[i].Name))
                {
                    dataGridView.Columns[i].ReadOnly = false;
                }
                else
                {
                    dataGridView.Columns[i].ReadOnly = true;
                }
            }

            for (int r = 0; r < table.rows.Count; r++)
            {
                int rowAddedIndex = dataGridView.Rows.Add();

                for (int c = 0; c < table.rows[r].Count; c++)
                {
                    dataGridView.Rows[rowAddedIndex].Cells[c].Value = table.rows[r][c].DisplayValue;
                }
            }
        }

        public void Draw_Header_Table(Table HeaderTable)
        {
            Draw_Table(HeaderDGV, HeaderTable);
        }

        public void Draw_Data_Table(Table DataTable)
        {
            Draw_Table(DataDGV, DataTable);
        }

        public void Draw_Trailer_Table(Table TrailerTable)
        {
            Draw_Table(TrailerDGV, TrailerTable);
        }

        private void HeaderDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                SelectedCellCoords = (e.RowIndex, e.ColumnIndex);
                SelectedTable = Tables.Header;
                FieldOptionsCMSEnabler?.Invoke(this, EventArgs.Empty);
            }
        }

        private void AddHeaderRowBtn_Click(object sender, EventArgs e)
        {
            HeaderDGV.Rows.Add();
            SelectedTable = Tables.Header;
            RowAdded?.Invoke(this, EventArgs.Empty);
        }

        private void HeaderDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SelectedTable = Tables.Header;
            SelectedCellCoords = (e.RowIndex, e.ColumnIndex);
            SelectedCellValue = HeaderDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            EditedCellValue?.Invoke(this, EventArgs.Empty);
        }

        private void HeaderDGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            SelectedTable = Tables.Header;
            SelectedCellCoords = (e.Row.Index, 0);
            RowDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void DataDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                SelectedCellCoords = (e.RowIndex, e.ColumnIndex);
                SelectedTable = Tables.Data;
                FieldOptionsCMSEnabler?.Invoke(this, EventArgs.Empty);
            }
        }

        private void AddDataRowBtn_Click(object sender, EventArgs e)
        {
            DataDGV.Rows.Add();
            SelectedTable = Tables.Data;
            RowAdded?.Invoke(this, EventArgs.Empty);
        }

        private void DataDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SelectedTable = Tables.Data;
            SelectedCellCoords = (e.RowIndex, e.ColumnIndex);
            SelectedCellValue = DataDGV.Rows[SelectedCellCoords.Row].Cells[SelectedCellCoords.Column].Value;
            EditedCellValue?.Invoke(this, EventArgs.Empty);

        }

        private void DataDGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            SelectedTable = Tables.Data;
            SelectedCellCoords = (e.Row.Index, 0);
            RowDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void TrailerDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                SelectedCellCoords = (e.RowIndex, e.ColumnIndex);
                SelectedTable = Tables.Trailer;
                FieldOptionsCMSEnabler?.Invoke(this, EventArgs.Empty);
            }
        }

        private void AddTrailerRowBtn_Click(object sender, EventArgs e)
        {
            TrailerDGV.Rows.Add();
            SelectedTable = Tables.Trailer;
            RowAdded?.Invoke(this, EventArgs.Empty);

        }

        private void TrailerDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SelectedTable = Tables.Trailer;
            SelectedCellCoords = (e.RowIndex, e.ColumnIndex);
            SelectedCellValue = TrailerDGV.Rows[SelectedCellCoords.Row].Cells[SelectedCellCoords.Column].Value;
            EditedCellValue?.Invoke(this, EventArgs.Empty);
        }

        private void TrailerDGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            SelectedTable = Tables.Trailer;
            SelectedCellCoords = (e.Row.Index, 0);
            RowDeleted?.Invoke(this, EventArgs.Empty);
        }

    }
}
