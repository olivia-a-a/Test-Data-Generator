using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestDataGeneratorApp.Presenters
{
    public enum Tables
    {
        Header,
        Data,
        Trailer
    }
    public class TestGeneratorPresenter
    {
        private ITestGeneratorView TestGeneratorView;
        public string JSONPath = "test_generator_config.json";
        public string TestDataFilePath = "";
        private string JSONData = "";
        private TestDataConfig? DataFileConfigs;
        private List<string> Options = ["String Format", "Date Format", "Number Format"];
        private string RequiredColumn = "Record Quantity";
        private List<string> EditableColumns = ["Record Quantity"];
        private Table SelectedTable = new();
        private IField SelectedCell;

        public Table HeaderTable { get; set; }
        public Table DataTable { get; set; }
        public Table TrailerTable { get; set; }

        public TestGeneratorPresenter(ITestGeneratorView view) 
        { 
            TestGeneratorView = view;
            TestGeneratorView.LoadView += SetupTestDataTables;
            TestGeneratorView.GenerateFile += GenerateTestDataFile;
            TestGeneratorView.SelectedStringFieldOption += ShowOptionForm;
            TestGeneratorView.EditedCellValue += EditCellData;
            TestGeneratorView.FieldOptionsCMSEnabler += ShowFieldOptions;
            TestGeneratorView.RowAdded += CheckTableSelectedToAddRow;
            TestGeneratorView.RowDeleted += CheckTableSelectedToDeleteRow;
            TestGeneratorView.ShowFileName += ShowFileNameForm;
        }

        private void ReadJSONFile()
        {
            try
            {
                JSONData = File.ReadAllText(JSONPath);
            } 
            catch (FileNotFoundException)
            {
                TestGeneratorView.Msg = $"File {JSONPath} not found. \nPlease ensure the .exe is in the same directory as {JSONPath}";
                TestGeneratorView.show_Message();
            }
        }

        private void SerialiseJSONFile()
        {
            try
            {
                DataFileConfigs = JsonSerializer.Deserialize<TestDataConfig>(JSONData, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } });
            }
            catch (JsonException error)
            {
                TestGeneratorView.Msg = $"The JSON file at {JSONPath} contains an error. Please use the information below to correct the error before restarting the application: \n\n{error.Message}";
                TestGeneratorView.show_Message();
            }
        }

        private void AddRequiredColumns(List<string> columns)
        {
            if (!columns.Contains(RequiredColumn))
            {
                columns.Add(RequiredColumn);
                TestGeneratorView.Msg = $"Added the required {RequiredColumn} column.";
                TestGeneratorView.show_Message();
            }
            else
            {
                columns.Remove(RequiredColumn);
                columns.Add(RequiredColumn); // making sure record quantity is always last
            }
        }

        private void RemoveColumnDuplicates(List<string> columns)
        {
            string duplicatedColumns = "";
            Dictionary<string, int> columnCounts = new();

            foreach (string column in columns)
            {
                if (columnCounts.ContainsKey(column))
                    columnCounts[column]++;
                else
                    columnCounts[column] = 1;
            }

            foreach (var pair in columnCounts)
            {
                if (pair.Value > 1)
                {
                    for (int i = 0; i < pair.Value - 1; i++)
                    {
                        columns.Remove(pair.Key);
                    }
                    duplicatedColumns += $"\n - {pair.Key}";
                }
            }

            if (duplicatedColumns.Length > 0)
            {
                TestGeneratorView.Msg = $"Removed the following duplicated column(s) {duplicatedColumns}";
                TestGeneratorView.show_Message();
            }            
        }

        private void RemoveBlankColumns(List<string> columns)
        {
            List<string> columnsToRemove = [];
            int blanksRemoved = 0;

            foreach (string column in columns)
            {
                if (string.IsNullOrWhiteSpace(column))
                {
                    columnsToRemove.Add(column); // can't ammend collection while looping through so have to add to a different list holding what needs to be removed
                }
            }

            foreach (string columnToRemove in columnsToRemove) 
            {
                if (columns.Contains(columnToRemove))
                {
                    columns.Remove(columnToRemove);
                    blanksRemoved++;
                }
            }

            if (blanksRemoved > 0)
            {
                TestGeneratorView.Msg = $"Removed {blanksRemoved} blank column(s)";
                TestGeneratorView.show_Message();
            }
        }

        private void ValidateColumns(List<string> columns)
        {
            RemoveBlankColumns(columns);
            RemoveColumnDuplicates(columns);
            AddRequiredColumns(columns);        
        }

        public void SetupTestDataTables(object? sender, EventArgs e)
        {
            ReadJSONFile();
            SerialiseJSONFile();

            TestGeneratorView.EditableColumns.AddRange(EditableColumns);

            if (DataFileConfigs?.header_table != null)
            {
                HeaderTable = DataFileConfigs.header_table;
                if (HeaderTable.columns.Count > 0)
                {
                    ValidateColumns(HeaderTable.columns);
                }
                else
                {
                    TestGeneratorView.AddHeaderRowEnabled = false;
                }                
                TestGeneratorView.Draw_Header_Table(HeaderTable);
            }
            else
            {
                TestGeneratorView.AddHeaderRowEnabled = false;
            }

            if (DataFileConfigs?.data_table != null)
            {
                DataTable = DataFileConfigs.data_table;
                if (DataTable.columns.Count > 0)
                {
                    ValidateColumns(DataTable.columns);
                }
                else
                {
                    TestGeneratorView.AddDataRowEnabled = false;
                }
                TestGeneratorView.Draw_Data_Table(DataTable);
            }
            else
            {
                TestGeneratorView.AddDataRowEnabled = false;
            }

            if (DataFileConfigs?.trailer_table != null)
            {
                TrailerTable = DataFileConfigs.trailer_table;
                if (TrailerTable.columns.Count > 0)
                {
                    ValidateColumns(TrailerTable.columns);
                }
                else
                {
                    TestGeneratorView.AddTrailerRowEnabled = false;
                }
                TestGeneratorView.Draw_Trailer_Table(TrailerTable);
            }
            else
            {
                TestGeneratorView.AddTrailerRowEnabled = false;
            }

            foreach (string option in Options)
            {
                TestGeneratorView.FieldOptions = option;
            }
        }

        public void GenerateTestDataFile(object? sender, EventArgs e)
        {
            TestGeneratorView.GenerateBtnEnabled = false;
            if (string.IsNullOrEmpty(TestGeneratorView.FolderPath) || string.IsNullOrEmpty(TestGeneratorView.FileName))
            {
                TestGeneratorView.Msg = $"Invalid file path.\nPlease select a different folder or file name.";
                TestGeneratorView.show_Message();
            }
            else
            {
                TestDataFilePath = TestGeneratorView.FullPath;
                List<List<IField>> CombinedRows = new();
                CombinedRows.AddRange(HeaderTable.rows);
                CombinedRows.AddRange(DataTable.rows);
                CombinedRows.AddRange(TrailerTable.rows);


                using (StreamWriter TestDataFile = new(TestDataFilePath))
                {                    
                    foreach (List<IField> Row in CombinedRows)
                    {
                        string RecordQuantity = Row[Row.Count - 1].Value; // record quantity is always the last column

                        int num;
                        if (int.TryParse(RecordQuantity, out num))
                        {
                            for (int i = 0; i < num; i++)
                            {
                                string FileLine = "";
                                foreach (IField Cell in Row)
                                {
                                    if (Cell.FieldName != "Record Quantity") // ignore the record quantity column
                                    {
                                        Cell.GenerateValue();
                                        FileLine += $"{Cell.Value}|";
                                    }
                                }
                                TestDataFile.WriteLine(FileLine);
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(RecordQuantity))
                            {
                                TestGeneratorView.Msg = $"Skipping record. Unable to generate '{RecordQuantity}' records. \n\nPlease ensure that all Record Quantity entries are whole numbers.";
                                TestGeneratorView.show_Message();
                            }  
                        }
                    }
                }

                TestGeneratorView.Msg = "File generation complete.";
                TestGeneratorView.show_Message();
            }
            TestGeneratorView.GenerateBtnEnabled = true;
        }

        public void ShowFileNameForm(object? sender, EventArgs e)
        {
            TestGeneratorView.FileNameForm = new FileNameForm();
            TestGeneratorView.FileNameForm.ShowAsDialogue();
            TestGeneratorView.FileName = TestGeneratorView.FileNameForm.FileName;
            TestGeneratorView.FullPath = TestGeneratorView.FolderPath + TestGeneratorView.FileName;
        }

        public void ShowOptionForm(object? sender, EventArgs e)
        {
            SetSelectedTable();
            SetSelectedCell();
            if (TestGeneratorView.SelectedFieldOption == "String Format")
            {
                TestGeneratorView.OptionForm = new StringFieldForm();
            }
            else if (TestGeneratorView.SelectedFieldOption == "Date Format")
            {
                TestGeneratorView.OptionForm = new DateFieldForm();
            }
            else if (TestGeneratorView.SelectedFieldOption == "Number Format")
            {
                TestGeneratorView.OptionForm = new NumberFieldForm();
            }

            TestGeneratorView.OptionForm.FieldName = SelectedCell.FieldName;
            TestGeneratorView.OptionForm.FieldFormat = SelectedCell;
            TestGeneratorView.OptionForm.ShowAsDialogue();
            SelectedTable.rows[TestGeneratorView.SelectedCellCoords.Row][TestGeneratorView.SelectedCellCoords.Column] = TestGeneratorView.OptionForm.FieldFormat;
            SelectedTable.rows[TestGeneratorView.SelectedCellCoords.Row][TestGeneratorView.SelectedCellCoords.Column].FieldName = SelectedCell.FieldName;
            
            SetSelectedCell();
            TestGeneratorView.SelectedCellValue = SelectedCell.DisplayValue;


            switch (TestGeneratorView.SelectedTable)
            {
                case Tables.Header:
                    TestGeneratorView.HeaderCellValue = SelectedCell.DisplayValue;
                    break;
                case Tables.Data:
                    TestGeneratorView.DataCellValue = SelectedCell.DisplayValue;
                    break;
                case Tables.Trailer:
                    TestGeneratorView.TrailerCellValue = SelectedCell.DisplayValue;
                    break;
                default:
                    break;
            }
            TestGeneratorView.SelectedCellCoords = (-1, -1);
            TestGeneratorView.EnableFieldOptions = false;
        }

        public void ShowFieldOptions(object? sender, EventArgs e)
        {
            // only enable the context menu strip if its a valid cell thats been selected
            SetSelectedTable();
            if (TestGeneratorView.SelectedCellCoords.Row < 0 || TestGeneratorView.SelectedCellCoords.Column < 0)
            {                
                TestGeneratorView.EnableFieldOptions = false; 
            }
            else {
                SetSelectedCell();
                if (EditableColumns.Contains(SelectedCell.FieldName))
                {
                    TestGeneratorView.EnableFieldOptions = false;
                }
                else
                {            
                    TestGeneratorView.EnableFieldOptions = true;
                }                
            }
        }

        public void EditCellData(object? sender, EventArgs e)
        {
            SetSelectedTable();
            SetSelectedCell();
            string editedValue = TestGeneratorView.SelectedCellValue.ToString() ?? "";

            int quantity;
            if (int.TryParse(TestGeneratorView.SelectedCellValue.ToString(), out quantity))
            {
                SelectedCell.Value = quantity.ToString();
                SelectedCell.DisplayValue = quantity.ToString();
            }
            else
            {
                TestGeneratorView.Msg = $"Please ensure only integers (whole numbers) are provided in the Record Quantity column. \n\n You provided: {TestGeneratorView.SelectedCellValue}";
                TestGeneratorView.show_Message();
                SelectedCell.Value = editedValue;
                SelectedCell.DisplayValue = editedValue;
            }
        }

        public void CheckTableSelectedToAddRow(object? sender, EventArgs e)
        {
            SetSelectedTable();
            List<IField> FetchedRow = [];

            for (int i = 0; i < SelectedTable.columns.Count; i++)
            {
                IField TempFormat = new StringField
                {
                    FieldName = SelectedTable.columns[i]
                };

                FetchedRow.Add(TempFormat);
            }
            SelectedTable.rows.Add(FetchedRow);
        }

        public void CheckTableSelectedToDeleteRow(object? sender, EventArgs e)
        {
            SetSelectedTable();
            SelectedTable.rows.RemoveAt(TestGeneratorView.SelectedCellCoords.Row);
        }

        private void SetSelectedTable()
        {
            switch (TestGeneratorView.SelectedTable)
            {
                case Tables.Header:
                    SelectedTable = HeaderTable;
                    break;
                case Tables.Data:
                    SelectedTable = DataTable;
                    break;
                case Tables.Trailer:
                    SelectedTable = TrailerTable;
                    break;
                default:
                    break;
            }
        }

        private void SetSelectedCell()
        {
            switch (TestGeneratorView.SelectedTable)
            {
                case Tables.Header:
                    SelectedTable = HeaderTable;
                    SelectedCell = HeaderTable.rows[TestGeneratorView.SelectedCellCoords.Row][TestGeneratorView.SelectedCellCoords.Column];
                    break;
                case Tables.Data:
                    SelectedTable = DataTable;
                    SelectedCell = DataTable.rows[TestGeneratorView.SelectedCellCoords.Row][TestGeneratorView.SelectedCellCoords.Column];
                    break;
                case Tables.Trailer:
                    SelectedTable = TrailerTable;
                    SelectedCell = TrailerTable.rows[TestGeneratorView.SelectedCellCoords.Row][TestGeneratorView.SelectedCellCoords.Column];
                    break;
                default:
                    break;
            }
        }

    }
}
