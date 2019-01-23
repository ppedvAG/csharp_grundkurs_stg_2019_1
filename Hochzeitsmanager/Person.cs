using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hochzeitsmanager
{
    class Person
    {


        //Eigenschaften: prop
        public string Vorname { get; private set; }

        //_ bedeutet: Klassenvaraible
        private string _nachname;

        public string Nachname
        {
            get { return _nachname; }
            set
            {
                //Leere Namen oder Namen die nur aus Leerzeichen bestehen nicht zulassen!
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Nachname darf nicht leer sein!");
                }

                //value steht für den Wert, der der Property Nachname zugewiesen wurde
                _nachname = value;
            }
        }

        //Getter-Property (nur lesbar, nicht setzbar)
        public string Name
        {
            //Strg+K+D: Dokument reformatieren
            get
            {
                return $"{Vorname} {Nachname}";
            }
        }

        public int Alter
        {
            get
            {
                DateTime today = DateTime.Now;
                //return today.Year - Geburtsdatum.Year;

                TimeSpan zeitraum = today - Geburtsdatum;
                return (int)(zeitraum.Days / 365.241);
            }
        }

        private DateTime _geburtsdatum;
        public DateTime Geburtsdatum
        {
            get
            {
                return _geburtsdatum;
            }
            private set
            {
                //Geburtsdatum darf nicht in der Zukunft liegen!
                if (value > DateTime.Now)
                {
                    throw new Exception("Das Geburtsdatum darf nicht in der Zukunft liegen!");
                }
                _geburtsdatum = value;
            }
        }


        private Person _ehepartner;
        public Person Ehepartner
        {
            get { return _ehepartner; }
            private set
            {
                _ehepartner = value;
                //Auch der Ehepartner muss mich als Ehepartner speichern
                value._ehepartner = this;
            }
        }

        /// <summary>
        /// true = Männlich, false = Weiblich
        /// </summary>
        public bool Geschlecht { get; private set; }

        //Konstruktor: Heißt genauso wie die Klasse und hat keine  Rückgabetypen.
        //Wird aufgerufen wenn die Klasse mit new instantiiert (initialisiert) wird
        public Person(string vorname, string nachname, DateTime gdatum, bool geschlecht)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geburtsdatum = gdatum;
            Geschlecht = geschlecht;
        }


        public bool Heirate(Person zuHeiratendePerson)
        {
            //Zu heiratende Person muss existieren
            if (zuHeiratendePerson == null)
                return false;

            //Beide müssen volljährig sein
            if (zuHeiratendePerson.Alter < 18 || Alter < 18)
                return false;

            //Nicht sich selbst heiraten
            if (zuHeiratendePerson == this)
                return false;

            //Vielehe verhindern
            if (this.Ehepartner != null || zuHeiratendePerson.Ehepartner != null)
                return false;

            //TODO: Gleichgeschlechtlichigkeit prüfen

            //Hochzeit vollziehen
            this.Ehepartner = zuHeiratendePerson;
            return true;
        }

        public override string ToString()
        {
            //Max Mustermann (22.2.1990), männlich

            //string geschlecht = Geschlecht ? "weiblich" : "männlich";


            string geschlecht = "weiblich";
            if (Geschlecht)
            {
                geschlecht = "männlich";
            }

            return $"{Name} ({Alter}), {geschlecht}";
        }
    }
}