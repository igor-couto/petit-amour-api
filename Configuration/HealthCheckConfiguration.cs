namespace PetitAmourAPI.Configuration;

public static class HealthCheckConfiguration
{
    public static void RegisterHealthCheck(this IServiceCollection services)
        => services.AddHealthChecks();

    public static void UseHealthCheckConfiguration(this WebApplication app)
        => app.MapHealthChecks("/health");
}
