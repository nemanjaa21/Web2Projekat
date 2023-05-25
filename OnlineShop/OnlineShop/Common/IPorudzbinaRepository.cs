using OnlineShop.Models;

namespace OnlineShop.Common
{
    public interface IPorudzbinaRepository
    {
        Task<Porudzbina> CreatePorudzbina(Porudzbina poruzbina);
        Task<List<Porudzbina>> GetAll();
        Task<Porudzbina> GetPorudzbinaById(int id);
    }
}
