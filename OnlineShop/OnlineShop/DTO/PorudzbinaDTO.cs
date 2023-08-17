namespace OnlineShop.DTO
{
    public class PorudzbinaDTO
    {
        public int Id { get; set; }
        public string? Komentar { get; set; }
        public string? Adresa { get; set; }
        public double Cena { get; set; }
        public DateTime VremePorudzbine { get; set; }
        public DateTime VremeDostave { get; set; }
        public string Status { get; set; }
        public List<PorudzbinaArtikalDTO>? PorudzbinaArtikli { get; set; }
        public int IdKorisnika { get; set; }
        public int CenaDostave { get; set; }
    }
}
