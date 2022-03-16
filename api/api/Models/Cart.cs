using System.Runtime.Serialization;

namespace api.Models
{
    [DataContract]
    public class Cart
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public int quantity { get; set; }
        [DataMember]
        public float price { get; set; }
        [DataMember]
        public Guid OrderId { get; set; }
        [DataMember]
        public Order Orders { get; set; }
    }
}