namespace OnlineShop.Models
{
    public class Korisnik
    {
        public int IdKorisnika { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string ImeIPrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public byte[] SlikaKorisnika { get; set; }
        public List<Artikal> Artikli { get; set; }
        public Verifikovan Verifikovan { get; set; }
        public List<Porudzbina> Porudzbine { get; set; }




    }
}
