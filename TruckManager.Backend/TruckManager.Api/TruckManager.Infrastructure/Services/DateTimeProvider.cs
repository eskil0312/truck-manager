using TruckManager.Application.Common.Interfaces.Services;

namespace TruckManager.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
