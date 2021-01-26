using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class seedFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sqlInsert = @"INSERT INTO Features (Name) VALUES ('Feature1');
                                 INSERT INTO Features (Name) VALUES ('Feature2');
                                 INSERT INTO Features (Name) VALUES ('Feature3');";

            migrationBuilder.Sql(sqlInsert);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Feature1', 'Feature2', 'Feature3')");
        }
    }
}
