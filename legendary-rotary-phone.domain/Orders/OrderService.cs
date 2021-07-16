using AutoMapper;
using legendary_rotary_phone.infrastructure;
using legendary_rotary_phone.infrastructure.Orders;
using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public class OrderService : IOrderService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IOrderRepository orderRepository;
        readonly IMapper mapper;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
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
