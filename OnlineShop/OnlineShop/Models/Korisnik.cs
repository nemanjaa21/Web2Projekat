using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Korisnik
    {
        public int Id { get; set; }

        public TipKorisnika TipKorisnika { get; set; }

        [Required(ErrorMessage = "Polje KorisnickoIme je obavezno.")]
        public string? KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Polje Email je obavezno.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Format polja Email nije validan.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Polje Lozinka je obavezno.")]
        public string? Lozinka { get; set; }

        [Required(ErrorMessage = "Polje Ime je obavezno.")]
        public string? Ime { get; set; }

        [Required(ErrorMessage = "Polje Prezime je obavezno.")]
        public string? Prezime { get; set; }

        [Required(ErrorMessage = "Polje DatumRodjenja je obavezno.")]
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }

        public string? Adresa { get; set; }

        public byte[]? SlikaKorisnika { get; set; }

        public List<Artikal>? Artikli { get; set; }

        public Verifikovan Verifikovan { get; set; }

        public List<Porudzbina>? Porudzbine { get; set; }




    }
}
