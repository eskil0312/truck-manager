using ErrorOr;
using MediatR;
using TruckManager.Application.Authentication.Common;
using TruckManager.Application.Common.Interfaces.Authentication;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Domain.Common.Errors;
using TruckManager.Domain.Entities;

namespace TruckManager.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtGenerator;
        private readonly IUserRepository _userRespository;


        public LoginQueryHandler(IJwtTokenGenerator jwtGenerator, IUserRepository userRespository)
        {
            _jwtGenerator = jwtGenerator;
            _userRespository = userRespository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (_userRespository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;

            }

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
