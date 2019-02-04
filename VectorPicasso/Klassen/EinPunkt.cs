using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace VectorPicasso.Klassen
{
    public class EinPunkt : Grafik
    {
        public Point Ursprung { get; set; }

        //snippet: ctor
        public EinPunkt(Point ursprung)
        {
            Ursprung = ursprung;
        }
        
        public override void ZeichneDich()
        {
            System.Windows.Shapes.Ellipse ellipse = new System.Windows.Shapes.Ellipse();
            Canvas.SetTop(ellipse, Ursprung.Y);
            Canvas.SetLeft(ellipse, Ursprung.X);
            ellipse.Fill = Strichfarbe;
            ellipse.Width = Strichdicke;
            ellipse.Height = Strichdicke;

            Grafik.Leinwand.Children.Add(ellipse);
        }

        public override string ToString()
        {
            return base.ToString() + $", Ursprung: {Ursprung}";
        }
    }
}
