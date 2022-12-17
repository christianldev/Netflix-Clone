using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netflix.Application.Dtos.User.Request;
using Netflix.Application.Interfaces;

namespace Netflix.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public AuthenticationController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateUser([FromBody] TokenRequestDto request)
        {
            var response = await _userApplication.AuthenticateUser(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto request)
        {
            var response = await _userApplication.RegisterUser(request);
            return Ok(response);
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto request)
        {
            var response = await _userApplication.RefreshToken(request);
            return Ok(response);
        }
    }
}