namespace OnlineShop.Models
{
    public class Artikal
    {
        public int IdArtikla { get; set; }
        public string NazivArtikla { get; set; }
        public int CenaArtikla { get; set; }
        public byte[] SlikaArtikla { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public List<PorudzbinaArtikal> PorudzbinaArtikli { get; set; }
        public Korisnik Korisnik { get; set; }
        public int IdKorisnika { get; set; }
        public bool Obrisan { get; set; }


    }
}
