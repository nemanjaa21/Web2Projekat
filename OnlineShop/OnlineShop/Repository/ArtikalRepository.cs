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

        public Artikal CreateArtical(Artikal a)
        {
            try
            {
                dc.Artikli.Add(a);
                dc.SaveChanges();
                return a;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public void DeleteArtical(int id)
        {
            try
            {
                Artikal a = dc.Artikli.SingleOrDefault(a => a.IdArtikla == id);
                if (a != null)
                {
                    a.Obrisan = true; // logicko brisanje
                    dc.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public List<Artikal> GetAllArticals()
        {
            return dc.Artikli.ToList();
        }

        public Artikal GetArticalById(int id)
        {
            try
            {
                Artikal a = dc.Artikli.SingleOrDefault(a => a.IdArtikla == id);
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

        public Artikal UpdateArtical(Artikal a)
        {
            try
            {
                dc.Artikli.Update(a);
                dc.SaveChanges();
                return a;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
