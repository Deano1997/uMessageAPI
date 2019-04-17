using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using uMessageAPI.DTOs;
using uMessageAPI.DTOs.User;
using uMessageAPI.Models;
using uMessageAPI.Utility;

namespace uMessageAPI.Controllers {

    [Route("api/v1/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase {

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public UsersController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration) {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        #region CRUD

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> Create([FromBody] CreateUserDTO model) {
            // Create user object from our data transfer object.
            var user = uMessageAPI.Models.User.FromCreateUserDTO(model);
            // Create user and assign given password.
            var result = await userManager.CreateAsync(user, model.Password);
            // Check whether the user was successfully created.
            if (result.Succeeded) {
                // Generate the user response for given user.
                return Ok(UserDTO.FromUser(user));
            }

            // TODO: User result.Errors to inform frontend about possible errors.
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(Guid id) {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether a valid user was resolved.
            if (user != null) {
                // Generate the user response for given user.
                return Ok(UserDTO.FromUser(user));
            }

            return Unauthorized();
        }

        [HttpGet("current")]
        public async Task<ActionResult<UserDTO>> GetBySession() {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether a valid user was resolved.
            if (user != null) {
                // Generate the user response for given user.
                return Ok(UserDTO.FromUser(user));
            }

            return Unauthorized();
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update([FromBody] UpdateUserDTO model) {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether a valid user was resolved.
            if (user != null) {
                // Validate whether the provided password matches our user model. For security reasons we should not
                // allow updates to the account without a corresponding password.
                var passwordMatchResult = await signInManager.CheckPasswordSignInAsync(user, model.CurrentPassword, false);
                // Check whether the user provided a valid password for current user.
                if (passwordMatchResult.Succeeded) {
                    // Update the user model with the information received from our DTO.
                    user.UpdateFromUpdateUserDTO(model);
                    // Check whether a new password is provided.
                    if (model.NewPassword != null) {
                        // Generate a new password has for the given password.
                        user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.NewPassword);
                    }
                    // Save changes made to the user model.
                    var result = await userManager.UpdateAsync(user);
                    // Check whether updating the user model was successful.
                    if (result.Succeeded) {
                        // Reply with the updated version of the user model.
                        return Ok(UserDTO.FromUser(user));
                    }
                    else {
                        // TODO: User result.Errors to inform frontend about possible errors.
                        return BadRequest();
                    }
                }
            }

            return Unauthorized();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteUserDTO model) {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether a valid user was resolved.
            if (user != null) {
                // Validate whether the provided password matches our user model. For security reasons we should not
                // allow updates to the account without a corresponding password.
                var passwordMatchResult = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                // Check whether the user provided a valid password for current user.
                if (passwordMatchResult.Succeeded) {
                    // Delete the given user account.
                    var result = await userManager.DeleteAsync(user);
                    // Check whether the operation was successful.
                    if (result.Succeeded) {
                        // Inform about successful delete operation.
                        return NoContent();
                    }
                    // TODO: User result.Errors to inform frontend about possible errors.
                }
            }

            return Unauthorized();
        }

        #endregion

        #region Utility

        // FIXME: Move this into a base class so that we do not have to duplicate.
        private Task<uMessageAPI.Models.User> GetCurrentUserAsync() {
            return userManager.GetUserAsync(User);
        }

        #endregion

    }
}
