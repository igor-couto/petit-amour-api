using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(5)]
public class CreateOrderItemsTable : Migration
{
    public override void Up()
    {
        Create.Table("OrderItems")
            .WithColumn("Id").AsString(40).NotNullable().PrimaryKey()
            .WithColumn("OrderId").AsString(40).NotNullable()
            .WithColumn("ProductId").AsString(40).NotNullable()
            .WithColumn("Quantity").AsInt16().NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable();
    }

    public override void Down() => Delete.Table("OrderItems");
}