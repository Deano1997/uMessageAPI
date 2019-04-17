using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.Auth
{
    public class RequestTokenDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
