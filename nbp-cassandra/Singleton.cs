using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.QueryEntities;

namespace NBP_Cassandra
{
    public enum Role
    {
        Admin,
        Korisnik,
        Restoran,
        NoRole
    }
    public class Singleton
    {
        private static Singleton instance = null;

        public static Singleton Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Singleton();
                    return instance;
                }
                return instance;
            }
        }
        private Singleton()
        {
            Role = Role.NoRole;
            Korisnik = null;
            Restoran = null;
        }

        public Korisnik Korisnik { get; set; }

        public Restoran Restoran { get; set; }

        public Role Role { get; set; }

        public FormLogin FormLogin { get; set; }

    }
}
