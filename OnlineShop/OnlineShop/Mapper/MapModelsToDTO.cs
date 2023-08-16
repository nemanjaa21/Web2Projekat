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
            CreateMap<Korisnik, VerifikacijaKorisnikaDTO>().ReverseMap();
            CreateMap<Artikal, ArtikalDTO>().ReverseMap();
            CreateMap<Artikal, KreiranjeArtiklaDTO>().ReverseMap();
            CreateMap<Artikal, IzmenaArtiklaDTO>().ReverseMap();
            CreateMap<Porudzbina,PorudzbinaDTO>().ReverseMap();
            CreateMap<Porudzbina, NapraviPorudzbinuDTO>().ReverseMap();
            CreateMap<PorudzbinaArtikal, PorudzbinaArtikalDTO>().ReverseMap();
            CreateMap<PorudzbinaArtikal, NapraviPorudzbinaArtikalDTO>().ReverseMap();

            //za slike
            CreateMap<IFormFile, byte[]>().ConvertUsing((file, _, context) => ConvertIFormFileToByteArray(file, context));
            CreateMap<byte[], IFormFile>().ConvertUsing((byteArray, _, context) => ConvertByteArrayToIFormFile(byteArray, context));


        }
        public byte[] ConvertIFormFileToByteArray(IFormFile file, ResolutionContext context)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public IFormFile ConvertByteArrayToIFormFile(byte[] byteArray, ResolutionContext context)
        {
            var memoryStream = new MemoryStream(byteArray);
            var formFile = new FormFile(memoryStream, 0, byteArray.Length, null, "file");

            return formFile;
        }


    }
}
