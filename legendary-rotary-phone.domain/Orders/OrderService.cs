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

        public async Task<IEnumerable<OrderDtoIdentifiable>> GetAll()
        {
            IEnumerable<OrderModel> orders = await unitOfWork.Orders.Get();
            return mapper.Map<IEnumerable<OrderDtoIdentifiable>>(orders);
        }

        public async Task<OrderDtoIdentifiable> PlaceOrder(OrderDtoNew orderDto)
        {
            OrderModel order = mapper.Map<OrderModel>(orderDto);
            unitOfWork.Orders.Add(order);
            await unitOfWork.Save();
            return mapper.Map<OrderDtoIdentifiable>(order);
        }

        public async Task<OrderDtoIdentifiable> Update(int id, OrderDtoUpdate order)
        {
            OrderModel details = await unitOfWork.Orders.Details(id);
            if (details == null)
            {
                throw new RotaryNotFoundException<OrderModel>(id);
            }

            mapper.Map(order, details);
            await unitOfWork.Save();
            return mapper.Map<OrderDtoIdentifiable>(details);
        }
    }
}
