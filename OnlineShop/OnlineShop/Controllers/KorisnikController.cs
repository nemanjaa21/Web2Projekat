using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;
using OnlineShop.DTO;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService korisnikService;

        public KorisnikController(IKorisnikService korisnikService)
        {
            this.korisnikService = korisnikService;
        }

        [Authorize]
        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetUser(int id) // posle neka bude token
        {
            KorisnikDTO k = await korisnikService.GetUser(id);
            if (k == null)
            {
                return BadRequest();
            }

            return Ok(k);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("registracija")]
        public async Task<IActionResult> Registracija([FromBody] RegistracijaDTO registracija)
        {
            KorisnikDTO k = await korisnikService.Register(registracija);
            if (k == null)
                return BadRequest();
            return Ok(k);
        }

        [HttpPut("Verifikacija/{id}/{secondParam}")]
        //[Authorize(Roles = "Administrator")]
        [AllowAnonymous] // obrisi posle
        public async Task<IActionResult> Verifikacija(int id,bool secondParam)
        {
            KorisnikDTO korisnik = await korisnikService.Verifikacija(id, Verifikovan.UProcesu);
            if (secondParam)
            {
                 korisnik = await korisnikService.Verifikacija(id, Verifikovan.Prihvacen);
            }
            else
            {
                 korisnik = await korisnikService.Verifikacija(id, Verifikovan.Odbijen);
            }
            if (korisnik is null)
                return BadRequest();
            return Ok(korisnik);
        }

        //[HttpPut]
        //[Authorize]
        //public async Task<IActionResult> Put(IzmenaDTO profile)
        //{
        //    int id = int.Parse(Korisnik.Claims.First(k => k.Type == "UserId").Value);
        //    KorisnikDTO korisnik = await korisnikService.Update(id, profile);
        //    if (korisnik is null)
        //        return BadRequest();
        //    return Ok(korisnik);
        //}

    }
}
