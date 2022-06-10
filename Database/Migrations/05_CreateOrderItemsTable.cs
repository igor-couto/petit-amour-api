using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(5)]
public class CreateOrderItemTable : Migration
{
    public override void Up()
    {
        Create.Table("OrderItem")
            .WithColumn("Id").AsString(40).NotNullable().PrimaryKey()
            .WithColumn("OrderId").AsString(40).NotNullable()
            .WithColumn("ProductId").AsString(40).NotNullable()
            .WithColumn("Quantity").AsInt16().NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable();
    }

    public override void Down() => Delete.Table("OrderItem");
}