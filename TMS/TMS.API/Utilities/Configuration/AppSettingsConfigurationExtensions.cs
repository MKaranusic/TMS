using TMS.API.Configuration;

namespace TMS.API.Utilities.Configuration;

public static class AppSettingsConfigurationExtensions
{
    public static IServiceCollection AddAppOptions(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<Cors>(config.GetSection("Cors"));
        return services;
    }
}
