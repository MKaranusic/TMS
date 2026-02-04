using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using TMS.API.Configuration;
using TMS.API.Middleware;
using TMS.API.Utilities;
using TMS.API.Utilities.Configuration;
using TMS.Data.DAL;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting TMS.API");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application", "TMS.API"));

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddProblemDetails();
    builder.Services.AddExceptionHandler<EnhancedGlobalExceptionHandler>();

    builder.Services.AddAppOptions(builder.Configuration);
    builder.Services.RegisterDomainServices(builder.Configuration);

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<TMSDbContext>();
        dbContext.Database.Migrate();
    }

    app.UseExceptionHandler();

    if (app.Environment.IsProduction())
    {
        app.UseHsts();
        var allowedOrigins = builder.Configuration
            .GetSection("Cors")
            .Get<Cors>()
            .AllowedOrigins;

        app.UseCors(policy => policy
            .WithOrigins(allowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader());
    }
    else
    {
        app.UseCors(policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    }

    // Left for production as per the requirment
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
