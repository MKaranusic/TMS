using Microsoft.EntityFrameworkCore;
using TMS.Data.DAL;

namespace TMS.API.Utilities;

internal static class StartupExtensions
{
    internal static IServiceCollection RegisterDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterDbContexts(configuration);
        return services;
    }

    internal static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        static void ConfigureSqlServerOptions(DbContextOptionsBuilder options, string connectionString, int timeout)
        {
            options.UseSqlServer(connectionString, o => o.CommandTimeout(timeout));
        }

        var tmsConnectionString = configuration.GetConnectionString("TMSConnection")
            ?? throw new InvalidOperationException(Messages.ErrorConnectionStringNotFound);

        services.AddDbContext<TMSDbContext>(opt => ConfigureSqlServerOptions(opt, tmsConnectionString, 30));
    }
}
