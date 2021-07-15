using System.ComponentModel.DataAnnotations;

namespace legendary_rotary_phone.Domain.Orders
{
    public class Order
    {
        [Required]
        public string Number { get; set; }

        [Required]
        public string Additional { get; set; }
    }
}
