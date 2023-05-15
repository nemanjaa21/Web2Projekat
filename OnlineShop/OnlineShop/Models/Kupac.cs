namespace OnlineShop.Models
{
    public class Kupac : Korisnik
    {
       
        public List<Porudzbina> Porudzbine { get; set; }
        public bool Status { get; set; }


    }
}
