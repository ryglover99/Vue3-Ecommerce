using glovers_backstore.Data.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using glovers_backstore.Interfaces;
using glovers_backstore.Business.Interfaces;
using glovers_backstore.Data.Enums;

namespace glovers_backstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService) 
        {
            _orderService = orderService;
        } 

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<Order> Get(int number)
        {
            return await _orderService.Get(number);
        }


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromBody] Order order)
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
