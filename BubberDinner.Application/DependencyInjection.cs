
using System.Reflection;
using BubberDinner.Application.Authentication.Commands;
using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BubberDinner.Application.Services;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        
        var assemblies = new[]
        {
            typeof(RegisterCommandValidtor).Assembly,
            typeof(LoginQueryValidation).Assembly
        };

        services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Scoped);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}

