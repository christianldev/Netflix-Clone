using Netflix.API.Application.Interfaces;

namespace Netflix.API.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
