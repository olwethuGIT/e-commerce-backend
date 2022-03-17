using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace api.Models
{
    [DataContract]
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public int Rate { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public User Users { get; set; }
        [DataMember]
        public Product Products { get; set; }
    }
}
