using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Views;

namespace TestDataGeneratorApp.Presenters
{
    public class DateFieldPresenter
    {
        private string customDateFormat = "dd/MM/yyyy HH:mm:ss";
        private string dotNetFormatSpecifierDocumentation = "https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings";
        private IDateFieldView DateFieldOptionView;
        public DateFieldPresenter(IDateFieldView view) 
        {
            DateFieldOptionView = view;
            DateFieldOptionView.FormatLinkClicked += OpenDotNetDocumentation;
            DateFieldOptionView.CustomDateChanged += CustomDateIsChanged;
            DateFieldOptionView.DateFormatChanged += DateFormatIsChanged;
            DateFieldOptionView.FieldFormClosing += SaveFieldFormat;
            DateFieldOptionView.LoadView += SetUpFieldFormat;            
        }

        public void SetUpFieldFormat(object? sender, EventArgs e)
        {
            DateFieldOptionView.SetMaxDateToolTip = "Format: " + customDateFormat;
            DateFieldOptionView.SetMinDateToolTip = "Format: " + customDateFormat;
            DateFieldOptionView.SetMaxDateFormat = customDateFormat;
            DateFieldOptionView.SetMinDateFormat = customDateFormat;

            switch (DateFieldOptionView.FieldFormat) 
            {
                case DateField DateCell:
                    DateFieldOptionView.MaxDate = DateCell.MaxDate;
                    DateFieldOptionView.MinDate = DateCell.MinDate;
                    DateFieldOptionView.Custom = DateCell.Custom;
                    DateFieldOptionView.Format = DateCell.Format;
                    DateFieldOptionView.StaysTheSame = DateCell.StaysTheSame;
                    break;
                default: // for when the field format was a different type before this one was selected
                    DateField NewDateOption = new();
                    DateFieldOptionView.MaxDate = NewDateOption.MaxDate;
                    DateFieldOptionView.MinDate = NewDateOption.MinDate;
                    DateFieldOptionView.Custom = NewDateOption.Custom;
                    DateFieldOptionView.Format = NewDateOption.Format;
                    DateFieldOptionView.StaysTheSame = NewDateOption.StaysTheSame;
                    break;
            }
        }

        public void SaveFieldFormat(object? sender, EventArgs e)
        {
            DateFieldOptionView.CancelClose = false;
            DateField NewDateOption = new(DateFieldOptionView.MaxDate, DateFieldOptionView.MinDate);

            try
            {
                DateFieldOptionView.MaxDate.ToString(DateFieldOptionView.Format); // try to see if the format works
                NewDateOption.Custom = DateFieldOptionView.Custom;
                NewDateOption.Format = DateFieldOptionView.Format;
                NewDateOption.StaysTheSame = DateFieldOptionView.StaysTheSame;
            }
            catch (FormatException)
            {
                DateFieldOptionView.Msg = $"Please ensure a valid format for the date is provided. \nClick the help button to find out which format characters are accepted.";
                DateFieldOptionView.CancelClose = true;
                DateFieldOptionView.show_Message();
            }

            DateFieldOptionView.FieldFormat = NewDateOption;

            if (DateFieldOptionView.Custom.Length > 0)
            {
                DateFieldOptionView.FieldFormat.DisplayValue = DateFieldOptionView.Custom;
            }
            else if (DateFieldOptionView.Format.Length > 0 || DateFieldOptionView.MaxDate > NewDateOption.defaultDate || DateFieldOptionView.MinDate > NewDateOption.defaultDate ||
                DateFieldOptionView.StaysTheSame)
            {
                DateFieldOptionView.FieldFormat.DisplayValue = "Date Format";
            }
            else
            {
                DateFieldOptionView.FieldFormat.DisplayValue = "";
            }
        }

        public void CustomDateIsChanged(object? sender, EventArgs e)
        {
            if (DateFieldOptionView.Custom.Length > 0)
            {
                DateFieldOptionView.MaxDateEnabled = false;
                DateFieldOptionView.MinDateEnabled = false;
                DateFieldOptionView.FormatEnabled = false;
                DateFieldOptionView.StaysTheSame = true;
                DateFieldOptionView.StaysTheSameEnabled = false;
            }
            else
            {
                DateFieldOptionView.MaxDateEnabled = true;
                DateFieldOptionView.MinDateEnabled = true;
                DateFieldOptionView.FormatEnabled = true;
                DateFieldOptionView.StaysTheSame = false;
                DateFieldOptionView.StaysTheSameEnabled = true;
            }
        }

        public void DateFormatIsChanged(object? sender, EventArgs e)
        {
            if (DateFieldOptionView.Format.Length > 0)
            {
                DateFieldOptionView.CustomEnabled = false;
            }
            else
            {
                DateFieldOptionView.CustomEnabled = true;
            }
        }  
        
        public void OpenDotNetDocumentation(object? sender, EventArgs e)
        {
            System.Diagnostics.Process.Start( 
                new System.Diagnostics.ProcessStartInfo { 
                    FileName = dotNetFormatSpecifierDocumentation, 
                    UseShellExecute = true
                }
            );
        }
    }
}
