using Bogus;
using Bogus.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestDataGeneratorApp.Models
{ 
    [JsonDerivedType(typeof(StringField), nameof(StringField))]
    [JsonDerivedType(typeof(DateField), nameof(DateField))]
    [JsonDerivedType(typeof(NumberField), nameof(NumberField))]
    public interface IField
    {
        string FieldName { get; set; }
        string Value { get; set; }

        string DisplayValue { get; set; }
        void GenerateValue();
    }

}
