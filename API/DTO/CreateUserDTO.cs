using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class CreateUserDTO
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        public string Password { get; set; }
    }
}
