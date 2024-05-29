using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp3.Migrations
{
    public partial class SearchProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"
                CREATE PROCEDURE SearchProducts
                    @Nume NVARCHAR(100),
                    @CodDeBare NVARCHAR(50),
                    @ProducatorId INT,
                    @CategorieId INT
                AS
                BEGIN
                    SELECT *
                    FROM Produs
                    WHERE
                        (@Nume IS NULL OR Nume LIKE '%' + @Nume + '%')
                        AND (@CodDeBare IS NULL OR CodDeBare = @CodDeBare)
                        AND (@ProducatorId IS NULL OR ProducatorId = @ProducatorId)
                        AND (@CategorieId IS NULL OR CategorieId = @CategorieId)
                END
            ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var procedure = "DROP PROCEDURE IF EXISTS SearchProducts;";
            migrationBuilder.Sql(procedure);
        }
    }
}

