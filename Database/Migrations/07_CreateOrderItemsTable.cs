using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(7)]
public class CreateOrderItemTable : Migration
{
    public override void Up()
    {
        Create.Table("order_item")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("order_id").AsGuid().NotNullable().ForeignKey("order", "id")
            .WithColumn("product_id").AsGuid().NotNullable().ForeignKey("product", "id")
            .WithColumn("quantity").AsInt16().NotNullable()
            .WithColumn("price").AsDecimal().NotNullable();
    }

    public override void Down() => Delete.Table("order_item");
}