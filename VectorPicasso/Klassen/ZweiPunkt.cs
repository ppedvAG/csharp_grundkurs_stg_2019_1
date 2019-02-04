using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VectorPicasso.Klassen
{
    public abstract class ZweiPunkt : EinPunkt
    {
        public virtual int Winkel { get; set; } = 0;
        public virtual Point Abstand { get; set; } = new Point(0, 0);

        public ZweiPunkt(Point ursprung) : base(ursprung)
        {
            
        }

        public override string ToString()
        {
            return base.ToString() + $"Abstand: {Abstand}, Winkel: {Winkel}";
        }
    }
}
