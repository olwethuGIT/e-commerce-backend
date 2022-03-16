using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public float Amount { get; set; }
        public ICollection<Cart>? Products { get; set; }
        public string? CreatedAt { get; set; }
        public string? Username { get; set; }
        public User? User { get; set; }
    }
}
