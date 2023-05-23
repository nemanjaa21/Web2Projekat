using Microsoft.IdentityModel.JsonWebTokens;
using OnlineShop.DTO;

namespace OnlineShop.Common
{
    public interface IKorisnikService
    {
        Task<KorisnikDTO> Register(KorisnikDTO korisnik);
        Task<KorisnikDTO> Update(KorisnikDTO korisnik);
        Task<KorisnikDTO> GetUser(int id); // izmeni preko tokena posle
    }
}
