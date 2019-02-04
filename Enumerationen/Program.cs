using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerationen
{
    class Program
    {
        public enum Rechenoperationen { Addition = '+', Subtraktion = '-', Division = '/', Multiplikation = '*' }

        static void Main(string[] args)
        { 

            Console.Write("Gib die 1. Zahl ein: ");
            double z1 = double.Parse(Console.ReadLine());
            Console.Write("Gib die 2. Zahl ein: ");
            double z2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Wähle deine Rechenoperation: ");

            char rechenSymbol = Console.ReadKey().KeyChar;

            string asds = rechenSymbol.ToString();

            //Casting
            Rechenoperationen operation = (Rechenoperationen)rechenSymbol;

            double ergebnis = Berechne(z1, z2, operation);
            Console.WriteLine($"Ergebnis: {ergebnis}");

            Console.BackgroundColor = ConsoleColor.Green;

            double ergebnisSub = Berechne(z1, z2, Rechenoperationen.Addition);

            double ergebnisDiv = Berechne(z1, z2, Rechenoperationen.Division);
 
            Console.WriteLine($"Ergebnis Division: {ergebnisDiv}");
            
            Console.ReadKey();
        }


        /// <summary>
        /// Berechnet 2 Zahlen
        /// </summary>
        /// <param name="z1">Zahl1</param>
        /// <param name="z2">Zahl2</param>
        /// <param name="operation"> Art der Operation</param>
        /// <returns>Ergebnis</returns>
        public static double Berechne(double z1, double z2, Rechenoperationen operation)
        {
            switch (operation)
            {
                case Rechenoperationen.Addition:
                    return z1 + z2;
                case Rechenoperationen.Subtraktion:
                    return z1 - z2;
                case Rechenoperationen.Division:
                    if (z2 != 0)
                    {
                        return z1 / z2;
                    }
                    throw new DivideByZeroException();
                case Rechenoperationen.Multiplikation:
                    return z1 * z2;
            }

            throw new Exception("Ungültige Operation");
        }
    }
}
