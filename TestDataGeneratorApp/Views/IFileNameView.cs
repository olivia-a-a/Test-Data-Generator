using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGeneratorApp.Views
{
    public interface IFileNameView
    {
        public string EnteredFileName { get; set; }

        public string FileName { get; set; }

        public string DefaultFileTypeExplain { set; }

        public void ShowAsDialogue();

        public event EventHandler? ValidateFileName;
        public event EventHandler? LoadView;

    }
}
