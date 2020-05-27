using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using DataLayer.QueryEntities;

namespace DataLayer
{
    public class DataProvider
    {
        #region Korisnik
        public static void CreateKorisnik(String ime, String prezime, String mail, String pass, String brtel)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;
            Guid userId = Guid.NewGuid();

            session.Execute("insert into korisnik (user_id,broj_telefona, email, ime, prezime) values" +
                " (" + userId + ",'" + brtel + "','" + mail + "','" + ime + "','" + prezime + "')");
            session.Execute("insert into korisnikpomailu (user_id, email, password) values (" + userId + ",'" + mail + "','" + pass + "')");

        }

        public static Korisnik GetKorisnik(Guid userId)
        {
            ISession session = SessionManager.GetSession();
            Korisnik user = new Korisnik();

            if (session == null)
                return null;

            Row userData = session.Execute("select * from korisnik where user_id = " + userId).FirstOrDefault();

            if (userData != null)
            {
                user.UserId = userId;
                user.Ime = userData["ime"] != null ? userData["ime"].ToString() : String.Empty;
                user.Prezime = userData["prezime"] != null ? userData["prezime"].ToString() : String.Empty;
                user.BrojTelefona = userData["broj_telefona"] != null ? userData["broj_telefona"].ToString() : String.Empty;
                user.Email = userData["email"] != null ? userData["email"].ToString() : String.Empty;
            }

            return user;
        }

        public static Korisnik GetKorisnikPoMailu(String email)
        {
            ISession session = SessionManager.GetSession();
            Korisnik user = new Korisnik();

            if (session == null)
                return null;

            Row userData = session.Execute("select * from korisnikpomailu where email = '" + email + "'").FirstOrDefault();
            if (userData == null)
                return null;
            else
                user = GetKorisnik(Guid.Parse(userData["user_id"].ToString()));
            return user;
        }
        public static String GetKorisnikPassword(String mail)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;

            Row userData = session.Execute("select * from korisnikpomailu where email='" + mail + "'").FirstOrDefault();
            if (userData == null) return null;

