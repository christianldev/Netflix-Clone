using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using netflix_api_application.Interfaces;
using netflix_api_application.Wrappers;
using netflix_api_domain.Entities;

namespace netflix_api_application.Features.Authentication.Commands.RegisterUserCommand;

public class RegisterUserCommand : IRequest<Response<int>>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public char Status { get; set; }
}


// Se devuleve un entero con el id del usuario registrado, para capturarlo con su respectivo recurso
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response<int>>
{
    private readonly IRepositoryAsync<Customer> _repositoryAsync;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }


    public async Task<Response<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var newRegister = _mapper.Map<Customer>(request);
        var data = await _repositoryAsync.AddAsync(newRegister);

        return new Response<int>(data.Id);

    }
}
