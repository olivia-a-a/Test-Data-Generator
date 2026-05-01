using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGeneratorApp.Models
{
    public class DateField : IField
    {
        public DateTime defaultDate = new DateTime(1753, 01, 01);

        public DateTime MaxDate { get; set; }
        public DateTime MinDate { get; set; }
        public string Custom { get; set; }
        public string Format { get; set; }
        public bool StaysTheSame { get; set; }

        private string _value = "";
        private string _field_name = "";
        private string _display_value = "";
        private Faker f = new Faker();
        public string FieldName { get => _field_name; set => _field_name = value; }
        public string Value { get => _value; set => _value = value; }
        public string DisplayValue { get => _display_value; set => _display_value = value; }

        public DateField(DateTime? MaxDate = null,
            DateTime? MinDate = null,
            string Custom = "",
            string Format = "",
            bool StaysTheSame = false)
        {
            this.MaxDate = MaxDate ?? defaultDate;
            this.MinDate = MinDate ?? defaultDate;
            this.Custom = Custom;
            this.Format = Format;
            this.StaysTheSame = StaysTheSame;
        }

        private string GenerateBase()
        {
            if (MaxDate.Equals(defaultDate) && MinDate.Equals(defaultDate) && Format.Length == 0)
            {
                return "";
            }
            return f.Date.Between(MinDate, MaxDate).ToString(Format);
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
                    }
                }
                else
                {
                    f = new Faker();
                    generatedValue = GenerateBase();
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
