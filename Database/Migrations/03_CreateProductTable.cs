using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(3)]
public class CreateProductTable : Migration
{
    public override void Up()
    {
        Create.Table("product")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable()
            .WithColumn("price").AsCurrency().NotNullable()
            .WithColumn("category_id").AsGuid().NotNullable().ForeignKey("product_category", "id");
    }

    public override void Down() => Delete.Table("product");
}