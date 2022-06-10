namespace PetitAmourAPI.Domain.Models;

public record PaymentMethod
{
    public short Id { get; }
    public string Name { get; }
    public short Discount { get; }
}