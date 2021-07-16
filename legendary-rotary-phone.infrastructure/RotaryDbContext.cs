using legendary_rotary_phone.infrastructure.Orders;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace legendary_rotary_phone.infrastructure
{
    public class RotaryDbContext : DbContext, IUnitOfWork, IOrderRepository
    {
        public DbSet<Order> Orders { get; set; }

        public async Task Save()
        {
           await SaveChangesAsync();
        }
    }
}
