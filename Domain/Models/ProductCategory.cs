namespace PetitAmourAPI.Domain.Models;

public record ProductCategory
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public short Position { get; init; }
}