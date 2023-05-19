using OnlineShop.DTO;
using OnlineShop.Models;

namespace OnlineShop.Mapper
{
    public class MyMapper
    {
        
        public List<KorisnikDTO> MapirajKorisnikNaKorisnikDTO(List<Korisnik> korisnici)
        {
            List<KorisnikDTO> dtos = new List<KorisnikDTO>();

            foreach (Korisnik k in korisnici)
            {
                KorisnikDTO kDTO = new KorisnikDTO();
                kDTO.Id = k.IdKorisnika;
                kDTO.Verifikovan = k.Verifikovan;
                kDTO.KorisnickoIme = k.KorisnickoIme;
                kDTO.Email = k.Email;
                kDTO.Lozinka = k.Lozinka;
                kDTO.ImeIPrezime = k.ImeIPrezime;
                kDTO.DatumRodjenja = k.DatumRodjenja;
                kDTO.Adresa = k.Adresa;
                kDTO.Slika = k.SlikaKorisnika;
                kDTO.Tip = k.TipKorisnika;
                //dodaj jos za artikle i porudzbine
                dtos.Add(kDTO);
            }
            return dtos;
        }
    }
}
