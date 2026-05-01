using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Views;

namespace TestDataGeneratorApp.Presenters
{
    public class StringFieldPresenter
    {
        private IStringFieldView StringFieldOptionView;
        private StringFieldBaseType baseType = StringFieldBaseType.None;
        public StringFieldPresenter(IStringFieldView view)
        {
            StringFieldOptionView = view;
            StringFieldOptionView.FieldFormClosing += SaveFieldFormat;
            StringFieldOptionView.LoadView += SetUpFieldFormat;
            StringFieldOptionView.AddressChecked += AddressIsChecked;
            StringFieldOptionView.FirstNameChecked += FirstNameIsChecked;
            StringFieldOptionView.LastNameChecked += LastNameIsChecked;
            StringFieldOptionView.FullNameChecked += FullNameIsChecked;
            StringFieldOptionView.PhoneNumberChecked += PhoneNumberIsChecked;
            StringFieldOptionView.EmailChecked += EmailIsChecked;
            StringFieldOptionView.PostcodeChecked += PostcodeIsChecked;
            StringFieldOptionView.CompanyChecked += CompanyIsChecked;
            StringFieldOptionView.NINOChecked += NINOIsChecked;
            StringFieldOptionView.YesNoChecked += YesNoIsChecked;
            StringFieldOptionView.TrueFalseChecked += TrueFalseIsChecked;
            StringFieldOptionView.RandomCharChecked += RandomCharIsChecked;
            StringFieldOptionView.CustomTextChanged += CustomStringProvided;
            
        }

        private void SetDisplayValue(string displayValue="")
        {
            StringFieldOptionView.FieldFormat.DisplayValue = displayValue;
        }

        public void SaveFieldFormat(object? sender, EventArgs e)
        {            
            StringFieldOptionView.FieldFormat = new StringField(StringFieldOptionView.MaxLength,
                StringFieldOptionView.MinLength,
                StringFieldOptionView.Custom,
                baseType,
                StringFieldOptionView.ContainsNumbers,
                StringFieldOptionView.ContainsUppercase,
                StringFieldOptionView.ContainsLowercase,
                StringFieldOptionView.Prefix, 
                StringFieldOptionView.StaysTheSame);

            if (StringFieldOptionView.MaxLength > 0 || StringFieldOptionView.MinLength > 0 || baseType != StringFieldBaseType.None || 
                StringFieldOptionView.ContainsNumbers || StringFieldOptionView.ContainsLowercase || 
                StringFieldOptionView.Prefix.Length > 0 || StringFieldOptionView.StaysTheSame)
            {
                SetDisplayValue("String Format");
            }
            else if (StringFieldOptionView.Custom.Length > 0)
            {
                SetDisplayValue(StringFieldOptionView.Custom);
            }
            else 
            {
                SetDisplayValue("");
            }
        }

        private void SetBase(StringFieldBaseType baseType)
        {
            switch (baseType)
            {
                case StringFieldBaseType.None:
                    break;
                case StringFieldBaseType.FullAddress:
                    StringFieldOptionView.IsAddress = true;
                    break;
                case StringFieldBaseType.FirstName:
                    StringFieldOptionView.IsFirstName = true;
                    break;
                case StringFieldBaseType.LastName:
                    StringFieldOptionView.IsLastName = true;
                    break;
                case StringFieldBaseType.FullName:
                    StringFieldOptionView.IsFullName = true;
                    break;
                case StringFieldBaseType.RandomChar:
                    StringFieldOptionView.IsRandomChar = true;
                    break;
                case StringFieldBaseType.PhoneNumber:
                    StringFieldOptionView.IsPhoneNumber = true;
                    break;
                case StringFieldBaseType.Email:
                    StringFieldOptionView.IsEmail = true;
                    break;
                case StringFieldBaseType.PostCode:
                    StringFieldOptionView.IsPostcode = true;
                    break;
                case StringFieldBaseType.YesNo:
                    StringFieldOptionView.IsYesNo = true;
                    break;
                case StringFieldBaseType.TrueFalse:
                    StringFieldOptionView.IsTrueFalse = true;
                    break;
                case StringFieldBaseType.CompanyName:
                    StringFieldOptionView.IsCompanyName = true;
                    break;
                case StringFieldBaseType.NINO:
                    StringFieldOptionView.IsNINO = true;
                    break;
                default:
                    break;
            }
        }

        public void SetUpFieldFormat(object? sender, EventArgs e)
        {
            switch (StringFieldOptionView.FieldFormat)
            {
                case StringField StringCell:
                    StringFieldOptionView.Custom = StringCell.Custom;                    
                    StringFieldOptionView.ContainsNumbers = StringCell.ContainsNumbers;
                    StringFieldOptionView.ContainsUppercase = StringCell.ContainsUpperCase;
                    StringFieldOptionView.ContainsLowercase = StringCell.ContainsLowerCase;
                    SetBase(StringCell.BaseType);
                    StringFieldOptionView.Prefix = StringCell.Prefix;
                    StringFieldOptionView.StaysTheSame = StringCell.StaysTheSame;
                    // last to be updated as the other fields being changed triggers the events which changes them to default values
                    StringFieldOptionView.MaxLength = StringCell.MaxLength;
                    StringFieldOptionView.MinLength = StringCell.MinLength;
                    break;
                default:
                    StringField newStringField = new();                    
                    StringFieldOptionView.Custom = newStringField.Custom;                    
                    StringFieldOptionView.ContainsNumbers = newStringField.ContainsNumbers;
                    StringFieldOptionView.ContainsUppercase = newStringField.ContainsUpperCase;
                    StringFieldOptionView.ContainsLowercase = newStringField.ContainsLowerCase;
                    SetBase(newStringField.BaseType);
                    StringFieldOptionView.Prefix = newStringField.Prefix;
                    StringFieldOptionView.StaysTheSame = newStringField.StaysTheSame;
                    StringFieldOptionView.MaxLength = newStringField.MaxLength;
                    StringFieldOptionView.MinLength = newStringField.MinLength;
                    break;
            }
        }

