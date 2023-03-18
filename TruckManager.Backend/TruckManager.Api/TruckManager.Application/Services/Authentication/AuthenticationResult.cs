
using TruckManager.Domain.Entities;

namespace TruckManager.Application.Services.Authentication;

public record AuthenticationResult(User user, string Token);
