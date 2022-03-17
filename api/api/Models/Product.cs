using System.Runtime.Serialization;

namespace api.Models
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public ICollection<Review> Reviews { get; set;}
    }
}
