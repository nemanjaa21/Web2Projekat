using OnlineShop.DTO;

namespace OnlineShop.Common
{
    public interface IKorisnikService
    {
        KorisnikDTO Register(KorisnikDTO korisnik);
        KorisnikDTO Update(KorisnikDTO korisnik);
        KorisnikDTO GetUser(int id); // izmeni preko tokena posle
    }
}
