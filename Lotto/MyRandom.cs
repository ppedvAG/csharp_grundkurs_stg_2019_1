using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class MyRandom : Random
    {
        public override int Next(int untereSchranke, int obereSchranke)
        {
            return base.Next(untereSchranke, obereSchranke + 1);
        }
    }

    public class MyList<T> : List<T>
    {
        public int Zähler { get; set; }

        public new void Add(T neuesElement)
        {
            Zähler++;
        }
    }
}