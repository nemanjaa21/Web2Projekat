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
        Task<KorisnikDTO> GetUser(int id); // izmeni preko tokena posle
        Task<List<KorisnikDTO>> GetAll();
        Task<KorisnikDTO> Verifikacija(int id, Verifikovan verifikovan);

    }
}
