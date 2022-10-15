using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WerBezahltWas
{
    public class Transaktion
    {
        public Person BezahltePerson { get; set; }
        public List<Person> BeguenstigstePersonen { get; set; }
        public float Betrag { get; set; }
        public List<float> Anteile { get; set; }
        // TODO : check if u need betrag for check or u did it somewhere else
        public Transaktion(Person bezahltePerson, List<Person> beguenstigstePersonen, List<float> anteile, float betrag)
        {
            BezahltePerson = bezahltePerson;
            BeguenstigstePersonen = beguenstigstePersonen;
            Betrag = betrag;
            Anteile = anteile;
        }
        public void Ausführen()
        {
            for(int i = 0; i < BeguenstigstePersonen.Count; i++)
            {
                Schuld schuld = new Schuld(BezahltePerson, BeguenstigstePersonen[i], Anteile[i]);
                BezahltePerson.Forderungen.Add(schuld);
                BeguenstigstePersonen[i].Schulden.Add(schuld);
            }
        }
    }
}