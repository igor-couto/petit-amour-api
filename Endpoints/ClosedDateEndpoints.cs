using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetitAmourAPI.Domain.Requests;

namespace AccountingLedgerApi.Endpoints;

public static class ClosedDateEndpoints
{
    public static void MapClosedDateEndpoints(this WebApplication app)
    {
        app.MapGet("/closed-date", GetAllClosedDates);

        app.MapPost("/closed-date", PostClosedDate);

        app.MapDelete("/closed-date", DeleteClosedDate);
    }

    private static async Task<IResult> GetAllClosedDates([FromServices] ClosedDateRepository repository)
    {
        var closedDates = await repository.GetAllClosedDates();

        var result = closedDates.Select(closedDate => closedDate.ToShortDateString());

        return Results.Ok(result);
    }

    private static async Task<IResult> PostClosedDate(
        [FromServices] ClosedDateRepository repository,
        [FromBody] DateRequest date,
        IValidator<DateRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(date);
        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));

        var (success, message) = await repository.Insert(date);

        if (success)
            return Results.Ok();
        else
            return Results.BadRequest(message);
    }

    private static async Task<IResult> DeleteClosedDate(
        [FromServices] ClosedDateRepository repository,
        [FromBody] DateRequest date,
        IValidator<DateRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(date);
        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));

        var (success, message) = await repository.Delete(date);

        if (success)
            return Results.Ok();
        else
            return Results.BadRequest(message);
    }
}