using legendary_rotary_phone.domain;
using legendary_rotary_phone.domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace legendary_rotary_phone_api.Domain.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDtoNew order)
        {
            return Ok(await orderService.PlaceOrder(order));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await orderService.GetAll());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, OrderDtoUpdate order)
        {
            return Ok(await orderService.Update(id, order));
        }

        [HttpGet("failing/rotaryexc")] //test dzialania ExceptionFilter dla RotaryExc
        public IActionResult GetRotaryException()
        {
            throw new RotaryException("msg");
        }

        [HttpGet("failing/exc")] //test dzialania ExceptionFilter dla Exception
        public IActionResult GetSystemException()
        {
            throw new Exception("exception message");
        }
    }
}
