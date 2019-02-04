using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace VectorPicasso.Klassen
{
    public class Quadrat : Rechteck
    {
        private int _winkel;

        public new int Winkel
        {
            get { return _winkel; }
            set { _winkel = value > 360 ? 0 : value; }
        }

        private Point _abstand;
        public override Point Abstand
        {
            get
            {
                return _abstand;
            }
            set
            {
                Point neuerPoint = value;
                neuerPoint.Y = neuerPoint.X;
                _abstand = neuerPoint;
            }
        }

        public string Dummy { get; set; }

        public Quadrat(Point ursprung, Brush füllfarbe = null) : base(ursprung, füllfarbe)
        {

        }
    }
}
