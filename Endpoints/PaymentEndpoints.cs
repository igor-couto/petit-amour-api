using Microsoft.AspNetCore.Mvc;

namespace AccountingLedgerApi.Endpoints;

public static class PaymentEndpoints
{
    public static void MapPaymentEndpoints(this WebApplication app)
        => app.MapGet("/payment", GetAllPayments);

    private static async Task<IResult> GetAllPayments([FromServices] PaymentRepository repository)
    {
        var paymentTypes = await repository.GetAllPaymentTypes();

        return Results.Ok(paymentTypes);
    }
}