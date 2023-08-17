using AutoMapper;
using OnlineShop.Common;
using OnlineShop.DTO;
using OnlineShop.Models;
using System.Text;

namespace OnlineShop.Services
{
    public class ArtikalService : IArtikalService
    {
        private readonly IArtikalRepository artikalRepo;
        private readonly IKorisnikRepository korisnikRepo;
        private readonly IMapper imapper;
        private readonly IConfiguration config;

        public ArtikalService(IArtikalRepository artikalRepo, IKorisnikRepository korisnikRepo, IMapper imapper, IConfiguration config)
        {
            this.artikalRepo = artikalRepo;
            this.korisnikRepo = korisnikRepo;
            this.imapper = imapper;
            this.config = config;
            
        }

        public async Task<ArtikalDTO> Create(int id, KreiranjeArtiklaDTO artikal)
        {
            if (String.IsNullOrEmpty(artikal.NazivArtikla) || String.IsNullOrEmpty(artikal.Kolicina.ToString()) ||
                String.IsNullOrEmpty(artikal.CenaArtikla.ToString()) || String.IsNullOrEmpty(artikal.Opis))
                throw new Exception($"Morate popuniti sva polja za artikal!");

            if (artikal.CenaArtikla < 1 || artikal.Kolicina < 1)
                throw new Exception($"Cena artikla i kolicina moraju biti pozitivne vrednosti!");

            List<Korisnik> korisnici = await korisnikRepo.GetAllUsers();
            Korisnik prodavac = korisnici.Where(s => s.Id == id).FirstOrDefault();

            if (prodavac is null)
                throw new Exception($"Prodavac sa ID-em: {id} ne postoji.");

            Artikal noviArtikal = imapper.Map<Artikal>(artikal);

            using (var memoryStream = new MemoryStream())
            {
                artikal.SlikaArtikla.CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();
                noviArtikal.SlikaArtikla = imageBytes;
            }

            noviArtikal.Obrisan = false;
            noviArtikal.Korisnik = prodavac;
            noviArtikal.IdKorisnika = id;

            ArtikalDTO dto = imapper.Map<Artikal, ArtikalDTO>(await artikalRepo.CreateArtical(noviArtikal));
            return dto;
        }

        public async Task<bool> Delete(int idk, int ida)
        {
            List<Artikal> artikli = await artikalRepo.GetAllArticals();
            artikli = artikli.Where(a => a.IdKorisnika == idk).ToList();
            Artikal a = artikli.Where(a => a.Id == ida).FirstOrDefault();
            if (a is null)
                throw new Exception($"Artikal sa ID-em: {ida} ne postoji.");

            return await artikalRepo.DeleteArtical(ida);
        }

        public async Task<List<ArtikalDTO>> GetAllArticals()
        {
            List<Artikal> products = await artikalRepo.GetAllArticals();
            products = products.Where(p => p.Obrisan == false).ToList();

            return imapper.Map<List<Artikal>, List<ArtikalDTO>>(products);

        }

        public async Task<ArtikalDTO> GetArtikalBasedOnId(int ida)
        {
            Artikal a = await artikalRepo.GetArticalById(ida);
            if (a is null)
                throw new Exception($"Artikal sa ID-em: {ida} ne postoji.");
            return imapper.Map<Artikal, ArtikalDTO>(a);
        }

        public async Task<List<ArtikalDTO>> MyArticals(int idk)
        {
            List<Artikal> artikli = await artikalRepo.GetAllArticals();
            artikli = artikli.Where(a => a.IdKorisnika == idk && a.Obrisan == false).ToList();
            if (artikli is null)
                throw new Exception($"Nema artikala u vasoj kolekciji.");
            List<ArtikalDTO> lista = imapper.Map<List<Artikal>, List<ArtikalDTO>>(artikli);
            return lista;
        }

        public async Task<ArtikalDTO> Update(int idk, int ida, IzmenaArtiklaDTO artikal)
        {
            Artikal a = await artikalRepo.GetArticalById(ida);
            if (a is null)
                throw new Exception($"Artikal sa ID-em: {ida} ne postoji.");

            if (a.IdKorisnika != idk)
                throw new Exception($"Ne mozete azurirati artikal kom niste vlasnik!");

            if (String.IsNullOrEmpty(artikal.NazivArtikla) || String.IsNullOrEmpty(artikal.Kolicina.ToString()) ||
                String.IsNullOrEmpty(artikal.CenaArtikla.ToString()) || String.IsNullOrEmpty(artikal.Opis))
                throw new Exception($"Morate popuniti sva polja za azuriranje artikla!");

            if (artikal.CenaArtikla < 1 || artikal.Kolicina < 1)
                throw new Exception($"Cena artikla i kolicina moraju biti pozitivne vrednosti!");

            imapper.Map(artikal, a);
            using (var memoryStream = new MemoryStream())
            {
                artikal.SlikaArtikla.CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();
                a.SlikaArtikla = imageBytes;
            }

            ArtikalDTO dto = imapper.Map<Artikal, ArtikalDTO>(await artikalRepo.UpdateArtical(a));
            return dto;
        }
    }
}
