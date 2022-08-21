using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflix_api_application.Interfaces;

// Ver fechas de cuando se creo y cuando se modifico la entidad
public interface IDateTimeService
{
    DateTime NowUtc { get; }
}
