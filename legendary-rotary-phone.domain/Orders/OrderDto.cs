using System.ComponentModel.DataAnnotations;

namespace legendary_rotary_phone.domain.Orders
{
    public class OrderDto
    {
        [Required]
        [MaxLength(24)]
        public string Number { get; set; }

        [Required]
        [MaxLength(256)]
        public string Additional { get; set; }
    }
}
