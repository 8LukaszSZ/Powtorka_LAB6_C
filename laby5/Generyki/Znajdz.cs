using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generyki
{
    public class Znajdz
    {
        public static T ZnajdźWiększy<T>(T pierwszy, T drugi) where T : IComparable<T>
        {
            int porównanie = pierwszy.CompareTo(drugi);
            if (porównanie > 0)
            {
                return pierwszy;
            }
            else if (porównanie < 0)
            {
                return drugi;
            }
            else
            {   
                return pierwszy;
            }
        }
    }

    public class Student2
    {
        public string Nazwisko2 { get; set; }
        public double Ocena2 { get; set; }
    }

    public class Student : IComparable<Student>
    {
        public string Imię { get; set; }
        public string Nazwisko { get; set; }

        public Student(string imię, string nazwisko)
        {
            Imię = imię;
            Nazwisko = nazwisko;
        }

        public int CompareTo(Student other)
        {
            return Nazwisko.CompareTo(other.Nazwisko);
        }
    }

    public class Regał<T> where T : IEquatable<T>
    {
        public T Półka1 { get; set; }
        public T Półka2 { get; set; }
        public T Półka3 { get; set; }

        public Regał()
        {
            Półka1 = default(T);
            Półka2 = default(T);
            Półka3 = default(T);
        }

        public override string ToString()
        {
            return $"Półka1: {Półka1}, Półka2: {Półka2}, Półka3: {Półka3}";
        }
        public void WstawNaWolnąPółkę(T wartość)
        {
            if (EqualityComparer<T>.Default.Equals(Półka1, default(T)))
            {
                Półka1 = wartość;
            }
            else if (EqualityComparer<T>.Default.Equals(Półka2, default(T)))
            {
                Półka2 = wartość;
            }
            else if (EqualityComparer<T>.Default.Equals(Półka3, default(T)))
            {
                Półka3 = wartość;
            }
            else
            {
                throw new InvalidOperationException("Brak wolnej półki.");
            }
        }

        public T WolnaPółka
        {
            set
            {
                WstawNaWolnąPółkę(value);
            }
        }
    }

}
