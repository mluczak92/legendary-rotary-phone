using System.Collections.Generic;
using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public interface IOrderService
    {
        Task<OrderDtoIdentifiable> PlaceOrder(OrderDtoNew orderDto);
        Task<IEnumerable<OrderDtoIdentifiable>> GetAll();
        Task<OrderDtoIdentifiable> Update(int id, OrderDtoUpdate orderDto);
    }
}
