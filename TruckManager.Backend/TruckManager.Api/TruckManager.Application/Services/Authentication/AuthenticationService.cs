using TruckManager.Application.Common.Interfaces.Authentication;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.Entities;

namespace TruckManager.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserRepository _userRespository;

    public AuthenticationService(IJwtTokenGenerator jwtGenerator, IUserRepository userRespository)
    {
        _jwtGenerator = jwtGenerator;
        _userRespository = userRespository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if(_userRespository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist");
        }

        if(user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string email, string password, string firstName, string lastName)
    {
        if(_userRespository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email exists");
        }

        var user = new User
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Password = password,
        };

        _userRespository.Add(user);

        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
