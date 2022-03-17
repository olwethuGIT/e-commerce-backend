using System.Runtime.Serialization;

namespace api.Dto
{
    [DataContract]
    public class ReviewDto
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public int Rate { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
    }
}
