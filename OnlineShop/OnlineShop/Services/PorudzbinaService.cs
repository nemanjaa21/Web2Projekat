using AutoMapper;
using OnlineShop.Common;
using OnlineShop.DTO;
using OnlineShop.Models;

namespace OnlineShop.Services
{
    
    public class PorudzbinaService : IPorudzbinaService
    {
        private readonly IPorudzbinaRepository porudzbinaRepo;
        private readonly IMapper imapper;
        private readonly IConfiguration config;
        private readonly IKorisnikRepository korisnikRepo;
        private readonly IArtikalRepository artikalRepo;

        public PorudzbinaService(IPorudzbinaRepository porudzbinaRepo, IMapper imapper, IConfiguration config, IKorisnikRepository korisnikRepo, IArtikalRepository artikalRepo)
        {
            this.porudzbinaRepo = porudzbinaRepo;
            this.artikalRepo = artikalRepo;
            this.config = config;
            this.imapper = imapper;
            this.korisnikRepo = korisnikRepo;
        }

        public async Task<PorudzbinaDTO> Create(int id, NapraviPorudzbinuDTO porudzbinaDto)
        {
            if (String.IsNullOrEmpty(porudzbinaDto.Adresa))
                throw new Exception($"Morate uneti adresu.");

            Porudzbina novaPorudzbina = imapper.Map<NapraviPorudzbinuDTO, Porudzbina>(porudzbinaDto);
            novaPorudzbina.IdKorisnika = id;
            novaPorudzbina.VremePorudzbine = DateTime.Now;
            novaPorudzbina.VremeDostave = DateTime.Now.AddHours(1).AddMinutes(new Random().Next(60));
            novaPorudzbina.CenaDostave = 200;
            novaPorudzbina.Status = Status.UToku;

            foreach (PorudzbinaArtikal op in novaPorudzbina.PorudzbinaArtikli)
            {
                Artikal a = await artikalRepo.GetArticalById(op.IdArtikla);

                if (op.KolicinaArtikla > a.Kolicina)
                    throw new Exception("Nema dovoljno proizvoda na stanju.");

                op.IdArtikla = a.Id;
                a.Kolicina -= op.KolicinaArtikla;
                novaPorudzbina.CenaPorudzbine += op.KolicinaArtikla * a.CenaArtikla;

            }
            //PROBLEMMMMMMMMMMMMMMM
            PorudzbinaDTO dto = imapper.Map<Porudzbina, PorudzbinaDTO>(await porudzbinaRepo.CreatePorudzbina(novaPorudzbina));
            return dto;
        }

        public async Task<List<PorudzbinaDTO>> DobaviSveIsporucenePorudzbine(int id)
        {
            Korisnik k = await korisnikRepo.GetById(id);
            if (k == null)
                throw new Exception($"Korisnik sa ID: {id} ne postoji.");

            List<Porudzbina> svePorudzbine = await porudzbinaRepo.GetAll();
            svePorudzbine = svePorudzbine.Where(o => o.Status == Status.Isporucena).ToList();
            if (svePorudzbine == null)
                throw new Exception($"Nema porudzbina.");

            if (k.TipKorisnika == TipKorisnika.Kupac)
            {
                List<Porudzbina> porudzbineKupca = new List<Porudzbina>();
                porudzbineKupca = svePorudzbine.Where(o => o.IdKorisnika == k.Id).ToList();
                return imapper.Map<List<Porudzbina>, List<PorudzbinaDTO>>(porudzbineKupca);
            }
            else if (k.TipKorisnika == TipKorisnika.Prodavac)
            {
                List<Porudzbina> porudzbineProdavca = new List<Porudzbina>();
                List<Artikal> artikli = await artikalRepo.GetAllArticals();
                artikli = artikli.Where(p => p.IdKorisnika == k.Id).ToList();

                foreach (Porudzbina o in svePorudzbine)
                {
                    foreach (PorudzbinaArtikal op in o.PorudzbinaArtikli)
                    {
                        foreach (Artikal p in artikli)
                        {
                            if (p.Id == op.IdArtikla)
                                porudzbineProdavca.Add(o);
                        }
                    }
                }
                return imapper.Map<List<Porudzbina>, List<PorudzbinaDTO>>(porudzbineProdavca);
            }
            return null;
        }

        public async Task<List<PorudzbinaDTO>> DobaviSvePorudzbine()
        {
            List<Porudzbina> sve = await porudzbinaRepo.GetAll();
            return imapper.Map<List<Porudzbina>, List<PorudzbinaDTO>>(sve);
        }

        public async Task<List<PorudzbinaDTO>> DobaviSvePorudzbineUToku(int id)
        {
            Korisnik k = await korisnikRepo.GetById(id);
            if (k == null)
                throw new Exception($"Korisnik sa ID: {id} ne postoji.");

            List<Porudzbina> svePorudzbine = await porudzbinaRepo.GetAll();
            svePorudzbine = svePorudzbine.Where(o => o.Status == Status.UToku).ToList();
            if (svePorudzbine == null)
                throw new Exception($"Nema porudzbina.");

            if (k.TipKorisnika == TipKorisnika.Kupac)
            {
                List<Porudzbina> porudzbineKupca = new List<Porudzbina>();
                porudzbineKupca = svePorudzbine.Where(o => o.IdKorisnika == k.Id).ToList();
                return imapper.Map<List<Porudzbina>, List<PorudzbinaDTO>>(porudzbineKupca);
            }
            else if (k.TipKorisnika == TipKorisnika.Prodavac)
            {
                List<Porudzbina> porudzbineProdavca = new List<Porudzbina>();
                List<Artikal> artikli = await artikalRepo.GetAllArticals();
                artikli = artikli.Where(p => p.IdKorisnika == k.Id).ToList();

                foreach (Porudzbina o in svePorudzbine)
                {
                    foreach (PorudzbinaArtikal op in o.PorudzbinaArtikli)
                    {
                        foreach (Artikal p in artikli)
                        {
                            if (p.Id == op.IdArtikla)
                                porudzbineProdavca.Add(o);
                        }
                    }
                }
                return imapper.Map<List<Porudzbina>, List<PorudzbinaDTO>>(porudzbineProdavca);
            }
            return null;
        }

        public async Task<bool> OdbijPorudzbinu(int id)
        {
            Porudzbina p = await porudzbinaRepo.GetPorudzbinaById(id);
            if (p == null)
                throw new Exception($"Porudzbina sa ID: {id} ne postoji.");
            p.Status = Status.Odbijena;
            List<Artikal> artikli = await artikalRepo.GetAllArticals();
            foreach (PorudzbinaArtikal op in p.PorudzbinaArtikli)
            {
                foreach (Artikal a in artikli)
                {
                    if (a.Id == op.IdArtikla)
                    {
                        a.Kolicina += op.KolicinaArtikla;
                    }
                }
            }
            porudzbinaRepo.SaveChanges();
            return true;
        }

        public async Task<PorudzbinaDTO> PorudzbinaPoId(int id)
        {
            Porudzbina p = await porudzbinaRepo.GetPorudzbinaById(id);
            if (p == null)
                throw new Exception($"Porudzbina sa ID: {id} ne postoji.");
            return imapper.Map<Porudzbina, PorudzbinaDTO>(p);
        }
    }
}
