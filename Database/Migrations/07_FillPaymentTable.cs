using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(7)]
public class FillPaymentTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("PaymentMethod")
            .Row(new
            {
                Id = 0,
                Name = "Dinheiro",
                Discount = 5
            })
            .Row(new
            {
                Id = 1,
                Name = "Pix",
                Discount = 5
            })
            .Row(new
            {
                Id = 2,
                Name = "Cartão",
                Discount = 1
            });
    }

    public override void Down() { }
}