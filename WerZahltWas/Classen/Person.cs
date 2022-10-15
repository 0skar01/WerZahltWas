using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WerBezahltWas
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Schuld> Schulden { get; set; }
        public List<Schuld> Forderungen { get; set; }
        
    }
}