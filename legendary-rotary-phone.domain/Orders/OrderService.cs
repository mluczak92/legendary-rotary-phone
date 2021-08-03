using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace legendary_rotary_phone.domain.Orders
{
    public class OrderService : ABaseService, IOrderService
    {
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {

        }

        public async Task<IEnumerable<IdentifiableOrderDto>> GetAll()
        {
            IEnumerable<Order> orders = await unitOfWork.Orders.Get();
            return mapper.Map<IEnumerable<IdentifiableOrderDto>>(orders);
        }

        public async Task<IdentifiableOrderDto> PlaceOrder(OrderDto orderDto)
        {
            Order order = mapper.Map<Order>(orderDto);
            unitOfWork.Orders.Add(order);
            await unitOfWork.Save();
            return mapper.Map<IdentifiableOrderDto>(order);
        }
    }
}
