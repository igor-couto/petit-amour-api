using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(4)]
public class CreateOrderTable : Migration
{
    public override void Up()
    {
        Create.Table("Order")
            .WithColumn("Id").AsString().NotNullable().PrimaryKey()
            .WithColumn("CustomerId").AsFixedLengthString(256).NotNullable()
            .WithColumn("Amount").AsFixedLengthString(16).NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable()
            .WithColumn("DueDate").AsDateTime().NotNullable()
            .WithColumn("PaymentType").AsDateTime().NotNullable();
    }

    public override void Down() => Delete.Table("Order");
}