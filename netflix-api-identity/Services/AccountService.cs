using Microsoft.AspNetCore.Identity;
using netflix_api_application.DTOs;
using netflix_api_application.Enums;
using netflix_api_application.Exceptions;
using netflix_api_application.Interfaces;
using netflix_api_application.Wrappers;
using netflix_api_domain.Settings;
using netflix_api_identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
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

        //private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        //{

        //}
    }
}
