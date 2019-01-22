using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ideen für Erweiterungen: 
            //Mehrere Spiele hintereinander
            //Doppelte Zahlen sicherer verhindern (hochzählen statt jedesmal neuen random.Next aufzurufen)
            //Richtig getippte Zahlen anzeigen

            const int anzahlZahlen = 6;
            const int limit = 49;

            int[] getipptenZahlen = new int[anzahlZahlen];
            int[] gezogenenZahlen = new int[anzahlZahlen];

            //1. Tippen der Zahlen
            #region Variante ohne for-Schleife
            //int i = 0;
            //while (i <  anzahlZahlen)
            //{
            //    getipptenZahlen[i] = int.Parse(Console.ReadLine());
            //    i++;
            //}
            #endregion

            //Zählschleife
            for (int i = 0; i < anzahlZahlen ; i++)
            {
                Console.Write($"Gebe die {i + 1}. Zahl ein: ");
                int test = int.Parse(Console.ReadLine());

                if (!getipptenZahlen.Contains(test))
                {
                    getipptenZahlen[i] = test;
                }
                else
                {
                    i--;
                }
            }

            //2. Ziehen der Zahlen
            Random random = new Random();

            for (int i = 0; i < anzahlZahlen; i++)
            {
                int test;
                do
                {
                    test = random.Next(1, limit + 1);
                } while (gezogenenZahlen.Contains(test));

                gezogenenZahlen[i] = test;
            }

            //3. Auswertung
            int treffer = 0;
            for (int i = 0; i < anzahlZahlen; i++)
            {
                if(getipptenZahlen.Contains(gezogenenZahlen[i]))
                {
                    treffer++;
                }
            }

            //Ausgabe: Du hast 6 Richtige!
            Console.WriteLine($"Du hast {treffer} Treffer!");
            Console.Write("Gezogene Zahlen: ");
            for (int i = 0; i < anzahlZahlen; i++)
            {
                Console.Write($"{gezogenenZahlen[i]}, ");
            }

            Console.ReadKey();
        }
    }
}
