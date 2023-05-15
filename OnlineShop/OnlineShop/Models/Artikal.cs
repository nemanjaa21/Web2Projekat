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
        public string KorisnickoIme { get; set; } //strani kljuc
        public List<PorudzbinaArtikal> PorudzbinaArtikli { get; set; }


    }
}
