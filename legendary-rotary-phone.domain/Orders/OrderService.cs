using AutoMapper;
using legendary_rotary_phone.infrastructure;
using legendary_rotary_phone.infrastructure.Orders;
using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public class OrderService : ABaseService, IOrderService
    {
        readonly IOrderRepository orderRepository;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
            : base(mapper, unitOfWork)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<OrderDto> PlaceOrder(OrderDto orderDto)
        {
            var added = orderRepository.Orders.Add(mapper.Map<Order>(orderDto));
            await unitOfWork.Save();
            return mapper.Map<OrderDto>(added.Entity);
        }
    }
}
