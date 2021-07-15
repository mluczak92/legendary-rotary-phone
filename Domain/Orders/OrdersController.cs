using Microsoft.AspNetCore.Mvc;

namespace legendary_rotary_phone.Domain.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(Order order)
        {
            return Ok(order);
        }
    }
}
