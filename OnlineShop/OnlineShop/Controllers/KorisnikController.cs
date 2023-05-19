using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;

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
        public IActionResult GetUser(int id) // posle neka bude token
        {
            return Ok(korisnikService.GetUser(id));
        }
    }
}
