namespace PetitAmourAPI.Domain.Models;

public record OrderItem
{
    public string Id { get; set; }
    public string OrderId { get; set; }
    public string ProductId { get; set; }
    public short Quantity { get; set; }
    public decimal Price { get; set; }
}