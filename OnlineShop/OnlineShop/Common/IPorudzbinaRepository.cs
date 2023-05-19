using OnlineShop.Models;

namespace OnlineShop.Common
{
    public interface IPorudzbinaRepository
    {
        Porudzbina CreatePorudzbina(Porudzbina poruzbina);
        List<Porudzbina> GetAll();
        Porudzbina GetPorudzbinaById(int id);
    }
}
