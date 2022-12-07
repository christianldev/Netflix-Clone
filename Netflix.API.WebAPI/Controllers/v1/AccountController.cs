﻿using Netflix.API.Application.DTOS.Request;
using Netflix.API.Application.Features.Authenticate.Command.AuthenticateCommand;
using Netflix.API.Application.Features.Authenticate.Command.RegisterCommand;
using Microsoft.AspNetCore.Mvc;

namespace Netflix.API.WebAPI.Controllers.v1
{
    [ApiVersion("1")]

    public class AccountController : BaseApiController
    {

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest account)
        {

            return Ok(await Mediator!.Send(new AuthenticateCommand
            {
                Email = account.Email,
                Password = account.Password,
                IpAddress = GenerateIpAddress()
            }));

        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest account)
        {
            return Ok(await Mediator!.Send(new RegisterCommand
            {
                Email = account.Email,
                Password = account.Password,
                ConfirmPassword = account.ConfirmPassword,
                FirstName = account.FirstName,
                LastName = account.LastName,
                UserName = account.UserName,
                BirthDate = account.BirthDate,
                Origin = Request.Headers["Origin"]
            }));
        }


        private string? GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {

                return Request.Headers["X-Forwarded-For"];
            }
            return HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString();

        }
    }
}
