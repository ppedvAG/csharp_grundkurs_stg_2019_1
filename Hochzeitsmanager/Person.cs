using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hochzeitsmanager
{
    public class Person : ICloneable
    {
        //Datentyp für eine Delegate-Variable
        public delegate void HochzeitsFailDelegate(Person p1, Person p2, string grund);

        //Events
        //event-Schlüsselwort kapselt die Delegate-Variable in einer Art Property
        public event HochzeitsFailDelegate HochzeitsFail;

        #region Definition von event
        //private HochzeitsFailDelegate _hochzeitsfail;
        //public HochzeitsFailDelegate MyProperty
        //{
        //    set {
        //        _hochzeitsfail += value;

        //    }
        //}
        #endregion


        private Person _verstecktePerson;
        public Person VerstecktePerson
        {
            get { return  (Person)_verstecktePerson.Clone(); }
            private set { _verstecktePerson = value; }
        }

        //Eigenschaften: prop
        public string Vorname { get; private set; }

        public static bool HomoEheErlaubt { get; set; } = false;

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

        //Getter-Property (nur lesbar, nicht setzbar)
        public int Alter
        {
            get
            {
                //Berechne das Alter auf Basis des Geburtsdatums und des heutigen Datums
                DateTime today = DateTime.Now;
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
        private HochzeitsFailDelegate _hochzeitsProperty;

        public Person Ehepartner
        {
            get { return _ehepartner; }
            private set
            {
                if (value == null)
                {
                    _ehepartner.Ehepartner = null;
                }
                else
                {
                    value._ehepartner = this;
                }
                _ehepartner = value;
                //Auch der Ehepartner muss mich als Ehepartner speichern
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

        /// <summary>
        /// Heirate eine andere Person, wenn Hochzeit legal ist
        /// </summary>
        /// <param name="zuHeiratendePerson">Die zu heiratende Person</param>
        /// <returns>War die Hochzeit erfolgreich?</returns>
        public bool Heirate(Person zuHeiratendePerson)
        {
            //Zu heiratende Person muss existieren
            if (zuHeiratendePerson == null)
            {
                //? prüft ob HochzeitsFail null ist. Nur wenn es ungleich null, wird die Methode nach
                //dem ? aufgerufen.
                HochzeitsFail?.Invoke(this, zuHeiratendePerson, "Zu heiratende Person muss existieren");
                return false;
            }

            //Beide müssen volljährig sein
            if (zuHeiratendePerson.Alter < 18 || Alter < 18)
            {
                HochzeitsFail?.Invoke(this, zuHeiratendePerson, "Beide müssen volljährig sein");
                return false;
            }

            //Nicht sich selbst heiraten
            if (zuHeiratendePerson == this)
            {
                HochzeitsFail?.Invoke(this, zuHeiratendePerson, "Nicht sich selbst heiraten");
                return false;
            }

            //Vielehe verhindern
            if (this.Ehepartner != null || zuHeiratendePerson.Ehepartner != null)
            {
                HochzeitsFail?.Invoke(this, zuHeiratendePerson, "Vielehe verhindern");
                return false;
            }

            //Gleichgeschlechtlichigkeit prüfen
            if (HomoEheErlaubt != true && this.Geschlecht == zuHeiratendePerson.Geschlecht)
            {
                HochzeitsFail?.Invoke(this, zuHeiratendePerson, "Homoehe nicht erlaubt!");
                return false;
            }


            //Hochzeit vollziehen
            this.Ehepartner = zuHeiratendePerson;
            return true;
        }

        public bool ScheideDich()
        {
            //kann geschieden werden?
            if (Ehepartner != null)
            {
                this.Ehepartner = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gibt die wichtigsten Informationen über das Objekt als String aus
        /// </summary>
        /// <returns>Beschreibung als Zeichenkette</returns>
        public override string ToString()
        {
            //Max Mustermann (30), männlich, verheiratet mit Anna Weber
            //Maria Bauer (15), weiblich, ledig

            string geschlecht = "weiblich";
            if (Geschlecht)
            {
                geschlecht = "männlich";
            }
            #region Kurzschreibweise für die if-Abfrage
            //string geschlecht = Geschlecht ? "weiblich" : "männlich"
            #endregion

            string verheiratet = ", ledig";
            if (Ehepartner != null)
            {
                verheiratet = $" verheiratet mit {Ehepartner.Name}";
            }

            return $"{Name} ({Alter}), {geschlecht}{verheiratet}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}