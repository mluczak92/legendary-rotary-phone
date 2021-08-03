using legendary_rotary_phone.domain.Orders;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(p => p.RowVersion)
                .IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }

        public async Task Save()
        {
           await SaveChangesAsync();
        }
    }
}
