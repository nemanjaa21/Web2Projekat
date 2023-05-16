namespace OnlineShop.Models
{
    public class Prodavac : Korisnik
    {
        public List<Artikal> Artikli { get; set; }
        public Verifikovan Verifikovan { get; set; }
        public bool Status { get; set; }
        public Administrator Administrator { get; set; }
        public string ImeAdministratora { get; set; }
        public List<Porudzbina> Porudzbina { get; set; }



    }
}
