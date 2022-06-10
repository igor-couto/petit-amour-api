using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(3)]
public class CreateCustomerTable : Migration
{
    public override void Up()
    {
        Create.Table("Customer")
            .WithColumn("Id").AsString(40).NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(256).NotNullable()
            .WithColumn("PhoneNumber").AsString(16).NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable();
    }

    public override void Down() => Delete.Table("Customer");
}