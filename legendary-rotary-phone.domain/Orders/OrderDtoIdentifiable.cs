using AutoMapper;

namespace legendary_rotary_phone.domain.Orders
{
    public class OrderDtoIdentifiable : OrderDtoNew
    {
        public int Id { get; set; }
        public ulong RowVersion { get; set; }
        public int State { get; set; }
    }

    public class IdentifiableOrderDtoMappingProfile : Profile
    {
        public IdentifiableOrderDtoMappingProfile()
        {
            CreateMap<OrderModel, OrderDtoIdentifiable>();
        }
    }
}