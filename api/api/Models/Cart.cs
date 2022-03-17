using System.Runtime.Serialization;

namespace api.Models
{
    [DataContract]
    public class Cart
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public Guid OrderId { get; set; }
        [DataMember]
        public Order Orders { get; set; }
    }
}