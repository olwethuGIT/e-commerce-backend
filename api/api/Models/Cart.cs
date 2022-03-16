namespace api.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public string? title { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public Guid OrderId { get; set; }
        public Order? Orders { get; set; }
    }
}