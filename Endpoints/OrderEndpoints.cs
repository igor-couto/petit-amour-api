using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace PetitAmourAPI.Endpoints;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this WebApplication app)
        => app.MapPost("/order", CreateOrder);

    private static async Task<IResult> CreateOrder(
        [FromServices] OrderService service,
        [FromBody] OrderRequest orderRequest,
        IValidator<OrderRequest> validator
        )
    {
        var validationResult = await validator.ValidateAsync(orderRequest);
        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));

        var message = await service.CreateOrder(orderRequest);

        return Results.Ok(message);
    }
}