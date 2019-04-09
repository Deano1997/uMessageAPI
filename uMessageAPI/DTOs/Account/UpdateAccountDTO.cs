using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.Account
{
    public class UpdateAccountDTO
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

    }
}