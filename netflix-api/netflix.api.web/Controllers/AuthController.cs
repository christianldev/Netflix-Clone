using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netflix.api.application.DTOs.Request.Auth;
using netflix.api.application.DTOs.Response.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflix.api.web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationSceme)]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public AcceptedResult Login([FromBody]req_login request)
        {
            var modelo = new res_login();
            if (request.username == "admin")
            {
                modelo.Ok = true;
                modelo.Mensaje = null;
                modelo.token = "pendiente";
                modelo.info_cliente = new LoginDto()
                {
                    email = "admin@correo.com",
                    username = "admin",
                    phone = "99999999"
                };
            }
            else{
                modelo.Ok = true;
                modelo.Mensaje = "Las credenciales enviadas son inválidas";
                modelo.token = null;
                modelo.info_cliente = new LoginDto()
                {
                    email = "null",
                    username = "null",
                    phone = "null"
                };
            }
            return Accepted(modelo);
        }
    }
}
