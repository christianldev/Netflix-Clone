using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using netflix.api.application.Interfaces.ApiAuth;
using netflix.api.application.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace netflix.api.application.AppServices.ApiAuth
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _ssKey;

        public TokenService(IConfiguration config)
        {
            string secr = config["Token:SecretKey"];
            _ssKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secr));
        }

        public string CreateToken(AuthRequest usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Username),
                new Claim("Dato1", "Pruebaaaaaaa")
            };

            var credenciales = new SigningCredentials(_ssKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = credenciales,
                Audience = "https://poveda-auth.com/"
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
