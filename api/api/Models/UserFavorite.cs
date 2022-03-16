using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class UserFavorite
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public int ProductId { get; set; }
        public bool IsFavorite { get; set; }
        public User? Users { get; set; }
    }
}
