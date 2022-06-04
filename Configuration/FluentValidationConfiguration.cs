using PetitAmourAPI.Domain.Requests;

namespace PetitAmourAPI.Configuration;

public static class FluentValidationConfiguration
{
    public static void RegisterFluentValidation(this IServiceCollection services)
        => services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<DateRequest>());
}
