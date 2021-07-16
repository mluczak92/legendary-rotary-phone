using legendary_rotary_phone.architecture;
using legendary_rotary_phone.domain.Orders;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(OrderDto order)
        {
            return Ok(orderService.PlaceOrder(order));
        }

        [HttpPost("failing")]
        public IActionResult Fail()
        {
            throw new RotaryException("msg", "details");
        }
    }
}
