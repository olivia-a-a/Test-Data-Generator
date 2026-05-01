using Newtonsoft.Json;
using System.Reflection;
using System.Windows.Forms;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Presenters;
using TestDataGeneratorApp.Views;

namespace GeneratorAppTest
{
    public class TestGeneratorPresTests
    {
        [SetUp]
        public void Setup()
        {
            string JSONstring = """"                 
                {
                    "file_name": {
                	    "file_name_column1": {
                		    "Title": "Prefix",
                		    "Data": "CFSDWH"
                	    },
                	    "file_name_column2": {
                		    "Title": "date",
                		    "Data": "yyyyMMdd"
                	    },
                	    "file_name_column3": {
                		    "Title": "Suffix",
                		    "Data": "01"
                	    }
                    },
                	"header_table": {
                        "columns": ["TestHeader1", "TestHeader2", "Record Quantity"],
                        "rows": [ [
                                    {"$type":"StringField","MaxLength":0,"MinLength":0,"Custom":"","BaseType":"None", "ContainsNumbers":false,"ContainsUpperCase":false,"ContainsLowerCase":false,"Prefix":"","Value":"","FieldName":"TestHeader1","DisplayValue":""},
                		            {"$type":"StringField","MaxLength":0,"MinLength":0,"Custom":"","BaseType":"None", "ContainsNumbers":false,"ContainsUpperCase":false,"ContainsLowerCase":false,"Prefix":"","Value":"","FieldName":"TestHeader2","DisplayValue":""},
                		            {"$type":"StringField","MaxLength":0,"MinLength":0,"Custom":"","BaseType":"None", "ContainsNumbers":false,"ContainsUpperCase":false,"ContainsLowerCase":false,"Prefix":"","Value":"","FieldName":"Record Quantity","DisplayValue":""}
                                    ]
                                ]
                	},

                    "data_table": {
                	    "columns": ["TestHeader1", "TestHeader2", "TestHeader2", "TestHeader2", "   ", "", "      "]

                    },

                    "trailer_table": {
                	    "columns": []
                    }
                }                
                """";

            File.WriteAllText("test_data_config_sample.json", JSONstring);      
        }

        // ~~~ TABLE POPULATION TESTS ~~~ 

        [Test]
        public void SetupTestDataTables_TableHasColumns_TableColumnsPopulated()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";

            int ExpectedNumberOfColumns = 3;

            //Act
            Form.TestGeneratorForm_Load();

            //Assert
            Assert.That(Presenter.HeaderTable.columns.Count, Is.EqualTo(ExpectedNumberOfColumns));
        }

        [Test]
        public void SetupTestDataTables_TableHasInvalidColumns_InvalidColumnsRemovedRequiredAdded()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";

            int ExpectedNumberOfColumns = 3;

            //Act
            Form.TestGeneratorForm_Load();

