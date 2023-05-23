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

        public async Task<List<Korisnik>> GetAllUsers()
        {
            List<Korisnik> korisnici = dc.Korisnici.ToList();
            return korisnici;
        }
        public async Task<Korisnik> CreateUser(Korisnik korisnik)
        {
            try
            {
                dc.Korisnici.Add(korisnik);
                await dc.SaveChangesAsync();
                return korisnik;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Korisnik> GetById(int id)
        {
            try
            {
                Korisnik? k = await dc.Korisnici.Include(k => k.Porudzbine).FirstOrDefaultAsync(k => k.IdKorisnika == id);
                return k;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Korisnik> UpdateUser(Korisnik korisnik)
        {
            try
            {
                dc.Korisnici.Update(korisnik);
                await dc.SaveChangesAsync();
                return korisnik;
            }
            catch(DbException dbe)
            {
                return null;
            }
        }

        public async Task<Korisnik> Verifikacija(int id, string status)
        {
            Korisnik? k = dc.Korisnici.Find(id);
            k.Verifikovan = Enum.Parse<Verifikovan>(status);
            await dc.SaveChangesAsync();
            return k;
        }

        //public void DeleteUser(int id)
        //{
        //    try
        //    {
        //        Korisnik k = dc.Korisnici.SingleOrDefault(k => k.IdKorisnika == id);
        //        if (k != null /*&& k.TipKorisnika != TipKorisnika.Administrator*/)
        //        {
        //            dc.Korisnici.Remove(k);
        //            dc.SaveChanges();
                    
        //        }
                
        //    }
        //    catch (Exception e)
        //    {
               
        //    }


        //}

    }
}
