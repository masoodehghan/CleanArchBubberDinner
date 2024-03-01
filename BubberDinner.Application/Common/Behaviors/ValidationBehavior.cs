using BubberDinner.Application.Authentication.Commands;
using BubberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;


namespace BubberDinner.Application.Common.Behaviors;


public class ValidateRegisterCommandBehavior :
    IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request,
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
        CancellationToken cancellationToken)
    {
        var result = await next();
        return result;
    }
}

