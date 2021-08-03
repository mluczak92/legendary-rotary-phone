using System.Collections.Generic;
using System.Threading.Tasks;
using legendary_rotary_phone.domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace legendary_rotary_phone.infrastructure.ef.Orders
{
    public class OrderRepository : IOrderRepository
    {
        readonly RotaryDbContext context;

        public OrderRepository(RotaryDbContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await context.Orders.ToListAsync();
        }
    }
}
