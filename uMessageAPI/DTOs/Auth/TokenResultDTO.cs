using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;

namespace uMessageAPI.DTOs.Auth
{
    public class TokenResultDTO
    {
        [Required]
        public string Token { get; set; }

        public static TokenResultDTO FromToken(JwtSecurityToken token) {
            return new TokenResultDTO { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }

    }
}
