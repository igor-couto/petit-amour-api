namespace PetitAmourAPI.Domain.Models;

public record Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
}