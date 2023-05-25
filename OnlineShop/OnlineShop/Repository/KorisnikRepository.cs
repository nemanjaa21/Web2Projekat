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
            try
            {
                List<Korisnik> korisnici = await dc.Korisnici.ToListAsync();
                return korisnici;
            }
            catch(Exception)
            {
                return null;
            }
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
                Korisnik? k = await dc.Korisnici.Include(k => k.Porudzbine).FirstOrDefaultAsync(k => k.Id == id);
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

        public async Task<Korisnik> Verifikacija(int id, Verifikovan status)
        {
            Korisnik? k = dc.Korisnici.Find(id);
            k.Verifikovan = status;
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
