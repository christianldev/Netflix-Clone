﻿using FluentValidation;

namespace Netflix.API.Application.Features.Authenticate.Command.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.FirstName)
               .NotEmpty()
               .MaximumLength(80);

            RuleFor(p => p.LastName)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(p => p.Email)
                .NotEmpty()
               .EmailAddress()
               .MaximumLength(100);

            RuleFor(p => p.UserName)
                .NotEmpty()
               .MaximumLength(100);

            RuleFor(p => p.Password)
             .NotEmpty()
            .MaximumLength(20)
            .MinimumLength(6);

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty()
           .Equal(p => p.Password);
        }
    }
}
