using Newtonsoft.Json;
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
using System.Xml.Serialization;
using VectorPicasso.Klassen;

namespace VectorPicasso
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        enum Grafikarten { Punkt, Rechteck, Strich, Kreis };
        Grafikarten _ausgewählteGrafikart;

        ObservableCollection<Grafik> _grafikliste = new ObservableCollection<Grafik>(); 

        public MainWindow()
        {
            InitializeComponent();
            //setze die Leinwand auf die Canvas
            Grafik.Leinwand = canvas;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
            if(sender is RadioButton)
            {
                RadioButton btn = (RadioButton)sender;
                if(btn.Content.ToString() == "Punkt")
                {
                    _ausgewählteGrafikart = Grafikarten.Punkt;
                }
                else if(btn.Content.ToString() == "Rechteck")
                {
                    _ausgewählteGrafikart = Grafikarten.Rechteck;
                }
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Grafik neueGrafik = null;

            switch (_ausgewählteGrafikart)
            {
                case Grafikarten.Punkt:
                    neueGrafik = new EinPunkt(e.GetPosition(canvas));
                    neueGrafik.Strichdicke = 10;
                    neueGrafik.Strichfarbe = Brushes.Fuchsia;
                    break;
                case Grafikarten.Rechteck:
                    break;
                case Grafikarten.Strich:
                    break;
                case Grafikarten.Kreis:
                    break;
                default:
                    break;
            }
            neueGrafik.ZeichneDich();
            _grafikliste.Add(neueGrafik);
        }

        const string Dateiname = "MeinBild.vg";
        const string DateinameXML = "MeinBild.xml";
        JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            //Sorgt dafür dass beim Serialisierung der Datentyp mit ins JSON geschrieben wird
            TypeNameHandling = TypeNameHandling.Objects,
        };

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            //Datei soll im Bin-Ordner abgelegt werden
            //false bedeutet: Datei wird überschrieben. Bei true wird sie erweitert.

            //using sorgt dafür, dass die Datei auch bei einer Exception auf jeden Fall geschlossen wird
            using (StreamWriter writer = new StreamWriter(Dateiname, false))
            {
                         
                string jsonString = JsonConvert.SerializeObject(_grafikliste, _settings);
                writer.Write(jsonString);
                writer.Close();
            }

            //using (StreamWriter writer = new StreamWriter(DateinameXML, false))
            //{

            //    List<string> wörter = new List<string>()
            //    {
            //        "Adasd",
            //        "adsdas",
            //        "adsad"
            //    };
                
            //    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            //    serializer.Serialize(writer, wörter);
   
            //}

        }

        private void Laden_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader reader = new StreamReader(Dateiname))
            {
                string jsonString = reader.ReadToEnd();
                reader.Close();
                _grafikliste = JsonConvert.DeserializeObject<ObservableCollection<Grafik>>(jsonString,_settings);
            }

            //Canvas wieder bemalen
            foreach (Grafik item in _grafikliste)
            {
                item.ZeichneDich();
            }
        }
    }
}
