using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.User
{
    public class UpdateUserDTO
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}