using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using netflix_api_application.Wrappers;

namespace netflix_api_application.Features.Authentication.Commands.RegisterUserCommand;

public class RegisterUserCommand : IRequest<Response<string>>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}