namespace PetitAmourAPI.Domain.Models;

public record Customer
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string PhoneNumber { get; init; }
    public DateTime CreatedAt { get; init; }
}