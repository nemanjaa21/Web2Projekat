using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;
using System.Data;
using OnlineShop.DTO;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorudzbinaController : ControllerBase
    {
        IPorudzbinaService porudzbinaService;

        public PorudzbinaController(IPorudzbinaService porudzbinaService)
        {
            this.porudzbinaService = porudzbinaService;
        }

        [HttpPost("create-order")]
        [Authorize(Roles = "Kupac")]
        public async Task<IActionResult> CreateOrder(NapraviPorudzbinuDTO orderDto)
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            PorudzbinaDTO order = await porudzbinaService.Create(id, orderDto);
            if (order == null)
                return BadRequest();
            return Ok(order);
        }

        //GET api/order
        [HttpGet("get-all-orders")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllOrders()
        {
            List<PorudzbinaDTO> porudzbine = await porudzbinaService.DobaviSvePorudzbine();
            if (porudzbine == null)
                return BadRequest();
            return Ok(porudzbine);
        }

        //GET api/order
        [HttpGet("get-customer-delivered-orders")]
        [Authorize(Roles = "Kupac")]
        public async Task<IActionResult> GetCustomerDeliveredOrders()
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            List<PorudzbinaDTO> porudzbine = await porudzbinaService.DobaviSveIsporucenePorudzbine(id);
            if (porudzbine == null)
                return BadRequest();
            return Ok(porudzbine);
        }

        //GET api/order
        [HttpGet("get-salesman-delivered-orders")]
        [Authorize(Roles = "Prodavac", Policy = "VerifiedUserOnly")]
        public async Task<IActionResult> GetSalesmanDeliveredOrders()
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            List<PorudzbinaDTO> porudzbine = await porudzbinaService.DobaviSveIsporucenePorudzbine(id);
            if (porudzbine == null)
                return BadRequest();
            return Ok(porudzbine);
        }

        //GET api/order
        [HttpGet("get-customer-in-progress-orders")]
        [Authorize(Roles = "Kupac")]
        public async Task<IActionResult> GetCustomerInProgressOrders()
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            List<PorudzbinaDTO> porudzbine = await porudzbinaService.DobaviSvePorudzbineUToku(id);
            if (porudzbine == null)
                return BadRequest();
            return Ok(porudzbine);
        }

        //GET api/order
        [HttpGet("get-salesman-in-progress-orders")]
        [Authorize(Roles = "Prodavac", Policy = "VerifiedUserOnly")]
        public async Task<IActionResult> GetSalesmanInProgressOrders()
        {
            int id = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            List<PorudzbinaDTO> porudzbine = await porudzbinaService.DobaviSvePorudzbineUToku(id);
            if (porudzbine == null)
                return BadRequest();
            return Ok(porudzbine);
        }

        //GET api/order
        [HttpPut("deny-order/{id}")]
        [Authorize(Roles = "Kupac")]
        public async Task<IActionResult> DenyOrder(int id)
        {
            bool temp = await porudzbinaService.OdbijPorudzbinu(id);
            if (!temp)
                return BadRequest();
            return Ok();
        }
    }
}
