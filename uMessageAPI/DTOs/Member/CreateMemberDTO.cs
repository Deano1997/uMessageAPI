
using System.ComponentModel.DataAnnotations;
using uMessageAPI.DTOs.User;
using uMessageAPI.Models;

namespace uMessageAPI.DTOs.Member {
    public class CreateMemberDTO {

        [Required]
        public MemberRole Role { get; set; }
        public CreateUserDTO User { get;set; }
    }
}
