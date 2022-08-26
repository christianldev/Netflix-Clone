using MediatR;
using netflix_api_application.DTOs;
using netflix_api_application.Interfaces;
using netflix_api_application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflix_api_application.Features.Authentication.Commands.LoginUserCommand;


public class LoginUserCommand : IRequest<Response<AuthenticationResponse>>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public string IpAddress { get; set; }

    public class AuthenticateHandler : IRequestHandler<LoginUserCommand, Response<AuthenticationResponse>>
    {
        private readonly IAccountServices _accountService;
        public AuthenticateHandler(IAccountServices accountService)
        {
            _accountService = accountService;
        }
        public async Task<Response<AuthenticationResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.AuthenticateAsync(new AuthenticationRequest
            {
                Email = request.Email,
                Password = request.Password,


            }, request.IpAddress);
        }
    }


}


