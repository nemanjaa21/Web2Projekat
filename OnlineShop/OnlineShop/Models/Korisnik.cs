namespace OnlineShop.Models
{
    public abstract class Korisnik
    {
        
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string ImeIPrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public byte[] SlikaKorisnika { get; set; }
       


    }
}
