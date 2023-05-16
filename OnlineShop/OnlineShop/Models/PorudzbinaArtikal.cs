namespace OnlineShop.Models
{
    public class PorudzbinaArtikal
    {
        public int IdPorudzbine { get; set; }
        public int IdArtikla { get; set; }
        public Porudzbina Porudzbina { get; set; }
        public Artikal Artikal { get; set; }
        public int KolicinaArtikla { get; set; }
        public int UkupnaCenaArtikala { get; set; }
    }
}
