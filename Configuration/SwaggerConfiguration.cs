namespace PetitAmourAPI.Configuration;

public static class SwaggerConfiguration
{
    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v0",
                new OpenApiInfo
                {
                    Title = "Petit Amour API",
                    Description = "API Confeitaria Petit Amour",
                    Version = "v0"
                });
        });
    }

    public static void UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v0/swagger.json", "Petit Amour API v0");
            options.DefaultModelsExpandDepth(-1);
        });
    }
}
