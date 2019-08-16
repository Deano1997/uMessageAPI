using System;
using System.ComponentModel.DataAnnotations;
using uMessageAPI.DTOs.Member;

namespace uMessageAPI.Models {
    public class Member : Generics.IEntity {

        #region Properties
        //Onnodig Id's wegdoen! 
        public Guid ChannelId { get; set; }

        public Channel Channel { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        [Required]
        public MemberRole Role { get; set; }
        public Guid Id { get; set; }

        #endregion

        #region DTO related helper methods

        public void UpdateFromUpdateMemberDTO(UpdateMemberDTO model) {
            this.Role = model.Role;
        }

        public static Member FromCreateMemberDTO(Channel channel, CreateMemberDTO model) {
            return new Member { Channel = channel, UserId = model.UserId, Role = model.Role,ChannelId = model.ChannelId};
        }

        #endregion

    }
}
