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
    internal class StringFieldPresTests
    {

        [Test]
        public void SaveFieldFormat_NoOptionChanged_DisplayValueEmpty()
        {
            //Arrange
            MockStringFieldForm Form = new();
            StringFieldPresenter Presenter = new(Form);

            StringField format = new();
            Form.FieldFormat = format;

            string ExpectedDisplayValue = "";

            //Act
            Form.StringFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat.DisplayValue, Is.EqualTo(ExpectedDisplayValue));
        }

        [Test]
        public void SaveFieldFormat_AnOptionChanged_DisplayValueIsStringFormat()
        {
            //Arrange
            MockStringFieldForm Form = new();
            StringFieldPresenter Presenter = new(Form);

            StringField format = new();
            Form.FieldFormat = format;

            Form.IsFirstName = true; // simulating selection of an option

            string ExpectedDisplayValue = "String Format";

            //Act
            Form.StringFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat.DisplayValue, Is.EqualTo(ExpectedDisplayValue));
        }

        [Test]
        public void SaveFieldFormat_CustomOptionSet_DisplayValueIsCustomValue()
        {
            //Arrange
            MockStringFieldForm Form = new();
            StringFieldPresenter Presenter = new(Form);

            StringField format = new();
            Form.FieldFormat = format;

            Form.Custom = "MyCustom"; // simulating input of custom value

            string ExpectedDisplayValue = "MyCustom";

            //Act
            Form.StringFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat.DisplayValue, Is.EqualTo(ExpectedDisplayValue));
        }

        [Test]
        public void SaveFieldFormat_CellFormatPreviouslyDateOption_CellFormatUpdatedToStringOption()
        {
            //Arrange
            MockStringFieldForm Form = new();
            StringFieldPresenter Presenter = new(Form);

            DateField format = new();
            Form.FieldFormat = format;

            Form.StringFieldOptionForm_Load();

            //Act
            Form.StringFieldOptionForm_FormClosing();

            //Assert
            Assert.That(Form.FieldFormat, Is.InstanceOf<StringField>());
        }
    }

    class MockStringFieldForm : IStringFieldView
    {
        private string _field_name = "";
        private int _max_length;
        private bool _max_length_enabled;

        private int _min_length;
        private bool _min_length_enabled;

        private string _prefix = "";
        private string _custom = "";
        private bool _custom_enabled;


        private bool _is_address;
        private bool _is_address_enabled;
        private bool _is_firstname;
        private bool _is_firstname_enabled;
        private bool _is_lastname;
        private bool _is_lastname_enabled;
        private bool _is_fullname;
        private bool _is_fullname_enabled;
        private bool _is_randomchar;
        private bool _is_randomchar_enabled;
        private bool _contains_numbers;
        private bool _contains_numbers_enabled;
        private bool _contains_uppercase;
        private bool _contains_uppercase_enabled;
        private bool _contains_lowercase;
        private bool _contains_lowercase_enabled;
        private bool _stays_the_same;
        private bool _stays_the_same_enabled;
        private bool _is_phonenumber;
        private bool _is_phonenumber_enabled;
        private bool _is_email;
        private bool _is_email_enabled;
        private bool _is_postcode;
        private bool _is_postcode_enabled;
        private bool _is_companyname;
        private bool _is_companyname_enabled;
        private bool _is_nino;
        private bool _is_nino_enabled;
        private bool _is_yesno;
        private bool _is_yesno_enabled;
        private bool _is_truefalse;
        private bool _is_truefalse_enabled;


        public string FieldName { get => _field_name; set => _field_name = value; }
        public IField FieldFormat { get; set; }
        public int MaxLength { get => _max_length; set => _max_length = value; }
        public bool MaxLengthEnabled { get => _max_length_enabled; set => _max_length_enabled = value; }
        public int MinLength { get => _min_length; set => _min_length = value; }
        public bool MinLengthEnabled { get => _min_length_enabled; set => _min_length_enabled = value; }
        public string Prefix { get => _prefix; set => _prefix = value; }
        public string Custom { get => _custom; set => _custom = value; }
        public bool CustomEnabled { get => _custom_enabled; set => _custom_enabled = value; }
        public bool IsAddress { get => _is_address; set => _is_address = value; }
        public bool IsAddressEnabled { get => _is_address_enabled; set => _is_address_enabled = value; }
        public bool IsFirstName { get => _is_firstname; set => _is_firstname = value; }
        public bool IsFirstNameEnabled { get => _is_firstname_enabled; set => _is_firstname_enabled = value; }
        public bool IsLastName { get => _is_lastname; set => _is_lastname = value; }
        public bool IsLastNameEnabled { get => _is_lastname_enabled; set => _is_lastname_enabled = value; }
        public bool IsFullName { get => _is_fullname; set => _is_fullname = value; }
        public bool IsFullNameEnabled { get => _is_fullname_enabled; set => _is_fullname_enabled = value; }
        public bool IsRandomChar { get => _is_randomchar; set => _is_randomchar = value; }
        public bool IsRandomCharEnabled { get => _is_randomchar_enabled; set => _is_randomchar_enabled = value; }
        public bool ContainsNumbers { get => _contains_numbers; set => _contains_numbers = value; }
        public bool ContainsNumbersEnabled { get => _contains_numbers_enabled; set => _contains_numbers_enabled = value; }
        public bool ContainsUppercase { get => _contains_uppercase; set => _contains_uppercase = value; }
        public bool ContainsUppercaseEnabled { get => _contains_uppercase_enabled; set => _contains_uppercase_enabled = value; }
        public bool ContainsLowercase { get => _contains_lowercase; set => _contains_lowercase = value; }
        public bool ContainsLowercaseEnabled { get => _contains_lowercase_enabled; set => _contains_lowercase_enabled = value; }
        public bool StaysTheSame { get => _stays_the_same; set => _stays_the_same = value; }
        public bool StaysTheSameEnabled { get => _stays_the_same_enabled; set => _stays_the_same_enabled = value; }
        public bool IsPhoneNumber { get => _is_phonenumber; set => _is_phonenumber = value; }
        public bool IsPhoneNumberEnabled { get => _is_phonenumber_enabled; set => _is_phonenumber_enabled = value; }
        public bool IsEmail { get => _is_email; set => _is_email = value; }
        public bool IsEmailEnabled { get => _is_email_enabled; set => _is_email_enabled = value; }
        public bool IsPostcode { get => _is_postcode; set => _is_postcode = value; }
        public bool IsPostcodeEnabled { get => _is_postcode_enabled; set => _is_postcode_enabled = value; }
        public bool IsCompanyName { get => _is_companyname; set => _is_companyname = value; }
        public bool IsCompanyNameEnabled { get => _is_companyname_enabled; set => _is_companyname_enabled = value; }
        public bool IsNINO { get => _is_nino; set => _is_nino = value; }
        public bool IsNINOEnabled { get => _is_nino_enabled; set => _is_nino_enabled = value; }
        public bool IsYesNo { get => _is_yesno; set => _is_yesno = value; }
        public bool IsYesNoEnabled { get => _is_yesno_enabled; set => _is_yesno_enabled = value; }
        public bool IsTrueFalse { get => _is_truefalse; set => _is_truefalse = value; }
        public bool IsTrueFalseEnabled { get => _is_truefalse_enabled; set => _is_truefalse_enabled = value; }

        public event EventHandler? FieldFormClosing;
        public event EventHandler? LoadView;
        public event EventHandler? AddressChecked;
        public event EventHandler? FirstNameChecked;
        public event EventHandler? LastNameChecked;
        public event EventHandler? FullNameChecked;
        public event EventHandler? RandomCharChecked;
        public event EventHandler? CustomTextChanged;
        public event EventHandler? PhoneNumberChecked;
        public event EventHandler? EmailChecked;
        public event EventHandler? PostcodeChecked;
        public event EventHandler? CompanyChecked;
        public event EventHandler? NINOChecked;
        public event EventHandler? YesNoChecked;
        public event EventHandler? TrueFalseChecked;

        public void StringFieldOptionForm_Load()
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        public void StringFieldOptionForm_FormClosing()
        {
            FieldFormClosing?.Invoke(this, EventArgs.Empty);
        }

        public void ShowAsDialogue()
        {
            throw new NotImplementedException();
        }
    }
}
