using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Presenters;
using TestDataGeneratorApp.Views;

namespace TestDataGeneratorApp
{
    public partial class StringFieldForm : Form, IStringFieldView, IOptionView
    {
        private StringFieldPresenter Presenter;

        public IField FieldFormat { get; set; }

        public string FieldName { get => FieldNameLbl.Text; set => FieldNameLbl.Text = value; }

        public int MaxLength { get => (int)MaxStringLength.Value; set => MaxStringLength.Value = value; }
        public bool MaxLengthEnabled { get => MaxStringLength.Enabled; set => MaxStringLength.Enabled = value; }

        public int MinLength { get => (int)MinStringLength.Value; set => MinStringLength.Value = value; }
        public bool MinLengthEnabled { get => MinStringLength.Enabled; set => MinStringLength.Enabled = value; }

        public string Prefix { get => PrefixTextBox.Text; set => PrefixTextBox.Text = value; }

        public string Custom { get => CustomTextBox.Text; set => CustomTextBox.Text = value; }
        public bool CustomEnabled { get => CustomTextBox.Enabled; set => CustomTextBox.Enabled = value; }

        public bool IsAddress { get => AddressCheckBox.Checked; set => AddressCheckBox.Checked = value; }
        public bool IsAddressEnabled { get => AddressCheckBox.Enabled; set => AddressCheckBox.Enabled = value; }

        public bool IsFirstName { get => FirstNameCheckBox.Checked; set => FirstNameCheckBox.Checked = value; }
        public bool IsFirstNameEnabled { get => FirstNameCheckBox.Enabled; set => FirstNameCheckBox.Enabled = value; }

        public bool IsLastName { get => LastNameCheckBox.Checked; set => LastNameCheckBox.Checked = value; }
        public bool IsLastNameEnabled { get => LastNameCheckBox.Enabled; set => LastNameCheckBox.Enabled = value; }

        public bool IsFullName { get => FullNameCheckBox.Checked; set => FullNameCheckBox.Checked = value; }
        public bool IsFullNameEnabled { get => FullNameCheckBox.Enabled; set => FullNameCheckBox.Enabled = value; }

        public bool IsRandomChar { get => RandomCharCheckBox.Checked; set => RandomCharCheckBox.Checked = value; }
        public bool IsRandomCharEnabled { get => RandomCharCheckBox.Enabled; set => RandomCharCheckBox.Enabled = value; }

        public bool IsPhoneNumber { get => PhoneNumCheckBox.Checked; set => PhoneNumCheckBox.Checked = value; }
        public bool IsPhoneNumberEnabled { get => PhoneNumCheckBox.Enabled; set => PhoneNumCheckBox.Enabled = value; }

        public bool IsEmail { get => EmailCheckBox.Checked; set => EmailCheckBox.Checked = value; }
        public bool IsEmailEnabled { get => EmailCheckBox.Enabled; set => EmailCheckBox.Enabled = value; }

        public bool IsPostcode { get => PostcodeCheckBox.Checked; set => PostcodeCheckBox.Checked = value; }
        public bool IsPostcodeEnabled { get => PostcodeCheckBox.Enabled; set => PostcodeCheckBox.Enabled = value; }

        public bool IsCompanyName { get => CompanyCheckBox.Checked; set => CompanyCheckBox.Checked = value; }
        public bool IsCompanyNameEnabled { get => CompanyCheckBox.Enabled; set => CompanyCheckBox.Enabled = value; }

        public bool IsNINO { get => NINOCheckBox.Checked; set => NINOCheckBox.Checked = value; }
        public bool IsNINOEnabled { get => NINOCheckBox.Enabled; set => NINOCheckBox.Enabled = value; }

        public bool IsYesNo { get => YesNoCheckBox.Checked; set => YesNoCheckBox.Checked = value; }
        public bool IsYesNoEnabled { get => YesNoCheckBox.Enabled; set => YesNoCheckBox.Enabled = value; }

        public bool IsTrueFalse { get => TrueFalseCheckBox.Checked; set => TrueFalseCheckBox.Checked = value; }
        public bool IsTrueFalseEnabled { get => TrueFalseCheckBox.Enabled; set => TrueFalseCheckBox.Enabled = value; }

        public bool ContainsNumbers { get => NumbersCheckBox.Checked; set => NumbersCheckBox.Checked = value; }
        public bool ContainsNumbersEnabled { get => NumbersCheckBox.Enabled; set => NumbersCheckBox.Enabled = value; }

        public bool ContainsUppercase { get => UppercaseCheckBox.Checked; set => UppercaseCheckBox.Checked = value; }
        public bool ContainsUppercaseEnabled { get => UppercaseCheckBox.Enabled; set => UppercaseCheckBox.Enabled = value; }

        public bool ContainsLowercase { get => LowercaseCheckBox.Checked; set => LowercaseCheckBox.Checked = value; }
        public bool ContainsLowercaseEnabled { get => LowercaseCheckBox.Enabled; set => LowercaseCheckBox.Enabled = value; }
        public bool StaysTheSame { get => StaysSameCheckBox.Checked; set => StaysSameCheckBox.Checked = value; }
        public bool StaysTheSameEnabled { get => StaysSameCheckBox.Enabled; set => StaysSameCheckBox.Enabled = value; }

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
        public StringFieldForm()
        {
            this.Presenter = new StringFieldPresenter(this);
            InitializeComponent();
        }

        public void StringFieldOptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FieldFormClosing?.Invoke(this, EventArgs.Empty);
        }

        private void StringFieldOptionForm_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        public void ShowAsDialogue()
        {
            this.ShowDialog();
        }

        private void AddressCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            AddressChecked?.Invoke(this, EventArgs.Empty);
        }

        private void FirstNameCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            FirstNameChecked?.Invoke(this, EventArgs.Empty);
        }

        private void LastNameCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            LastNameChecked?.Invoke(this, EventArgs.Empty);
        }

        private void FullNameCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            FullNameChecked?.Invoke(this, EventArgs.Empty);
        }

        private void RandomCharCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            RandomCharChecked?.Invoke(this, EventArgs.Empty);
        }

        private void CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomTextChanged?.Invoke(this, EventArgs.Empty);

        }
        private void PhoneNumCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            PhoneNumberChecked?.Invoke(this, EventArgs.Empty);
        }

        private void EmailCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            EmailChecked?.Invoke(this, EventArgs.Empty);
        }

        private void PostcodeCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            PostcodeChecked?.Invoke(this, EventArgs.Empty);
        }

        private void CompanyCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            CompanyChecked?.Invoke(this, EventArgs.Empty);
        }

        private void NINOCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            NINOChecked?.Invoke(this, EventArgs.Empty);
        }

        private void YesNoCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            YesNoChecked?.Invoke(this, EventArgs.Empty);
        }

        private void TrueFalseCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            TrueFalseChecked?.Invoke(this, EventArgs.Empty);
        }

    }
}
