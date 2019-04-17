using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using uMessageAPI.DTOs.Auth;
using uMessageAPI.Models;
using uMessageAPI.Utility;

namespace uMessageAPI.Controllers {

    [Route("api/v1/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase {

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration) {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
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
            return JwtTokenHelper.CreateSecurityToken(claims, configuration);
        }

        [Route("requestToken")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TokenResultDTO>> RequestToken([FromBody] RequestTokenDTO model) {
            // Find a user that matches the given username.
            var user = await userManager.FindByNameAsync(model.UserName);
            // Check whether a valid user was resolved.
            if (user != null) {
                // Validate whether the provided password matches our user model.
                var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
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

        #region Utility

        // FIXME: Move this into a base class so that we do not have to duplicate.
        private Task<uMessageAPI.Models.User> GetCurrentUserAsync() {
            return userManager.GetUserAsync(User);
        }

        #endregion

    }
}
