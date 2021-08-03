using AutoMapper;

namespace legendary_rotary_phone.domain.Orders
{
    public class OrderDtoUpdate
    {
        public ulong RowVersion { get; set; }
        public int State { get; set; }
    }

    public class OrderDtoUpdateMappingProfile : Profile
    {
        public OrderDtoUpdateMappingProfile()
        {
            CreateMap<OrderDtoUpdate, OrderModel>();
        }
    }
}