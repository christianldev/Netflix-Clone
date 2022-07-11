using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netflix.api.application.Interfaces.ApiAuth;
using netflix.api.application.Model;
using netflix.api.application.Model.ApiAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace netflix.api.auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        public static AuthUserResponse user = new AuthUserResponse();

        private readonly ILogger<AuthController> _logger;

        private readonly ITokenService _tokenservice;

        private readonly IAuthService _authservice;

        public AuthController(ITokenService _tokenservice,
                              ILogger<AuthController> logger)
        {
            this._tokenservice = _tokenservice;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthUserResponse>> Register(User request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Email and Password are required");
            }

            _authservice.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(AuthRequest request)
        {
            var modelo = new AuthResponse();

            if (user.Email != request.Email)
            {
                return BadRequest("Usuario no encontrado");
            }

            else if (!_authservice.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Contraseña incorrecta");
            }

            else if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                modelo.MensajeError = "Debe ingresar un correo y contraseña";
                return BadRequest(modelo);
            }

            modelo.Token = _tokenservice.CreateToken(request);

            return Accepted(modelo);
        }



    }
}
