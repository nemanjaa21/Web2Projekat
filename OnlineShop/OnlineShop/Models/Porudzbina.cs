using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Porudzbina
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje Adresa je obavezno.")]
        public string? Adresa { get; set; }

        public string? Komentar { get; set; }
        public DateTime VremePorudzbine { get; set; }
        public DateTime VremeDostave { get; set; }
        public double CenaPorudzbine { get; set; }
        public Status Status { get; set; }
        public List<PorudzbinaArtikal>? PorudzbinaArtikli { get; set; }
        public Korisnik? Korisnik { get; set; }
        public int IdKorisnika { get; set; }
        public double CenaDostave { get; } = 50;


    }
}
