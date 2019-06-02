using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models;

namespace uMessageAPI.DTOs.Member {
    public class MemberDTO {
        [Required]
        public Guid ChannelId { get; set; }

        [Required]
        public Guid UserId { get; set; }

       [Required]
        public MemberRole Role { get; set; }

        public static MemberDTO FromMember(uMessageAPI.Models.Member member) {
            return new MemberDTO { ChannelId = member.ChannelId, UserId = member.UserId,Role =  member.Role};
        }
    }
}
