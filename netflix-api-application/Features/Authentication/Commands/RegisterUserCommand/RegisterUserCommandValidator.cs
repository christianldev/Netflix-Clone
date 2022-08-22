using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace netflix_api_application.Features.Authentication.Commands.RegisterUserCommand;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} es obligatorio");
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} es obligatorio");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} es obligatorio");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio")
            .Length(10).WithMessage("{PropertyName} debe tener 10 dígitos")
            .Matches("^[0-9]*$").WithMessage("{PropertyName} solo puede contener números")
            .MinimumLength(10).WithMessage("{PropertyName} debe tener 10 dígitos");
        RuleFor(x => x.BirthDate).NotEmpty().WithMessage("{PropertyName} es obligatorio");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} es obligatorio")
            .EmailAddress().WithMessage("{PropertyName} no es un correo válido")
            .MaximumLength(100).WithMessage("{PropertyName} no puede tener más de 100 caracteres");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}

