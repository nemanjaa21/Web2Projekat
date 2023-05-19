using OnlineShop.Models;

namespace OnlineShop.Common
{
    public interface IArtikalRepository
    {
        Artikal CreateArtical(Artikal a);
        List<Artikal> GetAllArticals();
        Artikal GetArticalById(int id);
        Artikal UpdateArtical(Artikal a);
        void DeleteArtical(int id);
    }
}
