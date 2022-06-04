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

    builder.Services.AddScoped<DbContext>();

    builder.Services.AddScoped<ClosedDateRepository>();

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
}