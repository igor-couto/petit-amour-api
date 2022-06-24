using Microsoft.AspNetCore.Mvc;

namespace PetitAmourAPI.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
        => app.MapGet("/product", GetAllProducts);

    private static async Task<IResult> GetAllProducts([FromServices] ProductRepository repository)
    {
        var products = await repository.AllProducts();
        var categories = await repository.AllCategories();

        var productResponse = new ProductResponse(products, categories);

        return Results.Ok(productResponse);
    }
}