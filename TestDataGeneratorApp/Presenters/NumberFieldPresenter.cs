using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Views;

namespace TestDataGeneratorApp.Presenters
{
    public class NumberFieldPresenter
    {
        private INumberFieldView NumberFieldOptionView;
        public NumberFieldPresenter(INumberFieldView view) 
        {
            NumberFieldOptionView = view;
            NumberFieldOptionView.CustomNumChanged += CustomNumIsChanged;
            NumberFieldOptionView.MaxNumChanged += MaxNumIsChanged;
            NumberFieldOptionView.MinNumChanged += MinNumIsChanged;
            NumberFieldOptionView.FieldFormClosing += SaveFieldFormat;
            NumberFieldOptionView.LoadView += SetUpFieldFormat;            
        }

        public void SetUpFieldFormat(object? sender, EventArgs e)
        {
            switch (NumberFieldOptionView.FieldFormat) 
            {
                case NumberField NumCell:
                    NumberFieldOptionView.MinNum = NumCell.MinNum;
                    NumberFieldOptionView.MaxNum = NumCell.MaxNum;
                    NumberFieldOptionView.DecimalPlace = NumCell.DecimalPlaces;
                    NumberFieldOptionView.StaysTheSame = NumCell.StaysTheSame;
                    NumberFieldOptionView.Custom = NumCell.Custom;
                    break;
                default: // for when the field format was a different type before this one was selected
                    NumberField NewNumberOption = new();
                    NumberFieldOptionView.MinNum = NewNumberOption.MinNum;
                    NumberFieldOptionView.MaxNum = NewNumberOption.MaxNum;
                    NumberFieldOptionView.DecimalPlace = NewNumberOption.DecimalPlaces;
                    NumberFieldOptionView.StaysTheSame = NewNumberOption.StaysTheSame;
                    NumberFieldOptionView.Custom = NewNumberOption.Custom;
                    break;
            }
        }

        public void SaveFieldFormat(object? sender, EventArgs e)
        {
            NumberFieldOptionView.CancelClose = false;
            NumberField NewNumOption = new();
            double minDouble = 0;
            double maxDouble = 0;
            double customDouble = 0;

            if ((!double.TryParse(NumberFieldOptionView.MinNum, out minDouble) && NumberFieldOptionView.MinNum.Length > 0) || 
                (!double.TryParse(NumberFieldOptionView.MaxNum, out maxDouble) && NumberFieldOptionView.MaxNum.Length > 0) || 
                (!double.TryParse(NumberFieldOptionView.Custom, out customDouble) && NumberFieldOptionView.Custom.Length > 0)
                )
            {
                NumberFieldOptionView.Msg = "Please ensure all the fields you have amended are valid numbers.";
                NumberFieldOptionView.CancelClose = true;
                NumberFieldOptionView.show_Message();
            }

            if (NumberFieldOptionView.MinNum == "")
            {
                NewNumOption.MinNum = "0";
            }
            else
            {
                NewNumOption.MinNum = NumberFieldOptionView.MinNum;
            }

            if (NumberFieldOptionView.MaxNum == "")
            {
                NewNumOption.MaxNum = "0";
            }
            else
            {
                NewNumOption.MaxNum = NumberFieldOptionView.MaxNum;
            }

            NewNumOption.Custom = NumberFieldOptionView.Custom;
            NewNumOption.DecimalPlaces = (int)NumberFieldOptionView.DecimalPlace;
            NewNumOption.StaysTheSame = NumberFieldOptionView.StaysTheSame;

            NumberFieldOptionView.FieldFormat = NewNumOption;

            if (NumberFieldOptionView.Custom.Length > 0)
            {
                NumberFieldOptionView.FieldFormat.DisplayValue = NumberFieldOptionView.Custom;
            }
            else if (NumberFieldOptionView.MinNum.Length > 0 || NumberFieldOptionView.MaxNum.Length > 0 || NumberFieldOptionView.Custom.Length > 0 ||
                NumberFieldOptionView.StaysTheSame || NumberFieldOptionView.DecimalPlace > 0)
            {
                NumberFieldOptionView.FieldFormat.DisplayValue = "Number Format";
            }
            else
            {
                NumberFieldOptionView.FieldFormat.DisplayValue = "";
            }
        }

        public void MaxNumIsChanged(object? sender, EventArgs e)
        {
            if (NumberFieldOptionView.MaxNum.Length > 0)
            {
                NumberFieldOptionView.CustomEnabled = false;
            }
            else
            {
                NumberFieldOptionView.CustomEnabled = true;
            }
        }

        public void MinNumIsChanged(object? sender, EventArgs e)
        {
            if (NumberFieldOptionView.MinNum.Length > 0)
            {
                NumberFieldOptionView.CustomEnabled = false;
            }
            else
            {
                NumberFieldOptionView.CustomEnabled = true;
            }
        }  
        
        public void CustomNumIsChanged(object? sender, EventArgs e)
        {
            if (NumberFieldOptionView.Custom.Length > 0)
            {
                NumberFieldOptionView.MaxNumEnabled = false;
                NumberFieldOptionView.MinNumEnabled = false;
                NumberFieldOptionView.DecimalPlaceEnabled = false;
                NumberFieldOptionView.StaysTheSame = true;
                NumberFieldOptionView.StaysTheSameEnabled = false;
            }
            else
            {
                NumberFieldOptionView.MaxNumEnabled = true;
                NumberFieldOptionView.MinNumEnabled = true;
                NumberFieldOptionView.DecimalPlaceEnabled = true;
                NumberFieldOptionView.StaysTheSame = false;
                NumberFieldOptionView.StaysTheSameEnabled = true;
            }
        }
    }
}
