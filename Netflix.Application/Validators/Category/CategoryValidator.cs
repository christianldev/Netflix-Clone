using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Netflix.Application.Dtos.Category.Request;

using Netflix.Utilities.Static;

namespace Netflix.Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Nombre de la categoría no puede ser nulo")
                .NotEmpty().WithMessage("Nombre de la categoría es requerido");
            RuleFor(x => x.State).NotEmpty().WithMessage("El estado de la categoría es requerido");
            RuleFor(x => x.State).Must(x => x == (int)StateTypes.Active || x == (int)StateTypes.Inactive).WithMessage("State is invalid");
        }
    }

}