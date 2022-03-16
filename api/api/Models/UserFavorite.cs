using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace api.Models
{
    [DataContract]
    public class UserFavorite
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public bool IsFavorite { get; set; }
        [DataMember]
        public User Users { get; set; }
    }
}
