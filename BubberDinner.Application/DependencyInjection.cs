
using BubberDinner.Application.Authentication.Commands;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Common.Behaviors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BubberDinner.Application.Services;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        

        services.AddScoped<
                IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
                ValidateRegisterCommandBehavior>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
            typeof(DependencyInjection).Assembly)
        );

        return services;
    }
}

