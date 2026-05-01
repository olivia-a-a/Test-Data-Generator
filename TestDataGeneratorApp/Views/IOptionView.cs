using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorApp.Models;

namespace TestDataGeneratorApp.Views
{
    public interface IOptionView
    {
        public string FieldName { get; set; }

        public IField FieldFormat { get; set; }

        public void ShowAsDialogue();

    }
}
