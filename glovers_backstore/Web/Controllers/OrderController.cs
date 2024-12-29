using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using glovers_backstore.Business.Interfaces;
using glovers_backstore.Data.Enums;
using Microsoft.AspNetCore.Http.Extensions;
using glovers_backstore.Business.DTOs.Order;

namespace glovers_backstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get(string number)
        {

            if(string.IsNullOrEmpty(number)) return BadRequest();

            var result = await _orderService.Get(number);

            switch (result.Status)
            {
                case TransactionStatus.Success:
                    return Ok(result.Data);
                default: return Problem();
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] OrderRequestDTO order)
        {
            if (order == null) return BadRequest();

            var result = await _orderService.Create(order);

            switch (result.Status)
            {
                case TransactionStatus.Success:
                    return Created(Request.GetDisplayUrl(), result.Data);
                default: return Problem();
            }
        }

    }
}
