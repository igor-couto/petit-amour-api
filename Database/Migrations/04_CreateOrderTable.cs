using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(4)]
public class CreateOrderTable : Migration
{
    public override void Up()
    {
        Create.Table("Order")
            .WithColumn("Id").AsString(40).NotNullable().PrimaryKey()
            .WithColumn("CustomerId").AsString(40).NotNullable()
            .WithColumn("Amount").AsDecimal().NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable()
            .WithColumn("DeliveryDate").AsDateTime().NotNullable()
            .WithColumn("PaymentMethod").AsInt16().NotNullable()
            .WithColumn("DeliveryAddress").AsString(512).NotNullable();
    }

    public override void Down() => Delete.Table("Order");
}