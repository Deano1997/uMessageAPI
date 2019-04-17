using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.User
{
    public class UpdateUserDTO
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

    }
}