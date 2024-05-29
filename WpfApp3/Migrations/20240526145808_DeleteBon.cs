using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp3.Migrations
{
    public partial class DeleteBon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"
                CREATE PROCEDURE sp_DeleteBonCasa
                    @BonCasaId INT
                AS
                BEGIN
                    UPDATE BonCasa
                    SET isActive = 0
                    WHERE BonCasaId = @BonCasaId;
                END;
            ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var procedure = @"
                DROP PROCEDURE IF EXISTS sp_DeleteBonCasa;
            ";

            migrationBuilder.Sql(procedure);
        }
    }
}
