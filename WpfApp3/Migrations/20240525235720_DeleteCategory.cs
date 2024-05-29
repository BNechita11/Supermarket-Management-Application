using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class DeleteCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"
                CREATE PROCEDURE [dbo].[DeleteCategory]
                    @CategorieId INT
                AS
                BEGIN
                    -- Actualizăm câmpul IsActive la false pentru categoria specificată
                    UPDATE Categorie
                    SET IsActive = 0
                    WHERE CategorieId = @CategorieId;
                END;
            ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[DeleteCategory];");
        }
    }
}

