using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Models;

namespace TestDataGeneratorApp.Views
{
    public interface IDateFieldView
    {
        public string Msg { get; set; }
        public IField FieldFormat { get; set; }

        public string FieldName { get; set; }

        public DateTime MaxDate { get; set; }
        public bool MaxDateEnabled { get;  set; }
        public string SetMaxDateToolTip { set; }
        public string SetMaxDateFormat { set; }

        public DateTime MinDate { get; set; }
        public bool MinDateEnabled { get; set; }
        public string SetMinDateToolTip { set; }
        public string SetMinDateFormat { set; }

        public string Custom { get; set; }
        public bool CustomEnabled { get; set; }

        public string Format { get; set; }
        public bool FormatEnabled { get; set; }

        public bool StaysTheSame { get; set; }
        public bool StaysTheSameEnabled { get; set; }

        public bool CancelClose { set; }

        public event EventHandler? FormatLinkClicked;
        public event EventHandler? CustomDateChanged;
        public event EventHandler? DateFormatChanged;
        public event EventHandler? FieldFormClosing;
        public event EventHandler? LoadView;

        public void show_Message();
    }
}
