using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT4Hofer.models
{
    public class Schueler
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int SchulklasseId { get; set; }
        public virtual Schulklasse Schulklasse { get; set; }
        public virtual List<Klassenbucheintrag> KlassenbucheintragListe { get; set; } = new List<Klassenbucheintrag>();
    }
}
