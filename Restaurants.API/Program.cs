using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;
using Restaurants.API.Middlewares;
using Restaurants.Domain.Entities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearerAuth" , new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme , Id = "bearerAuth"}
            } ,
            []
        }
    });
});


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Host.UseSerilog((ctx , cfg) =>
{
    cfg.ReadFrom.Configuration(ctx.Configuration);
});
builder.Services.AddScoped<RequestTimeLoggingMiddleware>();


var app = builder.Build();

app.MapGroup("api/identity").MapIdentityApi<User>();

app.ConfigureExceptionHandler();
app.UseMiddleware<RequestTimeLoggingMiddleware>();

#region Seed The Database
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();
#endregion

app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
