using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.User
{
    public class DeleteUserDTO
    {
        
        [Required]
        public string Password { get; set; }

    }
}