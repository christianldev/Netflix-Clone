using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netflix_api_application.DTOs;
using netflix_api_application.Features.Authentication.Commands.LoginUserCommand;
using netflix_api_application.Features.Authentication.Commands.RegisterUserCommand;

namespace netflix_api_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseApiController
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(AuthenticationRequest request)
        {
            return Ok(await Mediator.Send(new LoginUserCommand
            {
                Email = request.Email,
                Password = request.Password,
                IpAddress = GenerateIpAddress()
            }));

        }
        [HttpPost("register")]

        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterUserCommand
            {
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.UserName,
                BirthDate = request.BirthDate,
                Phone = request.Phone,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                Origin = Request.Headers["origin"]
            }));
        }

        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }
    }
}
