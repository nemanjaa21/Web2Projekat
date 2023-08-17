using AutoMapper;
using Google.Apis.Auth;
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
        
        private readonly IKorisnikRepository korisnikRepo;
        private readonly IConfiguration config;
        private readonly IConfigurationSection googleId;



        public AutentifikacijaService( IKorisnikRepository korisnikRepo, IConfiguration config)
        {
            
            this.korisnikRepo = korisnikRepo;
            this.config = config;
            this.googleId = config.GetSection("GoogleClientId");
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
        public async Task<string> GoogleLogin(string token)
        {
            GoogleDTO externalUser = await VerifikacijaGoogleTokena(token);
            if (externalUser == null) { throw new Exception("Nije validan google token."); }

            List<Korisnik> users = await korisnikRepo.GetAllUsers();
            Korisnik user = users.Find(u => u.Email.Equals(externalUser.Email));

            if (user == null)
            {
                user = new Korisnik()
                {
                    Ime = externalUser.Ime,
                    Prezime = externalUser.Prezime,
                    KorisnickoIme = externalUser.KorisnickoIme,
                    Email = externalUser.Email,
                    SlikaKorisnika = new byte[0],
                    Lozinka = "",
                    Adresa = "",
                    DatumRodjenja = DateTime.Now,
                    TipKorisnika = TipKorisnika.Kupac,
                    Verifikovan = Verifikovan.Prihvacen
                };

                await korisnikRepo.CreateUser(user);
            }

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("Email", user.Email!),
                        new Claim(ClaimTypes.Role, user.TipKorisnika.ToString()),
                        new Claim("Verification", user.Verifikovan.ToString())

                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"] ?? "default"));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenString = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(tokenString);

        }

        private async Task<GoogleDTO> VerifikacijaGoogleTokena(string externalLoginToken)
        {
            try
            {
                var validationSettings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { googleId.Value }
                };

                var googleUserInfo = await GoogleJsonWebSignature.ValidateAsync(externalLoginToken, validationSettings);

                GoogleDTO externalUser = new GoogleDTO()
                {
                    KorisnickoIme = googleUserInfo.Email.Split("@")[0],
                    Ime = googleUserInfo.GivenName,
                    Prezime = googleUserInfo.FamilyName,
                    Email = googleUserInfo.Email
                };

                return externalUser;
            }
            catch
            {
                return null;
            }
        }
    }
}
