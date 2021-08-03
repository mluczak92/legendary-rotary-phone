using System.Collections.Generic;
using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public interface IOrderService
    {
        Task<IdentifiableOrderDto> PlaceOrder(OrderDto orderDto);
        Task<IEnumerable<IdentifiableOrderDto>> GetAll();
    }
}
