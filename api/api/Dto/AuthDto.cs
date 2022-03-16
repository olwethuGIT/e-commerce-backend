using System.ComponentModel.DataAnnotations;

namespace api.Dto
{
    public class AuthDto
    {
        [Required(ErrorMessage = "Please provide a username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide a password")]
        public string Password { get; set; }
    }
}
