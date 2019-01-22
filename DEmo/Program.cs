using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEmo
{
    class Program
    {



        static void Main(string[] args)
        {
            //Instanz der Klasse Person anlegen
            Person v = new Person();
            //Eigenschaft name des Objektes v setzen
            v.name = "Volker";

            //2. Instanz der Klasse Person anlegen
            Person luise = new Person();

            //Instanz der Klasse Rechner anlegen
            Rechner dell = new Rechner();
            //Eigenschaft name des Objektes dell setzen
            dell.name = "Dell";


            //Instanz der Klasse Rechner anlegen
            Rechner hp = new Rechner();
            //Eigenschaft name des Objekts hp setzen
            hp.name = "HP";

            //die Rechner dell und hp dem Objekt v zuweisen
            v.meinRechner = new List<Rechner> { dell, hp };
            
            Console.ReadKey();
        }
    }

    public class Person
    {
        
        public string name;
        //jede Person kann beliebig viele Rechner haben
        public List<Rechner> meinRechner;

    }

    public class Rechner
    {
        public string name;
    }
}
