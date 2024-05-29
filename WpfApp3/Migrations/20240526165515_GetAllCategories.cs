using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class GetAllCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedureText =
                @"CREATE PROCEDURE GetAllCategories
                  AS
                  BEGIN
                      SET NOCOUNT ON;
                      SELECT * FROM Categorie;
                  END;";

            migrationBuilder.Sql(procedureText);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetAllCategories");
        }
    }
}
