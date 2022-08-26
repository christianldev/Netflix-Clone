using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using netflix_api_application.DTOs;
using netflix_api_application.Interfaces;
using netflix_api_application.Wrappers;
using netflix_api_domain.Entities;

namespace netflix_api_application.Features.Authentication.Commands.RegisterUserCommand;

public class RegisterUserCommand : IRequest<Response<string>>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string Origin { get; set; }

    // Se devuleve un entero con el id del usuario registrado, para capturarlo con su respectivo recurso

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response<string>>
    {
        private readonly IAccountServices _accountService;

        public RegisterUserCommandHandler(IAccountServices accountService)
        {
            _accountService = accountService;
        }
        public async Task<Response<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.RegisterAsync(new RegisterRequest
            {

                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName,
                BirthDate = request.BirthDate,
                Phone = request.Phone,
                Name = request.Name,
                LastName = request.LastName,
            }, request.Origin);
        }

    }
}



