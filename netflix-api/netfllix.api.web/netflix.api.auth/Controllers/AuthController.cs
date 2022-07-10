using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netflix.api.application.Interfaces.ApiAuth;
using netflix.api.application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflix.api.auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        private readonly ITokenService _tokenservice;
        public AuthController(ITokenService _tokenservice,
                              ILogger<AuthController> logger)
        {
            this._tokenservice = _tokenservice;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login(AuthRequest request)
        {
            var modelo = new AuthResponse();

            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                modelo.MensajeError = "Debe ingresar un correo y contraseña";
                return BadRequest(modelo);
            }

            if (request.Password == "admin" && request.Email == "admin@correo.com")
            {
                modelo.Token = _tokenservice.CreateToken(request);
                //modelo.User = new User()
                //{
                //    Email = "admin@correo.com",
                //    Username = "admin",
                //    Password = "admin"
                //};


            }
            else
            {
                modelo.Token = null;
                modelo.User = new User()
                {
                    Email = "null",
                    Username = "null",
                    Password = "null"
                };
                modelo.MensajeError = "Las credenciales no son validas";
                return Unauthorized(modelo);
            }
            return Accepted(modelo);
        }
    }
}
