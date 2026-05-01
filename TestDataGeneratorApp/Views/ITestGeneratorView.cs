using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Presenters;

namespace TestDataGeneratorApp.Views
{
    public interface ITestGeneratorView
    {
        public string Msg { get; set; }

        public List<string> EditableColumns { get; set; }

        public string FieldOptions { set;  }
        public object HeaderCellValue { get; set; }

        public object DataCellValue { get; set; }

        public object TrailerCellValue { get; set; }

        public bool AddHeaderRowEnabled { get; set; }
        public bool AddTrailerRowEnabled { get; set; }
        public bool AddDataRowEnabled { get; set; }

        public bool EnableFieldOptions { set; }

        public string SelectedFieldOption { get; set; }

        public (int Row, int Column) SelectedCellCoords { get; set; }

        public object SelectedCellValue { get; set; }

        public Tables SelectedTable  { get; set; }

        public string FileName { get; set; }
        public string FolderPath { get; set; }
        public string FullPath { get; set; }

        public bool GenerateBtnEnabled { get; set; }
        public IOptionView OptionForm { get; set; }

        public IFileNameView FileNameForm { get; set; }

        public void show_Message();
        public void Draw_Header_Table(Table HeaderTable);
        public void Draw_Data_Table(Table HeaderTable);

        public void Draw_Trailer_Table(Table HeaderTable);

        public event EventHandler? LoadView;

        public event EventHandler? GenerateFile;

        public event EventHandler? SelectedStringFieldOption;

        public event EventHandler? ShowFileName;

        public event EventHandler? EditedCellValue;
        public event EventHandler? FieldOptionsCMSEnabler;
        public event EventHandler? RowAdded;
        public event EventHandler? RowDeleted;
    }
}
