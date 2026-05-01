using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Models;

namespace TestDataGeneratorApp.Views
{
    public interface INumberFieldView
    {
        public string Msg { get; set; }
        public IField FieldFormat { get; set; }

        public decimal DecimalPlace { get; set; }

        public bool DecimalPlaceEnabled { get; set; }

        public string MaxNum { get; set; }
        public bool MaxNumEnabled { get; set; }
        public string MinNum { get; set; }

        public bool MinNumEnabled { get; set; }
        public bool StaysTheSame { get; set; }
        public bool StaysTheSameEnabled { get; set; }

        public string Custom { get; set; }
        public bool CustomEnabled { get; set; }

        public bool CancelClose { get; set; }

        public event EventHandler? MaxNumChanged;
        public event EventHandler? MinNumChanged;
        public event EventHandler? CustomNumChanged;
        public event EventHandler? FieldFormClosing;
        public event EventHandler? LoadView;

        public void show_Message();
    }
}
