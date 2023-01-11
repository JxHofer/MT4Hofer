using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT4Hofer.models
{
   public class Klassenbucheintrag
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Datum { get; set; } = DateTime.Today;
        public int SchuelerId { get; set; }
        public virtual Schueler Schueler { get; set; }
    }
}
