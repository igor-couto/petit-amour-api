using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(2)]
public class CreateProductTable : Migration
{
    public override void Up()
    {
        Create.Table("Product")
            .WithColumn("Id").AsString(40).NotNullable().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Price").AsCurrency().NotNullable();
    }

    public override void Down() => Delete.Table("Product");
}