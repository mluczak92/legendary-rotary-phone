using legendary_rotary_phone.architecture;
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
        public async Task<IActionResult> Create(OrderDto order)
        {
            return Ok(await orderService.PlaceOrder(order));
        }

        [HttpPost("failing/rotaryexc")]
        public IActionResult GetRotaryException()
        {
            throw new RotaryException("msg", "details");
        }

        [HttpPost("failing/exc")]
        public IActionResult GetSystemException()
        {
            throw new Exception("exception message");
        }
    }
}
