using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using uMessageAPI.DTOs.User;

namespace uMessageAPI.Models {
    public class User : IdentityUser<Guid>, Generics.IEntity
    {

        #region Properties

        public ICollection<Member> Members { get; set; }

        #endregion

        #region DTO related helper methods

        public void UpdateFromUpdateUserDTO(UpdateUserDTO model) {
            this.Email = model.Email;
        }

        public static User FromCreateUserDTO(CreateUserDTO model) {
            return new User { UserName = model.UserName, Email = model.Email };
        }

        #endregion

    }
}
