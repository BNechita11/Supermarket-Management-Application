using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp3.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedureText =
                @"CREATE PROCEDURE UpdateCategories
                      @CategorieId INT,
                      @Nume NVARCHAR(100),
                      @IsActive BIT
                  AS
                  BEGIN
                      UPDATE Categorie
                      SET Nume = @Nume,
                          IsActive = @IsActive
                      WHERE CategorieId = @CategorieId;
                  END;";

            migrationBuilder.Sql(procedureText);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS UpdateCategories");
        }
    }
}
