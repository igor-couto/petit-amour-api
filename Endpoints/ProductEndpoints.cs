using Microsoft.AspNetCore.Mvc;

namespace AccountingLedgerApi.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
        => app.MapGet("/product", GetAllProducts);

    private static async Task<IResult> GetAllProducts([FromServices] ProductRepository repository)
    {
        var products = await repository.GetAllProducts();

        return Results.Ok(products);
    }
}