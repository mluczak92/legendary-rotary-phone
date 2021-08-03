using System.Collections.Generic;
using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Task<IEnumerable<Order>> Get();
    }
}
