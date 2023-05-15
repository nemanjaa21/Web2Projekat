namespace OnlineShop.Models
{
    public class Prodavac : Korisnik
    {
        public List<Artikal> Artikli { get; set; }
        public Verifikovan Verifikovan { get; set; }
       

    }
}
