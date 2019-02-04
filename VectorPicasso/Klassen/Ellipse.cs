using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace VectorPicasso.Klassen
{
    public class Ellipse : ZweiPunkt
    {
        public Brush Füllfarbe { get; set; }

        public Ellipse(Point ursprung, Brush füllfarbe = null ) : base(ursprung)
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
    }
}
