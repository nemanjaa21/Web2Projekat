using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;
using OnlineShop.DTO;
using System.Data;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtikalController : ControllerBase
    {
        private readonly IArtikalService artikalService;

        public ArtikalController(IArtikalService artikalService)
        {
            this.artikalService = artikalService;
        }

        //GET api/product
        [HttpGet("get-my-products")]
        [Authorize(Roles = "Prodavac", Policy = "VerifiedUserOnly")]
        public async Task<IActionResult> GetMyProducts()
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            List<ArtikalDTO> artikli = await artikalService.MyArticals(id);
            if (artikli == null)
                return BadRequest();
            return Ok(artikli);
        }

        //GET api/product
        [HttpGet("get-all-products")]
        [Authorize(Roles = "Kupac")]
        public async Task<IActionResult> GetAllProducts()
        {
            List<ArtikalDTO> artikli = await artikalService.GetAllArticals();
            if (artikli == null)
                return BadRequest();
            return Ok(artikli);
        }

        //GET api/product/id
        [HttpGet("{id}")]
        [Authorize(Roles = "Prodavac")]
        public async Task<IActionResult> Get(int id)
        {
            ArtikalDTO artikalDto = await artikalService.GetArtikalBasedOnId(id);
            if (artikalDto == null)
                return BadRequest();
            return Ok(artikalDto);
        }

        //POST api/product
        [HttpPost]
        [Authorize(Roles = "Prodavac", Policy = "VerifiedUserOnly")]
        public async Task<IActionResult> Post([FromForm] KreiranjeArtiklaDTO productDto)
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            ArtikalDTO artikalDto = await artikalService.Create(id, productDto);
            if (artikalDto == null)
                return BadRequest();
            return Ok(artikalDto);
        }

        //PUT api/product
        [HttpPut("{id}")]
        [Authorize(Roles = "Prodavac", Policy = "VerifiedUserOnly")]
        public async Task<IActionResult> Put(int id, [FromBody] IzmenaArtiklaDTO productDto)
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            ArtikalDTO artikalDto = await artikalService.Update(userId, id, productDto);
            if (artikalDto == null)
                return BadRequest();
            return Ok(artikalDto);
        }

        //DELETE api/product/id
        [HttpDelete("{id}")]
        [Authorize(Roles = "Prodavac", Policy = "VerifiedUserOnly")]
        public async Task<IActionResult> Delete(int id)
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            bool obrisan = await artikalService.Delete(userId, id);
            if (obrisan == false)
                return BadRequest();
            return Ok();
        }
    }
}
