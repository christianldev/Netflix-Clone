using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netflix_api_application.Interfaces;

namespace netflix_api_shared.Services;

public class DateTimeService : IDateTimeService
{

    public DateTime NowUtc => DateTime.UtcNow;
}
