using Microsoft.AspNetCore.Mvc;
using TruckManager.Application.Services.Authentication;
using TruckManager.Contracts.Authentication;

namespace TruckManager.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResponse = _authenticationService.Register(request.Email,
                                                           request.Password,
                                                           request.FirstName,
                                                           request.LastName);
        var response = new AuthenticationResponse(authResponse.user.Id,
                                                  authResponse.user.FirstName,
                                                  authResponse.user.LastName,
                                                  authResponse.user.Email,
                                                  authResponse.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResponse = _authenticationService.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(authResponse.user.Id,
                                                  authResponse.user.FirstName,
                                                  authResponse.user.LastName,
                                                  authResponse.user.Email,
                                                  authResponse.Token);
        return Ok(response);
    }
}
