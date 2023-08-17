using OnlineShop.DTO;

namespace OnlineShop.Common
{
    public interface IPorudzbinaService
    {
        Task<List<PorudzbinaDTO>> DobaviSvePorudzbine();
        Task<List<PorudzbinaDTO>> DobaviSveIsporucenePorudzbine(int id);
        Task<List<PorudzbinaDTO>> DobaviSvePorudzbineUToku(int id);
        Task<PorudzbinaDTO> PorudzbinaPoId(int id);
        Task<PorudzbinaDTO> Create(int id, NapraviPorudzbinuDTO orderDto);
        Task<bool> OdbijPorudzbinu(int id);
    }
}
