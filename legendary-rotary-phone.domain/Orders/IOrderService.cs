using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public interface IOrderService
    {
        public Task<OrderDto> PlaceOrder(OrderDto orderDto);
    }
}
