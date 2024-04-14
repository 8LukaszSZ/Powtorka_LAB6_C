using Generyki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stozek stozek;
        private readonly Dictionary<int, Student2> studenci = new Dictionary<int, Student2>();
        public MainWindow()
        {
            InitializeComponent();
            stozek = new Stozek();
            stozek.ObsługaBłędu += ObsługaBłęduHandler;

            studenci.Add(12345, new Generyki.Student2 { Nazwisko2 = "Kowalski", Ocena2 = 4.5 });
            studenci.Add(67890, new Generyki.Student2 { Nazwisko2 = "Nowak", Ocena2 = 3.0 });
            studenci.Add(54321, new Generyki.Student2 { Nazwisko2 = "Wiśniewski", Ocena2 = 5.0 });
            studenci.Add(98765, new Generyki.Student2 { Nazwisko2 = "Lewandowski", Ocena2 = 4.2 });

        }
        private void ObsługaBłęduHandler(string opisBłędu)
        {
            MessageBox.Show(opisBłędu, "Błąd");
            lblBlad.Content = opisBłędu;
        }

        private void btnOblicz_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(txtWysokosc.Text, out double wysokosc);
            double.TryParse(txtPromien.Text, out double promien);

            stozek.Wysokość = wysokosc;
            stozek.Promień = promien;
            double objętość = (Math.PI * stozek.Promień * stozek.Promień * stozek.Wysokość) / 3;
            lblWynik.Content = $"Objętość stożka: {objętość}";
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            string tekst1 = "jabłko";
            string tekst2 = "banan";
            string większyTekst = Generyki.Znajdz.ZnajdźWiększy(tekst1, tekst2);
            MessageBox.Show($"Większy tekst: {większyTekst}");

            double liczba1 = 10.5;
            double liczba2 = 8.2;
            double większaLiczba = Generyki.Znajdz.ZnajdźWiększy(liczba1, liczba2);
            MessageBox.Show($"Większa liczba: {większaLiczba}");

            Generyki.Student student1 = new Generyki.Student("Jan", "Kowalski");
            Generyki.Student student2 = new Generyki.Student("Anna", "Nowak");
            Generyki.Student lepszyStudent = Generyki.Znajdz.ZnajdźWiększy(student1, student2);
            MessageBox.Show($"Lepszy student: {lepszyStudent.Imię} {lepszyStudent.Nazwisko}");
        }

        private void btnTest2_Click(object sender, RoutedEventArgs e)
        {
            Regał<double> regałDouble = new Regał<double>();
            regałDouble.WstawNaWolnąPółkę(3.14);
            MessageBox.Show($"Wartość na Półce1: {regałDouble.Półka1}");

            // Przykład użycia klasy Regał dla typu Student
            //Regał<Student> regałStudent = new Regał<Student>();
            //regałStudent.WstawNaWolnąPółkę(new Student("Jan", "Kowalski"));
            //MessageBox.Show($"Dane na Półce2: {regałStudent.Półka2}");

            //Przykład użycia właściwości WolnaPółka
            //regałStudent.WolnaPółka = new Student("Anna", "Nowak");
            //Student studentNaWolnejPółce = regałStudent.WolnaPółka;
            //MessageBox.Show($"Dane na Wolnej Półce: {studentNaWolnejPółce.Imię} {studentNaWolnejPółce.Nazwisko}");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumerAlbumuTextBox.Text, out int numerAlbumu))
            {
                if (studenci.TryGetValue(numerAlbumu, out Student2 znalezionyStudent))
                {
                    MessageBox.Show($"Znaleziony student:\nNazwisko: {znalezionyStudent.Nazwisko2}\nOcena: {znalezionyStudent.Ocena2}");
                }
                else
                {
                    MessageBox.Show("Nie znaleziono studenta o podanym numerze albumu.");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź poprawny numer albumu (liczbę całkowitą).");
            }
        }
    }
}
