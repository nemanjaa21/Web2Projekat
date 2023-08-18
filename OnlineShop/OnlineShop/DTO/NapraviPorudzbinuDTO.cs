namespace OnlineShop.DTO
{
    public class NapraviPorudzbinuDTO
    {
        public List<NapraviPorudzbinuArtikalDTO> PorudzbinaArtikli { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public string? Komentar { get; set; }
    }
}
