using OnlineShop.Models;
using System.Globalization;

namespace OnlineShop.Common
{
    public interface IKorisnikRepository
    {
        Korisnik GetById(int id);
        Korisnik CreateUser(Korisnik korisnik);
        List<Korisnik> GetAllUsers();
        Korisnik UpdateUser(Korisnik korisnik);
        Korisnik Verifikacija(int id, string status);
        void DeleteUser(int id);
    }
}
