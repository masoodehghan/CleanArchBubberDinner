using BubberDinner.Api;
using BubberDinner.Api.Common.Errors;
using BubberDinner.Api.Middleware;
using BubberDinner.Application.Services;
using BubberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);



var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}