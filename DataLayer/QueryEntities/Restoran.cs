using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.QueryEntities
{
    public class Restoran
    {
        public Guid RestoranId { get; set; }
        public String Adresa { get; set; }
        public String Email { get; set; }
        public String Grad { get; set; }
        public String Opstina { get; set; }
        public String Naziv { get; set; }

    }
}
