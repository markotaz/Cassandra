using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.QueryEntities
{
    public class ProizvodiRestorana
    {
        public Guid RestoranId { get; set; }
        public Guid ProizvodId { get; set; }
        public String Tip { get; set; }
        public Int32 Cena { get; set; }
        public String Masa { get; set; }
        public String Naziv { get; set; }
        public String Opis { get; set; }
    }
}