            //Assert
            Assert.That(Presenter.DataTable.columns.Count, Is.EqualTo(ExpectedNumberOfColumns));
        }

        [Test]
        public void SetupTestDataTables_TableHasNoColumns_AddRowButtonDisabled()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";

            bool AddRowEnabled = false;

            //Act
            Form.TestGeneratorForm_Load();

            //Assert
            Assert.That(Form.AddTrailerRowEnabled, Is.EqualTo(AddRowEnabled));
        }

        [Test]
        public void SetupTestDataTables_TableContainsBlankColumns_BlanksRemoved()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";

            bool AllBlanksRemoved = true;

            //Act
            Form.TestGeneratorForm_Load();


            //Assert
            Assert.That(Presenter.DataTable.columns.All(x => !string.IsNullOrEmpty(x)), Is.EqualTo(AllBlanksRemoved));
        }

        [Test]
        public void SetupTestDataTables_TableContainsDuplicateColumns_DuplicatesRemoved()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";

            //Act
            Form.TestGeneratorForm_Load();

            //Assert
            int NumberOfDistinctColumns = Presenter.DataTable.columns.Distinct().Count();
            int NumberOfColumns = Presenter.DataTable.columns.Count();
            Assert.That(NumberOfDistinctColumns, Is.EqualTo(NumberOfColumns));
        }

        [Test]
        public void SetupTestDataTables_NoRecordQuantityColumn_OneRecordQuantityColumnAdded()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";

            string RecordQuantityColumn = "Record Quantity";

            //Act
            Form.TestGeneratorForm_Load();

            //Assert
            Assert.That(Presenter.DataTable.columns, Has.Exactly(1).EqualTo(RecordQuantityColumn));
        }

        // ~~~ CELL SELECTION TESTS ~~~ 

        [Test]
        public void VerifyCellSelection_RightClickOnValidCellInHeader_FieldOptionsEnabled()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.TestGeneratorForm_Load();

            (int Row, int Column) SelectedCellCoords = (0, 0); // simulating right click of cell 0,0

            bool ExpectedCMSEnabled = true;

            //Act
            Form.HeaderDGV_CellMouseDown(SelectedCellCoords.Row, SelectedCellCoords.Column);

            //Assert
            Assert.That(Form.EnableFieldOptions, Is.EqualTo(ExpectedCMSEnabled));
        }

        [Test]
        public void VerifyCellSelection_RightClickOnInvalidCellInHeader_DisableFieldOptions()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.TestGeneratorForm_Load();

            (int Row, int Column) SelectedCellCoords = (-1, 0); // simulating right click of cell -1,0

            bool ExpectedCMSEnabled = false;

            //Act
            Form.HeaderDGV_CellMouseDown(SelectedCellCoords.Row, SelectedCellCoords.Column);

            //Assert
            Assert.That(Form.EnableFieldOptions, Is.EqualTo(ExpectedCMSEnabled));
        }

        [Test]
        public void VerifyCellSelection_RightClickOnRecordQuantityCellInHeader_DisableFieldOptions()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.TestGeneratorForm_Load();

            (int Row, int Column) SelectedCellCoords = (0, 2);  // simulating right click of cell 0, 2 which is the Record Quantity cell

            bool ExpectedCMSEnabled = false;

            //Act
            Form.HeaderDGV_CellMouseDown(SelectedCellCoords.Row, SelectedCellCoords.Column);

            //Assert
            Assert.That(Form.EnableFieldOptions, Is.EqualTo(ExpectedCMSEnabled));
        }

        // ~~~ CELL EDITING TESTS ~~~

        [Test]
        public void ValidateCellData_RecordQuantityCellLeftEmpty_CellValueIsEmptyString()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.TestGeneratorForm_Load();

            (int Row, int Column) SelectedCellCoords = (0, 2);  // simulating right click of cell 0, 2 which is the Record Quantity cell

            string ExpectedCellValue = "";

            //Act
            Form.HeaderDGV_CellEndEdit(SelectedCellCoords.Row, SelectedCellCoords.Column, "");

            //Assert
            Assert.That(Presenter.HeaderTable.rows[SelectedCellCoords.Row][SelectedCellCoords.Column].Value, Is.EqualTo(ExpectedCellValue));
        }

        [Test]
        public void ValidateCellData_RecordQuantityCellValidData_CellValueIsInteger()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.TestGeneratorForm_Load();

            (int Row, int Column) SelectedCellCoords = (0, 2);  // simulating right click of cell 0, 2 which is the Record Quantity cell

            string ExpectedCellValue = "10";

            //Act
            Form.HeaderDGV_CellEndEdit(SelectedCellCoords.Row, SelectedCellCoords.Column, "10");

            //Assert
            Assert.That(Presenter.HeaderTable.rows[SelectedCellCoords.Row][SelectedCellCoords.Column].Value, Is.EqualTo(ExpectedCellValue));
        }

        [Test]
        public void ValidateCellData_RecordQuantityCellInValidData_MsgIsDisplayed()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.TestGeneratorForm_Load();

            (int Row, int Column) SelectedCellCoords = (0, 2);  // simulating right click of cell 0, 2 which is the Record Quantity cell

            string ExpectedMsgString = $"Please ensure only integers (whole numbers) are provided in the Record Quantity column. \n\n You provided: invalid";

            //Act
            Form.HeaderDGV_CellEndEdit(SelectedCellCoords.Row, SelectedCellCoords.Column, "invalid");

            //Assert
            Assert.That(Form.Msg, Is.EqualTo(ExpectedMsgString));
        }

        // ~~~ FILE GENERATION TESTS ~~~
        [Test]
        public void GenerateTestDataFile_RecordQuantityIsInteger_IntegerAmountOfRecordsGenerated()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.FolderPath = Directory.GetCurrentDirectory();
            Form.FileName = "\\mydata_sample.dat";
            Form.FullPath = Form.FolderPath + Form.FileName;
            Form.TestGeneratorForm_Load();

            Presenter.HeaderTable.rows[0].Last().Value = "3"; //Record Quantity is the last column
            int ExpectedLineCount = 3;

            //Act
            Form.generateDataBtn_Click();

            //Assert
            Assert.That(File.ReadLines("mydata_sample.dat").Count(), Is.EqualTo(ExpectedLineCount));
        }

        [Test]
        public void GenerateTestDataFile_RecordQuantityIsZero_NoRecordsGenerated()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Presenter.TestDataFilePath = "mydata_sample.dat";
            Form.FolderPath = Directory.GetCurrentDirectory();
            Form.FileName = "\\mydata_sample.dat";
            Form.FullPath = Form.FolderPath + Form.FileName;
            Form.TestGeneratorForm_Load();

            Presenter.HeaderTable.rows[0].Last().Value = "0"; //Record Quantity is the last column
            int ExpectedLineCount = 0;

            //Act
            Form.generateDataBtn_Click();

            //Assert
            Assert.That(File.ReadLines("mydata_sample.dat").Count(), Is.EqualTo(ExpectedLineCount));
        }

        [Test]
        public void GenerateTestDataFile_FileNotProvided_MsgDisplayed()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.FolderPath = Directory.GetCurrentDirectory();
            Form.FileName = "";
            Form.FullPath = Form.FolderPath + Form.FileName;
            Form.TestGeneratorForm_Load();

            Presenter.HeaderTable.rows[0].Last().Value = "3"; //Record Quantity is the last column
            string ExpectedMsgString = $"Invalid file path.\nPlease select a different folder or file name.";

            //Act
            Form.generateDataBtn_Click();

            //Assert
            Assert.That(Form.Msg, Is.EqualTo(ExpectedMsgString));
        }

        [Test]
        public void GenerateTestDataFile_FolderPathNotProvided_MsgDisplayed()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.FolderPath = "";
            Form.FileName = "\\mydata_sample.dat";
            Form.FullPath = Form.FolderPath + Form.FileName;
            Form.TestGeneratorForm_Load();

            Presenter.HeaderTable.rows[0].Last().Value = "3"; //Record Quantity is the last column
            string ExpectedMsgString = $"Invalid file path.\nPlease select a different folder or file name.";

            //Act
            Form.generateDataBtn_Click();

            //Assert
            Assert.That(Form.Msg, Is.EqualTo(ExpectedMsgString));
        }



        // ~~~ ADDING/DELETING A ROW TESTS ~~~
        [Test]
        public void AddHeaderRow_HeaderTableSelected_RowIsAddedToHeaderTable()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.TestGeneratorForm_Load();

            int ExpectedHeaderTableRowCount = 2;

            //Act
            Form.AddHeaderRowBtn_Click();

            //Assert
            Assert.That(Presenter.HeaderTable.rows.Count, Is.EqualTo(ExpectedHeaderTableRowCount));
        }

        [Test]
        public void AddHeaderRow_HeaderTableSelected_RowIsDeletedFromHeaderTable()
        {
            //Arrange
            MockTestGeneratorForm Form = new();
            TestGeneratorPresenter Presenter = new(Form);
            Presenter.JSONPath = "test_data_config_sample.json";
            Form.TestGeneratorForm_Load();

            int ExpectedHeaderTableRowCount = 0;

            //Act
            Form.HeaderDGV_UserDeletingRow(0);

            //Assert
            Assert.That(Presenter.HeaderTable.rows.Count, Is.EqualTo(ExpectedHeaderTableRowCount));
        }


        [TearDown]
        public void Teardown()
        {
            File.Delete("test_data_file_config_sample.json");
            File.Delete("mydata_sample.dat");
        }
    }

    class MockTestGeneratorForm : ITestGeneratorView
    {
        private string _msg = "";
        private List<string> _editable_columns = [];
        private object _selected_cell_value = "";
        private object _header_cell_value;
        private object _data_cell_value;
        private object _trailer_cell_value;
        private (int Row, int Column) _selected_cell_coords = (-1, -1);
        private string _selected_field_option = "";
        private bool _CMS_enabled;
        private List<string> _options = [];
        private TestGeneratorPresenter Presenter;
        private bool _add_header_row_enabled = true;
        private bool _add_trailer_row_enabled = true;
        private bool _add_data_row_enabled = true;
        private Tables _selected_table;
        private string _file_name = "";
        private string _folder_path = "";
        private string _full_path = "";
        private int _progress_bar_max;
        private int _progress_bar_min;
        private int _progress_bar_value;
        private bool _generate_btn_enabled;

        public event EventHandler? LoadView;
        public event EventHandler? GenerateFile;
        public event EventHandler? SelectedStringFieldOption;
        public event EventHandler? EditedCellValue;
        public event EventHandler? FieldOptionsCMSEnabler;
        public event EventHandler? RowAdded;
        public event EventHandler? RowDeleted;
        public event EventHandler? ShowFileName;

        public string Msg { get => _msg; set => _msg = value; }
        public List<string> EditableColumns { get => _editable_columns; set => _editable_columns = value; }
        public string FieldOptions { set => _options.Add(value); }
        public object HeaderCellValue { get => _header_cell_value; set => _header_cell_value = value; }
        public bool EnableFieldOptions { set => _CMS_enabled = value; get => _CMS_enabled; }
        public string SelectedFieldOption { get; set; }
        public (int Row, int Column) SelectedCellCoords { get => _selected_cell_coords; set => _selected_cell_coords = value; }
        public object SelectedCellValue { get => _selected_cell_value; set => _selected_cell_value = value; }
        public Tables SelectedTable { get => _selected_table; set => _selected_table = value; }

        public string FileName { get => _file_name; set => _file_name = value; }
        public string FolderPath { get => _folder_path; set => _folder_path = value; }
        public string FullPath{ get => _full_path; set => _full_path = value; }
        public IOptionView OptionForm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object DataCellValue { get => _data_cell_value; set => _data_cell_value = value; }
        public object TrailerCellValue { get => _trailer_cell_value; set => _trailer_cell_value = value; }

        public bool AddHeaderRowEnabled { get => _add_header_row_enabled; set => _add_header_row_enabled = value; }
        public bool AddTrailerRowEnabled { get => _add_trailer_row_enabled; set => _add_trailer_row_enabled = value; }
        public bool AddDataRowEnabled { get => _add_data_row_enabled; set => _add_data_row_enabled = value; }

        public int ProgressBarMax { get => _progress_bar_max; set => _progress_bar_max = value; }
        public int ProgressBarMin { get => _progress_bar_min; set => _progress_bar_min = value; }
        public int ProgressBarValue { get => _progress_bar_value; set => _progress_bar_value = value; }
        public IFileNameView FileNameForm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool GenerateBtnEnabled { get => _generate_btn_enabled; set => _generate_btn_enabled = value; }

        public void TestGeneratorForm_Load()
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        public void FieldOptionsCMS_ItemClicked()
        {
            SelectedStringFieldOption?.Invoke(this, EventArgs.Empty);
        }

        public void HeaderDGV_CellMouseDown(int row, int col)
        {
            SelectedCellCoords = (row, col);
            SelectedTable = Tables.Header;
            FieldOptionsCMSEnabler?.Invoke(this, EventArgs.Empty);
        }

        public void HeaderDGV_CellEndEdit(int row, int col, object newValue)
        {
            SelectedTable = Tables.Header;
            SelectedCellCoords = (row, col);
            SelectedCellValue = newValue;
            EditedCellValue?.Invoke(this, EventArgs.Empty);
        }

        public void generateDataBtn_Click()
        {
            GenerateFile?.Invoke(this, EventArgs.Empty);
        }

        public void AddHeaderRowBtn_Click()
        {
            SelectedTable = Tables.Header;
            RowAdded?.Invoke(this, EventArgs.Empty);
        }

        public void HeaderDGV_UserDeletingRow(int indexToDelete)
        {
            SelectedTable = Tables.Header;
            SelectedCellCoords = (indexToDelete, 0);
            RowDeleted?.Invoke(this, EventArgs.Empty);
        }

        public void show_Message()
        {
            return;
        }

        public void Draw_Header_Table(Table HeaderTable)
        {
            return;
        }

        public void Draw_Data_Table(Table HeaderTable)
        {
            return;
        }

        public void Draw_Trailer_Table(Table HeaderTable)
        {
            return;
        }
    }
}