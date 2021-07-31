using legendary_rotary_phone.infrastructure.Orders;
using System.Threading.Tasks;

namespace legendary_rotary_phone.infrastructure
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        Task Save();
    }
}
