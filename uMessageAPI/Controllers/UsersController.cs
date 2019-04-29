using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
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

        public UsersController(SignInManager<User> signInManager, UserManager<User> userManager) {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO[]>> List() {
            throw new Exception("User repository should be used");
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
            // Find the matching user for given identifier.
            var user = await userManager.FindByIdAsync(id.ToString());
            // Check whether a valid user was resolved.
            if (user != null) {
                // Generate the user response for given user.
                return Ok(UserDTO.FromUser(user));
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Update(Guid id, [FromBody] UpdateUserDTO model) {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether the current user was resolved.
            if (user != null && user.Id == id) {
                // Update the user model with the information received from our DTO.
                user.UpdateFromUpdateUserDTO(model);
                // Save changes made to the user model.
                var result = await userManager.UpdateAsync(user);
                // Check whether updating the user model was successful.
                if (result.Succeeded) {
                    // Reply with the updated version of the user model.
                    return Ok(UserDTO.FromUser(user));
                }
            }

            return Forbid();
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
