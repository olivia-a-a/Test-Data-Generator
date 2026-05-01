using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Models;

namespace TestDataGeneratorApp.Views
{  
    public interface IStringFieldView
    {
        public string FieldName { get; set; }

        public IField FieldFormat { get; set; }

        public int MaxLength { get; set; }
        public bool MaxLengthEnabled { get; set; }

        public int MinLength { get; set; }
        public bool MinLengthEnabled { get; set; }

        public string Prefix { get; set; }

        public string Custom { get; set; }
        public bool CustomEnabled { get; set; }

        public bool IsAddress { get; set; }
        public bool IsAddressEnabled { get; set; }

        public bool IsFirstName { get; set; }
        public bool IsFirstNameEnabled { get; set; }

        public bool IsLastName { get; set; }
        public bool IsLastNameEnabled { get; set; }

        public bool IsFullName { get; set; }
        public bool IsFullNameEnabled { get; set; }

        public bool IsRandomChar { get; set; }
        public bool IsRandomCharEnabled { get; set; }

        public bool IsPhoneNumber { get; set; }
        public bool IsPhoneNumberEnabled { get; set; }

        public bool IsEmail { get; set; }
        public bool IsEmailEnabled { get; set; }

        public bool IsPostcode { get; set; }
        public bool IsPostcodeEnabled { get; set; }

        public bool IsCompanyName { get; set; }
        public bool IsCompanyNameEnabled { get; set; }

        public bool IsNINO { get; set; }
        public bool IsNINOEnabled { get; set; }

        public bool IsYesNo { get; set; }
        public bool IsYesNoEnabled { get; set; }

        public bool IsTrueFalse { get; set; }
        public bool IsTrueFalseEnabled { get; set; }

        public bool ContainsNumbers { get; set; }
        public bool ContainsNumbersEnabled { get; set; }

        public bool ContainsUppercase { get; set; }
        public bool ContainsUppercaseEnabled { get; set; }

        public bool ContainsLowercase { get; set; }
        public bool ContainsLowercaseEnabled { get; set; }

        public bool StaysTheSame { get; set; }
        public bool StaysTheSameEnabled { get; set; }


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
    }
}
