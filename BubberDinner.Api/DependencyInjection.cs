
using BubberDinner.Api.Common.Errors;
using BubberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BubberDinner.Api;


public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMapping();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();


        return services;
    }
}

