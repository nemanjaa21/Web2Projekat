namespace OnlineShop.Models
{
    public class Administrator : Korisnik
    {
        public List<Prodavac> Prodavci { get; set; }
        public List<Kupac> Kupci { get; set; }

    }
}
