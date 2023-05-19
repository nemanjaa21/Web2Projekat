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
        public Porudzbina CreatePorudzbina(Porudzbina poruzbina)
        {
            try
            {
                dc.Porudzbine.Add(poruzbina);
                dc.SaveChanges();
                return poruzbina;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Porudzbina> GetAll()
        {
            return dc.Porudzbine.ToList();
        }

        public Porudzbina GetPorudzbinaById(int id)
        {
            try
            {
                Porudzbina p =  dc.Porudzbine.SingleOrDefault(p => p.IdPorudzbine == id);
                dc.SaveChanges();
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
