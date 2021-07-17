using legendary_rotary_phone.infrastructure.Orders;

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
    }
}
