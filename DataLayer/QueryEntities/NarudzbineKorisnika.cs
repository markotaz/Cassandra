using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.QueryEntities
{
    public class NarudzbineKorisnika
    {
        public Guid UserId { get; set; }
        public Guid NarudzbinaId { get; set; }
        public Guid RestoranId { get; set; }
        public DateTimeOffset Datum { get; set; }
        public String Adresa { get; set; }
        public String Iznos { get; set; }
        public List<String> ListaProizvoda { get; set; }
        public String StatusObrade { get; set; }
    }
}
