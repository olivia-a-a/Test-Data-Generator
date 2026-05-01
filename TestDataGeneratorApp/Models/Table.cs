using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGeneratorApp.Models
{
    public class Table
    {
        private List<string> _columns = [];
        private List<List<IField>> _rows = [];
        public List<string> columns { get => _columns; set => _columns = value; }
        public List<List<IField>> rows { get => _rows; set => _rows = value; }
    }
}
