using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(2)]
public class CreateProductCategoryTable : Migration
{
    public override void Up()
    {
        Create.Table("product_category")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("name").AsString(64).NotNullable()
            .WithColumn("position").AsInt16().NotNullable();
    }

    public override void Down() => Delete.Table("product_category");
}