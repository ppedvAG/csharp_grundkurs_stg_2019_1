using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Hochzeitsmanager
{
    /// <summary>
    /// Interaction logic for HochzeitWindow.xaml
    /// </summary>
    public partial class HochzeitWindow : Window
    {
        public HochzeitWindow(ObservableCollection<Person> personen)
        {
            InitializeComponent();
            listboxZuHeiratendePersonen.ItemsSource = personen;
        }

        public Person ZuHeiratendePerson { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZuHeiratendePerson = (Person)listboxZuHeiratendePersonen.SelectedItem;
            this.Close();
        }
    }
}
