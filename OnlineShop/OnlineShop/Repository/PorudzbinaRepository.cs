using Microsoft.EntityFrameworkCore;
using OnlineShop.Common;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Repository
{
    public class PorudzbinaRepository : IPorudzbinaRepository
    {
        private readonly DataContext dc;
        public PorudzbinaRepository(DataContext dataContext)
        {
            dc = dataContext;
        }
        public async Task<Porudzbina> CreatePorudzbina(Porudzbina poruzbina)
        {
            try
            {
                dc.Porudzbine.Add(poruzbina);
                await dc.SaveChangesAsync();
                return poruzbina;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<List<Porudzbina>> GetAll()
        {
            try
            {
                List<Porudzbina> porudzbine = await dc.Porudzbine.ToListAsync();

                return porudzbine;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Porudzbina> GetPorudzbinaById(int id)
        {
            try
            {
                Porudzbina p = await dc.Porudzbine.FirstOrDefaultAsync(p => p.Id == id);
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task SaveChanges()
        {
            await dc.SaveChangesAsync();
        }
    }
}
