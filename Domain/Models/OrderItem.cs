namespace PetitAmourAPI.Domain.Models;

public record OrderItem
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public short Quantity { get; init; }
    public decimal Price { get; init; }
}