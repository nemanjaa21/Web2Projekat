using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Common;
using OnlineShop.DTO;
using OnlineShop.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.Services
{
    public class AutentifikacijaService : IAutentifikacijaService
    {
        private readonly IMapper imapper;
        private readonly IKorisnikRepository korisnikRepo;
        private readonly IConfiguration config;


        public AutentifikacijaService(IMapper imapper, IKorisnikRepository korisnikRepo, IConfiguration config)
        {
            this.imapper = imapper;
            this.korisnikRepo = korisnikRepo;
            this.config = config;
        }

        public async Task<string> Login(LoginDTO login)
        {
            var korisnici = await korisnikRepo.GetAllUsers();
            Korisnik? k = korisnici.Where(ko => ko.Email == login.Email).FirstOrDefault();
            if (k == null)
            { 
                throw new Exception($"Korisnik sa {login.Email} ne postoji.");
            }
            if (!BCrypt.Net.BCrypt.Verify(login.Lozinka, k.Lozinka))
            {
                throw new Exception($"Lozinka je pogresna!");
            }
           

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", k.Id.ToString()),
                        new Claim("Email", k.Email),
                        new Claim(ClaimTypes.Role, k.TipKorisnika.ToString()),
                        new Claim("Verification", k.Verifikovan.ToString())


            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"] ?? "default"));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
