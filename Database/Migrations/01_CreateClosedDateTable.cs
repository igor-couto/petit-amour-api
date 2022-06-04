using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(1)]
public class CreateClosedDateTable : Migration
{
    public override void Up()
    {
        Create.Table("ClosedDate")
            .WithColumn("Date").AsDate().NotNullable().PrimaryKey();
    }

    public override void Down() => Delete.Table("ClosedDate");
}