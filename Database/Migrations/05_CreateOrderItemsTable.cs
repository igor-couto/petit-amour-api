using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(5)]
public class CreateOrderItemsTable : Migration
{
    public override void Up()
    {
        Create.Table("OrderItems")
            .WithColumn("Id").AsString().NotNullable().PrimaryKey()
            .WithColumn("OrderId").AsFixedLengthString(256).NotNullable()
            .WithColumn("ProductId").AsFixedLengthString(16).NotNullable()
            .WithColumn("Price").AsDateTime().NotNullable()
            .WithColumn("Additional").AsDateTime().NotNullable();
    }

    public override void Down() => Delete.Table("OrderItems");
}