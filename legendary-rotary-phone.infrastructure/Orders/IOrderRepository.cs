using Microsoft.EntityFrameworkCore;

namespace legendary_rotary_phone.infrastructure.Orders
{
    public interface IOrderRepository
    {
        DbSet<Order> Orders { get; }
    }
}
