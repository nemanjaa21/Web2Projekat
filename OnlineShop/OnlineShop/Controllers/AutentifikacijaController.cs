using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;
using OnlineShop.DTO;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutentifikacijaController : ControllerBase
    {
        private readonly IAutentifikacijaService autentifikacijaSerivce;

        public AutentifikacijaController(IAutentifikacijaService autentifikacijaSerivce)
        {
            this.autentifikacijaSerivce = autentifikacijaSerivce;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LoginDTO login)
        {
            string token = await autentifikacijaSerivce.Login(login);
            if (token is null)
                return BadRequest();
            return Ok(token);
        }

        [HttpPost("google-login")]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleLogin([FromForm] string googleToken)
        {
            string token = await autentifikacijaSerivce.GoogleLogin(googleToken);
            return Ok(token);
        }
    }
}
