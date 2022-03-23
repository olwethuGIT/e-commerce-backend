using api.Models;
using System.Runtime.Serialization;

namespace api.Dto
{
    [DataContract]
    public class ProductListDto
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
        public ICollection<Photo> Photos { get; set; }
        [DataMember]
        public bool IsFavorite { get; set; }
        [DataMember]
        public ICollection<Review> Reviews { get; set; }
        [DataMember]
        public bool AllowReview { get; set; }
        [DataMember]
        public double Rating { get; set; }
    }
}
