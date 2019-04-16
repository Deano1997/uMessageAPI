using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace uMessageAPI.Utility {
    public static class JwtTokenHelper
    {
        public static SecurityKey CreateIssuerSigningKey(IConfiguration configuration) {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityToken:SigningKey"]));
        }

        public static TokenValidationParameters CreateTokenValidationParameters(IConfiguration configuration) {
            return new TokenValidationParameters {
                ValidAudience = configuration["JwtSecurityToken:Audience"],
                ValidateAudience = true,
                ValidIssuer = configuration["JwtSecurityToken:Issuer"],
                ValidateIssuer = true,
                IssuerSigningKey = CreateIssuerSigningKey(configuration),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
            };
        }

        public static JwtSecurityToken CreateSecurityToken(IEnumerable<Claim> claims, IConfiguration configuration) {
            // Create the signing credentials.
            var issuerSigningKey = CreateIssuerSigningKey(configuration);
            var signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);
            // Get the maximum lifetime for a security token.
            var tokenLifetime = configuration.GetValue<double>("JwtSecurityToken:Lifetime");
            // Create a JWT security token for given 
            return new JwtSecurityToken(
                issuer: configuration["JwtSecurityToken:Issuer"],
                audience: configuration["JwtSecurityToken:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(tokenLifetime),
                signingCredentials: signingCredentials
            );
        }

    }
}