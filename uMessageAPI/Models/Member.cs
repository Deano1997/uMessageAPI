using System;
using System.ComponentModel.DataAnnotations;
using uMessageAPI.DTOs.Member;

namespace uMessageAPI.Models {
    public class Member : Generics.IEntity {

        #region Properties

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

        public static Member FromCreateMemberDTO(CreateMemberDTO model) {
            //return new Member { User = model.User, Role = model.Role};
            throw new NotImplementedException();
        }

        #endregion

    }
}
