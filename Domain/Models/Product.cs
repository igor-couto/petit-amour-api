namespace PetitAmourAPI.Domain.Models;

public record Product
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public Guid Category_Id { get; init; }
}