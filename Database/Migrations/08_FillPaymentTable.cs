using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(8)]
public class FillPaymentTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("payment_method")
            .Row(new
            {
                id = 0,
                name = "Dinheiro",
                discount = 5
            })
            .Row(new
            {
                id = 1,
                name = "Pix",
                discount = 5
            })
            .Row(new
            {
                id = 2,
                name = "Cartão",
                discount = 1
            });
    }

    public override void Down() { }
}