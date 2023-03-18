using TruckManager.Domain.Entities;

namespace TruckManager.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
