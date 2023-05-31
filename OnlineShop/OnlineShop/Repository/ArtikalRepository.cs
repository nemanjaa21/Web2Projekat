using Microsoft.EntityFrameworkCore;
using OnlineShop.Common;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Repository
{
    public class ArtikalRepository : IArtikalRepository
    {
        private readonly DataContext dc;
        public ArtikalRepository(DataContext dataContext)
        {
            dc = dataContext;
        }

        public async Task<Artikal> CreateArtical(Artikal a)
        {
            try
            {
                dc.Artikli.Add(a);
                await dc.SaveChangesAsync();
                return a;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteArtical(int id)
        {
            try
            {
                Artikal a = await dc.Artikli.FirstOrDefaultAsync(a => a.Id == id);
                if (a != null)
                {
                    //fizicko brisanje

                    dc.Artikli.Remove(a);
                    await dc.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Artikal>> GetAllArticals()
        {
            try
            {
                List<Artikal> artikli1 = await dc.Artikli.ToListAsync();
                List<Artikal> artikli2 = new List<Artikal>();
                foreach (Artikal item in artikli1)
                {
                    
                        artikli2.Add(item);
                    
                }
                
                return artikli2;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Artikal> GetArticalById(int id)
        {
            try
            {
                Artikal a = await dc.Artikli.FirstOrDefaultAsync(a => a.Id == id);
                if (a != null)
                {
                    return a;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Artikal> UpdateArtical(Artikal a)
        {
            try
            {
                dc.Artikli.Update(a);
                await dc.SaveChangesAsync();
                return a;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
