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
            dc.Porudzbine.Add(poruzbina);
            try
            {
                
                dc.SaveChanges();
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
                List<Porudzbina> porudzbine = dc.Porudzbine.Include(o => o.PorudzbinaArtikli).ThenInclude(op => op.Artikal).ToList();
                return porudzbine;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Porudzbina> GetPorudzbinaById(int id)
        {
            try
            {
                Porudzbina porudzbina = dc.Porudzbine.Include(o => o.PorudzbinaArtikli).Where(o => o.Id == id).FirstOrDefault();
                return porudzbina;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SaveChanges()
        {
            dc.SaveChanges();
        }
    }
}
