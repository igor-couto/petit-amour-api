using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(3)]
public class CreateCustomerTable : Migration
{
    public override void Up()
    {
        Create.Table("Customer")
            .WithColumn("Id").AsString().NotNullable().PrimaryKey()
            .WithColumn("Name").AsFixedLengthString(256).NotNullable()
            .WithColumn("PhoneNumber").AsFixedLengthString(16).NotNullable()
            .WithColumn("Address").AsString().NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable();
    }

    public override void Down() => Delete.Table("Customer");
}