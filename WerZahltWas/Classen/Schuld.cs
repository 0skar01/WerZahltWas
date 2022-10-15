using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WerBezahltWas
{
    public class Schuld
    {
        public Person BezahltePerson { get; set; }
        public Person BeguenstigstePerson { get; set; }
        public float Betrag { get; set; }
        public Schuld(Person bezahltePerson, Person beguenstigstePerson, float betrag)
        {
            BezahltePerson = bezahltePerson;
            BeguenstigstePerson = beguenstigstePerson;
            Betrag = betrag;
        }
    }
}