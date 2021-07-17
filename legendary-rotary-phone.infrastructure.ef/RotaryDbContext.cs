using legendary_rotary_phone.infrastructure.Orders;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace legendary_rotary_phone.infrastructure.ef
{
    public class RotaryDbContext : DbContext
    {
        public RotaryDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public async Task Save()
        {
           await SaveChangesAsync();
        }
    }
}
