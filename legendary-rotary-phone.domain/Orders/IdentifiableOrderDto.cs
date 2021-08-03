using AutoMapper;

namespace legendary_rotary_phone.domain.Orders
{
    public class IdentifiableOrderDto : OrderDto
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
    }

    public class IdentifiableOrderDtoMappingProfile : Profile
    {
        public IdentifiableOrderDtoMappingProfile()
        {
            CreateMap<Order, IdentifiableOrderDto>();
        }
    }
}