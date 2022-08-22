using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace netflix_api_application.Exceptions;

public class ApiException : Exception
{
    public ApiException() : base() { }
    public ApiException(string message) : base(message) { }

    public ApiException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}
