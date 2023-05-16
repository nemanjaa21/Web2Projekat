namespace OnlineShop.Models
{
    public class Porudzbina
    {
        public int Id { get; set; }
        public string Komentar { get; set; }
        public string Adresa { get; set; }
        public DateTime VremePorudzbine { get; set; }
        public DateTime VremeDostave { get; set; }
        public string Status { get; set; }
        public Kupac Kupac { get; set; }
        public string KorisnickoImeKupca { get; set; }
        public List<PorudzbinaArtikal> PorudzbinaArtikli { get; set; }
        public double CenaDostave { get; } = 50;
    }
}
