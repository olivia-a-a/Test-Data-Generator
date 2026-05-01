using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGeneratorApp.Models
{
    internal class TestDataConfig
    {
        private Table _header_table = new();
        private Table _data_table = new();
        private Table _trailer_table = new();
        public Table header_table { get => _header_table; set => _header_table = value; }
        public Table data_table { get => _data_table; set => _data_table = value; }

        public Table trailer_table { get => _trailer_table; set => _trailer_table = value; }

    }
}
