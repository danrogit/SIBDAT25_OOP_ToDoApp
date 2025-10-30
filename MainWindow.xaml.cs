using SIBDAT25_OOP_ToDoApp.Model;
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;

namespace SIBDAT25_OOP_ToDoApp
{
    /// <summary>
    /// ToDo App, Casper, Daniel og Camilla.
    /// </summary>
    public partial class MainWindow : Window
    {      
        Opgave opgave = new Opgave();      
        ObservableCollection<Opgave> OpgaveListe { get; set; } = new ObservableCollection<Opgave>();
        
        public MainWindow()
        {
            InitializeComponent();
            TaskDate.SelectedDate = DateTime.Today;
            Liste.ItemsSource = OpgaveListe;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Add button
        {
            string NyOpgave = OpgaveFelt.Text;
            DateTime selectedDate = TaskDate.SelectedDate ?? DateTime.Today;

            if (!string.IsNullOrEmpty(NyOpgave))
            {
                OpgaveListe.Add(new Opgave 
                { Opg = NyOpgave, 
                    ok = false,
                    dato = selectedDate});
                OpgaveFelt.Clear();
            }
            else
            {
                MessageBox.Show("Tilføj en opgave.");
            }
        }

        private void Opgave_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Opgave sletOpgave = (Opgave)Liste.SelectedItem;

            if(sletOpgave != null)
            {
                OpgaveListe.Remove(sletOpgave);
            }
            else
            {
                MessageBox.Show("Vælge en opgave, for at slette.");
            }
        }

        private void Liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.DataContext is Opgave opgave)
            {
                opgave.ok = checkBox.IsChecked ?? false;
            }
        }

        

        private void Rediger_Click(object sender, RoutedEventArgs e)
        {
            Opgave valgtOpgave = (Opgave)Liste.SelectedItem;
            string NyTekst = OpgaveFelt.Text;

            if (valgtOpgave != null)
            {
                if(!string.IsNullOrEmpty(NyTekst))
                {
                    valgtOpgave.Opg = NyTekst;
                    valgtOpgave.dato = DateTime.Now;
                    Liste.Items.Refresh();
                    OpgaveFelt.Clear();
                }
                else
                {
                    MessageBox.Show("Rediger tekst og dato.");
                }
            }
           else
            {
                MessageBox.Show("Vælg en opgave du vil redigere.");
            }
        }
    }
}