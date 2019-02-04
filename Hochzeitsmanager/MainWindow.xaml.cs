using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Hochzeitsmanager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Generische Datentypen
        ObservableCollection<Person> Personenliste;

        public MainWindow()
        {
            InitializeComponent();
           
            //Code nachdem das Fenster gebaut wurde
            Personenliste = new ObservableCollection<Person>();
            //Synchronisiere ListBox und ComboBox mit der Personenliste
            listboxPersonen.ItemsSource = Personenliste;
            comboBoxZuHeiratendePerson.ItemsSource = Personenliste;

        }
        
        private void Person_Anlegen_Click(object sender, RoutedEventArgs e)
        {
            string vorname = textboxVorname.Text;
            string nachname = textboxNachname.Text;
            bool geschlecht = (bool)checkboxGeschlecht.IsChecked;
            DateTime gdatum = (DateTime)datepickerGeburtsdatum.SelectedDate;

            try
            {   
                Person neuePerson = new Person(vorname, nachname, gdatum, geschlecht);
                neuePerson.HochzeitsFail += HochzeitsFehlgeschlagen;
                Personenliste.Add(neuePerson);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
        }

        private void HochzeitsFehlgeschlagen(Person p1, Person p2, string grund)
        {
            string hochzeitsfehler = $"{p1.Name} konnte {p2.Name} nicht heiraten weil: {grund}";
            ListboxHochzeitsfehlerlog.Items.Add(hochzeitsfehler);
            MessageBox.Show(hochzeitsfehler);
        }

        private void Person_Heiraten_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Abfangen wenn keine Person ausgewählt wurde
            
            if(listboxPersonen.SelectedItem == null || comboBoxZuHeiratendePerson.SelectedItem == null)
            {
                MessageBox.Show("Wähle jeweils eine Person in jeder Liste aus!");
                return;
            }

            Person personAusListBox = (Person)listboxPersonen.SelectedItem;
            Person personAusComboBox = (Person)comboBoxZuHeiratendePerson.SelectedItem;

            bool heiratErfolgreich = personAusListBox.Heirate(personAusComboBox);

            if (heiratErfolgreich)
            { 
                listboxPersonen.Items.Refresh();
                comboBoxZuHeiratendePerson.Items.Refresh();
            }
            
        }

        private void Heirat_Popup_Click(object sender, RoutedEventArgs e)
        {
            HochzeitWindow dialogWindow = new HochzeitWindow(Personenliste);
            dialogWindow.ShowDialog();

            Person zuHeiratendePerson = dialogWindow.ZuHeiratendePerson;

            Person personAusListBox = (Person)listboxPersonen.SelectedItem;
            

            bool heiratErfolgreich = personAusListBox.Heirate(zuHeiratendePerson);
 

        }

        private void CheckboxHomoehe_Checked(object sender, RoutedEventArgs e)
        {
            Person.HomoEheErlaubt = true;
        }

        private void CheckboxHomoehe_Unchecked(object sender, RoutedEventArgs e)
        {
            Person.HomoEheErlaubt = false;

        }
    }
}
