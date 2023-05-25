using OnlineShop.Models;

namespace OnlineShop.Common
{
    public interface IArtikalRepository
    {
        Task<Artikal> CreateArtical(Artikal a);
        Task<List<Artikal>> GetAllArticals();
        Task<Artikal> GetArticalById(int id);
        Task<Artikal> UpdateArtical(Artikal a);
        Task<bool> DeleteArtical(int id);
    }
}
