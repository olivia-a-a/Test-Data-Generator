using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace TestDataGeneratorApp.Models
{
    public class NumberField : IField
    {
        private string _value = "";
        private string _field_name = "";
        private string _display_value = "";
        private Faker f = new Faker();
        public string FieldName { get => _field_name; set => _field_name = value; }
        public string Value { get => _value; set => _value = value; }
        public string DisplayValue { get => _display_value; set => _display_value = value; }

        public string MaxNum;

        public string MinNum;

        public int DecimalPlaces;
        public string Custom { get; set; }
        public bool StaysTheSame { get; set; }

        public NumberField(string MaxNum = "", string MinNum = "", int DecimalPlaces = 0, string Custom = "", bool StaysTheSame = false)
        {
            this.MaxNum = MaxNum;
            this.MinNum = MinNum;
            this.Custom = Custom;
            this.DecimalPlaces = DecimalPlaces;
            this.StaysTheSame = StaysTheSame;
        }

        private double GenerateBase()
        {            
            if (DecimalPlaces > 0)
            {
                double randDouble = f.Random.Double(double.Parse(MinNum), double.Parse(MaxNum));
                return Math.Round(randDouble, DecimalPlaces);
            }
            return f.Random.Int(int.Parse(MinNum), int.Parse(MaxNum));
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
                        generatedValue = GenerateBase().ToString();
                    }
                }
                else
                {
                    f = new Faker();
                    generatedValue = GenerateBase().ToString();
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
