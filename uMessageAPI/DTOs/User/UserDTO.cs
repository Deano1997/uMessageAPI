using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.User
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public static UserDTO FromUser(uMessageAPI.Models.User model) {
            return new UserDTO { UserName = model.UserName, Email = model.Email };
        }
    }
}