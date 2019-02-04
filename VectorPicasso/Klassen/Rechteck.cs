using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VectorPicasso.Klassen
{
    public class Rechteck : ZweiPunkt
    {

        public virtual Brush Füllfarbe { get; set; }
        

        public Rechteck(Point ursprung, Brush füllfarbe = null) : base(ursprung)
        {
            #region Ausführliche If-Schreibweise
            //if (füllfarbe == null)
            //{
            //    Füllfarbe = Brushes.Transparent;
            //}
            //else
            //{
            //    Füllfarbe = füllfarbe;
            //}
            #endregion
            Füllfarbe = (füllfarbe == null) ? Brushes.Transparent : füllfarbe;
        }

        public override void ZeichneDich()
        {
            Rectangle rectangle = new Rectangle();
            Canvas.SetLeft(rectangle, Ursprung.X);
            Canvas.SetTop(rectangle, Ursprung.Y);
            rectangle.Width = Abstand.X;
            rectangle.Height = Abstand.Y;
            rectangle.Stroke = Strichfarbe;
            rectangle.Fill = Füllfarbe;
            rectangle.RenderTransform = new RotateTransform(Winkel);

            Grafik.Leinwand.Children.Add(rectangle);
        }

        public override string ToString()
        {
            return base.ToString() + $", Füllbarbe: {Füllfarbe}";
        }
    }
}