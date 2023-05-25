using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Artikal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje NazivArtikla je obavezno.")]
        public string? NazivArtikla { get; set; }

        [Required(ErrorMessage = "Polje CenaArtikla je obavezno.")]
        public int CenaArtikla { get; set; }

        public byte[]? SlikaArtikla { get; set; }
        public int Kolicina { get; set; }
        public string? Opis { get; set; }
        public List<PorudzbinaArtikal>? PorudzbinaArtikli { get; set; }
        public Korisnik? Korisnik { get; set; }
        public int IdKorisnika { get; set; }
        public bool Obrisan { get; set; }


    }
}
