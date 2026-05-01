using Bogus;
using Bogus.Extensions;
using Bogus.Extensions.UnitedKingdom;
using CountryData.Bogus;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestDataGeneratorApp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StringFieldBaseType
    {
        None,
        FullAddress,
        FirstName,
        LastName,
        FullName,
        RandomChar, 
        PhoneNumber,
        Email,
        PostCode,
        YesNo,
        TrueFalse,
        CompanyName,
        NINO

    }
    public class StringField : IField
    {
        private List<string> YesNoList = ["Yes", "No"];
        private List<string> TrueFalseList = ["True", "False"];

        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public string Custom { get; set; }

        public StringFieldBaseType BaseType { get; set; }
        public bool ContainsNumbers { get; set; }
        public bool ContainsUpperCase { get; set; }
        public bool ContainsLowerCase { get; set; }

        public string Prefix { get; set; }
        public bool StaysTheSame { get; set; }

        private string _value = "";
        private string _field_name = "";
        private string _display_value = "";
        private Faker f = new Faker("en_GB");
        public string Value { get => _value; set => _value = value; }

        public string FieldName { get => _field_name; set => _field_name = value; }

        public string DisplayValue { get => _display_value; set => _display_value = value; }

        public StringField(int MaxLength = 0,
            int MinLength = 0,
            string Custom = "",
            StringFieldBaseType baseType = StringFieldBaseType.None,
            bool ContainsNumbers = false,
            bool ContainsUpperCase = false,
            bool ContainsLowerCase = false,
            string Prefix = "",
            bool StaysTheSame = false)
        {
            this.MaxLength = MaxLength;
            this.MinLength = MinLength;
            this.Custom = Custom;
            this.BaseType = baseType;
            this.ContainsNumbers = ContainsNumbers;
            this.ContainsUpperCase = ContainsUpperCase;
            this.ContainsLowerCase = ContainsLowerCase;
            this.Prefix = Prefix;
            this.StaysTheSame = StaysTheSame;
        }

        private string FormatCase(string baseString)
        {
            if (ContainsUpperCase && ContainsLowerCase)
            {
                return baseString;
            }
            if (!ContainsUpperCase && !ContainsLowerCase)
            {
                Regex r = new("[A-Za-z]");
                string numbersRemoved = r.Replace(baseString, f.Random.Int(0, 9).ToString());
                return numbersRemoved;
            }
            if (!ContainsUpperCase)
            {
                return baseString.ToLower();
            }
            if (!ContainsLowerCase)
            {
                return baseString.ToUpper();
            }

            return baseString;
        }

        private string FormatNumbers(string baseString)
        {
            if (ContainsNumbers && !baseString.Any(char.IsDigit))
            {
                // random character gets replaced with a #, which in ReplaceNumbers is replaced by a random number
                string hashtagInsterted = baseString.Replace(baseString[f.Random.Int(0, baseString.Length - 1)], '#');
                baseString = f.Random.ReplaceNumbers(hashtagInsterted);
            }
            if (!ContainsNumbers)
            {
                // replace all numbers (\d) with ?, which are then each replaced by an upper case character in Replace
                baseString = f.Random.Replace(Regex.Replace(baseString, "\\d", "?"));
            }
            return baseString;
        }

        private string AddPrefix(string baseString)
        {
            return Prefix.Trim() + baseString; // makes no difference if the prefix is an empty string
        }

        private string GenerateBase()
        {
            switch (BaseType)
            {
                case StringFieldBaseType.FullAddress:
                    return f.Address.FullAddress().ClampLength(min: MinLength, max: MaxLength);
                    break;
                case StringFieldBaseType.FirstName:
                    return f.Person.FirstName.ClampLength(min: MinLength, max: MaxLength);
                    break;
                case StringFieldBaseType.LastName:
                    return f.Person.LastName.ClampLength(min: MinLength, max: MaxLength);
                    break;
                case StringFieldBaseType.FullName:
                    return f.Person.FullName.ClampLength(min: MinLength, max: MaxLength);
                    break;
                case StringFieldBaseType.RandomChar:
                    string RandomBase = "";
                    for (int i = 0; i < MaxLength; i++)
                    {
                        RandomBase += f.Random.AlphaNumeric(1);
                    }
                    return RandomBase;
                    break;
                case StringFieldBaseType.PhoneNumber:
                    return f.Phone.PhoneNumber();
                    break;
                case StringFieldBaseType.Email:
                    return f.Person.Email.ClampLength(min: MinLength, max: MaxLength);
                    break;
                case StringFieldBaseType.PostCode:
                    return CountryDataSet.UnitedKingdom().PostCode();
                    break;
                case StringFieldBaseType.YesNo:
                    return f.Random.ListItem(YesNoList);
                    break;
                case StringFieldBaseType.TrueFalse:
                    return f.Random.ListItem(TrueFalseList);
                    break;
                case StringFieldBaseType.CompanyName:
                    return f.Company.CompanyName().ClampLength(min: MinLength, max: MaxLength);
                    break;
                    case StringFieldBaseType.NINO:
                        return f.Finance.Nino(false);
                default:
                    return "";
            }
        }

        public void GenerateValue()
        {

            string generatedValue = "";
            if (Custom.Equals(""))
            {
                if (StaysTheSame)
                {
                    if (Value.Length > 0)
                    {
                        generatedValue = Value;
                    }
                    else
                    {
                        generatedValue = GenerateBase();
                        generatedValue = FormatNumbers(generatedValue);
                        generatedValue = FormatCase(generatedValue);
                        generatedValue = AddPrefix(generatedValue);
                    }

                }
                else
                {
                    f = new Faker("en_GB");
                    generatedValue = GenerateBase();
                    generatedValue = FormatNumbers(generatedValue);
                    generatedValue = FormatCase(generatedValue);
                    generatedValue = AddPrefix(generatedValue);
                }

            }
            else
            {
                generatedValue = Custom;
            }

            Value = generatedValue;
        }
    }
}
