using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.User
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}