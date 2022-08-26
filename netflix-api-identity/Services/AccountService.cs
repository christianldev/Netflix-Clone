using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using netflix_api_application.DTOs;
using netflix_api_application.Enums;
using netflix_api_application.Exceptions;
using netflix_api_application.Interfaces;
using netflix_api_application.Wrappers;
using netflix_api_domain.Settings;
using netflix_api_identity.Helpers;
using netflix_api_identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

using System.Text;

namespace netflix_api_identity.Services
{
    public class AccountService : IAccountServices
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWTSettings _jwtSettings;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDateTimeService _dateTimeService;

        public AccountService(UserManager<ApplicationUser> userManager, JWTSettings jwtSettings, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IDateTimeService dateTimeService)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _dateTimeService = dateTimeService;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ApiException($"No existe el una cuenta con el {request.Email}");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"Credenciales incorrectas");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.Username = user.UserName;

            var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = roleList.ToList();
            response.IsVerified = user.EmailConfirmed;

            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;
            return new Response<AuthenticationResponse>(response, "Autenticado");
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userExist = await _userManager.FindByNameAsync(request.UserName);
            if (userExist != null)
            {
                throw new ApiException($"Usuario {request.UserName} ya existe");
            }
            var user = new ApplicationUser
            {
                Name = request.Name,
                UserName = request.UserName,
                Email = request.Email,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Phone = request.Phone,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true

            };

            var IfEmailExist = await _userManager.FindByEmailAsync(request.Email);
            if (IfEmailExist != null)
            {
                throw new ApiException($"Email {request.Email} ya existe");
            }
            else
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                    return new Response<string>(user.Id, message: "Usuario creado correctamente");
                }
                else
                {
                    throw new ApiException($"{result.Errors}.");
                }

            }
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            string ipAddress = IpHelper.GetIpAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("ip", ipAddress),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                ExpiresDate = DateTime.Now.AddDays(1),
                CreatedDate = DateTime.Now,
                CreatedByIp = ipAddress
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RSACryptoServiceProvider();

            return Convert.ToBase64String(rngCryptoServiceProvider.ExportCspBlob(true));
        }
    }

}
