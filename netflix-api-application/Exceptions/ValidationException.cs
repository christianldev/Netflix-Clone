using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace netflix_api_application.Exceptions;

public class ValidationException : Exception
{
    public List<string> Errors { get; }
    public ValidationException() : base("Se han producido uno o mas errores de validacion")
    {
        Errors = new List<string>();
    }

    // Metodo para iterar sobre los errores de validacion y añadirlos a la lista de errores.
    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }

}
