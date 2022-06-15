using FluentMigrator;

namespace PetitAmourAPI.Database.Migrations;

[Migration(1)]
public class CreateClosedDateTable : Migration
{
    public override void Up()
    {
        Create.Table("closed_date")
            .WithColumn("date").AsDate().NotNullable().PrimaryKey();
    }

    public override void Down() => Delete.Table("closed_date");
}