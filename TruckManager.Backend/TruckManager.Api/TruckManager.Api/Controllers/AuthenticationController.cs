﻿using ErrorOr;
using MapsterMapper;
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
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {

        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            Problem);

    }

    

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var query = _mapper.Map<LoginQuery>(request);

        var authResult = await _mediator.Send(query);
        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        return authResult.Match(
           authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
           Problem);
    }
}
