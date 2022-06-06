using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(6)]
public class CreatePaymentTypeTable : Migration
{
    public override void Up()
    {
        Create.Table("PaymentType")
            .WithColumn("Id").AsString().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(64).NotNullable()
            .WithColumn("Discount").AsInt16().Nullable();
    }

    public override void Down() => Delete.Table("PaymentType");
}