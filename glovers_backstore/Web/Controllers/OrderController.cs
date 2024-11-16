using glovers_backstore.Data.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using glovers_backstore.Interfaces;
using glovers_backstore.Business.Interfaces;
using glovers_backstore.Data.Enums;
using glovers_backstore.Business.DTOs;

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
        public async Task<Order> Get(string number)
        {
            return await _orderService.Get(number);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromBody] OrderDTO order)
        {
            var result = await _orderService.Put(order);

            return result switch
            {
                TransactionStatus.Success => Ok(),
                _ => StatusCode(500),
            };
        }

    }
}
