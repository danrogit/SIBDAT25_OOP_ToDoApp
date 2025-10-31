using SIBDAT25_OOP_ToDoApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIBDAT25_OOP_ToDoApp
{
    /// <summary>
    /// ToDo App, Casper, Daniel og Camilla.
    /// </summary>
    public partial class MainWindow : Window
    {      
        Opgave opgave = new Opgave(); // Instantiere et nyt objekt (opgave) 
        ObservableCollection<Opgave> OpgaveListe { get; set; } = new ObservableCollection<Opgave>(); // Dynamisk liste
        
        public MainWindow()  
        {
            InitializeComponent();
            TaskDate.SelectedDate = DateTime.Today;  // Dato feltet - en variabel (TaskDate)
            Liste.ItemsSource = OpgaveListe;  // Binder ListBox til OpgaveListe
        }

        // Tilføj knappen
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string NyOpgave = OpgaveFelt.Text;  // Koden læser hvad der er skrevet i input feltet
            DateTime selectedDate = TaskDate.SelectedDate ?? DateTime.Today;  // Tager valgte dato og hvis den er null, tager den DateTime.Today

            if (!string.IsNullOrEmpty(NyOpgave))  // Tjekker om tekstfeltet er null eller tomt
            {
                OpgaveListe.Add(new Opgave  // Tager input i felter og opretter ny opgave 
                {
                    Opg = NyOpgave,  
                    ok = false,
                    dato = selectedDate
                });

                OpgaveFelt.Clear(); // Nulstiller teksten opgavefelt teksten
            }
            else
            {
                MessageBox.Show("Tilføj en opgave.");  // Hvis intet er skrevet, så kommer popup med beskeden.
            }
        }

        private void Opgave_TextChanged(object sender, TextChangedEventArgs e)  // Tjekker om der er tekst, hvis der ikke er, så kommer popup
        {}

        // Fjern knappen
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Opgave sletOpgave = (Opgave)Liste.SelectedItem; // Sletter valgte listitem fra listen

            if(sletOpgave != null)   // Tjekker om en item er valgt fra listen, og sletter derefter
            {
                OpgaveListe.Remove(sletOpgave);
            }
            else
            {
                MessageBox.Show("Vælge en opgave, for at slette.");  // Hvis intet er valgt = popup med besked
            }
        }

        private void Liste_SelectionChanged(object sender, SelectionChangedEventArgs e) // Tjekker om list item er valgt
        {}

        private void CheckBox_Checked(object sender, RoutedEventArgs e) // Tjekker om boksen er markeret
        {
            if (sender is CheckBox checkBox && checkBox.DataContext is Opgave opgave) // Tjekker om opgaven er markeret eller ej
            {
                opgave.ok = checkBox.IsChecked ?? false; // Boolsk værdi; Er opgaven tjekket, så får den ikke et flueben
            }
        }


        // Rediger knappen
        private void Rediger_Click(object sender, RoutedEventArgs e)
        {
            Opgave valgtOpgave = (Opgave)Liste.SelectedItem;  // Oprettes et nyt objekt i classen
            string NyTekst = OpgaveFelt.Text; // Oprettes ny variabel til opgavefeltet

            if (valgtOpgave != null) // Hvis man har valgt en opgave fra listen
            {
                if(!string.IsNullOrEmpty(NyTekst))  // Hvis opgavefeltet har et tekst input, så må den gå videre
                {                 
                    valgtOpgave.Opg = NyTekst;
                    Liste.Items.Refresh();
                    OpgaveFelt.Clear();
                }
                else
                {
                    MessageBox.Show("Rediger teksten.");  // Hvis intet er skrevet i tekst input feltet, så kommer popup
                }
            }
           else
            {
                MessageBox.Show("Vælg en opgave du vil redigere."); // Hvis ingen opgave er valgt (er null), så kommer popup
            }
        }
    }
}