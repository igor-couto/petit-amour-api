namespace PetitAmourAPI.Domain.Models;

public record OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public short Quantity { get; set; }
    public decimal Price { get; set; }
}