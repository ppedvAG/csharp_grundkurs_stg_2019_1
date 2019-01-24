using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VectorPicasso.Klassen
{
    public class Grafik
    {

        public Brush Strichfarbe { get; private set; } = new SolidColorBrush(Colors.Black);

        private double _strichdicke = 1;
        public double Strichdicke
        {
            get { return _strichdicke; }
            set
            {
                if (value > 0)
                {
                    _strichdicke = value;
                }
                else
                    throw new Exception("Strichdicke muss größer als 0 sein!");
            }
        }

        public Grafik(Brush strichfarbe = null, double strichdicke = 1)
        {
            //Wenn der Aufrufer der Klasse keinen Parameter für strichfarbe übergibt,
            //dann setze Black als Standardfarbe
            Strichfarbe = (strichfarbe == null) ? Brushes.Black : strichfarbe;
            Strichdicke = strichdicke;
        }
    }
}