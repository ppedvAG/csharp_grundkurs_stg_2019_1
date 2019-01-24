using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{

    //Versionsnummern: https://de.wikipedia.org/wiki/Versionsnummer
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            //Parsing: von string zu byte
            Console.Write("Alter: ");
            byte alter = byte.Parse(Console.ReadLine());

            //Snippets: cw
            Console.WriteLine("Willkommen " + name + " (" + alter + "), viel Erfolg mit C#");
            Console.WriteLine("Willkommen {0} ({1}), viel Erfolg mit C#", name, alter);
            //Interpolated Strings
            // '{' mit {{ escapen
            Console.WriteLine($"{{Willkommen {name} ({alter}),\n viel Erfolg mit C#}}");
            
            string message = $"{{ Willkommen { name } ({ alter }),\n viel Erfolg mit C#}}";
            //strg + Space: Zeige mir was jetzt sinvolles eingegeben werden könnte


            Console.ReadKey();
        }
    }
}
