using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using uMessageAPI.DTOs;
using uMessageAPI.DTOs.Account;
using uMessageAPI.Models;
using uMessageAPI.Utility;

namespace uMessageAPI.Controllers {

    [Route("api/v1/account")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration) {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._configuration = configuration;
        }

        #region Token related operations

        private JwtSecurityToken GetToken(User user) {
            // Build the claims based on the user information.
            var claims = new [] {
                // The "NameIdentifier" claim is required to enable retrieving a user
                // based on the HttpContext.User claim principle using the user manager.
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };
            // Create a security token for given claims and configuration.
            return JwtTokenHelper.CreateSecurityToken(claims, this._configuration);
        }

        [Route("requestToken")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TokenResultDTO>> RequestToken([FromBody] RequestTokenDTO model) {
            // Find a user that matches the given username.
            var user = await this._userManager.FindByNameAsync(model.UserName);
            // Check whether a valid user was resolved.
            if (user != null) {
                // Validate whether the provided password matches our user model.
                var result = await this._signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                // Check whether the username/password combination matched.
                if (result.Succeeded) {
                    // Get the token for given user.
                    var userToken = GetToken(user);
                    // Generate the token response for given user.
                    return Ok(TokenResultDTO.FromToken(userToken));
                }
            }

            return BadRequest();
        }

        [Route("renewToken")]
        [HttpPost]
        public async Task<ActionResult<TokenResultDTO>> RenewToken() {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether a valid user was resolved.
            if (user != null) {
                // Get the token for given user.
                var userToken = GetToken(user);
                // Generate the token response for given user.
                return Ok(TokenResultDTO.FromToken(userToken));
            }

            return Unauthorized();
        }

        #endregion

        #region Account CRUD operation

        private Task<uMessageAPI.Models.User> GetCurrentUserAsync() {
            return this._userManager.GetUserAsync(User);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AccountDTO>> CreateAccount([FromBody] CreateAccountDTO model) {
            // Create user object from our data transfer object.
            var user = uMessageAPI.Models.User.FromCreateAccountDTO(model);
            // Create user and assign given password.
            var result = await this._userManager.CreateAsync(user, model.Password);
            // Check whether the user was successfully created.
            if (result.Succeeded) {
                // Get the token for given user.
                var userToken = GetToken(user);
                // Generate the user response for given user.
                return Ok(AccountDTO.FromUser(user));
            }

            // TODO: User result.Errors to inform frontend about possible errors.
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<AccountDTO>> GetAccount() {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether a valid user was resolved.
            if (user != null) {
                // Generate the user response for given user.
                return Ok(AccountDTO.FromUser(user));
            }

            return Unauthorized();
        }

        [HttpPut]
        public async Task<ActionResult<AccountDTO>> UpdateAccount([FromBody] UpdateAccountDTO model) {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether a valid user was resolved.
            if (user != null) {
                // Validate whether the provided password matches our user model. For security reasons we should not
                // allow updates to the account without a corresponding password.
                var passwordMatchResult = await this._signInManager.CheckPasswordSignInAsync(user, model.CurrentPassword, false);
                // Check whether the user provided a valid password for current user.
                if (passwordMatchResult.Succeeded) {
                    // Update the user model with the information received from our DTO.
                    user.UpdateFromUpdateAccountDTO(model);
                    // Check whether a new password is provided.
                    if (model.NewPassword != null) {
                        // Generate a new password has for the given password.
                        user.PasswordHash = this._userManager.PasswordHasher.HashPassword(user, model.NewPassword);
                    }
                    // Save changes made to the user model.
                    var result = await this._userManager.UpdateAsync(user);
                    // Check whether updating the user model was successful.
                    if (result.Succeeded) {
                        // Reply with the updated version of the user model.
                        return Ok(AccountDTO.FromUser(user));
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
        public async Task<ActionResult> DeleteAccount([FromBody] DeleteAccountDTO model) {
            // Get the currently logged in user.
            var user = await GetCurrentUserAsync();
            // Check whether a valid user was resolved.
            if (user != null) {
                // Validate whether the provided password matches our user model. For security reasons we should not
                // allow updates to the account without a corresponding password.
                var passwordMatchResult = await this._signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                // Check whether the user provided a valid password for current user.
                if (passwordMatchResult.Succeeded) {
                    // Delete the given user account.
                    var result = await this._userManager.DeleteAsync(user);
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

    }
}
