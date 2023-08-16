namespace OnlineShop.DTO
{
    public class PorudzbinaArtikalDTO
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public ArtikalDTO Artikal { get; set; } = null!;
    }
}
