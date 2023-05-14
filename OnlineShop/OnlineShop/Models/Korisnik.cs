namespace OnlineShop.Models
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string ImeIPrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public Enumeracije TipKorisnika { get; set; }
        public byte[] SlikaKorisnika { get; set; }
        public string Status { get; set; }
        public List<Porudzbina> Porudzbine { get; set; }

    }
}
