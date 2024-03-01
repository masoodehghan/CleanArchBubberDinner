using BubberDinner.Api;
using BubberDinner.Api.Common.Errors;
using BubberDinner.Api.Filter;
using BubberDinner.Api.Middleware;
using BubberDinner.Application.Services;
using BubberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttr>());


var app = builder.Build();

// app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();


app.Run();