            return userData["password"].ToString();
        }

        public static void DeleteKorisnik(Guid userId)
        {
            ISession session = SessionManager.GetSession();
            Korisnik user = new Korisnik();

            if (session == null)
                return;

            Row email = session.Execute("select email from korisnik where user_id = " + userId).FirstOrDefault();
            RowSet userData = session.Execute("delete from korisnik where user_id = " + userId);
            userData = session.Execute("delete from korisnikpomailu where email = '" + email["email"] + "'");
        }

        public static void UpdateKorisnik(Guid userId, String brtel, String mail, String pass)
        {
            ISession session = SessionManager.GetSession();
            Korisnik user = new Korisnik();

            if (session == null)
                return;

            Row email = session.Execute("select email from korisnik where user_id = " + userId).FirstOrDefault();
            session.Execute("update korisnik set email='" + mail + "', broj_telefona = '" + brtel + "' where user_id=" + userId);
            RowSet emailDelete = session.Execute("delete from korisnikpomailu where email = '" + email["email"] + "'");
            session.Execute("insert into korisnikpomailu (user_id, email, password) values (" + userId + ", '" + mail + "','" + pass + "')");

        }

        #endregion

        #region Restoran
        public static void CreateRestoran(String adr, String mail, String grad, String opstina, String naziv, String pass)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;
            Guid restoranId = Guid.NewGuid();
            session.Execute("insert into restoran (restoran_id, adresa, email, grad, naziv, opstina) values ("
                + restoranId + ",'" + adr + "','" + mail + "','" + grad + "','" + naziv + "','" + opstina + "')");
            session.Execute("insert into restoranpomailu (restoran_id,email,password) values (" + restoranId + ",'" + mail + "','" + pass + "')");
        }

        public static Restoran GetRestoran(Guid restId)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return null;

            Restoran res = new Restoran();
            Row rest = session.Execute("select * from restoran where restoran_id=" + restId).FirstOrDefault();
            if (rest != null)
            {
                res.RestoranId = restId;
                res.Adresa = rest["adresa"] != null ? rest["adresa"].ToString() : String.Empty;
                res.Email = rest["email"] != null ? rest["email"].ToString() : String.Empty;
                res.Grad = rest["grad"] != null ? rest["grad"].ToString() : String.Empty;
                res.Naziv = rest["naziv"] != null ? rest["naziv"].ToString() : String.Empty;
                res.Opstina = rest["opstina"] != null ? rest["opstina"].ToString() : String.Empty;
            }
            return res;
        }

        public static Restoran GetRestoranPoMailu(String mail)
        {
            ISession session = SessionManager.GetSession();
            Restoran res = new Restoran();

            if (session == null)
                return null;

            Row resData = session.Execute("select * from restoranpomailu where email = '" + mail + "'").FirstOrDefault();
            if (resData == null)
                return null;
            else
                res = GetRestoran(Guid.Parse(resData["restoran_id"].ToString()));
            return res;
        }

        public static String GetRestoranPassword(String mail)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;

            Row resData = session.Execute("select * from restoranpomailu where email='" + mail + "'").FirstOrDefault();
            if (resData == null) return null;

            return resData["password"].ToString();
        }

        public static List<Restoran> GetSviRestorani()
        {
            ISession session = SessionManager.GetSession();
            List<Restoran> restorani = new List<Restoran>();

            if (session == null)
                return null;

            RowSet listaRestorana = session.Execute("select * from restoran");

            foreach(var res in listaRestorana)
            {
                Restoran rest = new Restoran();
                rest.RestoranId = res["restoran_id"] != null ? Guid.Parse(res["restoran_id"].ToString()) : Guid.Empty;
                rest = GetRestoran(rest.RestoranId);
                restorani.Add(rest);

            }

            return restorani;
        }
        public static void DeleteRestoran(Guid restId)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            Row mail = session.Execute("select email from restoran where restoran_id=" + restId).FirstOrDefault();
            RowSet deleteRest = session.Execute("delete from restoran where restoran_id=" + restId);
            RowSet deleteRestMail = session.Execute("delete from restoranpomailu where email='" + mail["email"]+"'");
        }
        public static void UpdateRestoran(Guid restId, String adr, String mail, String ime, String pass)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            Row email = session.Execute("select email from restoran where restoran_id=" + restId).FirstOrDefault();
            RowSet update = session.Execute("update restoran set adresa='" + adr + "', email='" + mail + "', naziv='" + ime + "' where restoran_id=" + restId);
            RowSet deletePoMailu = session.Execute("delete from restoranpomailu where email='" + email["email"] + "'");
            RowSet updatePoMailu = session.Execute("insert into restoranpomailu (restoran_id,email,password) values (" + restId + ",'" + mail + "','" + pass + "')");

        }
        #endregion

        #region Narudzbina
        public static void CreateNarudzbina(DateTimeOffset datum, String adresa,  List<String> listaProiz,  Guid userId, Guid restId)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;
            Guid narudzbinaId = Guid.NewGuid();
            String lista = "";
            int suma = 0;
            foreach (String pr in listaProiz)
                suma += GetCenuProizvoda(pr);

            lista += "['";
            for (int i = 0; i < listaProiz.Count; i++)
            {
                if (i < listaProiz.Count-1)
                    lista += listaProiz[i] + "','";
                else
                    lista += listaProiz[i] + "']";
            }
                
            session.Execute("insert into narudzbina (narudzbina_id, datum, adresa, iznos, lista_proizvoda, restoran_id, status_obrade, user_id) values ("
                    + narudzbinaId + ",toTimestamp(NOW()),'" + adresa + "','" + suma + "'," + lista + "," + restId + ",'Neobradjena'," + userId + ")");
            session.Execute("insert into narudzbinerestorana (restoran_id, datum, adresa, iznos, lista_proizvoda, narudzbina_id, status_obrade) values ("
                    + restId + ",toTimestamp(NOW()),'" + adresa + "','" + suma + "'," + lista + "," + narudzbinaId + ",'Neobradjena')");
            session.Execute("insert into narudzbinekorisnika (narudzbina_id, datum, adresa, iznos, lista_proizvoda, user_id, status_obrade, restoran_id) values ("
                     + narudzbinaId + ",toTimestamp(NOW()),'" + adresa + "','" + suma + "'," + lista + "," + userId + ",'Neobradjena'," + restId + ")");
            
        }

        public static List<Narudzbina> GetNarudzbineRestorana(Guid resId)
        {
            ISession session = SessionManager.GetSession();
            List<Narudzbina> narudzbine = new List<Narudzbina>();
            object pom = new object();
            if (session == null)
                return null;

            RowSet nars = session.Execute("select * from narudzbinerestorana where restoran_id=" + resId);

            foreach(var nar in nars)
            {
                Narudzbina n = new Narudzbina();
                pom = nar["lista_proizvoda"];
                n.NarudzbinaId = nar["narudzbina_id"] != null ? Guid.Parse(nar["narudzbina_id"].ToString()) : Guid.Empty;
                n.RestoranId = resId;
                n.Adresa = nar["adresa"] != null ? nar["adresa"].ToString() : String.Empty;
          //      n.ListaProizvoda = nar["lista_proizvoda"] != null ? pom.ToString() : null;
                n.StatusObrade = nar["status_obrade"] != null ? nar["status_obrade"].ToString() : String.Empty;
                n.Datum = DateTimeOffset.Parse(nar["datum"].ToString());
                narudzbine.Add(n);
            }
            return narudzbine;
        }

        public static List<Narudzbina> GetNarudzbineKorisnika(Guid userId)
        {
            ISession session = SessionManager.GetSession();
            List<Narudzbina> narudzbine = new List<Narudzbina>();
            object pom = new object();
            if (session == null)
                return null;

            RowSet nars = session.Execute("select * from narudzbinekorisnika where user_id=" + userId);

            foreach (Row nar in nars)
            {
                Narudzbina n = new Narudzbina();
                pom = nar["lista_proizvoda"];
                n.UserId = userId;
                n.NarudzbinaId = nar["narudzbina_id"] != null ? Guid.Parse(nar["narudzbina_id"].ToString()) : Guid.Empty;
                n.RestoranId = nar["restoran_id"] != null ? Guid.Parse(nar["restoran_id"].ToString()) : Guid.Empty;
                n.Adresa = nar["adresa"] != null ? nar["adresa"].ToString() : String.Empty;
                n.Iznos = nar["iznos"] != null ? nar["iznos"].ToString() : String.Empty;
                //      n.ListaProizvoda = nar["lista_proizvoda"] != null ? pom.ToString() : null;
                n.StatusObrade = nar["status_obrade"] != null ? nar["status_obrade"].ToString() : String.Empty;
                n.Datum = DateTimeOffset.Parse(nar["datum"].ToString());
                narudzbine.Add(n);
            }
            return narudzbine;
        }

        public static void ObradiNarudzbinu(String narId, Guid restId)
        {
            ISession session = SessionManager.GetSession();
            List<Narudzbina> narudzbine = new List<Narudzbina>();
            object pom = new object();
            if (session == null)
                return;

            DateTimeOffset date = new DateTimeOffset();
            RowSet narRest = session.Execute("select * from narudzbinerestorana where restoran_id=" + restId);
            foreach(Row nr in narRest)
            {
                if(nr["narudzbina_id"].ToString() == narId)
                    date = DateTimeOffset.Parse(nr["datum"].ToString());
            }

            Row nar = session.Execute("select * from narudzbina where narudzbina_id=" + narId).FirstOrDefault();
            TimeUuid tuid = TimeUuid.NewId(date);

            session.Execute("update narudzbina set status_obrade='Obradjena' where narudzbina_id=" + narId + " and datum = toTimestamp(" + tuid + ")"); //DateTimeOffset.Parse(nar["datum"].ToString()).DateTime.ToUniversalTime().ToString("yyyy-mm-dd HH:MM:ss.ffffff") + "+0000'");
            session.Execute("update narudzbinekorisnika set status_obrade ='Obradjena' where user_id="+ narId + " and datum = toTimestamp(" + tuid + ")");
            session.Execute("update narudzbinerestorana set status_obrade ='Obradjena' where restoran_id="+ narId + " and datum = toTimestamp(" + tuid + ")");
        }

        #endregion

        #region Proizvod
        public static void CreateProizvod(Guid restoranId, String tip, Int32 cena, String masa, String naziv,  String opis)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;
            Guid proizvodId = Guid.NewGuid();

            session.Execute("insert into proizvod (proizvod_id, tip, cena, masa, naziv, opis) values ("
                + proizvodId + ",'" + tip + "'," + cena + ",'" + masa + "','" + naziv + "','" + opis + "')");
            session.Execute("insert into proizvodirestorana (restoran_id, proizvod_id, tip, cena, masa, naziv, opis) values ("
                + restoranId + ","+proizvodId + ",'" + tip + "'," + cena + ",'" + masa + "','" + naziv + "','" + opis + "')");
            session.Execute("insert into proizvodpoimenu (naziv,proizvod_id) values ('" + naziv + "', " + proizvodId + ")");
        }
        public static void UpdateProizvod(Guid restoranId, String naziv, String masa, Int32 cena, String tip)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;
            Row prId = session.Execute("select * from proizvodpoimenu where naziv='" + naziv + "'").FirstOrDefault();
            session.Execute("update proizvod set masa='" + masa + "', cena=" + cena + " where proizvod_id=" + prId["proizvod_id"] + " AND naziv='"+naziv+"' AND tip='"+tip+ "'");
            session.Execute("update proizvodirestorana set masa='" + masa + "', cena=" + cena + " where restoran_id=" + restoranId + " AND naziv='" + naziv + "' AND tip='" + tip + "'");
        }
        public static void DeleteProizvod(Guid restoranId, String naziv)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return;

            Row prId = session.Execute("select * from proizvodpoimenu where naziv='" + naziv + "'").FirstOrDefault();
            Row tip = session.Execute("select * from proizvod where proizvod_id=" + prId["proizvod_id"]).FirstOrDefault();
            session.Execute("delete from proizvod where proizvod_id=" + prId["proizvod_id"]);
            session.Execute("delete from proizvodirestorana where restoran_id=" + restoranId + "AND naziv='"+naziv+"' AND tip='"+tip["tip"]+"'");
            session.Execute("delete from proizvodpoimenu where naziv='" + naziv + "'");
        }
        public static Int32 GetCenuProizvoda(String naziv)
        {
            ISession session = SessionManager.GetSession();
            if (session == null)
                return 0;

            Row prId = session.Execute("select * from proizvodpoimenu where naziv='" + naziv + "'").FirstOrDefault();
            Row cena = session.Execute("select * from proizvod where proizvod_id=" + prId["proizvod_id"]).FirstOrDefault();
            return Int32.Parse(cena["cena"].ToString());
        }
        #endregion
    }
}
