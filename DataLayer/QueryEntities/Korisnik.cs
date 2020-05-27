using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.QueryEntities
{
    public class Korisnik
    {
        public Guid UserId { get; set; }
        public String Ime { get; set; }    
        public String Prezime { get; set; }
        public String Email { get; set; }
        public String BrojTelefona { get; set; }

    }
}
