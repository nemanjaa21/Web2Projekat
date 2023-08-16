using OnlineShop.Models;
using System.Globalization;

namespace OnlineShop.Common
{
    public interface IKorisnikRepository
    {
        Task<Korisnik> GetById(int id);
        Task<Korisnik> CreateUser(Korisnik korisnik);
        Task<List<Korisnik>> GetAllUsers();
        Task<List<Korisnik>> DobaviSveProdavce();
        Task<Korisnik> UpdateUser(Korisnik korisnik);
        Task<Korisnik> PrihvatiVer(int id);
        Task<Korisnik> OdbijVer(int id);


    }
}
