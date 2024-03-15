using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using BubberDinner.Application.Common.Errors;
using BubberDinner.Application.Authentication.Queries;
using ErrorOr;
using BubberDinner.Api.Controllers;
using BubberDinner.Domain.Common.Errors;
using MediatR;
using BubberDinner.Application.Authentication.Commands;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace BubberDinner.Contracts.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
        Console.WriteLine($"{typeof(AuthenticationController).GetType()} ISIISISISISI");
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
