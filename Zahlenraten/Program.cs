using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahlenraten
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zufallsgenerator
            Random random = new Random();
            //generiere Zahl zwischen 1 und 10
            int zufallszahl = random.Next(1, 11);
            int gerateneZahl = 0;
            int versuche = 0;

            while (true)
            {
                gerateneZahl = int.Parse(Console.ReadLine());
                versuche++;
                if (zufallszahl == gerateneZahl)
                {
                    //Code wenn Bedingung wahr ist
                    Console.WriteLine("Glückwunsch, die Zahl war richtig!");
                    break;
                }
                else if (zufallszahl > gerateneZahl)
                {
                    //Code wenn Bedingung falsch ist
                    Console.WriteLine("Die Zahl war zu groß!");

                }
                else
                {
                    //Code wenn beide Bedingungen falsch waren
                    Console.WriteLine("Die Zahl war zu klein");
                }
               
            }

            do
            {
                Console.Write("Rate eine Zahl zwischen 1 und 10: ");
                gerateneZahl = int.Parse(Console.ReadLine());

                versuche++;

                if (zufallszahl == gerateneZahl)
                {
                    //Code wenn Bedingung wahr ist
                    Console.WriteLine("Glückwunsch, die Zahl war richtig!");
                }
                else if (zufallszahl > gerateneZahl)
                {
                    //Code wenn Bedingung falsch ist
                    Console.WriteLine("Die Zahl war zu groß!");
                }
                else
                {
                    //Code wenn beide Bedingungen falsch waren
                    Console.WriteLine("Die Zahl war zu klein");
                }
            } while (gerateneZahl != zufallszahl);


            while (gerateneZahl != zufallszahl)
            {
                Console.Write("Rate eine Zahl zwischen 1 und 10: ");
                gerateneZahl = int.Parse(Console.ReadLine());

                if (zufallszahl == gerateneZahl)
                {
                    //Code wenn Bedingung wahr ist
                    Console.WriteLine("Glückwunsch, die Zahl war richtig!");
                }
                else if (zufallszahl > gerateneZahl)
                {
                    //Code wenn Bedingung falsch ist
                    Console.WriteLine("Die Zahl war zu groß!");
                }
                else
                {
                    //Code wenn beide Bedingungen falsch waren
                    Console.WriteLine("Die Zahl war zu klein");
                }
            }

            Console.WriteLine($"Du hattest {versuche} gebraucht");

            //Anzahl der Versuche ausgeben

            Console.ReadKey();
        }
    }
}
