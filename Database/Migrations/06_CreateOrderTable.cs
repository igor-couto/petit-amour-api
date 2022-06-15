using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(6)]
public class CreateOrderTable : Migration
{
    public override void Up()
    {
        Create.Table("order")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("customer_id").AsGuid().NotNullable().ForeignKey("customer", "id")
            .WithColumn("amount").AsDecimal().NotNullable()
            .WithColumn("payment_method").AsInt16().NotNullable().ForeignKey("payment_method", "id")
            .WithColumn("created_at").AsDateTime().NotNullable()
            .WithColumn("delivery_date").AsDateTime().NotNullable()
            .WithColumn("delivery_address").AsString(512).NotNullable();
    }

    public override void Down() => Delete.Table("Order");
}