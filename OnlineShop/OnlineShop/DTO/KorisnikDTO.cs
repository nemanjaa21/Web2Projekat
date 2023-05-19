using OnlineShop.Models;

namespace OnlineShop.DTO
{
    public class KorisnikDTO
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string ImeIPrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public byte[] Slika { get; set; }
        public Verifikovan Verifikovan { get; set; }
        public TipKorisnika Tip { get; set; }

        public List<PorudzbinaDTO> Porudzbine { get; set; }

        public KorisnikDTO()
        {
            
        }
        public KorisnikDTO(int id,string korisnickoIme, string email, string lozinka, string imeIPrezime, DateTime datumRodjenja, string adresa, byte[] slika)
        {
            this.Id = id;
            this.KorisnickoIme = korisnickoIme;
            this.Email = email;
            this.Lozinka = lozinka;
            this.ImeIPrezime = imeIPrezime;
            this.DatumRodjenja = datumRodjenja;
            this.Adresa = adresa;
            this.Slika = slika;
        }
    }
}
