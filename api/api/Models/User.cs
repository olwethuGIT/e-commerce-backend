using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace api.Models
{
    [DataContract]
    public class User
    {
        [Key]
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public byte[] PasswordHash { get; set; }
        [DataMember]
        public byte[] PasswordSalt { get; set; }
        [DataMember]
        public DateTime LastActive { get; set; }
        [DataMember]
        public ICollection<UserFavorite> Favorites { get; set; }
        [DataMember]
        public ICollection<Order> Orders { get; set; }
        [DataMember]
        public ICollection<Review> Reviews { get; set; }
    }
}
