namespace PetitAmourAPI.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void RegisterDependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<DatabaseConnection>();
        services.AddScoped<ClosedDateRepository>();
        services.AddScoped<CustomerRepository>();
        services.AddScoped<OrderRepository>();
        services.AddScoped<PaymentRepository>();
        services.AddScoped<ProductRepository>();
        services.AddTransient<OrderService>();
    }
}
