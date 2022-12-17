using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Netflix.Application.Dtos.User.Request;

namespace Netflix.Application.Validators.Authentication
{
    public class AuthenticationValidator : AbstractValidator<UserRequestDto>
    {
        public AuthenticationValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("El nombre de usuario no puede ser nulo")
                .NotEmpty().WithMessage("El nombre de usuario es requerido");
            RuleFor(x => x.Email)
                .NotNull().WithMessage("El correo electrónico no puede ser nulo")
                .NotEmpty().WithMessage("El correo electrónico es requerido")
                .EmailAddress().WithMessage("El correo electrónico no es válido");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("La contraseña no puede ser nula")
                .NotEmpty().WithMessage("La contraseña es requerida");

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("El nombre no puede ser nulo")
                .NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(x => x.LastName)
                .NotNull().WithMessage("El apellido no puede ser nulo")
                .NotEmpty().WithMessage("El apellido es requerido");
            RuleFor(x => x.Birthdate)
                .NotNull().WithMessage("La fecha de nacimiento no puede ser nula")
                .NotEmpty().WithMessage("La fecha de nacimiento es requerida");
            RuleFor(x => x.Phone)
                .NotNull().WithMessage("El teléfono no puede ser nulo")
                .NotEmpty().WithMessage("El teléfono es requerido");
            RuleFor(x => x.Address)
                .NotNull().WithMessage("La dirección no puede ser nula")
                .NotEmpty().WithMessage("La dirección es requerida");
            // RuleFor(x => x.Image)
            //     .NotNull().WithMessage("La imagen no puede ser nula")
            //     .NotEmpty().WithMessage("La imagen es requerida");
            RuleFor(x => x.ConfirmPassword)
                .NotNull().WithMessage("La confirmación de la contraseña no puede ser nula")
                .NotEmpty().WithMessage("La confirmación de la contraseña es requerida")
                .Equal(x => x.Password).WithMessage("Las contraseñas no coinciden");

        }
    }

}