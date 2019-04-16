using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using uMessageAPI.DTOs.Account;

namespace uMessageAPI.Models
{
    public class User : IdentityUser
    {

        #region Properties

        public ICollection<ChannelUser> ChannelUsers { get; set; }

        #endregion

        #region DTO related helper methods

        public void UpdateFromUpdateAccountDTO(UpdateAccountDTO model) {
            this.Email = model.Email;
        }

        public static User FromCreateAccountDTO(CreateAccountDTO model) {
            return new User { UserName = model.UserName, Email = model.Email };
        }

        #endregion

    }
}
