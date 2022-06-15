using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(5)]
public class CreatePaymentMethodTable : Migration
{
    public override void Up()
    {
        Create.Table("payment_method")
            .WithColumn("id").AsInt16().NotNullable().PrimaryKey()
            .WithColumn("name").AsString(64).NotNullable()
            .WithColumn("discount").AsInt16().Nullable();
    }

    public override void Down() => Delete.Table("payment_method");
}