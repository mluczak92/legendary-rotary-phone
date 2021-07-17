using legendary_rotary_phone.infrastructure.Orders;
using System.Threading.Tasks;

namespace legendary_rotary_phone.infrastructure.ef
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly RotaryDbContext context;

        public UnitOfWork(RotaryDbContext context, IOrderRepository orderRepo)
        {
            this.context = context;
            Orders = orderRepo;
        }

        public IOrderRepository Orders { get; }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
