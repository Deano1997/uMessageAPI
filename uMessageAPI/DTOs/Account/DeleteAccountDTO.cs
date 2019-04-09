using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.Account
{
    public class DeleteAccountDTO
    {
        
        [Required]
        public string Password { get; set; }

    }
}