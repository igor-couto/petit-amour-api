using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(8)]
public class CreateProductCategoryTable : Migration
{
    public override void Up()
    {
        Create.Table("ProductCategory")
            .WithColumn("Id").AsString(40).NotNullable().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable();
    }

    public override void Down() => Delete.Table("ProductCategory");
}