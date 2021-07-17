using AutoMapper;
using legendary_rotary_phone.infrastructure;
using legendary_rotary_phone.infrastructure.Orders;
using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public class OrderService : ABaseService, IOrderService
    {

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {

        }

        public async Task<OrderDto> PlaceOrder(OrderDto orderDto)
        {
            Order order = mapper.Map<Order>(orderDto);
            unitOfWork.Orders.Add(order);
            await unitOfWork.Save();
            return mapper.Map<OrderDto>(order);
        }
    }
}