        private void ResetBaseTypeOnView()
        {
            StringFieldOptionView.IsAddressEnabled = true;
            StringFieldOptionView.IsFirstNameEnabled = true;
            StringFieldOptionView.IsLastNameEnabled = true;
            StringFieldOptionView.IsFullNameEnabled = true;
            StringFieldOptionView.IsRandomCharEnabled = true;
            StringFieldOptionView.IsCompanyNameEnabled = true;
            StringFieldOptionView.IsEmailEnabled = true;
            StringFieldOptionView.IsNINOEnabled = true;
            StringFieldOptionView.IsPhoneNumberEnabled = true;
            StringFieldOptionView.IsYesNoEnabled = true;
            StringFieldOptionView.IsTrueFalseEnabled = true;
            StringFieldOptionView.IsPostcodeEnabled = true;

            StringFieldOptionView.CustomEnabled = true;
            StringFieldOptionView.ContainsLowercase = false;
            StringFieldOptionView.ContainsUppercase = false;
            StringFieldOptionView.ContainsNumbers = false;
            StringFieldOptionView.MaxLength = 0;
            StringFieldOptionView.MinLength = 0;
            baseType = StringFieldBaseType.None;
        }

        public void AddressIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsAddress == true)
            {
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;

                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = true;
                StringFieldOptionView.MaxLength = 100;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.FullAddress;
            }
            else 
            {
                ResetBaseTypeOnView();
            }          
        }

        public void FirstNameIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsFirstName == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;

                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = false;
                StringFieldOptionView.MaxLength = 50;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.FirstName;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void LastNameIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsLastName == true)
            {
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;

                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = false;
                StringFieldOptionView.MaxLength = 50;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.LastName;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void FullNameIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsFullName == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;

                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = false;
                StringFieldOptionView.MaxLength = 100;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.FullName;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void RandomCharIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsRandomChar == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;

                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = true;
                StringFieldOptionView.MaxLength = 50;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.RandomChar;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void CustomStringProvided(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.Custom.Length > 0)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;

                StringFieldOptionView.ContainsLowercaseEnabled = false;
                StringFieldOptionView.ContainsUppercaseEnabled = false;
                StringFieldOptionView.ContainsNumbersEnabled = false;
                StringFieldOptionView.MaxLengthEnabled = false;
                StringFieldOptionView.MinLengthEnabled = false;
                StringFieldOptionView.StaysTheSame = true;
                StringFieldOptionView.StaysTheSameEnabled = false;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void PhoneNumberIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsPhoneNumber == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;

                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.ContainsNumbers = true;
                StringFieldOptionView.ContainsNumbersEnabled = false;
                StringFieldOptionView.ContainsUppercase = false;
                StringFieldOptionView.ContainsUppercaseEnabled = false;
                StringFieldOptionView.ContainsLowercase = false;
                StringFieldOptionView.ContainsLowercaseEnabled = false;

                StringFieldOptionView.MaxLength = 20;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.PhoneNumber;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void EmailIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsEmail == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;

                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = false;
                StringFieldOptionView.ContainsNumbers = true;

                StringFieldOptionView.MaxLength = 50;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.Email;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void PostcodeIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsPostcode == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;

                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.ContainsLowercase = false;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = true;

                StringFieldOptionView.MaxLength = 8;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.PostCode;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void CompanyIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsCompanyName == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;

                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = false;

                StringFieldOptionView.MaxLength = 50;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.CompanyName;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void NINOIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsNINO == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;

                StringFieldOptionView.ContainsLowercase = false;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = true;

                StringFieldOptionView.MaxLength = 8;
                StringFieldOptionView.MinLength = 0;
                baseType = StringFieldBaseType.NINO;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void YesNoIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsYesNo == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsTrueFalseEnabled = false;

                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = false;

                StringFieldOptionView.MaxLength = 3;
                StringFieldOptionView.MinLength = 2;
                baseType = StringFieldBaseType.YesNo;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }

        public void TrueFalseIsChecked(object? sender, EventArgs e)
        {
            if (StringFieldOptionView.IsTrueFalse == true)
            {
                StringFieldOptionView.IsAddressEnabled = false;
                StringFieldOptionView.IsFirstNameEnabled = false;
                StringFieldOptionView.IsLastNameEnabled = false;
                StringFieldOptionView.IsFullNameEnabled = false;
                StringFieldOptionView.IsRandomCharEnabled = false;
                StringFieldOptionView.CustomEnabled = false;
                StringFieldOptionView.IsPostcodeEnabled = false;
                StringFieldOptionView.IsEmailEnabled = false;
                StringFieldOptionView.IsCompanyNameEnabled = false;
                StringFieldOptionView.IsPhoneNumberEnabled = false;
                StringFieldOptionView.IsNINOEnabled = false;
                StringFieldOptionView.IsYesNoEnabled = false;

                StringFieldOptionView.ContainsLowercase = true;
                StringFieldOptionView.ContainsUppercase = true;
                StringFieldOptionView.ContainsNumbers = false;

                StringFieldOptionView.MaxLength = 5;
                StringFieldOptionView.MinLength = 4;
                baseType = StringFieldBaseType.TrueFalse;
            }
            else
            {
                ResetBaseTypeOnView();
            }
        }
    }
}
