var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

await using var app = builder.Build();

ConfigureApplication(app);

app.Run();

static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.RegisterSwagger();

    builder.Services.RegisterHealthCheck();

    builder.Services.RegisterFluentValidation();

    builder.Services.RegisterDependencyInjections();

    builder.Services.RegisterFluentMigrator(builder.Configuration.GetConnectionString("DefaultConnection"));
}

static void ConfigureApplication(WebApplication app)
{
    app.UseFluentMigratorConfiguration();

    app.UseDeveloperExceptionPage();

    app.UseSwaggerConfiguration();

    app.UseHttpsRedirection();

    app.UseHealthCheckConfiguration();

    app.MapClosedDateEndpoints();
    app.MapOrderEndpoints();
    app.MapProductEndpoints();
    app.MapPaymentEndpoints();
}