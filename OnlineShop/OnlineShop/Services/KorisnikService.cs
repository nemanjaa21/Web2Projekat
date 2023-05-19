using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Common;
using OnlineShop.Data;
using OnlineShop.DTO;
using OnlineShop.Mapper;
using OnlineShop.Models;
using OnlineShop.Repository;
using System.Text;

namespace OnlineShop.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly IMapper imapper;
        private readonly KorisnikRepository korisnikRepo;
        private readonly DataContext dc;
        private readonly MyMapper mapper;
        public KorisnikService(IMapper m, DataContext dcc)
        {
            imapper = m;
            dc = dcc;
            mapper = new MyMapper();
            korisnikRepo = new KorisnikRepository(dcc);
        }

        public KorisnikDTO GetUser(int token)
        {
            Korisnik k = korisnikRepo.GetById(token);
            if(k == null)
            {
                return null;
            }
            KorisnikDTO kDTO = imapper.Map<KorisnikDTO>(k);
            return kDTO;
        }

        public KorisnikDTO Register(KorisnikDTO korisnik)
        {
            throw new NotImplementedException();
        }

        public KorisnikDTO Update(KorisnikDTO korisnik)
        {
            throw new NotImplementedException();
        }
    }
}
