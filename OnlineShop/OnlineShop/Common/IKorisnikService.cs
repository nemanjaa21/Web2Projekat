using Microsoft.IdentityModel.JsonWebTokens;
using OnlineShop.DTO;
using OnlineShop.Models;
using System.Data;

namespace OnlineShop.Common
{
    public interface IKorisnikService
    {
        Task<KorisnikDTO> Register(RegistracijaDTO registracija);
        Task<KorisnikDTO> Update(int id, IzmenaDTO izmena);
        Task<KorisnikDTO> GetUser(int id);
        Task<List<KorisnikDTO>> GetAll();
        Task<KorisnikDTO> PrihvatiVerifikaciju(int id);
        Task<KorisnikDTO> OdbijVerifikaciju(int id);
        Task<List<VerifikacijaKorisnikaDTO>> DobaviSveProdavce();
    }
}

