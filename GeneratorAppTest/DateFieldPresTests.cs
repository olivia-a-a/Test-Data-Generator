using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Presenters;
using TestDataGeneratorApp.Views;

namespace GeneratorAppTest
{
    internal class DateFieldPresTests
    {
        [Test]
        public void SaveFieldFormat_InvalidDateFormatProvided_MsgIsDisplayed() 
        {
            //Arrange
            MockDateFieldForm Form = new();
            DateFieldPresenter Presenter = new(Form);

            DateField format = new();
            Form.FieldFormat = format;

            Form.Format = "x";

            string ExpectedMsg = $"Please ensure a valid format for the date is provided. \nClick the help button to find out which format characters are accepted.";

            //Act
            Form.DateFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.Msg, Is.EqualTo(ExpectedMsg));
        }

        [Test]
        public void SaveFieldFormat_CustomOptionSet_DisplayValueIsCustomValue()
        {
            //Arrange
            MockDateFieldForm Form = new();
            DateFieldPresenter Presenter = new(Form);

            DateField format = new();
            Form.FieldFormat = format;

            Form.Custom = "04/03/2025";

            string ExpectedDisplayValue = "04/03/2025";

            //Act
            Form.DateFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat.DisplayValue, Is.EqualTo(ExpectedDisplayValue));
        }

        [Test]
        public void SaveFieldFormat_AnOptionChanged_DisplayValueIsDateFormat()
        {
            //Arrange
            MockDateFieldForm Form = new();
            DateFieldPresenter Presenter = new(Form);

            DateField format = new();
            Form.FieldFormat = format;

            Form.MaxDate = Form.MaxDate.AddMonths(1);

            string ExpectedDisplayValue = "Date Format";

            //Act
            Form.DateFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat.DisplayValue, Is.EqualTo(ExpectedDisplayValue));
        }

        [Test]
        public void SaveFieldFormat_NoOptionChanged_DisplayValueEmpty()
        {
            //Arrange
            MockDateFieldForm Form = new();
            DateFieldPresenter Presenter = new(Form);

            DateField format = new();
            Form.FieldFormat = format;

            string ExpectedDisplayValue = "";

            //Act
            Form.DateFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat.DisplayValue, Is.EqualTo(ExpectedDisplayValue));
        }

        [Test]
        public void SaveFieldFormat_CellFormatPreviouslyStringOption_CellFormatUpdatedToDateOption()
        {
            //Arrange
            MockDateFieldForm Form = new();
            DateFieldPresenter Presenter = new(Form);

            StringField format = new();
            Form.FieldFormat = format;

            Form.DateFieldOptionForm_Load();

            //Act
            Form.DateFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat, Is.InstanceOf<DateField>());
        }
    }

    class MockDateFieldForm : IDateFieldView
    {
        private string _msg = "";
        private string _field_name;
        private DateTime _max_date = new(1753, 01, 01);
        private bool _max_date_enabled;
        private string _set_max_date_tool_tip;
        private string _set_max_date_format;
        private DateTime _min_date = new(1753, 01, 01);
        private bool _min_date_enabled;
        private string _set_min_date_tool_tip = "";
        private string _set_min_date_format = "";
        private string _custom = "";
        private bool _custom_enabled;
        private string _format = "";
        private bool _format_enabled;
        private bool _allow_close;
        private bool _stays_the_same;
        private bool _stays_the_same_enabled;

        public string Msg { get => _msg; set => _msg = value; }
        public IField FieldFormat { get; set; }

        public string FieldName { get => _field_name; set => _field_name = value; }
        public DateTime MaxDate { get => _max_date; set => _max_date = value; }
        public bool MaxDateEnabled { get => _max_date_enabled; set => _max_date_enabled = value; }
        public string SetMaxDateToolTip { set => _set_max_date_tool_tip = value; }
        public string SetMaxDateFormat { set => _set_max_date_format = value; }

        public DateTime MinDate { get => _min_date; set => _min_date = value; }
        public bool MinDateEnabled { get => _min_date_enabled; set => _min_date_enabled = value; }
        public string SetMinDateToolTip { set => _set_min_date_tool_tip = value; }
        public string SetMinDateFormat { set => _set_min_date_format = value; }

        public string Custom { get => _custom; set => _custom = value; }
        public bool CustomEnabled { get => _custom_enabled; set => _custom_enabled = value; }

        public string Format { get => _format; set => _format = value; }
        public bool FormatEnabled { get => _format_enabled; set => _format_enabled = value; }

        public bool CancelClose { get => _allow_close; set => _allow_close = value; }
        public bool StaysTheSame { get => _stays_the_same; set => _stays_the_same = value; }
        public bool StaysTheSameEnabled { get => _stays_the_same_enabled; set => _stays_the_same_enabled = value; }

        public event EventHandler? FormatLinkClicked;
        public event EventHandler? CustomDateChanged;
        public event EventHandler? DateFormatChanged;
        public event EventHandler? FieldFormClosing;
        public event EventHandler? LoadView;

        public void DateFieldOptionForm_Load()
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }
        public void DateFieldOptionForm_FormClosing()
        {
            FieldFormClosing?.Invoke(this, EventArgs.Empty);
        }

        public void show_Message()
        {
            return;
        }
    }
}
