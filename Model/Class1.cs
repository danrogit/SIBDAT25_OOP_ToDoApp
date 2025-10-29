using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIBDAT25_OOP_ToDoApp.Model
{
    class Opgave
    {
        public string navn { get; set; }
        public DateTime dato { get; set; }
        public string status { get; set; }
        public string Opg { get; set; }
        public bool ok { get; set; }
        public override string ToString() => Opg ?? navn ?? string.Empty;
    }
}
