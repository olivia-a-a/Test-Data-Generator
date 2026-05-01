using System;
using NUnit.Framework;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Presenters;
using TestDataGeneratorApp.Views;

namespace GeneratorAppTest
{
    public class NumberFieldPresTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SaveFieldFormat_AnOptionChanged_DisplayValueIsNumberFormat()
        {
            // Arrange
            MockNumberFieldForm Form = new();
            NumberFieldPresenter Presenter = new(Form);

            NumberField format = new();
            Form.FieldFormat = format;

            string ExpectedDisplayValue = "Number Format";

            Form.MaxNum = "1";

            // Act
            Form.NumberFieldOptionForm_FormClosing();

            // Assert
            Assert.That(Form.FieldFormat.DisplayValue, Is.EqualTo(ExpectedDisplayValue));
        }

        [Test]
        public void SaveFieldFormat_NoOptionChanged_DisplayValueEmpty()
        {
            //Arrange
            MockStringFieldForm Form = new();
            StringFieldPresenter Presenter = new(Form);

            NumberField format = new();
            Form.FieldFormat = format;

            string ExpectedDisplayValue = "";

            //Act
            Form.StringFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat.DisplayValue, Is.EqualTo(ExpectedDisplayValue));
        }

        [Test]
        public void SetUpFieldFormat_PreviouslyStringField_FieldFormatUpdatedToNumberField()
        {
            // Arrange
            MockNumberFieldForm Form = new();
            NumberFieldPresenter Presenter = new(Form);

            
            StringField format = new();
            Form.FieldFormat = format;

            // Act
            Form.NumberFieldOptionForm_Load();

            // Assert
            Form.NumberFieldOptionForm_FormClosing();
            Assert.That(Form.FieldFormat, Is.InstanceOf<NumberField>());
        }

        [Test]
        public void SaveFieldFormat_MaxNumSetAsNonNum_ShowMsg()
        {
            // Arrange
            MockNumberFieldForm Form = new();
            NumberFieldPresenter Presenter = new(Form);

            NumberField format = new();
            Form.FieldFormat = format;

            string ExpectedMsg = "Please ensure all the fields you have amended are valid numbers.";

            Form.MaxNum = "x";

            //Act
            Form.NumberFieldOptionForm_FormClosing();

            // Assert
            Assert.That(Form.Msg, Is.EqualTo(ExpectedMsg));
        }
    }

    class MockNumberFieldForm : INumberFieldView
    {
        private string _msg = "";
        private IField _fieldFormat;
        private decimal _decimalPlace;
        private bool _decimalPlace_enabled;
        private string _maxNum = "";
        private bool _maxNum_enabled;
        private string _minNum = "";
        private bool _minNum_enabled;
        private bool _stays_the_same;
        private bool _stays_the_same_enabled;
        private string _custom = "";
        private bool _custom_enabled;
        private bool _cancel_close;

        public string Msg { get => _msg; set => _msg = value; }
        public IField FieldFormat { get => _fieldFormat; set => _fieldFormat = value; }

        public decimal DecimalPlace { get => _decimalPlace; set => _decimalPlace = value; }
        public bool DecimalPlaceEnabled { get => _decimalPlace_enabled; set => _decimalPlace_enabled = value; }

        public string MaxNum { get => _maxNum; set { _maxNum = value; MaxNumChanged?.Invoke(this, EventArgs.Empty); } }
        public bool MaxNumEnabled { get => _maxNum_enabled; set => _maxNum_enabled = value; }

        public string MinNum { get => _minNum; set { _minNum = value; MinNumChanged?.Invoke(this, EventArgs.Empty); } }
        public bool MinNumEnabled { get => _minNum_enabled; set => _minNum_enabled = value; }

        public bool StaysTheSame { get => _stays_the_same; set => _stays_the_same = value; }
        public bool StaysTheSameEnabled { get => _stays_the_same_enabled; set => _stays_the_same_enabled = value; }

        public string Custom { get => _custom; set { _custom = value; CustomNumChanged?.Invoke(this, EventArgs.Empty); } }
        public bool CustomEnabled { get => _custom_enabled; set => _custom_enabled = value; }

        public bool CancelClose { get => _cancel_close; set => _cancel_close = value; }

        public event EventHandler? MaxNumChanged;
        public event EventHandler? MinNumChanged;
        public event EventHandler? CustomNumChanged;
        public event EventHandler? FieldFormClosing;
        public event EventHandler? LoadView;

        public void NumberFieldOptionForm_Load()
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        public void NumberFieldOptionForm_FormClosing()
        {
            FieldFormClosing?.Invoke(this, EventArgs.Empty);
        }

        public void show_Message()
        {
            return;
        }
    }
}
