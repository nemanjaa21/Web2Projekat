namespace OnlineShop.Models
{
    public class Porudzbina
    {
        public int Id { get; set; }
        public Artikal Artikal { get; set; }
        public int Kolicina { get; set; }
        public string Komentar { get; set; }
        public string Adresa { get; set; }
        public DateTime VremePorudzbine { get; set; }
        public DateTime VremeDostave { get; set; }
        public string Status { get; set; }



    }
}
