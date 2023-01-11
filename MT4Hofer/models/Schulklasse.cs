using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT4Hofer.models
{
    public class Schulklasse
    {
        public int Id { get; set; }
        public string Namen { get; set; }
        public DateTime ErstelltDatum { get; set; } = DateTime.Now;
        public virtual List<Schueler> SchuelerListe { get; set; } = new List<Schueler>();

    }
}
