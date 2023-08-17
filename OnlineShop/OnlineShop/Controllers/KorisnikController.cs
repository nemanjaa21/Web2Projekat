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

        //GET api/user/GetAllUsers
        [HttpGet("get-all-users")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<KorisnikDTO> korisnici = await korisnikService.GetAll();
            if (korisnici == null)
                return BadRequest();
            return Ok(korisnici);
        }

        //GET api/user
        [Authorize]
        [HttpGet("get-my-profile")]
        public async Task<IActionResult> GetMyProfile()
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            KorisnikDTO k = await korisnikService.GetUser(id);
            if (k == null)
                return BadRequest();
            return Ok(k);
        }

        [HttpGet("get-all-salesmans")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllSalesmans()
        {
            List<VerifikacijaKorisnikaDTO> prodavci = await korisnikService.DobaviSveProdavce();
            if (prodavci == null)
                return BadRequest();
            return Ok(prodavci);
        }


        [HttpPost]
        [Consumes("multipart/form-data")] // jer ce forma da sadrzi fajl
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromForm] RegistracijaDTO registerDto)
        {
            KorisnikDTO user = await korisnikService.Register(registerDto);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }


        [HttpPut("accept-verification/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AcceptVerification(int id)
        {
            KorisnikDTO user = await korisnikService.PrihvatiVerifikaciju(id);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Put([FromForm] IzmenaDTO profileDto)
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            KorisnikDTO user = await korisnikService.Update(id, profileDto);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }

        [HttpPut("deny-verification/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DenyVerification(int id)
        {
            KorisnikDTO user = await korisnikService.OdbijVerifikaciju(id);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }


    }
}
