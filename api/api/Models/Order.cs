using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace api.Models
{
    [DataContract]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public ICollection<Cart> Products { get; set; }
        [DataMember]
        public string CreatedAt { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public User User { get; set; }
    }
}
