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
        public string navn { get; set; }           // Opgave navnet
        public DateTime dato { get; set; }         // Dato for opgaven
        public string Opg { get; set; }            // Ny opgave - linje 44 + 97 i MainWindow.xaml.cs
        public bool ok { get; set; }               // Boolsk værdi
        public override string ToString() => Opg ?? navn ?? string.Empty;  // Tjekker om navn og opg er null, og hvis det ikke er null bliver det returneret
    }
}
