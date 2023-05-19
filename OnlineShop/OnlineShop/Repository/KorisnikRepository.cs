using Microsoft.EntityFrameworkCore;
using OnlineShop.Common;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Data.Common;
using System.Linq;


namespace OnlineShop.Repository
{
    public class KorisnikRepository : IKorisnikRepository
    {
        private readonly DataContext dc;
        public KorisnikRepository(DataContext dataContext)
        {
            dc = dataContext;
        }

        public List<Korisnik> GetAllUsers()
        {
            List<Korisnik> korisnici = dc.Korisnici.ToList();
            return korisnici;
        }
        public Korisnik CreateUser(Korisnik korisnik)
        {
            try
            {
                dc.Korisnici.Add(korisnik);
                dc.SaveChanges();
                return korisnik;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Korisnik GetById(int id)
        {
            try
            {
                Korisnik k = dc.Korisnici.SingleOrDefault(k => k.IdKorisnika == id);
                return k;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Korisnik UpdateUser(Korisnik korisnik)
        {
            try
            {
                dc.Korisnici.Update(korisnik);
                dc.SaveChanges();
                return korisnik;
            }
            catch(DbException dbe)
            {
                return null;
            }
        }

        public Korisnik Verifikacija(int id, string status)
        {
            Korisnik k = dc.Korisnici.Find((int)id);
            k.Verifikovan = Enum.Parse<Verifikovan>(status);
            dc.SaveChanges();
            return k;
        }

        public void DeleteUser(int id)
        {
            try
            {
                Korisnik k = dc.Korisnici.SingleOrDefault(k => k.IdKorisnika == id);
                if (k != null /*&& k.TipKorisnika != TipKorisnika.Administrator*/)
                {
                    dc.Korisnici.Remove(k);
                    dc.SaveChanges();
                    
                }
                
            }
            catch (Exception e)
            {
               
            }


        }

    }
}
