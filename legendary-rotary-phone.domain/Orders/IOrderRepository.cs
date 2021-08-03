using System.Collections.Generic;
using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public interface IOrderRepository
    {
        void Add(OrderModel order);
        Task<IEnumerable<OrderModel>> Get();
        Task<OrderModel> Details(int id);
    }
}
