using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TruckManager.Application.Authentication.Commands.Register;
using TruckManager.Application.Authentication.Common;
using TruckManager.Application.Authentication.Queries.Login;
using TruckManager.Contracts.Authentication;
using TruckManager.Domain.Common.Errors;

namespace TruckManager.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {

        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Email, request.Password, request.FirstName, request.LastName);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthRsult(authResult)),
            Problem);

    }

    

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);

        var authResult = await _mediator.Send(query);
        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        return authResult.Match(
           authResult => Ok(MapAuthRsult(authResult)),
           Problem);
    }

    private AuthenticationResponse MapAuthRsult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.Id,
                                                          authResult.User.FirstName,
                                                          authResult.User.LastName,
                                                          authResult.User.Email,
                                                          authResult.Token);
    }
}
