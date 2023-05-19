using OnlineShop.DTO;
using OnlineShop.Models;
using AutoMapper;
namespace OnlineShop.Mapper
{
    public class MapModelsToDTO : Profile
    {
        public MapModelsToDTO()
        {
            CreateMap<Korisnik, KorisnikDTO>().ReverseMap(); //Kazemo mu da mapira Subject na SubjectDto i obrnuto
        }
        

    }
}
