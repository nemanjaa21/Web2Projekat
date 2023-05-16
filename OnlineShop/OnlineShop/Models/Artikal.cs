namespace OnlineShop.Models
{
    public class Artikal
    {
        public int IDArtikla { get; set; }
        public string Naziv { get; set; }
        public int Cena { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public byte[] SlikaArtikla { get; set; }
        public Prodavac Prodavac { get; set; }
        public string KorisnickoImeProdavca { get; set; } 
        public List<PorudzbinaArtikal> PorudzbinaArtikli { get; set; }
        public bool Obrisan { get; set; }



    }
}
