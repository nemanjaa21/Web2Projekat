using OnlineShop.Models;
using System.Globalization;

namespace OnlineShop.Common
{
    public interface IKorisnikRepository
    {
        Task<Korisnik> GetById(int id);
        Task<Korisnik> CreateUser(Korisnik korisnik);
        Task<List<Korisnik>> GetAllUsers();
        Task<Korisnik> UpdateUser(Korisnik korisnik);
        Task<Korisnik> Verifikacija(int id, Verifikovan status);

       
    }
}
