using OnlineShop.DTO;
using OnlineShop.Models;
using AutoMapper;
using System.Text;

namespace OnlineShop.Mapper
{
    public class MapModelsToDTO : Profile
    {
        public MapModelsToDTO()
        {
            CreateMap<Korisnik, KorisnikDTO>().ReverseMap(); //Kazemo mu da mapira Subject na SubjectDto i obrnuto
            CreateMap<Korisnik, RegistracijaDTO>().ReverseMap();
            CreateMap<Korisnik, IzmenaDTO>().ReverseMap();
            CreateMap<Artikal, ArtikalDTO>().ReverseMap();
            CreateMap<Artikal, KreiranjeArtiklaDTO>().ReverseMap();
            CreateMap<Artikal, IzmenaArtiklaDTO>().ReverseMap();

        }
        

    }
}
