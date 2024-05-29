using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class GetAllUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure =
                @"
                CREATE PROCEDURE GetAllUsers
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT * FROM Utilizator WHERE IsActive = 1;
                END;
                ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetAllUsers");
        }
    }
}
