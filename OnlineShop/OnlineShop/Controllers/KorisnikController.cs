using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;
using OnlineShop.DTO;

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

        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetUser(int id) // posle neka bude token
        {
            KorisnikDTO k = await korisnikService.GetUser(id);
            if(k == null)
            {
                return BadRequest();
            }

            return Ok(k);
        }
    }
}
