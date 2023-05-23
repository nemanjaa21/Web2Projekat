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
        private readonly IKorisnikRepository korisnikRepo;
        private readonly IConfiguration config;
       // private readonly MyMapper mapper;
        public KorisnikService(IMapper m, IKorisnikRepository repo, IConfiguration config)
        {
            this.imapper = m;
            this.korisnikRepo = repo;
            this.config = config;
        }

        public async Task<KorisnikDTO> GetUser(int token)
        {
            Korisnik k = await korisnikRepo.GetById(token);
            if(k == null)
            {
                return null;
            }
            return imapper.Map<Korisnik,KorisnikDTO>(k);
             
        }

        public Task<KorisnikDTO> Register(KorisnikDTO korisnik)
        {
            throw new NotImplementedException();
        }

        public Task<KorisnikDTO> Update(KorisnikDTO korisnik)
        {
            throw new NotImplementedException();
        }
    }
}
