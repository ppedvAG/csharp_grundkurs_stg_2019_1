using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        //Signatur der Methoden, auf dieser Delegate-Typ zeigen kann
        public delegate void MethodeMitStringParameterOhneRückgabewert(string p);
        public delegate int MethodeMitZweiIntegernUndIntAlsRückgabewert(int i, int i2);

        static void Main(string[] args)
        {
            MacheWas("Hallo");

            MethodeMitStringParameterOhneRückgabewert methodenZeiger = MacheWas;

            methodenZeiger += MacheWasExt;

            methodenZeiger("Hallo");

            MethodeMitZweiIntegernUndIntAlsRückgabewert methodenZeiger2 = Berechne;

            int ergebnis = methodenZeiger2(20, 20);

            int erg2 = methodenZeiger2.Invoke(10, 10);

            Console.WriteLine(ergebnis);

            Console.ReadKey();
        }

        public static void MacheWas(string wort)
        {
            Console.WriteLine($"{wort} wurde übergeben");
        }

        public static void MacheWasExt(string wort)
        {
            Console.WriteLine("Mach was extended");
        }

        public static int Berechne(int z1, int z2)
        {
            return z1 + z2;
        }


        public static int Dummy(MethodeMitZweiIntegernUndIntAlsRückgabewert methode)
        {
            return methode(20, 50);
        }
    }
}
