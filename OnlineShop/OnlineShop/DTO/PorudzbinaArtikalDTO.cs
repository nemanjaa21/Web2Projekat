namespace OnlineShop.DTO
{
    public class PorudzbinaArtikalDTO
    {
        public int IdArtikla { get; set; }
        public int KolicinaArtikla { get; set; }
        public ArtikalDTO Artikal { get; set; } = null!;
    }
}
