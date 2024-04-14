using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5Domowe
{
    public class Zadanie
    {
        public string Opis { get; set; }
        public DateTime DataWprowadzenia { get; set; }

        public Zadanie(string opis, DateTime dataWprowadzenia)
        {
            Opis = opis;
            DataWprowadzenia = dataWprowadzenia;
        }
    }
}
