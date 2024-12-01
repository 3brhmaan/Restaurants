using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Host.UseSerilog((ctx , cfg) =>
{
    cfg
    .MinimumLevel.Override("Microsoft" , LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore" , LogEventLevel.Information)
    .WriteTo.File("Logs/Restaurant-API-.log" , rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
    .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message:lj}{NewLine}{Exception}");
});



var app = builder.Build();

#region Seed The Database
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();
#endregion

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
