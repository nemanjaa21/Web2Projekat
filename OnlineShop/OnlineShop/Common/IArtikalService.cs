using OnlineShop.DTO;

namespace OnlineShop.Common
{
    public interface IArtikalService
    {
        Task<ArtikalDTO> Create(int id, KreiranjeArtiklaDTO artikal);
        Task<List<ArtikalDTO>> GetAllArticals();
        Task<ArtikalDTO> GetArtikalBasedOnId(int ida);
        Task<List<ArtikalDTO>> MyArticals(int idk);
        Task<ArtikalDTO> Update(int idk, int ida, IzmenaArtiklaDTO artikal);
        Task<bool> Delete(int idk, int ida);
    }
}
