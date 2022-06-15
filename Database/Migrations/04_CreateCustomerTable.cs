using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(4)]
public class CreateCustomerTable : Migration
{
    public override void Up()
    {
        Create.Table("customer")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("name").AsString(256).NotNullable()
            .WithColumn("phone_number").AsString(16).NotNullable()
            .WithColumn("created_at").AsDateTime().NotNullable();
    }

    public override void Down() => Delete.Table("customer");
}