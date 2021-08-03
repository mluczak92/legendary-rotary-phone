using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace legendary_rotary_phone.domain.Orders
{
    public class OrderDtoNew
    {
        [Required]
        [MaxLength(24)]
        public string Number { get; set; }

        [Required]
        [MaxLength(256)]
        public string Additional { get; set; }
    }

    public class OrderDtoNewMappingProfile : Profile
    {
        public OrderDtoNewMappingProfile()
        {
            CreateMap<OrderDtoNew, OrderModel>();
        }
    }
}
