using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Views;

namespace TestDataGeneratorApp.Presenters
{
    public class FileNamePresenter
    {
        private string defaultFileType = ".dat";
        private IFileNameView FileNameView;
        public FileNamePresenter(IFileNameView view)
        {
            FileNameView = view;
            FileNameView.ValidateFileName += SetFileName;
            FileNameView.LoadView += SetUpForm;
        }

        public void SetUpForm(object? sender, EventArgs e)
        {
            FileNameView.DefaultFileTypeExplain = $" {defaultFileType}.";
        }

        public void SetFileName(object? sender, EventArgs e)
        {
            if (FileNameView.EnteredFileName.Length > 0)
            {
                if (FileNameView.EnteredFileName.Contains("."))
                {
                    FileNameView.FileName = "\\" + FileNameView.EnteredFileName;
                }
                else 
                {
                    FileNameView.FileName = "\\" + FileNameView.EnteredFileName + defaultFileType;
                }
            }
        }
    }
}
