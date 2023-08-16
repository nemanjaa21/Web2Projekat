using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Common;
using OnlineShop.DTO;
using OnlineShop.Mapper;
using OnlineShop.Models;
using Org.BouncyCastle.Crypto.Generators;
using System.Text;

namespace OnlineShop.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly IMapper imapper;
        private readonly IKorisnikRepository korisnikRepo;
        private readonly IConfiguration config;
        private readonly ISlanjeEmailaService email;
       // private readonly MyMapper mapper;
        public KorisnikService(IMapper m, IKorisnikRepository repo, IConfiguration config, ISlanjeEmailaService email)
        {
            this.imapper = m;
            this.korisnikRepo = repo;
            this.config = config;
            this.email = email;
        }

        public async Task<List<VerifikacijaKorisnikaDTO>> DobaviSveProdavce()
        {
            List<Korisnik> korisnici = await korisnikRepo.DobaviSveProdavce();
            if (korisnici == null)
                throw new Exception($"There are no users!");
            return imapper.Map<List<Korisnik>, List<VerifikacijaKorisnikaDTO>>(korisnici);
        }

        public async Task<List<KorisnikDTO>> GetAll()
        {
            List<Korisnik> korisnici = await korisnikRepo.GetAllUsers();
            if(korisnici is null)
                throw new Exception("Trenutno nema korisnika!");

            return imapper.Map<List<Korisnik>, List<KorisnikDTO>>(korisnici);
            
        }

        public async Task<KorisnikDTO> GetUser(int id)
        {
            Korisnik k = await korisnikRepo.GetById(id);
            if(k == null)
            {
                throw new Exception($"Korisnik sa ID: {id} ne postoji.");
            }
            return imapper.Map<Korisnik,KorisnikDTO>(k);
             
        }

        public async Task<KorisnikDTO> OdbijVerifikaciju(int id)
        {
            Korisnik u = await korisnikRepo.GetById(id);
            if (u == null)
                throw new Exception($"User with ID: {id} doesn't exist.");
            if (u.Verifikovan != Models.Verifikovan.UProcesu)
                throw new Exception($"Cant change verification anymore!");

            u = await korisnikRepo.OdbijVer(id);
            if (u != null)
            {
                email.EmailObavestenje(u.Email, u.Verifikovan.ToString());
            }
            return imapper.Map<Korisnik, KorisnikDTO>(u);
        }

        public async Task<KorisnikDTO> PrihvatiVerifikaciju(int id)
        {
            Korisnik u = await korisnikRepo.GetById(id);
            if (u == null)
                throw new Exception($"User with ID: {id} doesn't exist.");
            if (u.Verifikovan != Models.Verifikovan.UProcesu)
                throw new Exception($"Cant change verification anymore!");

            u = await korisnikRepo.PrihvatiVer(id);
            if (u != null)
            {
                await email.EmailObavestenje(u.Email, u.Verifikovan.ToString());
            }
            return imapper.Map<Korisnik, KorisnikDTO>(u);
        }

        public async Task<KorisnikDTO> Register(RegistracijaDTO registracija)
        {
            List<Korisnik> korisnici = await korisnikRepo.GetAllUsers();

            if (String.IsNullOrEmpty(registracija.Ime) || String.IsNullOrEmpty(registracija.Prezime)
                || String.IsNullOrEmpty(registracija.KorisnickoIme)
                || String.IsNullOrEmpty(registracija.Email)
                || String.IsNullOrEmpty(registracija.Adresa)
                || String.IsNullOrEmpty(registracija.Lozinka)
                || String.IsNullOrEmpty(registracija.PonovljenaLozinka)
                || String.IsNullOrEmpty(registracija.TipKorisnika.ToString()))
                throw new Exception("Morate popuniti sva polja za registraciju!");

            if (korisnici.Any(k => k.KorisnickoIme.Equals(registracija.KorisnickoIme)))
                throw new Exception("Korisnicko ime je vec u upotrebi!");

            if (korisnici.Any(k => k.Email.Equals(registracija.Email)))
                throw new Exception("Email je vec u upotrebi!");

            if (registracija.Lozinka != registracija.PonovljenaLozinka)
                throw new Exception("Lozinke se ne poklapaju! Unesite lozinke ponovo.");

            Korisnik k1 = imapper.Map<RegistracijaDTO, Korisnik>(registracija);

            if (registracija.SlikaKorisnika != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    registracija.SlikaKorisnika.CopyTo(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    k1.SlikaKorisnika = imageBytes;
                }
            }
            k1.Lozinka = BCrypt.Net.BCrypt.HashPassword(k1.Lozinka);
            k1.TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), registracija.TipKorisnika.ToUpper());

            if (k1.TipKorisnika == TipKorisnika.Prodavac)
                k1.Verifikovan = Verifikovan.UProcesu;
            else
                k1.Verifikovan = Verifikovan.Prihvacen;

            KorisnikDTO dto = imapper.Map<Korisnik, KorisnikDTO>(await korisnikRepo.CreateUser(k1));
            return dto;
        }
        

        public async Task<KorisnikDTO> Update(int id,IzmenaDTO izmena)
        {
            List<Korisnik> korisnici = await korisnikRepo.GetAllUsers();
            Korisnik k = await korisnikRepo.GetById(id);
            if (k == null)
                throw new Exception($"Korisnik sa ID: {id} ne postoji.");

            if (String.IsNullOrEmpty(izmena.Ime) || String.IsNullOrEmpty(izmena.Prezime) ||
                String.IsNullOrEmpty(izmena.KorisnickoIme) || String.IsNullOrEmpty(izmena.Email) ||
                String.IsNullOrEmpty(izmena.Adresa))
                throw new Exception("Morate popuniti sva polja za izmenu profila.");

            if (izmena.KorisnickoIme != k.KorisnickoIme)
                if (korisnici.Any(u => u.KorisnickoIme.Equals(izmena.KorisnickoIme)))
                    throw new Exception("Korisnicko ime je vec u upotrebi.");

            if (izmena.Email != k.Email)
                if (korisnici.Any(u => u.Email == izmena.Email))
                    throw new Exception("Email je vec u upotrebi.");

            if (!String.IsNullOrEmpty(izmena.Lozinka))
            {
                if (String.IsNullOrEmpty(izmena.StaraLozinka))
                    throw new Exception("Morate uneti staru lozinku.");

                if (!BCrypt.Net.BCrypt.Verify(izmena.StaraLozinka, k.Lozinka))
                    throw new Exception("Stara lozinka je netacna.");

                k.Lozinka = BCrypt.Net.BCrypt.HashPassword(izmena.Lozinka);

            }

            if (!String.IsNullOrEmpty(izmena.StaraLozinka))
            {
                if (String.IsNullOrEmpty(izmena.Lozinka))
                    throw new Exception("Morate uneti novu lozinku.");

                if (!BCrypt.Net.BCrypt.Verify(izmena.StaraLozinka, k.Lozinka))
                    throw new Exception("Stara lozinka je netacna.");

                k.Lozinka = BCrypt.Net.BCrypt.HashPassword(izmena.Lozinka);

            }

            if (String.IsNullOrEmpty(izmena.Lozinka) && String.IsNullOrEmpty(izmena.StaraLozinka))
                izmena.Lozinka = k.Lozinka;

            imapper.Map(izmena, k);

            k.SlikaKorisnika = izmena.SlikaKorisnika;
           // k.SlikaKorisnika = Encoding.ASCII.GetBytes(izmena.Slika);

            KorisnikDTO dto = imapper.Map<Korisnik, KorisnikDTO>(await korisnikRepo.UpdateUser(k));
            // dto.SlikaKorisnika = Encoding.Default.GetString(k.SlikaKorisnika); // ovde pravi problem null je
            dto.SlikaKorisnika = k.SlikaKorisnika;
            return dto;
        }

        
    }
}
