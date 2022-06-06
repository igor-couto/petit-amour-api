namespace PetitAmourAPI.Domain.Models;

public record Product
{
    public string Id { get; }
    public string Name { get; }
    public decimal Price { get; }
}