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

namespace lab5Domowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Samochód samochód = new Samochód();

        Student student = new Student { Imię = "Jan", Nazwisko = "Kowalski" };
        Samochód2 samochód2 = new Samochód2 { Marka = "Ford", Model = "Focus" };

        Queue<Zadanie> kolejkaZadań = new Queue<Zadanie>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            ((IZwiększany)samochód).Zmień();
            listWynik.Items.Add($"Prędkość zwiększona: {samochód.PokażPrędkość()} km/h");

            ((IZmniejszany)samochód).Zmień();
            listWynik.Items.Add($"Prędkość zmniejszona: {samochód.PokażPrędkość()} km/h");
        }

        private void btnClick2_Click(object sender, RoutedEventArgs e)
        {
            Student poprawionyStudent = student.PobierzLepsząWersję();
            Samochód2 poprawionySamochód = samochód2.PobierzLepsząWersję();

            listWynik2.Items.Add($"Poprawiony student: {poprawionyStudent.Imię} {poprawionyStudent.Nazwisko}");
            listWynik2.Items.Add($"Poprawiony samochód: {poprawionySamochód.Marka} {poprawionySamochód.Model}");
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            string opis = Microsoft.VisualBasic.Interaction.InputBox("Wprowadź opis zadania:", "Dodaj zadanie");
            if (!string.IsNullOrEmpty(opis))
            {
                // Dodanie nowego zadania do kolejki z aktualną datą
                kolejkaZadań.Enqueue(new Zadanie(opis, DateTime.Now));
            }
        }

        private void btnPobierz_Click(object sender, RoutedEventArgs e)
        {
            if (kolejkaZadań.Count > 0)
            {
                // Pobranie zadania z kolejki
                Zadanie pobraneZadanie = kolejkaZadań.Dequeue();

                // Okno dialogowe z opisem i datą zadania
                MessageBox.Show($"Opis zadania: {pobraneZadanie.Opis}\nData wprowadzenia: {pobraneZadanie.DataWprowadzenia}",
                                "Pobrane zadanie");
            }
            else
            {
                MessageBox.Show("Kolejka zadań jest pusta!", "Błąd");
            }
        }
    }
}
