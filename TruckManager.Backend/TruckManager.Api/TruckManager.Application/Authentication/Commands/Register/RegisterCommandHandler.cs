using ErrorOr;
using MediatR;
using TruckManager.Application.Authentication.Common;
using TruckManager.Application.Common.Interfaces.Authentication;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.Common.Errors;
using TruckManager.Domain.Entities;

namespace TruckManager.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserRepository _userRespository;


    public RegisterCommandHandler(IJwtTokenGenerator jwtGenerator, IUserRepository userRespository)
    {
        _jwtGenerator = jwtGenerator;
        _userRespository = userRespository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRespository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;

        }

        var user = new User
        {
            Email = command.Email,  
            FirstName = command.FirstName,
            LastName = command.LastName,
            Password = command.Password,
        };

        _userRespository.Add(user);

        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
