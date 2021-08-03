using System.Threading.Tasks;
using legendary_rotary_phone.domain.Orders;

namespace legendary_rotary_phone.domain
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        Task Save();
    }
}
