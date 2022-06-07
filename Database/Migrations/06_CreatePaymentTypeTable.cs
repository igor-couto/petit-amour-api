using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(6)]
public class CreatePaymentMethodTable : Migration
{
    public override void Up()
    {
        Create.Table("PaymentMethod")
            .WithColumn("Id").AsInt16().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(64).NotNullable()
            .WithColumn("Discount").AsInt16().Nullable();
    }

    public override void Down() => Delete.Table("PaymentMethod");
}