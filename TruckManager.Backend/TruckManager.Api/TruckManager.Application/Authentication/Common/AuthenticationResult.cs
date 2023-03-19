using TruckManager.Domain.Entities;

namespace TruckManager.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}
