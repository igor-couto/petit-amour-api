namespace PetitAmourAPI.Domain.Models;

public record Order
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DeliveryDate { get; set; }
    public short PaymentMethod { get; set; }
    public string DeliveryAddress { get; set; }
}