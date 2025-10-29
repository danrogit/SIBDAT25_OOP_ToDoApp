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

namespace SIBDAT25_OOP_ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Opgave opgave = new Opgave();
        ObservableCollection<Opgave> OpgaveListe { get; set; } = new ObservableCollection<Opgave>();
        
        public MainWindow()
        {
            InitializeComponent();
            
            
            Liste.ItemsSource = OpgaveListe;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Add button
        {
            string NyOpgave = OpgaveFelt.Text;

            if (!string.IsNullOrEmpty(NyOpgave))
            {
                OpgaveListe.Add(new Opgave { Opg = NyOpgave, ok = false });
                OpgaveFelt.Clear();
            }
            else
            {
                MessageBox.Show("Tilføj Opgave");
            }
        }

        private void Opgave_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Opgave sletOpgave = (Opgave)Liste.SelectedItem;

            if(sletOpgave !=null)
            {
                OpgaveListe.Remove(sletOpgave);
            }
            else
            {
                MessageBox.Show("Slet Opgave");
            }
        }

        private void Liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}