namespace legendary_rotary_phone.domain.Orders
{
    public class OrderModel
    {
        public int Id { get; set; }
        public ulong RowVersion { get; set; }
        public string Number { get; set; }
        public string Additional { get; set; }
        public OrderState State { get; set; }
    }
}
