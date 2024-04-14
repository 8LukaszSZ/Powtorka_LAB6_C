using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5Domowe
{
    interface IZwiększany
    {
        void Zmień();
    }
    interface IZmniejszany
    {
        void Zmień();
    }
    // Interfejs generyczny IPoprawialny
    interface IPoprawialny<T>
    {
        T PobierzLepsząWersję();
    }

    // Klasa Samochód implementująca interfejsy IZwiększany i IZmniejszany
    class Samochód : IZwiększany, IZmniejszany
    {
        private int prędkość = 0;

        void IZwiększany.Zmień()
        {
            prędkość += 10;
        }

        void IZmniejszany.Zmień()
        {
            prędkość -= 5;
        }

        public int PokażPrędkość()
        {
            return prędkość;
        }
    }
    class Student : IPoprawialny<Student>
    {
        public string Imię { get; set; }
        public string Nazwisko { get; set; }

        public Student PobierzLepsząWersję()
        {
            // Tutaj można wprowadzić dowolne poprawki
            return new Student { Imię = Imię.ToUpper(), Nazwisko = Nazwisko.ToUpper() };
        }
    }

    class Samochód2 : IPoprawialny<Samochód2>
    {
        public string Marka { get; set; }
        public string Model { get; set; }

        public Samochód2 PobierzLepsząWersję()
        {
            // Tutaj można wprowadzić dowolne poprawki
            return new Samochód2 { Marka = Marka.ToUpper(), Model = Model.ToUpper() };
        }
    }

}
