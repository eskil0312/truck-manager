using ErrorOr;
using MediatR;
using TruckManager.Application.Authentication.Common;

namespace TruckManager.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
