using System.ComponentModel.DataAnnotations;
using uMessageAPI.Models;

namespace uMessageAPI.DTOs.Account
{
    public class AccountDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public static AccountDTO FromUser(User model) {
            return new AccountDTO { UserName = model.UserName, Email = model.Email };
        }
    }
}