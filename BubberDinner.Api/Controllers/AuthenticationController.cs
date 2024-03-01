using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using BubberDinner.Application.Common.Errors;
using BubberDinner.Application.Authentication.Queries;
using ErrorOr;
using BubberDinner.Api.Controllers;
using BubberDinner.Domain.Errors;
using MediatR;
using BubberDinner.Application.Authentication.Commands;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace BubberDinner.Contracts.Controllers;

[Route("auth")]
public class AuthenticationController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
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
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
        
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var query = _mapper.Map<LoginQuery>(request);
        var AuthResult = await _mediator.Send(query);

        if (AuthResult.IsError && AuthResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: AuthResult.FirstError.Description
                );
        }

        return AuthResult.Match(
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}
